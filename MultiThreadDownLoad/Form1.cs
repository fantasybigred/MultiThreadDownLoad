using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreadDownLoad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            sums = new List<long>();
            download = new Downloader();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text.Trim();
            listUrls.Items.Add(url);
            txtURL.Text = string.Empty;
        }

        private void txtScan_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(listUrls.Items[0].ToString()))
            {
                var names = listUrls.Items[0].ToString().Split('.');
                var extName = names[names.Length - 1];
                saveFileDialog1.DefaultExt = extName;
                saveFileDialog1.AddExtension = true;
                saveFileDialog1.Filter = string.Format("{0}文件|.{0}", extName);
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtDestAddress.Text = saveFileDialog1.FileName;
                }
            }
        }
        private Downloader download;
        private void btDownload_Click(object sender, EventArgs e)
        {
            SetControlUnable();

            txtCurrentThreadCount.Text = txtThreadCount.Text;
            string sourceFile = listUrls.Items[0].ToString();
            string destFileName = txtDestAddress.Text.Trim();
            int threadCount = Convert.ToInt32(txtThreadCount.Text.Trim());

            List<string> urls = new List<string>();
            foreach(var item in listUrls.Items)
            {
                urls.Add(item.ToString());
            }


                //Downloader download = new Downloader();
            download.OnUpdateSrcFileSize += new Downloader.UpdateSrcFileSize(download_OnUpdateSrcFileSize);
            download.OnGetStartTime += new Downloader.GetRunTime(download_OnGetStartTime);
            download.OnGetFinalTime += new Downloader.GetRunTime(download_OnGetFinalTime);
            //download.DownloadFile(sourceFile, destFileName, threadCount, 0);
            download.DownloadFile(urls, destFileName, threadCount, 0);

            download.OnDownloadingPercent += new Downloader.DownloadingPercent(download_OnDownloadingPercent);
            download.OnSetControlStaus += new Downloader.SetControlStaus(download_OnSetControlStaus);

            //sums = download.SumOfThreads;
        }

        private void download_OnSetControlStaus()
        {
            SetControlEnable();
        }

        private void SetControlUnable()
        {
            txtURL.Enabled = false;
            btnAdd.Enabled = false;
            txtThreadCount.Enabled = false;
            txtDestAddress.Enabled = false;
            btDownload.Enabled = false;
            txtScan.Enabled = false;
        }

        private void SetControlEnable()
        {
            txtURL.Enabled = true;
            btnAdd.Enabled = true;
            txtThreadCount.Enabled = true;
            txtThreadCount.Text = (3).ToString();
            txtDestAddress.Enabled = true;
            txtDestAddress.Text = string.Empty;
            btDownload.Enabled = true;
            txtStartTime.Text = string.Empty;
            txtFinalTime.Text = string.Empty;
            txtAlreadyDown.Text = string.Empty;
            progressBar1.Value = 0;
            txtTotalBytes.Text = string.Empty;
            listUrls.Items.Clear();
            txtScan.Enabled = true;
        }

        private void download_OnDownloadingPercent(double percent)
        {
            setProgressBar(percent);
        }

        private delegate void SetProgressBar(double percent);

        private void setProgressBar(double percent)
        {
            if(txtAlreadyDown.InvokeRequired)
            {
                SetProgressBar setpb = new SetProgressBar(setProgressBar);
                txtAlreadyDown.Invoke(setpb, new object[] { percent });
            }
            else
            {
                txtAlreadyDown.Text = Convert.ToInt32(percent) + "%";
                progressBar1.Value = (int)percent + 1;
            }
        }


        private void download_OnGetFinalTime(DateTime date)
        {
            txtFinalTime.Text = date.ToString();
        }

        private void download_OnGetStartTime(DateTime date)
        {
            txtStartTime.Text = date.ToString();
        }

        private void download_OnUpdateSrcFileSize(int rowIndex, long size)
        {
            txtTotalBytes.Text = size.ToString();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    foreach(var item in sums)
        //    {
        //        listBox1.Items.Add(item);
        //    }
        //    textBox1.Text = sums.Sum().ToString();
        //}

        private List<long> sums;

        private void btnCreateThread_Click(object sender, EventArgs e)
        {

        }
    }
}
