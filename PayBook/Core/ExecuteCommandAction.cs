using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace PayBook
{
    public class ExecuteCommandAction : TriggerAction<DependencyObject>
    {
        #region Command

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(ExecuteCommandAction), null);

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(ExecuteCommandAction), null);

        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register("CommandTarget", typeof(UIElement), typeof(ExecuteCommandAction), null);

        public static readonly DependencyProperty PassEventArgsToCommandProperty =
            DependencyProperty.Register("PassEventArgsToCommand", typeof(bool), typeof(ExecuteCommandAction), null);

        public ICommand Command
        {
            get { return (ICommand)base.GetValue(CommandProperty); }
            set { base.SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return base.GetValue(CommandParameterProperty); }
            set { base.SetValue(CommandParameterProperty, value); }
        }

        public UIElement CommandTarget
        {
            get { return (UIElement)base.GetValue(CommandTargetProperty); }
            set { base.SetValue(CommandTargetProperty, value); }
        }

        /// <summary>
        /// Indicates whether EventArgs will be used as command parameter, or we will use CommandParameter dependency property.
        /// </summary>
        public bool PassEventArgsToCommand
        {
            get { return (bool)base.GetValue(PassEventArgsToCommandProperty); }
            set { base.SetValue(PassEventArgsToCommandProperty, value); }
        }

        #endregion

        #region Invoke

        protected override void Invoke(object parameter)
        {
            if (this.Command == null) return;

            ICommand cmd = this.Command;
            object cmdParam = this.CommandParameter;

            if (cmdParam == null && this.PassEventArgsToCommand)
            {
                cmdParam = parameter;
            }

            if (cmd is RoutedCommand)
            {
                RoutedCommand routedCmd = (RoutedCommand)cmd;
                UIElement cmdTarget = this.CommandTarget ?? base.AssociatedObject as UIElement;

                if (routedCmd.CanExecute(cmdParam, cmdTarget))
                    routedCmd.Execute(cmdParam, cmdTarget);
            }
            else
            {
                if (cmd.CanExecute(cmdParam))
                    cmd.Execute(cmdParam);
            }
        }

        #endregion
    }
}