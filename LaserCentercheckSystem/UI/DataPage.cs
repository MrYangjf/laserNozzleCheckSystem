using LaserIntelliWeldingSystem.Communication;
using OfficeOpenXml;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Input;
using VMControls.BaseInterface;
//using System.ComponentModel;



namespace LaserIntelliWeldingSystem.UI
{
    public partial class DataPage : UIPage
    {
        DataTable ShowdataTable = new DataTable("DataTable");

        public DataPage()
        {
            InitializeComponent();
            uiCalendar1.Date = DateTime.Today;
            PageBangdingIni();
        }


        void PageBangdingIni()
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
            //uiDataGridView1.DataSource = dataTable;
            ShowdataTable.Columns.Add("No.", typeof(int));
            ShowdataTable.Columns.Add("SN", typeof(string));
            ShowdataTable.Columns.Add("Time", typeof(string));
            ShowdataTable.Columns.Add("Type", typeof(string));
            ShowdataTable.Columns.Add("Result", typeof(string));
            ShowdataTable.Columns.Add("CheckInfo", typeof(string));
        }

        private void btnChoseDate_Click(object sender, System.EventArgs e)
        {
            GlobalCommData.mProductManager.SelectTable(uiCalendar1.Date);
            uiDataGridView1.ClearAll();
            //uiDataGridView1.DataSource = null;
            uiDataGridView1.DataSource = ShowdataTable;
            uiDataGridView1.AutoGenerateColumns = true;
            try
            {
                //设置分页控件总数
                uiPagination1.TotalCount = GlobalCommData.mProductManager.mTable.Rows.Count;

                //设置分页控件每页数量
                uiPagination1.PageSize = 50;

                //uiDataGridView1.SelectIndexChange += uiDataGridView1_SelectIndexChange;
                ShowdataTable.Rows.Clear();
                for (int i = 0; i < 50; i++)
                {
                    if (i >= GlobalCommData.mProductManager.mTable.Rows.Count) break;
                    ShowdataTable.Rows.Add(GlobalCommData.mProductManager.mTable.Rows[i]["AUTOID"], GlobalCommData.mProductManager.mTable.Rows[i]["SN"]
                        , GlobalCommData.mProductManager.mTable.Rows[i]["Time"], GlobalCommData.mProductManager.mTable.Rows[i]["InspectionType"]
                        , GlobalCommData.mProductManager.mTable.Rows[i]["Result"], GlobalCommData.mProductManager.mTable.Rows[i]["Info"]);
                }

                //设置统计绑定的表格
                uiDataGridViewFooter1.DataGridView = uiDataGridView1;

                uiTitlePanel1.Text = "DataViewer：" + GlobalCommData.mProductManager.TableName;
            }
            catch
            {

            }
        }

        private void uiDataGridView1_SelectIndexChange(object sender, int index)
        {
            index.WriteConsole("SelectedIndex");
        }

        private void uiPagination1_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            ShowdataTable.Rows.Clear();

            for (int i = (pageIndex - 1) * count; i < pageIndex * count; i++)
            {
                if (i >= GlobalCommData.mProductManager.mTable.Rows.Count) break;
                ShowdataTable.Rows.Add(GlobalCommData.mProductManager.mTable.Rows[i]["AUTOID"], GlobalCommData.mProductManager.mTable.Rows[i]["SN"]
                    , GlobalCommData.mProductManager.mTable.Rows[i]["Time"], GlobalCommData.mProductManager.mTable.Rows[i]["InspectionType"]
                    , GlobalCommData.mProductManager.mTable.Rows[i]["Result"], GlobalCommData.mProductManager.mTable.Rows[i]["Info"]);
            }

            uiDataGridViewFooter1.Clear();
            uiDataGridViewFooter1["No."] = "All Count：" + GlobalCommData.mProductManager.mTable.Rows.Count;
        }

        public void ExportToExcel(DataTable dataTable, string filePath)
        {
            
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // 添加列头
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dataTable.Columns[i].ColumnName;
                }

                // 添加数据行
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dataTable.Rows[i][j];
                    }
                }

                // 保存文件
                package.SaveAs(new FileInfo(filePath));
            }
        }

        private void importExcel_Click(object sender, EventArgs e)
        {
            string dir = "";
            if (DirEx.SelectDirEx(CodeTranslator.Current.OpenDir, ref dir))
            {
                string strFilename =GlobalCommData.mProductManager.TableName+".xlsx";
                ExportToExcel(GlobalCommData.mProductManager.mTable, dir + strFilename);
                UIMessageTip.ShowOk(dir + strFilename);
            }
        }

        public override void Translate()
        {
            //必须保留
            base.Translate();
            //读取翻译代码中的多语资源
            CodeTranslator.Load(this);
        }

        private class CodeTranslator : IniCodeTranslator<CodeTranslator>
        {
            public string OpenDir { get; set; } = "打开文件夹";
        }
    }
}
