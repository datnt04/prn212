   M S B A M L   `   `   `  ����K  GNguyenTienDatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NguyenTienDatWPFNguyenTienDatWPF  5   	   %    NguyenTienDatWPF.CustomerDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NguyenTienDatWPF     5   	     � Title$  CustomerDialog��5   	   $	��450��6    $	��800��6-   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��	Họ Tên��6   $��5q�6"   �� 5   
   $��1��6   $��5q�6o   ��6   �� *Customer.CustomerFullName+ �� UpdateSourceTrigger$ PropertyChanged=�6o   �� 5   
   $��2��6   $��Email��6!   $��5q�6.   �� 5   
   $��3��6   $��5q�6k   ��6   �� *Customer.EmailAddress+$ PropertyChanged=�6k   �� 5   
   $��4��6   $��Điện Thoại��6!   $��5q�63   �� 5   
   $��5��6   $��5q�6h   ��6   �� *Customer.Telephone+$ PropertyChanged=�6h   �� 5   
   $��6��6   $��
Ngày Sinh��6!   $��5q�62   (  "System.Windows.Controls.DatePicker  5   
   $��7��6   $��5q�6U      SelectedDate 6"   �� *Customer.CustomerBirthday+6U   �� 5   
   $��8��6   $��Mật Khẩu��6!   $��5q�61   G� 5   
   -   5         G�Name$ PasswordBox��5      $��9��6+   $��5q�68   �� 5   
   $��10��6    �� Orientation$ 
Horizontal=�6#   $��Center=�6<   $��5q�6Y   .+�5      �� $
��Lưu��6   $��5q�6C   ��6#   �� *SaveCommand+6C   �� 5       $��Hủy��6   $��5q�6E   ��6#   �� *CancelCommand+6E   5!      5"      5#      