   M S B A M L   `   `   `  ����K  GNguyenTienDatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NguyenTienDatWPFNguyenTienDatWPF  5   	   I)clr-namespace:NguyenTienDatWPF.ConvertersNguyenTienDatWPF.Converters  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   !    NguyenTienDatWPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NguyenTienDatWPF     5   	   @
converters)clr-namespace:NguyenTienDatWPF.Converters     5   	   9system&clr-namespace:System;assembly=mscorlib     5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)    � 	Resources 5      /   )NguyenTienDatWPF.Converters.TypeConverter   TypeConverter   BooleanToVisibilityConverter��%:   &	        &	        5   
   6#   �� 5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��5q�6;   y�5      �� *	IsAdmin+ �� 	Converter# [ .+�5      �� $	��200��6Z   $��5q�6f   ��6   �� *SearchKeyword+ �� UpdateSourceTrigger$ PropertyChanged=�6f   �� 5      $��Tìm Phòng��6   $��5q�6P   ��6)   �� *SearchRoomsCommand+6P   �� 5      $��Tìm Khách Hàng��6   $��5q�6Y   ��6.   �� *SearchCustomersCommand+6Y   �� 5      $��Thêm Phòng��6   $��5q�6M   ��6*   �� *AddRoomCommand+6M   �� 5      $��Thêm Khách Hàng��6   $��5q�6V   ��6/   �� *AddCustomerCommand+6V   (  "System.Windows.Controls.DatePicker  5      $��5q�6<      SelectedDate 6   �� *	StartDate+6<     5      $��5q�6:    6   �� *	EndDate+6:   �� 5       $��Tạo Báo Cáo��6   $��5q�6U   ��6+   �� *GenerateReportCommand+6U   5!      �� 5$   
   $��0��6   $ 
Horizontal=�6"   $��5q�6;   y�5%      �� *
IsCustomer+# [ .+�5&      �� $��Center=�6h   $��5q�6�   ��6   �� *" CurrentCustomer.CustomerFullName+ �� StringFormat$ Xin chào, {0}��6�   �� 5'      $��Cập nhật thông tin��6   $��5q�6[   ��62   �� *UpdateProfileCommand+6[   �� 5(      $��Đặt Phòng��6   $��5q�6O   ��6)   �� *AddBookingCommand+6O   5)      �� 5+   
   $��1��6   $��5q�6"   .@�5-      �� $��Phòng��6   y�6%   �� *	IsAdmin+# [ .��5.      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��69   	   
IsReadOnly$
	 True��6U   ��6   �� *Rooms+
   Columns
 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ 	ID Phòng��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *RoomID+  51      $ Số Phòng��6-    6?   �� *
RoomNumber+  52      $ Mô Tả��6-    6<   �� *RoomDescription+  53      $ Sức Chứa��6-    6?   �� *RoomMaxCapacity+  54      $
 Giá��6-    6:   �� *RoomPricePerDate+4  .System.Windows.Controls.DataGridTemplateColumn  55      $ Hành Động��61      CellTemplate 56      �� 57   "   .R�58   &   �� $ 
Horizontal=�61   .+�59   *   �� $��Sửa��61   $��5q�6�   ��6?   �� *DataContext.UpdateRoomCommand+ �� RelativeSource ��  �� AncestorType DataGrid��6�   �� 6�   �� 5:   *   $
��Xóa��61   $��5q�6�   ��6?   �� *DataContext.DeleteRoomCommand+ ��  DataGrid��6�   �� 6�   5;   '   5<   #   5>      5@      5A      �� 5B      $��Khách Hàng��6   y�6*   �� *	IsAdmin+# [ .��5C        $ False��6=   $
	 True��6Y   ��6   �� *	Customers+
 5D        5E      $ ID Khách Hàng��6-    6D   �� *
CustomerID+  5F      $ 	Họ Tên��6-    6=   �� *CustomerFullName+  5G      $ Email��6-    6<   �� *EmailAddress+  5H      $ Điện Thoại��6-    6A   �� *	Telephone+  5I      $ Hành Động��61    5J      �� 5K   "   .R�5L   &   �� $ 
Horizontal=�61   .+�5M   *   �� $��Sửa��61   $��5q�6�   ��6?   �� *#!DataContext.UpdateCustomerCommand+ ��  DataGrid��6�   �� 6�   �� 5N   *   $
��Xóa��61   $��5q�6�   ��6?   �� *#!DataContext.DeleteCustomerCommand+ ��  DataGrid��6�   �� 6�   5O   '   5P   #   5R      5T      5U      �� 5V      $��Đặt Phòng��6   y�6)   �� *	IsAdmin+# [ .��5W        $ False��6<   $
	 True��6X   ��6   �� *
Bookings+
 5X        5Y      $ ID Đặt Phòng��6-    6C   �� *	BookingID+  5Z      $ ID Khách Hàng��6-    6D   �� *
CustomerID+  5[      $ 	ID Phòng��6-    6?   �� *RoomID+  5\      $ Ngày Bắt Đầu��6-    6C   �� *	StartDate+$ {0:dd/MM/yyyy}��  5]      $ Ngày Kết Thúc��6-    6D   �� *	EndDate+$ {0:dd/MM/yyyy}��  5^      $ Tổng Giá��6-    6?   �� *
TotalPrice+5`      5a      �� 5d      $��Thông Tin Đặt Phòng��6   y�63   �� *
IsCustomer+# [ .��5e        $ False��6<   $
	 True��6X   ��6   �� *
Bookings+
 5f        5g      $ ID Đặt Phòng��6-    6C   �� *	BookingID+  5h      $ Số Phòng��6-    6?   �� *Room.RoomNumber+  5i      $ Ngày Bắt Đầu��6-    6C   �� *	StartDate+$ {0:dd/MM/yyyy}��  5j      $ Ngày Kết Thúc��6-    6D   �� *	EndDate+$ {0:dd/MM/yyyy}��  5k      $ Tổng Giá��6-    6?   �� *
TotalPrice+5m      5n      5o      5p      5q      