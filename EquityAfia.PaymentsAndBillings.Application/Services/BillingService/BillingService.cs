


using EquityAfia.PaymentsAndBillings.Application.Interfaces.Billing;
using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Contracts.Messages.AppointmentBookings;
using EquityAfia.PaymentsAndBillings.Contracts.Messages.CommodityMedicineManagement;
using EquityAfia.PaymentsAndBillings.Contracts.Messages.UserManagement;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using MassTransit;

namespace EquityAfia.PaymentsAndBillings.Application.Services.BillingService
{
    public class BillingService : IBillingService
    {
        private readonly IRequestClient<GetUserDetailsRequest> _userClient;
        private readonly IRequestClient<GetProductDetailsRequest> _productClient;
        private readonly IRequestClient<GetAppointmentDetailsRequest> _appointmentClient;
        private readonly IBillingRepository _billingRepository;

        public BillingService(
            IRequestClient<GetUserDetailsRequest> userClient,
            IRequestClient<GetProductDetailsRequest> productClient,
            IRequestClient<GetAppointmentDetailsRequest> appointmentClient,
             IBillingRepository billingRepository)
        {
            _userClient = userClient;
            _productClient = productClient;
            _appointmentClient = appointmentClient;
            _billingRepository = billingRepository;
        }
        public async Task<BillingDto> AddBillingWithServicesAsync(BillingDto billingDto)
        {
            // Retrieve user details
            var userResponse = await _userClient.GetResponse<GetUserDetailsResponse>(new GetUserDetailsRequest
            {
                UserId = billingDto.CustomerId
            });
            var userDto = userResponse.Message;
            {
                throw new Exception("User not found");
            }
            // Retrieve products from CommodityMedicineManagement
            var productResponse = await _productClient.GetResponse<GetProductDetailsResponse>(new GetProductDetailsRequest
            {
                ProductId = billingDto.CustomerId
            });
            var products = productResponse.Message;
            // Retrieve appointment charges
            var appointmentResponse = await _appointmentClient.GetResponse<GetAppointmentDetailsResponse>(new GetAppointmentDetailsRequest
            {
                AppointmentId = billingDto.AppointmentId
            });
            var charges = appointmentResponse.Message;
            // Calculate total amount billed
            billingDto.AmountBilled = products.Price * products.Quantity + charges.AmountCharged;
            // Create Billing entity
            var billing = new Billing
            {
                BillingId = billingDto.BillingId,
                CustomerName = userDto.Name,
                CustomerId = billingDto.CustomerId,
                CustomerEmail = userDto.Email,
                CustomerPhoneNumber = userDto.PhoneNumber,
                AppointmentId = billingDto.AppointmentId,
                AmountBilled = (int)billingDto.AmountBilled,
                PayBill = billingDto.PayBill,
                AccNo = billingDto.AccNo,
                PaymentStatus = billingDto.PaymentStatus,
                Services = billingDto.Services.Select(s => new Service
                {
                    ServiceId = s.ServiceId,
                    Quantity = s.Quantity,
                    AmountCharged = s.AmountCharged
                }).ToList(),
                Products = new List<Product>
                {
                    new Product
                    {
                        ProductId = products.ProductId,
                        Quantity = products.Quantity,
                        Price = products.Price
                    }
                }
            };

            // Save billing to database
            await _billingRepository.AddAsync(billing);

            return billingDto;
        }
    }
}
        }







































































