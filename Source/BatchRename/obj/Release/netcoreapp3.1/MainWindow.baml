   M S B A M L   `   `   `  ���� F  BBatchRename, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BatchRenameBatchRename  M IFluent, Version=9.0.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent     BatchRename.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:BatchRename     7Fluent$clr-namespace:Fluent;assembly=Fluent     -     � WindowStartupLocation$  CenterScreen=� � Title$ B A T C H  R E N A M E��$	��620��$	��950�� � Icon$ /Images/IconWindow.ico�� � 
ResizeMode$ NoResize=� � 	Resources -  'BatchRename.RelativeToAbsoluteConverter   absoluteConverter��%   &	          .���� .+�  Fluent.Ribbon     Menu   Fluent.Backstage    Fluent.RibbonControl   Header$ 	Developer��   Content.    Fluent.BackstageTabControl  .@�  Fluent.BackstageTabItem     Header$ Student Information��$��50��.��� 	 � RowDefinitions	 �� $��50 ��� $��50 ��� $��* �.+�� $��0��
 � ColumnDefinitions
 �� $	��100 ��� $��* �.+��� $��0��$��MSSV:��$��25(�$
��Bold"�$��5q��� $��1��$��18120553��$��25(�$
��Bold"�
���  ��$��5q�� $��1��
 �� $	��100 ��� $��* �.+��� $��0��$��
Họ tên:��$��25(�$
��Bold"�$��5q��� $��1��$��Nguyễn Lê Ngọc Tần��$��25(�$
��Bold"�
���  ��$��5q�� $��2��
 �� $	��100 ��� $��* �.+��� $��0��$��Email sinh viên:��$��25(�$
��Bold"�$��5q��� $��1��$#��18120553@student.hcmus.edu.vn��$��25(�$
��Bold"�
���  ��$��5q�  $ Subject��.���� $��Lập trình Windows��$��25(�$
��Bold"�
���  ��$��5q�  $ 
How to use��.���� $��Link video demo��$��25(�$
��Bold"�
���  ��$��5q�   Tabs.   Fluent.RibbonTabItem     Header$
 Home��   Groups.   Fluent.RibbonGroupBox  $��	New start��.@�	  Fluent.Button	  -    	  Header$ Refresh��$��70��
���**��$
��Bold"�
������� 	  	LargeIcon �� $��/Images/Refresh.png�� �� BitmapScalingMode$ HighQuality=�  $��Rules��.@�	  -   $ 	Open rule��$��70��
���**��$
��Bold"� �� $��/Images/OpenFile.png��$ HighQuality=�	  -   $ 	Save rule��$��70��
���**��$
��Bold"� �� $��/Images/SaveFile.png��$ HighQuality=�  $�� ��.@�
  Fluent.ComboBox
   
  Header$ Preset��
����=H�$
��Bold"�$	��230��$��	0 10 0 10q�
�����_�$��3q�$��25��.@��� $��	My Rename�� �� 
IsSelected$
 true���� $��Hello���� $��Actions��
  -    
 Name$ cbb_Duplication��$ Duplication��
����=H�$
��Bold"�$	��230��$��0 5 0 0q�
�����_�$��3q�$��25��.@��� $��Keep the old name��$
 True���� $��
Add suffix���� $��
Add prefix��  $��Transactions��.@�	  -   $	 Add��$��70��
���**��$
��Bold"� �� $��/Images/Open.png��$ HighQuality=�	  -   $ Clear��$��70��
���**��$
��Bold"� �� $��/Images/Clear.png��$ HighQuality=�	  -   $ Preview��$��70��
���**��$
��Bold"� �� $��/Images/Preview.png��$ HighQuality=�	  $ Start Batch��$��70��
���**��$
��Bold"� �� $��/Images/Start.png��$ HighQuality=�  $
 Help���� .+�]� -	   $��MyWindow��.+��� $	��350��
 �� Top$ 40��.+��� 
���   �$	��0.3q�$��72��._��� -
   $��ListOperation��$��Disabled=�  �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%l   '��       �� " �� P�  �@J�IsKeyboardFocusWithin$
 True��. ���  �@��
IsSelected$
 True������ .R�� ���� .R�	  -   $��67��$
��Bold"� �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=� �� $ HighQuality=����� *Image+ �� 	Converter# [  �� 
���   �$	��0.3q�._�� -    �Name$ UserControl��$	��160��$	��350���� $��21��
�������$
��Bold"� �� TextAlignment$ Center=�
��� ���List Of Rules Added�� -    ��Name$ OperationList��$	��220��$	 205�� ��%�   '��       �� " �� P�  �@J�IsKeyboardFocusWithin$
 True��. ���  �@��
IsSelected$
 True����  � ��$
 Bold"���  � ��
 ����  � ContextMenu  �� .@�m� -   $��Delete this rule��m� -   $&�� Delete all rules with no checked��m� -   $#��Delete all rules with checked��m� -   $��Delete all rules������ .R��� �� ! �� Orientation$! 
Horizontal=�.+��� -   " d� 	IsChecked" �� *Check+$ PropertyChanged=��� $��13 0 0 0q�$��18��$��14(����� *Description+�� $	��469��$	��589��# �� Left$	# 263��$ 40��.+��� -   $ ��Name$	$ Tab�� % �� 
TargetType& ��Name' �� Triggers( �� 
TargetName��%  '��       �� " ��.���  � �� �� "% ��.R��� $��1q�
����� �._�� $��TabPanel��.+��� $& ContentSite��$��Center=�$��Center=�$��Header��$
��10,2q�' P�  �@��
IsSelected$
 True��. ��� $( TabPanel�� � ��
 ������  � ��$
 Bold"���  � ��
 �����P�  �@��
IsSelected$ False��. ��� $( TabPanel�� � ��
 �����.@��� -   ) ��Name$) tabFile��$��Rename Files��$��30��$
��Bold"�.��]� $	��432��.+��� -   $ filesListView��$	��432�� ��%y   '��       �� " ��.���  � ��$ Center=���  � ��$
 Bold"���  � ��
 �   ���  � ��
 �����  �� .@�m� -   $��Status Detail��m� -   $��	Show Path��m� -   $��Delete this item��m� -   $%��Delete all item in general path��m� -   $<��6Delete all item have general extension in general path��* �� View* �� .P��� $��Filename��+ �� Width$	+ 150��, �� DisplayMemberBinding, �� *Name+�� $��New Filename��$	+ 150��, �� *	NewName+�� $
��Path��$	+ 150��, �� *Path+�� $��Status��$	+ 150��, �� *Error+�� -   $) 	tabFolder��$��Rename Folders��$��30��$
��Bold"�.��]� $	��422��.+��� -   $ foldersListView�� ��%y   '��       �� " ��.���  � ��$ Center=���  � ��$
 Bold"���  � ��
 �   ���  � ��
 �����  �� .@�m� -   $��Status Detail��m� -   $��	Show Path��m� -   $��Delete this item��m� -    $%��Delete all item in general path��* �� .P��� $��
Foldername��$	+ 150��, �� *Name+�� $��New Foldername��$	+ 150��, �� *	NewName+�� $
��Path��$	+ 150��, �� *Path+�� $��Error��$	+ 150��, �� *Error+