using System;

namespace PhoneDirectory.Shared.Models
{
    public class Report
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatus Status { get; set; }
        public List<ReportDetail> Details { get; set; } = new List<ReportDetail>();
    }

    public class ReportDetail
    {
        public Guid ReportId { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneNumberCount { get; set; }
    }

    public enum ReportStatus
    {
        Preparing,
        Completed
    }
} 