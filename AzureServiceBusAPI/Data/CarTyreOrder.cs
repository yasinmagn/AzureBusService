namespace AzureServiceBusAPI.Data
{

        public class CarTyreOrderModel
        {
            // Properties
            public int OrderId { get; set; }
            public string CustomerName { get; set; }
            public string TyreBrand { get; set; }
            public string TyreModel { get; set; }
            public int Quantity { get; set; }
            public DateTime OrderDate { get; set; }
            public string Status { get; set; }

            // Constructor
            public CarTyreOrderModel(int orderId, string customerName, string tyreBrand, string tyreModel, int quantity)
            {
                OrderId = orderId;
                CustomerName = customerName;
                TyreBrand = tyreBrand;
                TyreModel = tyreModel;
                Quantity = quantity;
                OrderDate = DateTime.Now;
                Status = "Pending";
            }

            // Default constructor
            public CarTyreOrderModel()
            {
            }
        }
    }
