using System;
using Newtonsoft.Json;

namespace Integrations.Cb.Dto
{
    public class CruiseBookingHeaderDto
    {
        public long TswTransactionId { get; set; }
        public string Action { get; set; }
        public int? OrignalTswTransactionId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string OwnerNumber { get; set; }
        public string OwnerId { get; set; }
        public string CruiseLine { get; set; }
        public DateTime? SailDate { get; set; }
        public int? NumberOfNights { get; set; }
        public string ConfirmationNo { get; set; }
        public int? PointsUsed { get; set; }
        public decimal? DollarsUsed { get; set; }
        public string Comment { get; set; }
        public string CancelReason { get; set; }
        public bool Flag { get; set; }
    }
}
