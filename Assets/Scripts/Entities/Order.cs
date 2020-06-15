using System.Collections.Generic;

public class Order
{
    private int orderId { get; set; }
    private int customerId { get; set; }
    private OrderState orderState { get; set; }
    private List<OrderItem> items { get; }

    private bool isSuccess = false;

    public Order(int orderId)
    {
        this.orderId = orderId;
        this.items = new List<OrderItem>();
        this.orderState = OrderState.PENDING;
    }

    public void AddItem(OrderItem item)
    {
        items.Add(item);
    }

    /// <summary>
    /// Check if every order item is correctly completed
    /// Cache the status of the order for final score
    /// </summary>
    /// <returns>True if items are completed, false otherwise</returns>
    public bool CheckForSuccess() {

        isSuccess = true;

        items.ForEach(delegate (OrderItem item) {
            if (!item.CheckIfSuccess())
            {
                isSuccess = false;
                return;
            }
        });
        return isSuccess;
    }

    public enum OrderState
    {
        PENDING, 
        IN_PROGRESS,
        FINISHED
    }

    public override string ToString()
    {
        string itemsInfo = "";

        items.ForEach(delegate(OrderItem item) {
            itemsInfo += item.ToString();    
        });

        return "orderId: " + orderId
            + " , customerId: " + customerId
            + " , orderState: " + orderState
            + " , items: " + itemsInfo;
    }
}
