namespace Wolt_ConsoleApp.Enums;
internal enum ORDER_ENUM
{
    PENDING,        // Order has been placed but not yet processed
    CONFIRMED,      // Order has been confirmed by the system or seller
    PROCESSING,     // Order is being prepared or packed
    SHIPPED,        // Order has been shipped to the customer
    DELIVERED,      // Order has been successfully delivered
    CANCELED,       // Order was canceled by the user or system
    RETURNED,       // Order was returned by the customer
    REFUNDED,       // Order amount has been refunded to the customer
    FAILED,         // Order processing failed due to payment or other issues
    ON_HOLD         // Order is temporarily on hold for some reason
}
