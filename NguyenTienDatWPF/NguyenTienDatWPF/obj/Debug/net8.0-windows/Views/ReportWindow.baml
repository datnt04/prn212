   M S B A M L   `   `   `  ����K  GNguyenTienDatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:NguyenTienDatWPF.ViewsNguyenTienDatWPF.Views  5   	   I)clr-namespace:NguyenTienDatWPF.ViewModelsNguyenTienDatWPF.ViewModels  5   	   )    #NguyenTienDatWPF.Views.ReportWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:NguyenTienDatWPF.Views     5   	   8vm)clr-namespace:NguyenTienDatWPF.ViewModels     5   	     � Title$  Báo cáo - FU Mini Hotel��5	   	   $	��450��6)   $	��800��66    � 	Resources 5
      5   /NguyenTienDatWPF.ViewModels.ReportViewViewModel   	ViewModel��%   &	          5   
   6!   5      .��5      �  � DataContext# [  6   $��10q�64    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Báo cáo doanh thu��6!   $��20(�6:   $
��Bold"�6H   $��0,0,0,10q�6Z   � 5   
   $��1��6   $��0,0,0,10q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5       �� $��0��6   $��Từ ngày:��6(   $��Center=�68   (  "System.Windows.Controls.DatePicker  5!      $��1��6   $	��5,0q�6L      SelectedDate 6)   �� *	StartDate+6L   �� 5#      $��2��6   $��Đến ngày:��6(   $��Center=�69   $��10,0,0,0q�6T     5$      $��3��6   $	��5,0q�6J    6)   �� *	EndDate+6J   �� 5&      $��4��6   $��Tạo báo cáo��6%   $	��100��6;   $��10,0,0,0q�6G   5'      � 5)   
   $��2��6    5*      �� 5+      $��* �6#   �� 5,      $	��250 �6#   .+�5/      �� $��0��6   $��0,0,10,0q�6H   ��6'   �� *
Bookings+ �� View 50      �� 51      .P�52      �� $��ID��6)    �� Width$ 50��6k    �� DisplayMemberBinding 65   �� *BookingReservationID+6k   �� 53      $��Ngày đặt��6)   $	 100��6�    6;   �� *BookingDate+	 �� StringFormat$	 
dd/MM/yyyy��6�   �� 54      $��Khách hàng ID��6)   $	 100��6l    6@   �� *
CustomerID+6l   �� 55      $��Tổng giá��6)   $	 120��6�    6;   �� *
TotalPrice+$	 
{0:N0} VND��6�   �� 56      $��Trạng thái��6)   $ 80��6l    6=   �� *BookingStatus+6l   57      59      �� 5;      $��1��6   ���#ddd$��1q�68   
 �� Padding$
 10q�6L   ���#f9f9f9._�5<      �� .+�5=      �� $��Tổng kết��6    $
��Bold"�60   $��16(�6B   $��0,0,0,10q�6P   � 5?      $	��0,5q�6    5@      �� 5A      $
��Auto �6/   �� 5B      $��* �6/   .+�5D      �� $��0��6$   $ ��Tổng số đặt phòng:��64   �� 5E      $��1��6$   $��Right=�6S   $
��Bold"�6o   ��64   �� *TotalBookings+6o   5F      � 5H      $	��0,5q�6    5I      �� 5J      $
��Auto �6/   �� 5K      $��* �6/   .+�5M      �� $��0��6$   $��Tổng doanh thu:��64   �� 5N      $��1��6$   $��Right=�6m   $
��Bold"�6�   ��64   �� *TotalRevenue+$	 
{0:N0} VND��6�   5O      5P      5Q      5R      �� 5T   
   -   5        $��3��5T      $��Đóng��6   $��80��6-   $��Right=�68   $��0,10,0,0q�6T   6f   5U      5V      