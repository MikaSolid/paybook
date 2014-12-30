using System.ComponentModel;
using System.Windows;

namespace PayBook.ViewModels
{
    public static class Mvvm
    {
        #region IsInDesignMode

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

    }
}
