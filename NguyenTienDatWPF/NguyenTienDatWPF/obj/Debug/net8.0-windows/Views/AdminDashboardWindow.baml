   M S B A M L   `   `   `  ����K  GNguyenTienDatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:NguyenTienDatWPF.ViewsNguyenTienDatWPF.Views  5   	   I)clr-namespace:NguyenTienDatWPF.ViewModelsNguyenTienDatWPF.ViewModels  5   	   1    +NguyenTienDatWPF.Views.AdminDashboardWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:NguyenTienDatWPF.Views     5   	   8vm)clr-namespace:NguyenTienDatWPF.ViewModels     5   	     � Title$   Quản lý - FU Mini Hotel��5	   	   $	��450��6)   $	��800��66    � 	Resources 5
      =   7NguyenTienDatWPF.ViewModels.AdminDashboardViewViewModel   	ViewModel��%   &	          5   
   6)   5      .��5      �  � DataContext# [  6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   ���#2c3e50$��50��6P   .+�5      �� $ ��FU Mini Hotel - Quản lý��6   
�������$��20(�6J   $��Center=�5      $
��20,0q�63   �� 5      
�������$��16(�6F   $��Center=�5      $
��20,0q�63   ��5      �� *	AdminName+5   3   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5!      �� $��0��6   ���#34495e.+�5"      �� -   5        $��Quản lý phòng��5"      $��40��61   $��10q�6=   ���#3498db
�������6q   �� 5#      -   5        $��Quản lý đặt phòng��5#      $��40��65   $��10q�6A   ���#3498db
�������6u   �� 5$      -   5        $��Quản lý khách hàng��5$      $��40��66   $��10q�6B   ���#3498db
�������6v   �� 5%      -   5        $��	Báo cáo��5%      $��40��6+   $��10q�67   ���#3498db
�������6k   �� 5&      -   5        $��Đăng xuất��5&      $��40��6-   $��10q�69   ���#e74c3c
�������6m   5'      �� 5)      $��1��6   $.��(Chọn chức năng từ menu bên trái��6(   $��Center=�5*      $��Center=�63   $��18(�5+      ���#7f8c8d6&   5,      5-      5.      