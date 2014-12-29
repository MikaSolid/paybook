using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;

namespace PayBook
{
    public abstract class Observable : INotifyPropertyChanged
    {
        protected Observable() { }

        protected Observable(SynchronizationContext syncContext)
        {
            _syncContext = syncContext;
        }

        #region SyncContext

        protected readonly SynchronizationContext _syncContext;

        protected SynchronizationContext SyncContext
        {
            get { return _syncContext; }
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

        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            OnPropertyChanged(GetPropertyName(propertyExpression));
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException("propertyExpression");
            }

            var body = propertyExpression.Body as MemberExpression;

            if (body == null)
            {
                throw new ArgumentException("Invalid argument", "propertyExpression");
            }

            var property = body.Member as PropertyInfo;

            if (property == null)
            {
                throw new ArgumentException("Argument is not a property", "propertyExpression");
            }

            return property.Name;
        }

        #endregion
    }
}