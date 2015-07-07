using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreadDownLoad
{
    public class Downloader : IDisposable
    {
        private int bufferSize = 512;//缓冲池大小
        private int threadNum;//线程数
        //private bool[] threadStatus;//每个线程结束标志
        //private string[] fileNames;//每个线程接收文件的文件名
        //private int[] StartPos;//每个线程接收文件的起始位置
        //private int[] fileSize;//每个线程接收文件的大小
        //private string Url;//接受文件的URL
        private List<string> Urls;
        private bool HasMerge;//文件合并标志
        private string DestFileName;
        private long receiveSize;//已经接收到的字节数
        private long fileSizeAll;//文件字节数
        private int RowIndex;//任务索引

       // private List<long> sumOfThreads;

        private List<ThreadInfo> threadinfos;

        private object lockPercent;//用于在加载下载进度是上锁

        /// <summary>
        /// 下载进度
        /// </summary>
        /// <param name="rowIndex">任务索引</param>
        /// <param name="percent">进度</param>
        public delegate void DownloadingPercent(double percent);
        public event DownloadingPercent OnDownloadingPercent;

        /// <summary>
        /// 源文件大小
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="size"></param>
        public delegate void UpdateSrcFileSize(int rowIndex, long size);
        public event UpdateSrcFileSize OnUpdateSrcFileSize;
        /// <summary>
        /// 响应开始时间和结束时间的事件
        /// </summary>
        /// <param name="date"></param>
        public delegate void GetRunTime(DateTime date);
        public event GetRunTime OnGetStartTime;
        public event GetRunTime OnGetFinalTime;

        /// <summary>
        /// 响应改变控件状态事件，变为可使用
        /// </summary>
        public delegate void SetControlStaus();
        public event SetControlStaus OnSetControlStaus;

        //public List<long> SumOfThreads
        //{
        //    get { return sumOfThreads; }
        //}

        public Downloader()
        {
            //sumOfThreads = new List<long>();
            threadinfos = new List<ThreadInfo>();
            lockPercent = new object();
        }

        /// <summary>
        /// 方式多线程下载一个文件
        /// </summary>
        /// <param name="srcFileUrl">文件地址</param>
        /// <param name="destFileName">保存全名</param>
        /// <param name="maxThreadNum">线程数</param>
        /// <param name="rowIndex">任务索引</param>
        //public void DownloadFile(string srcFileUrl, string destFileName, int maxThreadNum, int rowIndex)
        //{
        //    if (srcFileUrl.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        DownloadHttpFile(srcFileUrl, destFileName, maxThreadNum, rowIndex);
        //    }

        //}

        /// <summary>
        /// Http方式多线程下载一个文件
        /// </summary>
        /// <param name="srcFileUrl">文件地址</param>
        /// <param name="destFileName">保存全名</param>
        /// <param name="maxThreadNum">线程数</param>
        /// <param name="rowIndex">任务索引</param>
        
        //public void DownloadFile(string srcFileUrl, string destFileName, int maxThreadNum, int rowIndex)
        public void DownloadFile(List<string> srcFileUrl, string destFileName, int maxThreadNum, int rowIndex)
        {
            OnGetStartTime(DateTime.Now);
            //Url = srcFileUrl;
            Urls = srcFileUrl;
            DestFileName = destFileName;
            RowIndex = rowIndex;
            threadNum = maxThreadNum;//多少个线程下载
            receiveSize = 0;

            

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.Urls[0]);
            fileSizeAll = request.GetResponse().ContentLength;
            request.Abort();
            OnUpdateSrcFileSize(0, fileSizeAll);

            //初始化多线程，每个线程平均分配文件大小，剩余部分由最后一个线程完成
            //threadStatus = new bool[threadNum];
            //fileNames = new string[threadNum];
            //StartPos = new int[threadNum];
            //fileSize = new int[threadNum];

            //threadinfos = new ThreadInfo[threadNum];

            int filethread = (int)fileSizeAll / threadNum;
            int filethreadEnd = filethread + (int)fileSizeAll % threadNum;
            for (int i = 0; i < threadNum; i++)
            {
                //sumOfThreads.Add(0);
                //threadStatus[i] = false;

                ThreadInfo currentThread = new ThreadInfo();

                //threadinfos[i].ThreadId = i;
                //threadinfos[i].ThreadStatus = false;
                //threadinfos[i].TmpFileName = string.Format("{0}_{1}.tmp", DestFileName, i);
                //threadinfos[i].Url = Urls[i % Urls.Count];

                currentThread.ThreadId = i;
                currentThread.ThreadStatus = false;
                currentThread.TmpFileName = string.Format("{0}_{1}.tmp", DestFileName, i);
                currentThread.Url = Urls[i % Urls.Count];

                //fileNames[i] = string.Format("{0}_{1}.tmp", DestFileName, i);
                if (i < threadNum - 1)
                {
                    //StartPos[i] = filethread * i;
                    //fileSize[i] = filethread - 1;

                    currentThread.StartPosition = filethread * i;
                    currentThread.FileSize = filethread - 1;
                }
                else
                {
                    //StartPos[i] = filethread * i;
                    //fileSize[i] = filethreadEnd - 1; 

                    currentThread.StartPosition = filethread * i;
                    currentThread.FileSize = filethreadEnd - 1; 
                }
                threadinfos.Add(currentThread);               
            }

            // 定义并启动线程数组
            for (int i = 0; i < threadinfos.Count; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveHttp), threadinfos[i]);
            }
            //启动合并线程
            ThreadPool.QueueUserWorkItem(new WaitCallback(MergeFile), null);
        }

        /// <summary>
        /// Http方式接收一个区块
        /// </summary>
        //private void ReceiveHttp(object threadId)
        private void ReceiveHttp(object thread)
        {
            //int ThreadId = (int)threadId;

            ThreadInfo currentThread = (ThreadInfo)thread;

            //string filename = fileNames[ThreadId];     // 线程临时文件
            byte[] buffer = new byte[bufferSize];         // 接收缓冲区
            int readSize = 0;                              // 接收字节数
            //FileStream fs = new FileStream(filename, System.IO.FileMode.Create);
            FileStream fs = new FileStream(currentThread.TmpFileName, System.IO.FileMode.Create);
            Stream ns = null;
            try
            {
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);

                //request.AddRange(StartPos[ThreadId], StartPos[ThreadId] + fileSize[ThreadId]);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(currentThread.Url);
                request.AddRange(currentThread.StartPosition, currentThread.StartPosition + currentThread.FileSize);

                ns = request.GetResponse().GetResponseStream();
                readSize = ns.Read(buffer, 0, bufferSize);
                while (readSize > 0)
                {
                    fs.Write(buffer, 0, readSize);
                    //sumOfThreads[currentThread.ThreadId] += readSize;

                    readSize = ns.Read(buffer, 0, bufferSize);
                    //lock (lockPercent)
                   // {
                        receiveSize += readSize;
                        double percent = (double)receiveSize / (double)fileSizeAll * 100;
                        OnDownloadingPercent(percent);//触发下载进度事件
                    //}
                }
            }
            catch //这里不用处理异常，如果等待超时了，会自动继续等待到可以下载为止
            {
                //throw ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
                if (ns != null)
                {
                    ns.Close();
                }
                
            }
            //threadStatus[currentThread.ThreadId] = true;
            currentThread.ThreadStatus = true;
        }
        

        /// <summary>
        /// 合并文件
        /// </summary>
        private void MergeFile(object obj)
        {
            while (true)
            {
                HasMerge = true;
                //for (int i = 0; i < threadNum; i++)
                //{
                //    //if (!threadStatus[i]) // 若有未结束线程，则等待
                //    if (!threadinfos[i].ThreadStatus)
                //    {
                //        HasMerge = false;
                //        System.Threading.Thread.Sleep(1000);
                //        break;
                //    }
                //}
                foreach (var item in threadinfos)
                {
                    //if (!threadStatus[i]) // 若有未结束线程，则等待
                    if (!item.ThreadStatus)
                    {
                        HasMerge = false;
                        System.Threading.Thread.Sleep(1000);
                        break;
                    }
                }
                if (HasMerge) // 否则，停止等待
                {
                    break;
                }
            }

            int readSize;
            string downFileNamePath = DestFileName;
            byte[] bytes = new byte[bufferSize];
            FileStream fs = new FileStream(downFileNamePath, FileMode.Create);
            FileStream fsTmp = null;

            for (int k = 0; k < threadNum; k++)
            {
                //fsTmp = new FileStream(fileNames[k], FileMode.Open);
                fsTmp = new FileStream(threadinfos[k].TmpFileName, FileMode.Open);
                while (true)
                {
                    readSize = fsTmp.Read(bytes, 0, bufferSize);
                    if (readSize > 0)
                        fs.Write(bytes, 0, readSize);
                    else
                        break;
                }
                fsTmp.Close();
                try
                {
                    File.Delete(threadinfos[k].TmpFileName);
                }
                catch
                {
                }
            }
            fs.Close();
            OnGetFinalTime(DateTime.Now);
            MessageBox.Show("下载完成！");
            OnSetControlStaus();
            //OnDownloadingPercent(RowIndex, 100);//触发下载进度事件
        }

        public void Dispose()
        {
            for (int k = 0; k < threadNum; k++)
            {
                try
                {
                    File.Delete(threadinfos[k].TmpFileName);
                }
                catch
                {
 			MessageBox.Show("线程已杀死！");
                }
            }
        }
    }
}
