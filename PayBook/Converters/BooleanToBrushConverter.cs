using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PayBook
{
    /// <summary> Converts Boolean value to and from Brush value. </summary>
    /// <remarks>
    /// <para>
    /// &lt;abc:BooleanToBrushConverter x:Key="BoolToBrushConverter" TrueBrush="Green" FalseBrush="Red" /&gt;
    /// </para>
    /// <para> </para>
    /// <para>
    /// &lt;Grid Background="{Binding IsXYZ, Converter={StaticResource BoolToBrushConverter}}"&gt;&lt;/Grid&gt;
    /// </para>
    /// </remarks>
    [ValueConversion(typeof(bool), typeof(Brush))]
    public class BooleanToBrushConverter : IValueConverter
    {
        #region True / False Visibility

        private Brush _falseBrush = Brushes.Black; // (Brush)new BrushConverter().ConvertFrom("#FF0069B5");

        private Brush _trueBrush = Brushes.White; // (Brush)new BrushConverter().ConvertFrom("#FF3099F5");

        /// <summary> Gets or sets Brush value which will be returned from converter in case that bound Boolean value is True. </summary>
        [Description("Brush value that will be returned from converter in case that bound Boolean value is True.")]
        public Brush TrueBrush
        {
            get { return this._trueBrush; }
            set { this._trueBrush = value; }
        }

        /// <summary> Gets or sets Brush value which will be returned from converter in case that bound Boolean value is False. </summary>
        [Description("Brush value that will be returned from converter in case that bound Boolean value is False.")]
        public Brush FalseBrush
        {
            get { return this._falseBrush; }
            set { this._falseBrush = value; }
        }

        #endregion

        #region IValueConverter

        /// <summary> Converts a Boolean value to Brush value. </summary>
        /// <returns> A Brush value. </returns>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">This paramater is not used.</param>
        /// <param name="parameter">This paramater is not used.</param>
        /// <param name="culture">This parameter is not used.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) throw new ArgumentNullException("value", "Value cannot be null");
            if (!(value is bool)) throw new ArgumentException("Value can only be boolean.", "value");
            if (targetType != typeof(Brush)) throw new ArgumentException("Value can only be Type of Brush", "targetType");

            return ((bool)value) ? this.TrueBrush : this.FalseBrush;
        }

        /// <summary> Converts a Brush value to Boolean value. </summary>
        /// <returns> A Boolean value. </returns>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">This paramater is not used.</param>
        /// <param name="parameter">This paramater is not used.</param>
        /// <param name="culture">This parameter is not used.</param>
        /// <remarks>If bound value is the same like TrueBrush proeperty result will be True.</remarks>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) throw new ArgumentNullException("value", "Value cannot be null");
            if (!(value is Brush)) throw new ArgumentException("Value can only be Brush.", "value");
            if (targetType != typeof(bool)) throw new ArgumentException("Value can only be Type of boolean", "targetType");

            Brush brush = (Brush)value;

            return Equals(brush, this.TrueBrush);
        }

        #endregion
    }
}
