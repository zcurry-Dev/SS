using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class DatabaseDiagnostics
    {
        public int DatabaseDiagnosticsId { get; set; }
        public string ProcedureName { get; set; }
        public string Parameters { get; set; }
        public int? TotalResultsReturned { get; set; }
        public string ExecutedUser { get; set; }
        public int? ErrorNum { get; set; }
        public int? ErrorSeverity { get; set; }
        public int? ErrorState { get; set; }
        public int? ErrorLine { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid RowGuid { get; set; }
    }
}
