using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AzureServiceBusAPI.Services;
using AzureServiceBusAPI.Data;
namespace AzureServiceBusAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBusService _orderBusService;

        public OrderController(IOrderBusService orderBusService)
        {
            _orderBusService = orderBusService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CarTyreOrderModel order)
        {
            var message = $"Order created: {order.OrderId} Order date:{order.OrderDate}";
            await _orderBusService.SendMessageAsync(message);
            return Ok();
        }
        [HttpGet("read")]
        public async Task<IActionResult> ReadMessage()
        {
            string message = await _orderBusService.ReceiveMessagesAsync();
            return Ok(message);
        }
    }
}


