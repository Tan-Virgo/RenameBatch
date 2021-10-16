﻿using BatchRename.Components;
using Microsoft.Win32;      
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.Win32;

namespace BatchRename
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Fluent.RibbonWindow
    {
        /// <summary>
        /// ---------------------- KHAI BÁO BIẾN
        /// </summary>
        
        BindingList<OperationManager> operationList; // danh sách các luật 
        BindingList<Folder> folderList = new BindingList<Folder>(); // danh sách các folder được chọn
        BindingList<File> fileList = new BindingList<File>(); // danh sách các file được chọn
        int indexSelectedFile = -1;   // phần tử item trong listview Rename file
        int indexSelectedFolder = -1; // phần tử item trong listview Rename folder
        OperationManager operationSelected = null; // luật được chọn
        int indexSelectedOperation = -1; // chỉ số phần tử item trong OpertionList được chọn
        BindingList<Operation> selectedOperationList = new BindingList<Operation>(); // danh sách các luật 


        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Welcome to Batch Rename Application!", "WELCOME", MessageBoxButton.OK, MessageBoxImage.Question);
           
        }


        /// <summary>
        /// ----------------------CÁC EVENT
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Do you want to quit this Application?", "Question", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            operationList = new BindingList<OperationManager>
            {
                new OperationManager(new ReplaceOperation(){ }, new ReplaceControl()),
                new OperationManager(new NewCaseOperation(){ }, new NewCaseControl())
                //new OperationManager(new FullnameNormalizeOperation(){ }, new FullnameNormalizeControl()),
                //new OperationManager(new MoveOperation(){ }, new MoveControl()),
                //new OperationManager(new UniqueNameOperation(){ }, new UniqueNameControl()),
            };
            ListOperation.ItemsSource = operationList;
            Open_OperationControl(operationList[0]);
            OperationList.ItemsSource = Global.operation;
        }



        ///=================================================================================================
        ///                                CÁC CHỨC NĂNG THAO TÁC
        ///=================================================================================================
        
        // Chức năng thêm File/Folder
        private void btn_Add(object sender, RoutedEventArgs e)
        {
            if (tabFile.IsSelected)
            {
                Selected_File();
            }
            else if (tabFolder.IsSelected)
            {
                Selected_Folder();            
            }
            else
            {
                MessageBox.Show("You must choose files or folders!","Warning", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Chức năng xóa toàn bộ File/Folder đã chọn
        private void btn_Clear(object sender, RoutedEventArgs e)
        {
            if (tabFile.IsSelected)
            {
                if (MessageBox.Show("Do you want to delete all Selected Files?", "Question", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    fileList.Clear();
                }
            }
            else
            {
                if (MessageBox.Show("Do you want to delete all Selected Folders?", "Question", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    folderList.Clear();
                }
            }
        }

        // Chức năng Làm mới toàn bộ ứng dụng
        private void btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to refresh all?", "Question", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                fileList.Clear();
                folderList.Clear();
                Global.operation.Clear();
            }
        }

        // Chức năng xem trước kết quả thực thi
        private void btn_Preview_Click(object sender, RoutedEventArgs e)
        {
            if (Global.operation == null)
            {
                MessageBox.Show("Action list doesn's have action. Please select action!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                selectedOperationList = new BindingList<Operation>(Global.operation);
            }


            // Preview với các Files
            if (tabFile.IsSelected)
            {
                if (fileList == null)
                {
                    MessageBox.Show("Don't have any seleted file in File List. Please select file by click button ADD !", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else // xử lý Preview File
                {
                    foreach (var item in fileList)
                    {
                        // cắt dấu . ra khỏi tên file: ví dụ: test.txt -> test và txt
                        string newName = ""; // lưu tên
                        string newExtension = ""; // lưu định dạng file
                        if (item.Extension != "")
                        {
                            newName = item.Name.Replace(item.Extension, "");
                            newExtension = item.Extension.Replace(".", "");
                        }
                        else
                        {
                            newName = item.Name;
                        }

                        item.StatusDetail = "";

                        // Thực hiện lần lược các luật đã chọn
                        for (int i = 0; i < selectedOperationList.Count; i++)
                        {
                            if (selectedOperationList[i].Check == true)
                            {
                                // thực thi các rule vô newname
                                var changeName = selectedOperationList[i].Operate(newName, newExtension, ref item.StatusDetail);

                                // Nếu thay đổi là đuôi ( chỉ đối với trường hợp replace đuôi)
                                if (selectedOperationList[i].GetStringName() == "Extension")
                                {
                                    // cập nhật lại newExtension mới nếu có sự thay đổi
                                    newExtension = changeName;
                                }
                                else
                                {
                                    // cập nhật lại newName mới nếu có sự thay đổi
                                    newName = changeName;
                                }
                            }

                            if (newName == "" && newExtension == "")
                            {
                                item.Newname = item.Name;
                                item.StatusDetail += "Name và Extension không thể đồng thời là chuỗi rỗng\n";
                            }
                            else
                            {
                                item.Newname = newName + "." + newExtension;
                            }

                            // cách đặt tên của một file trong winodws tối đa là 259 ký tự
                            if (item.Path.Length + 1 + item.Newname.Length >= 260)
                            {
                                item.StatusDetail += "The fully qualified file name must be less than 260 characters\n";
                                item.Newname = item.Name;
                            }
                            if (item.StatusDetail != "")
                            {
                                item.Status = "Fail";
                            }
                            else
                            {
                                item.Status = "Success";
                                item.StatusDetail = "Success";
                            }
                        } 
                    }
                    Option_After_Renamefile();
                    filesListView.ItemsSource = fileList;
                }
            }
            else
            {
                if (folderList == null)
                {
                    MessageBox.Show("Don't have any seleted folder in Folder List. Please select folder by click button ADD !", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else // Xử lý Preview folder
                {
                    if (folderList == null)
                    {
                        MessageBox.Show("List foldername doesn's have folder. Please select add foldername!");
                    }
                    else
                    {
                        foreach (var item in folderList)
                        {
                            var newName = item.Name;
                            item.StatusDetail = "";

                            for (int i = 0; i < selectedOperationList.Count; i++)
                            {
                                if (selectedOperationList[i].Check == true)
                                {
                                    // thực thi action vô prename
                                    var changeName = selectedOperationList[i].Operate(newName, "", ref item.StatusDetail);
                                    // Nếu thay đổi là đuôi ( chỉ đối với trường hợp replace đuôi)
                                    if (selectedOperationList[i].GetStringName() == "Extension")
                                    {
                                    }
                                    else
                                    {
                                        // cập nhật lại newName mới nếu có sự thay đổi
                                        newName = changeName;
                                    }
                                }

                            }

                            item.Newname = newName;
                            if (item.Path.Length + 1 + item.Newname.Length >= 248)
                            {
                                item.StatusDetail += "The directory name must be less than 248 characters\n";
                                item.Newname = item.Name;
                            }
                            if (item.StatusDetail != "")
                            {
                                item.Status = "Fail";
                            }
                            else
                            {
                                item.Status = "Success";
                                item.StatusDetail = "Success";
                            }
                        }
                        Option_After_RenameFolder();
                        foldersListView.ItemsSource = folderList;
                    }
                }
            }
        }


        ///=================================================================================================
        ///                                LIÊN QUAN LIST FILE/FOLDER
        ///=================================================================================================
        ///

        // Cập nhật indexSelectedFile mỗi khi chọn một Item trên listview
        private void filesListView_SelectedItem_Click(object sender, MouseButtonEventArgs e)
        {
            indexSelectedFile = filesListView.SelectedIndex;
        }

        // Cập nhật indexSelectedFolder mỗi khi chọn một Item trên listview
        private void folderListView_SelectedItem_Click(object sender, MouseButtonEventArgs e)
        {
            indexSelectedFolder = foldersListView.SelectedIndex;
        }

        // Xem chi tiết trạng thái thực thi của một Item trong listview
        private void FileStatusDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = filesListView.SelectedItem as File;
                if (indexSelectedFile != -1)
                {
                    MessageBox.Show(item.StatusDetail, "Detail Status of this File");
                }
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Xem chi tiết trạng thái thực thi của một Item trong listview
        private void FolderStatusDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = foldersListView.SelectedItem as Folder;
                if (indexSelectedFolder != -1)
                {
                    MessageBox.Show(item.StatusDetail, "Detail Status of this Folder");
                }
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Xem đường dẫn đến file
        private void FileShowPath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = filesListView.SelectedItem as File;
                if (indexSelectedFile != -1)
                {
                    MessageBox.Show(item.Path, "Detail Path");
                }
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Xem đường dẫn Folder
        private void FolderShowPath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = foldersListView.SelectedItem as Folder;
                if (indexSelectedFolder != -1)
                {
                    MessageBox.Show(item.Path, "Detail Path");
                }
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Xóa một Item File trong listview
        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = filesListView.SelectedItem as File;
                if (indexSelectedFile != -1)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to delete file: \"{item.Name}\" from Selected File List ?", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        fileList.RemoveAt(indexSelectedFile);
                    }
                    else
                    {
                        indexSelectedFile = -1;
                    }
                }
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Xóa một Item Folder trong listview
        private void DeleteFolder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = foldersListView.SelectedItem as Folder;
                if (indexSelectedFolder != -1)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to delete folder: \"{item.Name}\" from Selected Folder List ?", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        folderList.RemoveAt(indexSelectedFolder);
                    }
                    else
                    {
                        indexSelectedFolder = -1;
                    }
                }
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Xóa tất cả Item File có cùng đường dẫn trong listview
        private void DeleteAllFile_GeneralPath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = filesListView.SelectedItem as File;
                if (indexSelectedFile != -1)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to delect all item in path: \"{item.Path}\"", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        for (int i = 0; i < fileList.Count; i++)
                        {
                            if (fileList[i].Path == item.Path)
                            {
                                fileList.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                    else
                    {
                        indexSelectedFile = -1;
                    }
                }
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Xóa tất cả Item Folder có cùng đường dẫn trong listview
        private void DeleteAllFolder_GeneralPath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = foldersListView.SelectedItem as File;
                if (indexSelectedFolder != -1)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to delect all item in path: \"{item.Path}\"", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        for (int i = 0; i < folderList.Count; i++)
                        {
                            if (folderList[i].Path == item.Path)
                            {
                                folderList.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                    else
                    {
                        indexSelectedFolder = -1;
                    }
                }
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Xóa tất cả Item có cùng phần mở rộng trong listview
        private void DeleteAllFile_GeneralExtensionInGeneralPath_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = filesListView.SelectedItem as File;
                if (indexSelectedFile != -1)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to delete all item have extension: \"{item.Extension}\" in path: '{item.Path}'", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        for (int i = 0; i < fileList.Count; i++)
                        {
                            if (fileList[i].Path == item.Path && fileList[i].Extension == item.Extension)
                            {
                                fileList.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                    else
                    {
                        indexSelectedFile = -1;
                    }
                }
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        



        ///=================================================================================================
        ///                                LIÊN QUAN THAO TÁC VỚI CÁC RULES
        ///=================================================================================================
        
        // Hiển thị UserControl tương ứng khi click chọn một button item
        private void btn_Operation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Open_OperationControl(ListOperation.SelectedItem);
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // cập nhật Rule được check
        private void OperationItem_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                var index = OperationList.SelectedIndex;
                Global.operation[index].Check = true;
                OperationList.ItemsSource = Global.operation;
                indexSelectedOperation = index;
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Cập nhật rule bỏ check
        private void OperationItem_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                var index = OperationList.SelectedIndex;
                Global.operation[index].Check = false;
                OperationList.ItemsSource = Global.operation;
                indexSelectedOperation = index;
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Cập nhật indexSelectedOperation mỗi khi chọn một Item trên list view
        private void OperationList_SelectedItem_Click(object sender, MouseButtonEventArgs e)
        {
            indexSelectedOperation = OperationList.SelectedIndex;
        }

        // Xóa rule được chọn
        private void DeleteOperation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (indexSelectedOperation != -1)
                {
                    var result = MessageBox.Show($"Do you want to delete rule: \"{Global.operation[indexSelectedOperation].Description}\" ?", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        Global.operation.RemoveAt(indexSelectedOperation);
                        indexSelectedOperation = -1;
                    }
                }
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Xóa tất cả Rule không check
        private void DeleteAllOperation_NoChecked_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (indexSelectedOperation != -1)
                {
                    var result = MessageBox.Show($"Do you want to delete rule: \"{Global.operation[indexSelectedOperation].Description}\" ?", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                            for (int i = 0; i < Global.operation.Count; i++)
                        {
                            if (Global.operation[i].Check == false)
                            {
                                Global.operation.RemoveAt(i);
                                i--;
                            }
                        }
                        indexSelectedOperation = -1;
                    }
                }

            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Xóa tất cả Rule được check
        private void DeleteAllOperation_Checked_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (indexSelectedOperation != -1)
                {
                    var result = MessageBox.Show($"Do you want to delete rule: \"{Global.operation[indexSelectedOperation].Description}\" ?", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {

                        for (int i = 0; i < Global.operation.Count; i++)
                        {
                            if (Global.operation[i].Check == true)
                            {
                                Global.operation.RemoveAt(i);
                                i--;
                            }
                        }
                        indexSelectedOperation = -1;
                    }
                }
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Xóa toàn bộ Rule
        private void DeleteAllOperation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (indexSelectedOperation != -1)
                {
                    var result = MessageBox.Show($"Do you want to delete ALL RULES ?", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        for (int i = 0; i < Global.operation.Count; i++)
                        {
                            Global.operation.RemoveAt(i);
                            i--;
                        }
                        indexSelectedOperation = -1;
                    }
                }
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Save danh sách các Rule
        private void btn_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Global.operation == null)
                {
                    MessageBox.Show("There isn't currently rule on the list. Please add rule before save!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {

                    // TẠO một save file dialog dạng txt
                    SaveFileDialog saveFileDialog = new SaveFileDialog()
                    {
                        Title = "Save Rules into text Files",
                        Filter = "Text files (*.txt)|*.txt",
                        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                    };

                    // get filename
                    var path = "";

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        path = saveFileDialog.FileName;
                    }

                    // người dùng không chọn file -> Tạo file
                    if (path != "")
                    {
                        FileStream fs = new FileStream(path, FileMode.Create);

                        StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);

                        foreach (var act in Global.operation)
                        {
                            if (act.Check == true)
                            {
                                var str = act.Name + " * " + act.Description;
                                sWriter.WriteLine(str);
                            }
                        }

                        sWriter.Flush();
                        MessageBox.Show("Saved Your Rules in txt!", "Notify");
                        fs.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("This action has error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }

        // Mở file txt lưu các luật
        private void btn_OpenRuleFile_Click(object sender, RoutedEventArgs e)
        {

        }


        /// <summary>
        /// ----------------------CÁC HÀM THỰC THI
        /// </summary>
        /// 
        public void Selected_File()
        {
            var screen = new OpenFileDialog();
            screen.Multiselect = true;
            screen.Filter = "All files (*.*)|*.*";
            if (screen.ShowDialog() == true)
            {  
                foreach (var file in screen.FileNames)
                {

                    if (file.Length >= 260)
                    {
                        MessageBox.Show($"File: \"{System.IO.Path.GetFileName(file)}\" has too long Path!");
                        continue;
                    }

                    var fileName = new File()
                    {
                        Name = System.IO.Path.GetFileName(file),
                        Extension = System.IO.Path.GetExtension(file),
                        Newname = null,
                        Path = System.IO.Path.GetDirectoryName(file),
                        Status = null,
                        StatusDetail = null
                    };

                    // kiểm tra có chọn lại file cũ không
                    bool flag = true;
                    foreach (var item in fileList)
                    {
                        if (item.Name == fileName.Name && item.Path == fileName.Path)
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag == true)
                        fileList.Add(fileName);
                }
                filesListView.ItemsSource = fileList;
            }
        }

        public void Selected_Folder()
        {
            var screen = new CommonOpenFileDialog();
            screen.IsFolderPicker = true;

            if (screen.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var path = screen.FileName;
                var folders = Directory.GetDirectories(path);

                foreach (var folder in folders)
                {
                    var folderName = new Folder()
                    {
                        Name = System.IO.Path.GetFileName(folder),
                        Newname = null,
                        Path = System.IO.Path.GetDirectoryName(folder),
                        Status = null,
                        StatusDetail = null
                    };

                    // kiểm tra có chọn lại folder cũ không
                    bool flag = true;
                    foreach (var item in folderList)
                    {
                        if (item.Name == folderName.Name && item.Path == folderName.Path)
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag == true)
                        folderList.Add(folderName);
                }

                foldersListView.ItemsSource = folderList;
            }
        }

        //public void Selected_Folder()
        //{
        //    RadOpenFolderDialog openFolderDialog = new RadOpenFolderDialog();
        //    openFolderDialog.Owner = this;
        //    openFolderDialog.ShowDialog();
        //    if (openFolderDialog.DialogResult == true)
        //    {
        //        string folderName = openFolderDialog.FileName;
        //    }

        //    var screen = new CommonOpenFileDialog();
        //    screen.IsFolderPicker = true;

        //    if (screen.ShowDialog() == CommonFileDialogResult.Ok)
        //    {
        //        var path = screen.FileName;
        //        var folders = Directory.GetDirectories(path);

        //        foreach (var folder in folders)
        //        {
        //            var folderName = new Folder()
        //            {
        //                Name = System.IO.Path.GetFileName(folder),
        //                Newname = null,
        //                Path = System.IO.Path.GetDirectoryName(folder),
        //                Status = null,
        //                StatusDetail = null
        //            };

        //            // kiểm tra có chọn lại folder cũ không
        //            bool flag = true;
        //            foreach (var item in folderList)
        //            {
        //                if (item.Name == folderName.Name && item.Path == folderName.Path)
        //                {
        //                    flag = false;
        //                    break;
        //                }
        //            }

        //            if (flag == true)
        //                folderList.Add(folderName);
        //        }

        //        foldersListView.ItemsSource = folderList;
        //    }
        //}

        public void Open_OperationControl(object Item)
        {
            OperationManager operationMain = Item as OperationManager;
            UserControl.Children.Remove(operationMain.control);
            UserControl.Children.Add(operationMain.control);

            if (operationSelected != null)
            {
                if (operationSelected.Name != operationMain.Name)
                {
                    operationSelected.control.Visibility = Visibility.Hidden;
                    operationSelected.count = 0;
                }
            }

            operationSelected = operationMain;
            operationMain.ShowControl();
        }

        public void Option_After_Renamefile()
        {
            int flag1 = 0;
            int flag2 = 0;
            int flagoption = cbb_Duplication.SelectedIndex; 
            
            ComboBoxItem typeOption = (ComboBoxItem)cbb_Duplication.SelectedItem;

            while (flag1 == 0)
            {
                int i = 0;

                // Lựa chọn giữ lại tên cũ
                if (flagoption == 0)
                {
                    for (i = 0; i < fileList.Count - 1; i++)
                    {
                        flag2 = 0;
                        for (int j = i + 1; j < fileList.Count; j++)
                        {
                            // Kiểm tra FILE ĐANG XÉT có cùng đường dẫn + cùng tên mới với một FILE KHÁC
                            if (fileList[i].Path == fileList[j].Path && (fileList[i].Newname == fileList[j].Newname))
                            {
                                //flag2 = 1;

                                // Kiểm tra tên mới của FILE KHÁC đó trùng với tên cũ của nó
                                if (fileList[j].Newname != fileList[j].Name)
                                {
                                    // FILE KHÁC đó đã Rename thành công -> FILE ĐANG XÉT Rename thất bại
                                    if (fileList[j].Status == "Success")
                                    {
                                        fileList[j].Status = "Fail";
                                        fileList[j].StatusDetail = "Duplicate name: " + fileList[j].Newname + "\n";
                                    }
                                    else // FILE KHÁC đó Rename thất bại -> FILE ĐANG XÉT được quyền Rename, ghi nhận status
                                    {
                                        fileList[j].StatusDetail += "Duplicate name: " + fileList[j].Newname + "\n";
                                    }
                                    fileList[j].Newname = fileList[j].Name;
                                }
                                else
                                {
                                    flag2 = 1;
                                }
                            }
                        }

                        // Kiểm tra FILE ĐANG XÉT có tên mới trùng với tên cũ
                        if (flag2 == 1 && fileList[i].Newname != fileList[i].Name)
                        {
                            // cập nhật status
                            if (fileList[i].Status == "Success")
                            {
                                fileList[i].Status = "Fail";
                                fileList[i].StatusDetail = "Duplicate name: " + fileList[i].Newname + "\n";
                            }
                            else
                            {
                                fileList[i].StatusDetail += "Duplicate name: " + fileList[i].Newname + "\n";
                            }
                            // giữ lại tên cũ
                            fileList[i].Newname = fileList[i].Name;
                        }

                    }
                }

                // Thêm hậu tố
                if (flagoption == 1)
                {
                    int suffix = 1;
                    for (i = 0; i < fileList.Count - 1; i++)
                    {
                        flag1 = 0;
                        for (int j = i + 1; j < fileList.Count; j++)
                        {
                            if (fileList[i].Path == fileList[j].Path && fileList[i].Newname == fileList[j].Newname)
                            {
                                flag1 = 1;
                                if (fileList[j].Newname != fileList[j].Name)
                                {
                                    if (fileList[j].Path.Length + 1 + fileList[j].Newname.Length + suffix.ToString().Length >= 260)
                                    {
                                        fileList[j].Newname = fileList[j].Name;
                                        fileList[j].StatusDetail += "The fully qualified file name must be less than 260 characters\n";
                                    }
                                    else
                                    {
                                        var newName = fileList[j].Newname.Replace(fileList[j].Extension, "");
                                        fileList[j].Newname = newName + suffix.ToString() + fileList[j].Extension;
                                        suffix++;
                                    }
                                }
                            }
                        }
                        if (flag1 == 1 && fileList[i].Newname != fileList[i].Name)
                        {
                            if (fileList[i].Path.Length + 1 + fileList[i].Newname.Length + suffix.ToString().Length >= 260)
                            {
                                fileList[i].Newname = fileList[i].Name;
                                fileList[i].StatusDetail += "The fully qualified file name must be less than 260 characters\n";
                            }
                            else
                            {
                                var newName = fileList[i].Newname.Replace(fileList[i].Extension, "");
                                fileList[i].Newname = newName + suffix.ToString() + fileList[i].Extension;
                                suffix++;
                            }
                        }
                    }
                }

                // Thêm tiền tố
                if (flagoption == 2)
                {

                }

                // Kiểm tra còn trùng lắp tên nữa hay không để tiếp tục vòng lặp
                flag1 = 1;
                for (i = 0; i < fileList.Count - 1; i++)
                {
                    for (int j = i + 1; j < fileList.Count; j++)
                    {
                        if (fileList[i].Path == fileList[j].Path)
                        {
                            if (fileList[i].Newname == fileList[j].Newname)
                            {
                                flag1 = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void Option_After_RenameFolder()
        {
            int flag1 = 0;
            int flag2 = 0;
            int flagoption = cbb_Duplication.SelectedIndex;
            ComboBoxItem typeItem = (ComboBoxItem)cbb_Duplication.SelectedItem;
            
            while (flag1 == 0)
            {
                int i = 0;
                // giữ lại tên cũ
                if (flagoption == 0)
                {
                    for (i = 0; i < folderList.Count - 1; i++)
                    {
                        flag2 = 0;
                        for (int j = i + 1; j < folderList.Count; j++)
                        {
                            if (folderList[i].Path == folderList[j].Path && (folderList[i].Newname == folderList[j].Newname))
                            {
                                flag2 = 1;
                                if (folderList[j].Newname != folderList[j].Name)
                                {
                                    if (folderList[j].Status == "Success")
                                    {
                                        folderList[j].Status = "Fail";
                                        folderList[j].StatusDetail = "duplicate name:" + folderList[j].Newname + "\n";
                                    }
                                    else
                                    {
                                        folderList[j].StatusDetail += "duplicate name:" + folderList[j].Newname + "\n";
                                    }
                                    folderList[j].Newname = folderList[j].Name;
                                }
                            }
                        }
                        if (flag2 == 1 && folderList[i].Newname != folderList[i].Name)
                        {
                            if (folderList[i].Status == "Success")
                            {
                                folderList[i].Status = "Fail";
                                folderList[i].StatusDetail = "duplicate name:" + folderList[i].Newname + "\n";
                            }
                            else
                            {
                                folderList[i].StatusDetail += "duplicate name:" + folderList[i].Newname + "\n";
                            }
                            folderList[i].Newname = folderList[i].Name;
                        }

                    }
                }

                // thêm hậu tố
                if (flagoption == 1)
                {
                    int suffix = 1;
                    for (i = 0; i < folderList.Count - 1; i++)
                    {
                        flag2 = 0;
                        for (int j = i + 1; j < folderList.Count; j++)
                        {
                            if (folderList[i].Path == folderList[j].Path && folderList[i].Newname == folderList[j].Newname)
                            {
                                flag2 = 1;
                                if (folderList[j].Newname != folderList[j].Name)
                                {
                                    if (folderList[j].Path.Length + 1 + folderList[j].Newname.Length + suffix.ToString().Length >= 248)
                                    {
                                        folderList[j].Newname = folderList[j].Name;
                                        folderList[j].StatusDetail += "The directory name must be less than 248 characters\n";
                                    }
                                    else
                                    {
                                        folderList[j].Newname += suffix.ToString();
                                        suffix++;
                                    }
                                }
                            }
                        }
                        if (flag2 == 1 && folderList[i].Newname != folderList[i].Name)
                        {
                            if (folderList[i].Path.Length + 1 + folderList[i].Newname.Length + suffix.ToString().Length >= 248)
                            {
                                folderList[i].Newname = folderList[i].Name;
                                folderList[i].StatusDetail += "The directory name must be less than 248 characters\n";
                            }
                            folderList[i].Newname += suffix.ToString();
                            suffix++;
                        }
                    }
                }

                // Thêm tiền tố
                if (flagoption == 2)
                {

                }

                // kiểm tra có còn trùng hay không để tiếp tục vòng lặp
                flag1 = 1;
                for (i = 0; i < folderList.Count - 1; i++)
                {
                    for (int j = i + 1; j < folderList.Count; j++)
                    {
                        if (folderList[i].Path == folderList[j].Path)
                        {
                            if (folderList[i].Newname == folderList[j].Newname)
                            {
                                flag1 = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

       
    }
}
