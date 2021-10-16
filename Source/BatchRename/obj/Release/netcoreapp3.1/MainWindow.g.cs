﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7759D927F8B944587F09BA70F95675F87FD4CBAB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BatchRename;
using Fluent;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace BatchRename {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : Fluent.RibbonWindow, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 155 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Fluent.ComboBox cbb_Duplication;
        
        #line default
        #line hidden
        
        
        #line 216 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel MyWindow;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListOperation;
        
        #line default
        #line hidden
        
        
        #line 250 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid UserControl;
        
        #line default
        #line hidden
        
        
        #line 254 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView OperationList;
        
        #line default
        #line hidden
        
        
        #line 289 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl Tab;
        
        #line default
        #line hidden
        
        
        #line 320 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabFile;
        
        #line default
        #line hidden
        
        
        #line 322 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView filesListView;
        
        #line default
        #line hidden
        
        
        #line 352 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabFolder;
        
        #line default
        #line hidden
        
        
        #line 355 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView foldersListView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BatchRename;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 15 "..\..\..\MainWindow.xaml"
            ((BatchRename.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\MainWindow.xaml"
            ((BatchRename.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 113 "..\..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Refresh_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 125 "..\..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_OpenRuleFile_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 135 "..\..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Save);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cbb_Duplication = ((Fluent.ComboBox)(target));
            return;
            case 6:
            
            #line 174 "..\..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Add);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 184 "..\..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Clear);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 194 "..\..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Preview_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.MyWindow = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 10:
            this.ListOperation = ((System.Windows.Controls.ListView)(target));
            return;
            case 12:
            this.UserControl = ((System.Windows.Controls.Grid)(target));
            return;
            case 13:
            this.OperationList = ((System.Windows.Controls.ListView)(target));
            
            #line 254 "..\..\..\MainWindow.xaml"
            this.OperationList.PreviewMouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OperationList_SelectedItem_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 268 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteOperation_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 269 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteAllOperation_NoChecked_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 270 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteAllOperation_Checked_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 271 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteAllOperation_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.Tab = ((System.Windows.Controls.TabControl)(target));
            return;
            case 20:
            this.tabFile = ((System.Windows.Controls.TabItem)(target));
            return;
            case 21:
            this.filesListView = ((System.Windows.Controls.ListView)(target));
            
            #line 322 "..\..\..\MainWindow.xaml"
            this.filesListView.PreviewMouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.filesListView_SelectedItem_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 333 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.FileStatusDetail_Click);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 334 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.FileShowPath_Click);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 335 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteFile_Click);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 336 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteAllFile_GeneralPath_Click);
            
            #line default
            #line hidden
            return;
            case 26:
            
            #line 337 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteAllFile_GeneralExtensionInGeneralPath_Click);
            
            #line default
            #line hidden
            return;
            case 27:
            this.tabFolder = ((System.Windows.Controls.TabItem)(target));
            return;
            case 28:
            this.foldersListView = ((System.Windows.Controls.ListView)(target));
            
            #line 355 "..\..\..\MainWindow.xaml"
            this.foldersListView.PreviewMouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.folderListView_SelectedItem_Click);
            
            #line default
            #line hidden
            return;
            case 29:
            
            #line 366 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.FolderStatusDetail_Click);
            
            #line default
            #line hidden
            return;
            case 30:
            
            #line 367 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.FolderShowPath_Click);
            
            #line default
            #line hidden
            return;
            case 31:
            
            #line 368 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteFolder_Click);
            
            #line default
            #line hidden
            return;
            case 32:
            
            #line 369 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteAllFolder_GeneralPath_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 11:
            
            #line 239 "..\..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Operation_Click);
            
            #line default
            #line hidden
            break;
            case 18:
            
            #line 278 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.OperationItem_Unchecked);
            
            #line default
            #line hidden
            
            #line 278 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.OperationItem_Checked);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

