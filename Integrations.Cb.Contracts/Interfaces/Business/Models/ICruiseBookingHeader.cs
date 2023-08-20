using System;
using System.Text.Json.Serialization;

namespace Integrations.Cb.Contracts.Interfaces.Business.Models
{
    public interface ICruiseBookingHeader
    {
        long TswTransactionId { get; set; }
        string Action { get; set; }
        int? OrignalTswTransactionId { get; set; }
        DateTime? TransactionDate { get; set; }
        string OwnerNumber { get; set; }
        string OwnerId { get; set; }
        string CruiseLine { get; set; }
        DateTime? SailDate { get; set; }
        int? NumberOfNights { get; set; }
        string ConfirmationNo { get; set; }
        int? PointsUsed { get; set; }
        decimal? DollarsUsed { get; set; }
        string Comment { get; set; }
        string CancelReason { get; set; }
        bool Flag { get; set; }
    }
}
