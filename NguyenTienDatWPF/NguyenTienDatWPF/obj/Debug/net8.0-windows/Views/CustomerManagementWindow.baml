   M S B A M L   `   `   `  ����K  GNguyenTienDatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:NguyenTienDatWPF.ViewsNguyenTienDatWPF.Views  5   	   I)clr-namespace:NguyenTienDatWPF.ViewModelsNguyenTienDatWPF.ViewModels  5   	   5    /NguyenTienDatWPF.Views.CustomerManagementWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:NguyenTienDatWPF.Views     5   	   8vm)clr-namespace:NguyenTienDatWPF.ViewModels     5   	     � Title$  Quản lý Khách hàng��5	   	   $	��450��6$   $	��800��61    � 	Resources 5
      A   ;NguyenTienDatWPF.ViewModels.CustomerManagementViewViewModel   	ViewModel��%   &	          5   
   6-   5      .��5      �  � DataContext# [  6   $��10q�64    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0,0,0,10q�6;   .+�5      �� $��Tìm kiếm:��6   $��Center=�6)   $��0,0,5,0q�6D   �� 5      $	��200��6   $��0,0,10,0q�6c   ��6"   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�6c   �� 5      -   5        $��Thêm khách hàng mới��5      $	��150��63   $��10,0,0,0q�6?   6Q   5      �� 5   
   $��1��6   ��6    �� *	Customers+ �� SelectedItem 6B   �� *SelectedCustomer+ �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$ 50��6]   	 �� DisplayMemberBinding	 61   �� *
CustomerID+6]   �� 5      $
��Tên��6%   $	 150��6d   	 62   �� *CustomerFullName+6d   �� 5      $��Email��6%   $	 200��6b   	 64   �� *EmailAddress+6b   �� 5       $��Điện thoại��6%   $	 120��6d   	 69   �� *	Telephone+6d   �� 5!      $��	Thao tác��6%   $	 180��67   
 �� CellTemplate
 5"      �� 5#      .R�5$   "   �� $ 
Horizontal=�6-   .+�5%   &   �� -   5        $��Sửa��5%   -   $��60��6;   $��0,0,5,0q�6F   6W   �� 5&   &   -   5        $
��Xóa��5&   -   $��60��6;   $��5,0,0,0q�6F   6W   5'   #   5(      5*      5+      5-      �� 5/   
   -   5        $��2��5/      $��Đóng��6   $��80��6-   $��Right=�68   $��0,10,0,0q�6T   6f   50      51      