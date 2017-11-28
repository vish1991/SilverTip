using System;

namespace SilverTip.BusinessObjects
{
    public class Disposable : IDisposable
    {
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        ~Disposable()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue && disposing)
            {
                DisposeCore();
            }
            disposedValue = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void DisposeCore()
        {

        }
        #endregion
    }
}
