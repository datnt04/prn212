   M S B A M L   `   `   `  ����K  GNguyenTienDatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NguyenTienDatWPFNguyenTienDatWPF  5   	   "    NguyenTienDatWPF.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NguyenTienDatWPF     5   	     � Title$  LoginWindow��5   	   $	��450��6   $	��800��6*   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Email��6!   $��5q�6.   �� 5   
   -   5        $��1��5      $��5q�6[   ��6   �� *Email+ �� UpdateSourceTrigger$ PropertyChanged=�6f   �� 5   
   $��2��6   $��Mật Khẩu��6!   $��5q�61   G� 5   
   -   5         G�Name$ PasswordBox��5      $��3��6+   $��5q�68   �� 5   
   $��4��6   
���  ��$��5q�6P   ��6!   �� *ErrorMessage+6P   �� 5   
   $��5��6   $��Đăng Nhập��6   $��5q�6S   $��Center=�6^   ��62   �� *LoginCommand+6^   5      5      