using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

namespace PayBook
{
    public abstract class BaseVM : INotifyPropertyChanged
    {
        #region Constructors

        protected BaseVM() { }

        protected BaseVM(SynchronizationContext syncContext)
        {
            _syncContext = syncContext;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;

            if (_syncContext != null)
                _syncContext.Post(s => NotifyPropertyChanged(propertyName), null);
            else
                NotifyPropertyChanged(propertyName);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region SyncContext

        private readonly SynchronizationContext _syncContext;

        protected SynchronizationContext SyncContext
        {
            get { return _syncContext; }
        }

        #endregion

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

        #region IsInDesignMode

        public bool IsInDesignMode
        {
            get
            {
                return BaseVM.GetIsInDesignMode();
            }
        }

        private static bool? _isInDesignMode;

        public static bool GetIsInDesignMode()
        {
            if (!_isInDesignMode.HasValue)
            {
                var prop = DesignerProperties.IsInDesignModeProperty;

                _isInDesignMode = (bool)DependencyPropertyDescriptor
                    .FromProperty(prop, typeof(FrameworkElement))
                    .Metadata.DefaultValue;
            }

            return _isInDesignMode.Value;
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