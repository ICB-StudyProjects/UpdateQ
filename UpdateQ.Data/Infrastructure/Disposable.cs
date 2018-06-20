namespace UpdateQ.Data.Infrastructure
{
    using System;

    class Disposable : IDisposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.isDisposed && disposing)
            {
                DisposeCore();
            }
            this.isDisposed = true;
        }

        protected virtual void DisposeCore()
        { }
    }
}
