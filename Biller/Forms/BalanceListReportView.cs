using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    internal sealed partial class BalanceListReportView : Form
    {
        private DataTable dataSourceTable;

        private BalanceListReportView()
        {
            InitializeComponent();
        }

        public BalanceListReportView(DataTable table)
            : this()
        {
            dataSourceTable = table;
        }

        private void BalanceListReportView_Load(object sender, EventArgs e)
        {
            this.Icon = Global.MDIForm.Icon;

            BalanceListDataSet dataset = new BalanceListDataSet();
            dataset.BalanceListTable.Merge(dataSourceTable);

            CustomerBalanceListReport report = new CustomerBalanceListReport();
            report.SetDataSource(dataset);

            configureReportViewer();
            crystalReportViewer.ReportSource = report;

            DateTime accountDate;
            if (DateTime.Today.CompareTo(Global.CurrentFinancialYear.MaxDate) > 0)
            {
                accountDate = Global.CurrentFinancialYear.MaxDate;
            }
            else
            {
                accountDate = DateTime.Today;
            }

            report.SetParameterValue(0, accountDate);

            crystalReportViewer.Zoom(1);
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
    }
}