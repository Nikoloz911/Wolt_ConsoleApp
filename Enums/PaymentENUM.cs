namespace Wolt_ConsoleApp.Enums;
internal enum PAYMENT_ENUM
{
    PENDING,       // Payment is initiated but not completed
    COMPLETED,     // Payment has been successfully processed
    FAILED,        // Payment attempt was unsuccessful
    CANCELED,      // Payment was canceled by the user or system
    REFUNDED,      // Payment has been refunded to the user
    PROCESSING,    // Payment is being processed by the payment gateway
    ON_HOLD,       // Payment is temporarily on hold for review
    CHARGEBACK,    // Payment was disputed by the customer and reversed
    EXPIRED        // Payment authorization has expired
}
