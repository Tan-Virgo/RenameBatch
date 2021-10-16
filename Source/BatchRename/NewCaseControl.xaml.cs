using BatchRename.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BatchRename
{
    /// <summary>
    /// Interaction logic for NewCaseControl.xaml
    /// </summary>
    public partial class NewCaseControl : UserControl
    {
        public NewCaseControl()
        {
            InitializeComponent();
        }
        public NewCaseOperation newCase;
        private void btn_AddTo_OoperationList(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)newCaseCombobox.SelectedItem;
            newCase = new NewCaseOperation()
            {
                Args = new NewCaseOperationArguments()
                {
                    type = typeItem.Content.ToString()
                }
            };
            if (Global.operation == null)
            {
                Global.operation = new BindingList<Operation>();
            }
            Global.operation.Add(newCase);
        }
    }
}
