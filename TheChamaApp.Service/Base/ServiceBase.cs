using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TheChamaApp.Service.Base
{
    public class ServiceBase : IDisposable
    {
        #region # IDisposable Members

        private Component component = new Component();
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    component.Dispose();

                disposed = true;
            }
        }

        #endregion
    }
}
