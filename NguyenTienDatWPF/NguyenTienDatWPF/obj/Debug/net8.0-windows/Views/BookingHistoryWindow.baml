   M S B A M L   `   `   `  ����K  GNguyenTienDatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:NguyenTienDatWPF.ViewsNguyenTienDatWPF.Views  5   	   I)clr-namespace:NguyenTienDatWPF.ViewModelsNguyenTienDatWPF.ViewModels  5   	   1    +NguyenTienDatWPF.Views.BookingHistoryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:NguyenTienDatWPF.Views     5   	   8vm)clr-namespace:NguyenTienDatWPF.ViewModels     5   	     � Title$  Lịch sử Đặt phòng��5	   	   $	��400��6#   $	��600��60   .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $+��%Lịch sử đặt phòng của bạn��6!   $��16(�6B   $
��Bold"�6P   $��0,0,0,10q�6b   �� 5   
   $��1��6   $	��0,5q�6A   ��6    �� *
Bookings+ �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$ 50��6g    �� DisplayMemberBinding 61   �� *BookingReservationID+6g   �� 5      $��Ngày đặt��6%   $	 100��6}    67   �� *BookingDate+ �� StringFormat$ 
dd/MM/yyyy��6}   �� 5      $��Tổng giá��6%   $	 120��6~    67   �� *
TotalPrice+$ 
{0:N0} VND��6~   �� 5      $��Trạng thái��6%   $	 100��69    �� CellTemplate 5      �� 5      .R�5   "   �� ��5   &   `� 5   *   $	 {0}��67   .1�5   .   ��  �� Path$ BookingStatus�66   5    +   5"   #   5#      5%      �� 5&      $��
Chi tiết��6%   $	 100��67    5'      �� 5(      .R�5)   "   �� $��Xem chi tiết��6)   ��6@   �� * DataContext.ViewDetailsCommand+ �� RelativeSource �� 	 �� AncestorType
	 Window��6�   �� 5*      5,      5-      5/      �� 51   
   -   5        $��2��51      $��Đóng��6   $��Right=�6-   $��80��6I   $��0,10,0,0q�6T   6f   52      53      