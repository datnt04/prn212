   M S B A M L   `   `   `  ����K  GNguyenTienDatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:NguyenTienDatWPF.ViewsNguyenTienDatWPF.Views  5   	   I)clr-namespace:NguyenTienDatWPF.ViewModelsNguyenTienDatWPF.ViewModels  5   	   (    "NguyenTienDatWPF.Views.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:NguyenTienDatWPF.Views     5   	   8vm)clr-namespace:NguyenTienDatWPF.ViewModels     5   	     � Title$#  Đăng nhập - FU Mini Hotel��5	   	   $	��350��6+   $	��400��68    � WindowStartupLocation$ CenterScreen=�5
   	    � 	Resources 5      4   .NguyenTienDatWPF.ViewModels.LoginViewViewModel   LoginViewModel��%   &	          5   
   6    5      .��5      ��  �� Padding$ 20q�6   ���#F5F5F5._�5   
   �  � DataContext# [  6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��0��6   $��FU Mini Hotel Management��6%   $��20(�5      $
��Bold"�6&   $��Center=�5      $��0,0,0,20q�5      �� 5      $��1��6   $
��0,10q�6&   .+�5       �� $��Email:��6   $��0,0,0,5q�6*   �� 5!      $��5q�5"      $��14(�6&   ��5!      �� *Email+ �� UpdateSourceTrigger$ PropertyChanged=�5"   &   5#      �� 5%      $��2��6   $
��0,10q�6&   .+�5&      �� $��Mật khẩu:��6   $��0,0,0,5q�6-   G� 5'      -   5         G�Name$ PasswordBox��5'      $��5q�63   $��14(�6?   5(      �� 5*      $��3��6   
���  ��$
��Wrap=�5,      $
��0,10q�5-      ��5*   %   �� *ErrorMessage+5-      �� 5/      $��4��6    �� Orientation$ 
Horizontal=�6&   $��Center=�50      $
��0,20q�51      .+�52      �� -   5        $��Đăng nhập��52      $	��100��6-   $��30��69   $��0,0,10,0q�53      6+   �� 54      -   5        $��Hủy��54      $	��100��6'   $��30��63   $��10,0,0,0q�55      6+   56      57      58      59      