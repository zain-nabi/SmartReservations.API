using Application.Interface.User;
using AspNetCore.Reporting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reporting
{
    public class ReportService : Application.Reporting.IReport.IReport
    {
        private readonly IExternalUser _externalUser;


        public ReportService(IExternalUser externalUser)
        {
            _externalUser = externalUser;
        }

        public async Task<byte[]> GenerateReportAsync(string reportName, string reportType)
        {
            string filePath = Assembly.GetExecutingAssembly().Location.Replace("Application.Reporting.dll", string.Empty);

            string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdl", filePath, reportName);

            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Encoding.GetEncoding("utf-8");

            LocalReport report = new LocalReport(rdlcFilePath);
            var reportUsers = await _externalUser.GetReportUsers();
            report.AddDataSource("dataSourceUsers", reportUsers.ExternalUserModel);
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            var result = report.Execute(GetRenderType(reportType), 1, parameters);

            return result.MainStream;
        }

        private RenderType GetRenderType(string reportType)
        {
            var renderType = RenderType.Pdf;
            switch (reportType.ToUpper())
            {
                default:
                case "PDF":
                    renderType = RenderType.Pdf;
                    break;
                case "XLS":
                    renderType = RenderType.Excel;
                    break;
                case "WORD":
                    renderType = RenderType.Word;
                    break;
            }

            return renderType;
        }
    }
}
