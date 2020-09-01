using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bajaj.Dinesh.Biller.CrystalReports;
using Bajaj.Dinesh.Biller.Datasets;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows;

namespace Bajaj.Dinesh.Biller
{
    internal sealed partial class BillReportView : Form
    {
        private BillItemsDataSet dataset;
        private Dictionary<string, object> reportParameters;

        private BillReportView()
        {
            InitializeComponent();
        }

        public BillReportView(BillItemsDataSet dataset,
            Dictionary<string, object> reportParameters)
            : this()
        {
            this.dataset = dataset;
            this.reportParameters = reportParameters;
        }

        private void BillReportView_Load(object sender, EventArgs e)
        {
            this.Icon = this.MdiParent.Icon;
        }

        private void configureReportViewer()
        {
            crystalReportViewer.ToolPanelView =
               CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            //crystalReportViewer.ShowCopyButton = false;
            crystalReportViewer.ShowGroupTreeButton = false;
            crystalReportViewer.ShowParameterPanelButton = false;
            crystalReportViewer.ShowRefreshButton = false;
            crystalReportViewer.AllowedExportFormats =
                (int)(CrystalDecisions.Shared.ViewerExportFormats.ExcelRecordFormat |
                CrystalDecisions.Shared.ViewerExportFormats.PdfFormat |
                CrystalDecisions.Shared.ViewerExportFormats.WordFormat |
                CrystalDecisions.Shared.ViewerExportFormats.RtfFormat |
                CrystalDecisions.Shared.ViewerExportFormats.ExcelFormat);
        }

        private void addFirmDetailsToParameters()
        {
            string errorText;
            GlobalMethods.FirmDetails firmDetails =
                GlobalMethods.GetFirmDetails(out errorText);

            if (firmDetails == null)
            {
                firmDetails = new GlobalMethods.FirmDetails();
            }

            reportParameters.Add("FirmName", (Properties.Settings.Default.PrintFirmName ?
                firmDetails.FirmName : string.Empty));

            reportParameters.Add("FirmAddress",
                (Properties.Settings.Default.PrintFirmAddress ?
                firmDetails.FirmAddress.Replace("\r\n", ", ") : string.Empty));

            reportParameters.Add("PhoneNumbers", firmDetails.PhoneNumbers);
        }

        private void passParametersToReport(BillPrintoutReport report)
        {
            report.SetParameterValue(0, reportParameters["FirmName"]);
            report.SetParameterValue(1, reportParameters["FirmAddress"]);
            report.SetParameterValue(2, reportParameters["PhoneNumbers"]);
            report.SetParameterValue(3, reportParameters["DiscountAmount"]);
            report.SetParameterValue(4, reportParameters["ExpenseAmount"]);
            report.SetParameterValue(5, reportParameters["ExpenseText"]);
            report.SetParameterValue(6, reportParameters["InvoiceID"]);
            report.SetParameterValue(7, reportParameters["InvoiceDate"]);
            report.SetParameterValue(8, reportParameters["CustomerName"]);
        }

        internal void ShowReport()
        {
            addFirmDetailsToParameters();

            BillPrintoutReport report = new BillPrintoutReport();
            report.SetDataSource(dataset);

            if (Properties.Settings.Default.PrintDirectlyToPrinter)
            {
                passParametersToReport(report);

                PrinterSettings prtSetting = new PrinterSettings();
                report.PrintOptions.PrinterName = prtSetting.PrinterName;
                Cursor.Current = Cursors.Default;
                report.PrintToPrinter(1, false, 0, 0); //print the report
                this.Dispose();
            }
            else //display the report in the ReportViewerControl
            {
                configureReportViewer();
                crystalReportViewer.ReportSource = report;
                passParametersToReport(report);
                crystalReportViewer.Zoom(1); //show to fit page width
                this.Show();
            }
        }
    }
}