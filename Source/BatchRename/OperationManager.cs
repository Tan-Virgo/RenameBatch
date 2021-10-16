using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BatchRename
{
    class OperationManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private Operation operation { get; }
        public UserControl control { get; }
        public string Name => operation.Name;
        public string Image => operation.Image;
        public int count { get; set; }

        public OperationManager(Operation operation, UserControl control)
        {
            this.operation = operation;
            this.control = control;
            this.control.Visibility = Visibility.Visible;
        }
        public void Notify(string Expand)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Expand));
        }
        public void ShowControl()
        {
            count++;
            if (count % 2 == 1)
            {
                control.Visibility = Visibility.Visible;
            }
            else
            {
                control.Visibility = Visibility.Hidden;
            }
        }
    }
}
