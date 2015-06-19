using System;
using System.Windows.Forms;

namespace CommonLib
{
    public class WaitCursor : IDisposable
    {
        private Form target = null;
        private Cursor oldCursor;
        private bool disposed = false;

        public WaitCursor(Form target)
        {
            this.target = target;
            this.oldCursor = this.target.Cursor;
            this.target.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // free managed
                    if (this.target != null) this.target.Cursor = oldCursor;
                }
                // free unmanaged
                disposed = true;
            }
        }

        ~WaitCursor()
        {
            Dispose(false);
        }
    }
}
