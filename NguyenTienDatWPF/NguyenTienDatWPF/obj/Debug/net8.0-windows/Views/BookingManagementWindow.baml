   M S B A M L   `   `   `  ����K  GNguyenTienDatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:NguyenTienDatWPF.ViewsNguyenTienDatWPF.Views  5   	   I)clr-namespace:NguyenTienDatWPF.ViewModelsNguyenTienDatWPF.ViewModels  5   	   4    .NguyenTienDatWPF.Views.BookingManagementWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:NguyenTienDatWPF.Views     5   	   8vm)clr-namespace:NguyenTienDatWPF.ViewModels     5   	     � Title$  Quản lý Đặt phòng��5	   	   $	��450��6#   $	��800��60   .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0,0,0,10q�6;   .+�5      �� $��Tìm kiếm:��6   $��Center=�6)   $��0,0,5,0q�6D   �� 5      $	��200��6   $��0,0,10,0q�6c   ��6"   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�6c   �� 5      $��Thêm đặt phòng mới��6   $	��150��62   $��10,0,0,0q�6>   5      �� 5   
   $��1��6   ��6    �� *
Bookings+ �� SelectedItem 6A   �� *SelectedBooking+ �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$ 50��6g    �� DisplayMemberBinding 61   �� *BookingReservationID+6g   �� 5      $��Ngày đặt��6%   $	 100��6}    67   �� *BookingDate+ �� StringFormat$ 
dd/MM/yyyy��6}   �� 5      $��Tổng giá��6%   $	 120��6~    67   �� *
TotalPrice+$ 
{0:N0} VND��6~   �� 5      $��Khách hàng ID��6%   $	 100��6h    6<   �� *
CustomerID+6h   �� 5      $��Trạng thái��6%   $	 100��69   	 �� CellTemplate	 5      �� 5       .R�5!   "   �� ��5"   &   `� 5#   *   $	 {0}��67   .1�5$   .   �� 
 �� Path$
 BookingStatus�66   5%   +   5'   #   5(      5*      �� 5+      $��	Thao tác��6%   $	 180��67   	 5,      �� 5-      .R�5.   "   �� $ 
Horizontal=�6-   .+�5/   &   �� $��Sửa��6-   $��60��6;   $��0,0,5,0q�6F   �� 50   &   $
��Xóa��6-   $��60��6;   $��5,0,0,0q�6F   51   #   52      54      55      57      �� 59   
   -   5        $��2��59      $��Đóng��6   $��Right=�6-   $��80��6I   $��0,10,0,0q�6T   6f   5:      5;      