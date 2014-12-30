using System;

namespace PayBook
{
    public abstract class BaseVM : Observable
    {
        #region IsBusy

        private bool _isBusy = false;

        public bool IsBusy
        {
            get { return _isBusy; }
            private set
            {
                if (_isBusy == value) return;

                _isBusy = value;

                OnPropertyChanged("IsBusy");
            }
        }

        #endregion

        #region InvokeAsync

        protected void InvokeAsync<T>(Func<T> worker, Action<T> callback, Action uiCallback)
        {
            AsyncCallback asyncCallback = ar =>
            {
                T workerResult = worker.EndInvoke(ar);

                if (callback != null) callback(workerResult);

                if (uiCallback != null)
                {
                    _syncContext.Post(s =>
                    {
                        uiCallback();

                        IsBusy = false;
                    }, null);
                }
                else
                {
                    IsBusy = false;
                }
            };

            IsBusy = true;

            worker.BeginInvoke(asyncCallback, null);
        }

        protected void InvokeAsync<T, M>(Func<T> worker, Func<T, M> callback, Action<M> uiCallback)
        {
            AsyncCallback asyncCallback = ar =>
            {
                T workerResult = worker.EndInvoke(ar);

                M callbackResult = default(M);

                if (callback != null) callbackResult = callback(workerResult);

                if (uiCallback != null)
                {
                    _syncContext.Post(s =>
                    {
                        uiCallback(callbackResult);

                        IsBusy = false;
                    }, null);
                }
                else
                {
                    IsBusy = false;
                }
            };

            IsBusy = true;

            worker.BeginInvoke(asyncCallback, null);
        }

        #endregion
    }
}