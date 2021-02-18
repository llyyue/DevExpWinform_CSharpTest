using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using System.IO;
using DevExpWinform_CSharpTest.DataModel;
using log4net;

namespace DevExpWinform_CSharpTest
{
    public partial class MainView : RibbonForm
    {
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Random rnd = new Random(0);
        public MainView()
        {
            log.Info("App Starting...");

            InitializeComponent();
            gridControl_Stock.DataSource = new BindingList<Stock>();
            gridControl_Option.DataSource = new BindingList<Option>();

            LoadStock(Properties.Settings.Default.CsvFile_Stocks);
            LoadOption(Properties.Settings.Default.CsvFile_Options);


            //A useful function, would like to display at 1st time to show the feature to user. 
            gridView_Stock.ShowFindPanel();
            gridView_Option.ShowFindPanel();


            log.Info("App Started!");
        }

        #region Load Data
        //These 2 functions possible to be written as 1 if use a generic LoadData<T>
        void LoadStock(string filename)
        {
            var bList = gridControl_Stock.DataSource as BindingList<Stock>;

            using (StreamReader sr = new StreamReader(filename))
            {
                sr.ReadLine(); //Skip header
                string buff = null;
                while ((buff = sr.ReadLine()) != null)
                {
                    try
                    {
                        bList.Add(new Stock(buff.Split(',')));
                    }
                    catch (Exception ex)
                    {
                        log.Error("Load Stock Data Error \n" + buff, ex);
                        MessageBox.Show(ex.Message, "Load Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        void LoadOption(string filename)    
        {
            var bList = gridControl_Option.DataSource as BindingList<Option>;

            using (StreamReader sr = new StreamReader(filename))
            {
                sr.ReadLine(); //Skip header
                string buff = null;
                while ((buff = sr.ReadLine()) != null)
                {
                    try
                    {
                        bList.Add(new Option(buff.Split(',')));
                    }
                    catch (Exception ex)
                    {
                        log.Error("Load Option Data Error \n" + buff, ex);
                        MessageBox.Show(ex.Message, "Load Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Save/Restore Layout
        void SaveLayout(DevExpress.XtraGrid.Views.Grid.GridView gridV, string filename, string caption="")
        {
            if (MessageBox.Show(caption + " Saving Layout?", caption + " Saving Layout?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FileInfo file = new FileInfo(filename);
                if (!file.Directory.Exists)
                    file.Directory.Create();

                gridV.SaveLayoutToXml(filename);
                MessageBox.Show(caption + " Layout Saved", caption + " Layout Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void LoadLayout(DevExpress.XtraGrid.Views.Grid.GridView gridV, string filename, string caption = "")
        {
            FileInfo file = new FileInfo(filename);
            if (!file.Exists)
                return;

            if (MessageBox.Show(caption + " Restore Layout?", caption + " Restore Layout?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gridV.RestoreLayoutFromXml(filename);
                MessageBox.Show(caption + " Layout Restored", caption + " Layout Restored", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GetActiveLayoutGridV(out DevExpress.XtraGrid.Views.Grid.GridView gridV, out string layoutFilename, out string caption)
        {
            gridV = gridView_Stock;
            layoutFilename = Properties.Settings.Default.Layout_Stocks;
            caption = "Stocks";

            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                gridV = gridView_Option;
                layoutFilename = Properties.Settings.Default.Layout_Options;
                caption = "Options";
            }
        }


        private void barButtonItem_SaveLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetActiveLayoutGridV(out DevExpress.XtraGrid.Views.Grid.GridView gridV, out string layoutFilename, out string caption);
            SaveLayout(gridV, layoutFilename, caption);
        }
        private void barButtonItem_LoadLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetActiveLayoutGridV(out DevExpress.XtraGrid.Views.Grid.GridView gridV, out string layoutFilename, out string caption);
            LoadLayout(gridV, layoutFilename, caption);
        }
        #endregion

        #region Windows Size/Position to Save/Load
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = Properties.Settings.Default.WinState;
            this.DesktopBounds = Properties.Settings.Default.WinDeskBounds;
            SetViewSwitch(Properties.Settings.Default.Active_Grid_Index);

            barButtonItem_LoadLayout_ItemClick(this, null);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.WinState = this.WindowState;
            Properties.Settings.Default.WinDeskBounds = this.DesktopBounds;
            Properties.Settings.Default.Active_Grid_Index = xtraTabControl1.SelectedTabPageIndex;
            Properties.Settings.Default.Save();

            barButtonItem_SaveLayout_ItemClick(this, null);
        }

        #endregion

        #region GridView Switch
        private void button_Stocks_Click(object sender, EventArgs e)
        {
            SetViewSwitch(0);
        }
        private void button_Options_Click(object sender, EventArgs e)
        {
            SetViewSwitch(1);
        }
        private void barButtonItem_Stock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetViewSwitch(0);
        }
        private void barButtonItem_Option_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetViewSwitch(1);
        }

        void SetViewSwitch(int tabPage =0)
        {
            xtraTabControl1.SelectedTabPageIndex = tabPage;
            button_Stocks.Enabled = (tabPage != 0);
            button_Options.Enabled = (tabPage != 1);
            barButtonItem_Stock.Enabled = (tabPage != 0);
            barButtonItem_Option.Enabled = (tabPage != 1);
        }

        #endregion

        #region Real Time Update test
        private void barButtonItem_RtUpdateStart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetRtUpdateSwitch(true);
        }

        private void barButtonItem_RtUpdateStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetRtUpdateSwitch(false);
        }

        void SetRtUpdateSwitch(bool bStartTrue)
        {
            barButtonItem_RtUpdateStart.Enabled = !bStartTrue;
            barButtonItem_RtUpdateStop.Enabled = (bStartTrue);
            timer_RtUpdate.Enabled = (bStartTrue);
        }

        private void timer_RtUpdate_Tick(object sender, EventArgs e)
        {
            var bListStock = gridControl_Stock.DataSource as BindingList<Stock>;
            var bListOption = gridControl_Option.DataSource as BindingList<Option>;

            int i = rnd.Next(bListStock.Count);
            int j = rnd.Next(bListOption.Count);

            double sPx = bListStock[i].Close  + Math.Round(rnd.NextDouble() - 0.5, 2);
            double oPx = bListOption[j].Close + Math.Round(rnd.NextDouble() - 0.5, 2);

            bListStock[i].Close = Math.Max(0, sPx);
            bListStock[i].High = Math.Max(bListStock[i].High, sPx);
            bListStock[i].Low = Math.Min(bListStock[i].Low, sPx);

            bListOption[j].Close = Math.Max(0, oPx);
            bListOption[j].High = Math.Max(bListOption[j].High, oPx);
            bListOption[j].Low = Math.Min(bListOption[j].Low, oPx);

            //switch (rnd.Next(4))
            //{
            //    case 0:
            //        bListStock[i].Open += Math.Round(rnd.NextDouble()-0.5, 2);
            //        bListOption[j].Open += Math.Round(rnd.NextDouble() - 0.5, 2);
            //        break;
            //    case 1:
            //        bListStock[i].High += Math.Round(rnd.NextDouble() - 0.5, 2);
            //        bListOption[j].High += Math.Round(rnd.NextDouble() - 0.5, 2);
            //        break;
            //    case 2:
            //        bListStock[i].Low += Math.Round(rnd.NextDouble() - 0.5, 2);
            //        bListOption[j].Low += Math.Round(rnd.NextDouble() - 0.5, 2);
            //        break;
            //    case 3:
            //        bListStock[i].Close += Math.Round(rnd.NextDouble() - 0.5,2);
            //        bListOption[j].Close += Math.Round(rnd.NextDouble() - 0.5, 2);
            //        break;
            //}

        }

        #endregion


    }
}
