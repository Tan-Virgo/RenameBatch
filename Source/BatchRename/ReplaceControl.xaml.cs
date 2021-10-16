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
    /// Interaction logic for ReplaceControl.xaml
    /// </summary>
    public partial class ReplaceControl : UserControl
    {
        public ReplaceOperation replace;
        public ReplaceControl()
        {
            InitializeComponent();
        }

        private void btn_Add_To_List(object sender, RoutedEventArgs e)
        {
            int check = 1; // kiểm tra giá trị 1: thực hiện được, 0: sai
            var from = TextBoxFrom.Text;
            var to = TextBoxTo.Text;

            if (from == "")
            {
                check = 0;
                MessageBox.Show("You nust enter one value for FROM !");
            }

            if (to != "")
            {
                int flag = 0; // dùng kiểm tra

                for (int i = 0; i < to.Length; i++)
                {
                    // kiểm tra chuyển đổi có ký tự đặc biệt không?
                    if (to[i] == '/' || to[i] == ':' || to[i] == '*' || to[i] == '?' || to[i] == '<'
                        || to[i] == '>' || to[i] == '|' || (int)to[i] == 34 || (int)to[i] == 92)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    //to chứa kí tự không được đặt tên file: \/:*?"<>|
                    check = 0;
                    MessageBox.Show($"File's name can't include:\" {(char)92} / : * ? {(char)34} < > | \"");
                }
            }

            if (check == 1)
            {
                ComboBoxItem typeItem = (ComboBoxItem)CbbApplyTo.SelectedItem;
                replace = new ReplaceOperation()
                {
                    Args = new ReplaceOperationArguments()
                    {
                        From = TextBoxFrom.Text,
                        To = TextBoxTo.Text,
                        StringChange = typeItem.Content.ToString()
                    }
                };
                if (Global.operation == null)
                {
                    Global.operation = new BindingList<Operation>();
                }
                Global.operation.Add(replace);
            }

            // Xóa dữ liệu trên các Textbox
            TextBoxFrom.Text = "";
            TextBoxTo.Text = "";
        }
    }
}
