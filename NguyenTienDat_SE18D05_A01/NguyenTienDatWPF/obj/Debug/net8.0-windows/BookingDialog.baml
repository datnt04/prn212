   M S B A M L   `   `   `  ����K  GNguyenTienDatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NguyenTienDatWPFNguyenTienDatWPF  5   	   $    NguyenTienDatWPF.BookingDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NguyenTienDatWPF     5   	     � Title$  BookingDialog��5   	   $	��450��6   $	��800��6,   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Phòng��6   $��5q�6!   �� 5   
   $��1��6    �� DisplayMemberPath$ 
RoomNumber��6d   $��5q�6�   ��6    �� *Rooms+ �� SelectedItem 6>   �� *Booking.Room+6�   �� 5   
   $��2��6   $��Ngày Bắt Đầu��6!   $��5q�65   (  "System.Windows.Controls.DatePicker  5   
   $��3��6   $��5q�6M      SelectedDate 6"   �� *Booking.StartDate+6M   �� 5   
   $��4��6   $��Ngày Kết Thúc��6!   $��5q�66     5   
   $��5��6   $��5q�6K    6"   �� *Booking.EndDate+6K   �� 5   
   $��6��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��5q�6X   .+�5      �� $
��Lưu��6   $��5q�6C   ��6#   �� *SaveCommand+6C   �� 5      $��Hủy��6   $��5q�6E   ��6#   �� *CancelCommand+6E   5      5      5      