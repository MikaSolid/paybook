using System;
using System.Collections.Generic;

namespace PayBook
{
    public sealed class Container
    {
        private readonly IDictionary<object, Func<object>> _components
            = new Dictionary<object, Func<object>>();

        #region Singleton

        private static readonly Container _instance = new Container();

        public static Container GetInstance()
        {
            return _instance;
        }

        #endregion

        #region Constructor

        private Container()
        {
        }

        #endregion

        #region Register & resolve

        public void Register(Type type, Func<object> function)
        {
            if (!_components.ContainsKey(type))
            {
                _components.Add(type, function);
            }
            else
            {
                _components[type] = function;
            }
        }

        public T Resolve<T>()
        {
            try
            {
                return (T)_components[typeof(T)]();
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("The requested registration cannot be resolved.");
            }
        }

        #endregion
    }
}