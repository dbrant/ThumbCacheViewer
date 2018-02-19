using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace ThumbCacheViewer
{
    public class ListViewDblBuf : System.Windows.Forms.ListView
    {
        public ListViewDblBuf()
            : base()
        {
            this.DoubleBuffered = true;
        }
    }
}
