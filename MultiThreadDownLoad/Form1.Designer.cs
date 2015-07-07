namespace MultiThreadDownLoad
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSource = new System.Windows.Forms.Label();
            this.listUrls = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblThreads = new System.Windows.Forms.Label();
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.txtCurrentThreadCount = new System.Windows.Forms.TextBox();
            this.lblCurrentThread = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDestAddress = new System.Windows.Forms.TextBox();
            this.txtScan = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblTotalBytes = new System.Windows.Forms.Label();
            this.txtTotalBytes = new System.Windows.Forms.TextBox();
            this.btDownload = new System.Windows.Forms.Button();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblFinalTime = new System.Windows.Forms.Label();
            this.txtFinalTime = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblAlready = new System.Windows.Forms.Label();
            this.txtAlreadyDown = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(22, 18);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(101, 12);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "请添加下载源URL:";
            // 
            // listUrls
            // 
            this.listUrls.FormattingEnabled = true;
            this.listUrls.HorizontalScrollbar = true;
            this.listUrls.ItemHeight = 12;
            this.listUrls.Location = new System.Drawing.Point(24, 45);
            this.listUrls.Name = "listUrls";
            this.listUrls.Size = new System.Drawing.Size(266, 124);
            this.listUrls.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(514, 44);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "添加URL";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(323, 44);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(185, 21);
            this.txtURL.TabIndex = 3;
            // 
            // lblThreads
            // 
            this.lblThreads.AutoSize = true;
            this.lblThreads.Location = new System.Drawing.Point(323, 102);
            this.lblThreads.Name = "lblThreads";
            this.lblThreads.Size = new System.Drawing.Size(89, 12);
            this.lblThreads.TabIndex = 4;
            this.lblThreads.Text = "请输入线程数：";
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Location = new System.Drawing.Point(434, 99);
            this.txtThreadCount.Name = "txtThreadCount";
            this.txtThreadCount.Size = new System.Drawing.Size(100, 21);
            this.txtThreadCount.TabIndex = 5;
            this.txtThreadCount.Text = "3";
            // 
            // txtCurrentThreadCount
            // 
            this.txtCurrentThreadCount.Location = new System.Drawing.Point(434, 148);
            this.txtCurrentThreadCount.Name = "txtCurrentThreadCount";
            this.txtCurrentThreadCount.ReadOnly = true;
            this.txtCurrentThreadCount.Size = new System.Drawing.Size(100, 21);
            this.txtCurrentThreadCount.TabIndex = 9;
            // 
            // lblCurrentThread
            // 
            this.lblCurrentThread.AutoSize = true;
            this.lblCurrentThread.Location = new System.Drawing.Point(323, 151);
            this.lblCurrentThread.Name = "lblCurrentThread";
            this.lblCurrentThread.Size = new System.Drawing.Size(77, 12);
            this.lblCurrentThread.TabIndex = 8;
            this.lblCurrentThread.Text = "当前线程数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "目标文件保存地址：";
            // 
            // txtDestAddress
            // 
            this.txtDestAddress.Location = new System.Drawing.Point(144, 192);
            this.txtDestAddress.Name = "txtDestAddress";
            this.txtDestAddress.Size = new System.Drawing.Size(254, 21);
            this.txtDestAddress.TabIndex = 11;
            // 
            // txtScan
            // 
            this.txtScan.Location = new System.Drawing.Point(434, 190);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(75, 23);
            this.txtScan.TabIndex = 12;
            this.txtScan.Text = "另存为";
            this.txtScan.UseVisualStyleBackColor = true;
            this.txtScan.Click += new System.EventHandler(this.txtScan_Click);
            // 
            // lblTotalBytes
            // 
            this.lblTotalBytes.AutoSize = true;
            this.lblTotalBytes.Location = new System.Drawing.Point(26, 240);
            this.lblTotalBytes.Name = "lblTotalBytes";
            this.lblTotalBytes.Size = new System.Drawing.Size(59, 12);
            this.lblTotalBytes.TabIndex = 13;
            this.lblTotalBytes.Text = "总字节数:";
            // 
            // txtTotalBytes
            // 
            this.txtTotalBytes.Location = new System.Drawing.Point(111, 237);
            this.txtTotalBytes.Name = "txtTotalBytes";
            this.txtTotalBytes.ReadOnly = true;
            this.txtTotalBytes.Size = new System.Drawing.Size(117, 21);
            this.txtTotalBytes.TabIndex = 14;
            // 
            // btDownload
            // 
            this.btDownload.Location = new System.Drawing.Point(433, 237);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(75, 23);
            this.btDownload.TabIndex = 15;
            this.btDownload.Text = "下载";
            this.btDownload.UseVisualStyleBackColor = true;
            this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(91, 322);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(117, 21);
            this.txtStartTime.TabIndex = 16;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(26, 325);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(59, 12);
            this.lblStartTime.TabIndex = 17;
            this.lblStartTime.Text = "开始时间:";
            // 
            // lblFinalTime
            // 
            this.lblFinalTime.AutoSize = true;
            this.lblFinalTime.Location = new System.Drawing.Point(392, 328);
            this.lblFinalTime.Name = "lblFinalTime";
            this.lblFinalTime.Size = new System.Drawing.Size(59, 12);
            this.lblFinalTime.TabIndex = 19;
            this.lblFinalTime.Text = "结束时间:";
            // 
            // txtFinalTime
            // 
            this.txtFinalTime.Location = new System.Drawing.Point(472, 325);
            this.txtFinalTime.Name = "txtFinalTime";
            this.txtFinalTime.ReadOnly = true;
            this.txtFinalTime.Size = new System.Drawing.Size(117, 21);
            this.txtFinalTime.TabIndex = 18;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(28, 287);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(561, 23);
            this.progressBar1.TabIndex = 20;
            // 
            // lblAlready
            // 
            this.lblAlready.AutoSize = true;
            this.lblAlready.Location = new System.Drawing.Point(223, 325);
            this.lblAlready.Name = "lblAlready";
            this.lblAlready.Size = new System.Drawing.Size(53, 12);
            this.lblAlready.TabIndex = 21;
            this.lblAlready.Text = "已下载：";
            // 
            // txtAlreadyDown
            // 
            this.txtAlreadyDown.Location = new System.Drawing.Point(291, 322);
            this.txtAlreadyDown.Name = "txtAlreadyDown";
            this.txtAlreadyDown.ReadOnly = true;
            this.txtAlreadyDown.Size = new System.Drawing.Size(70, 21);
            this.txtAlreadyDown.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 428);
            this.Controls.Add(this.txtAlreadyDown);
            this.Controls.Add(this.lblAlready);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblFinalTime);
            this.Controls.Add(this.txtFinalTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.btDownload);
            this.Controls.Add(this.txtTotalBytes);
            this.Controls.Add(this.lblTotalBytes);
            this.Controls.Add(this.txtScan);
            this.Controls.Add(this.txtDestAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCurrentThreadCount);
            this.Controls.Add(this.lblCurrentThread);
            this.Controls.Add(this.txtThreadCount);
            this.Controls.Add(this.lblThreads);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listUrls);
            this.Controls.Add(this.lblSource);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.ListBox listUrls;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label lblThreads;
        private System.Windows.Forms.TextBox txtThreadCount;
        private System.Windows.Forms.TextBox txtCurrentThreadCount;
        private System.Windows.Forms.Label lblCurrentThread;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDestAddress;
        private System.Windows.Forms.Button txtScan;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblTotalBytes;
        private System.Windows.Forms.TextBox txtTotalBytes;
        private System.Windows.Forms.Button btDownload;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblFinalTime;
        private System.Windows.Forms.TextBox txtFinalTime;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblAlready;
        private System.Windows.Forms.TextBox txtAlreadyDown;
    }
}

