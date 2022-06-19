using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reporting.IReport
{
    public interface IReport
    {
        Task<byte[]> GenerateReportAsync(string reportName, string reportType);
        Task<byte[]> BookedReservationsByDateAsync(string reportName, string reportType, DateTime startDate, DateTime endDate);
    }
}
