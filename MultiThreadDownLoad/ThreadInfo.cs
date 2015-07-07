using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadDownLoad
{
    class ThreadInfo
    {
        public int ThreadId { get; set; }
        public bool ThreadStatus { get; set; }
        public long StartPosition { get; set; }
        public long FileSize { get; set; }
        public string Url { get; set; }
        public string TmpFileName { get; set; }
        public int Times { get; set; }

    }
}
