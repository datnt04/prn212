   M S B A M L   `   `   `  ����K  GNguyenTienDatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:NguyenTienDatWPF.ViewsNguyenTienDatWPF.Views  5   	   I)clr-namespace:NguyenTienDatWPF.ViewModelsNguyenTienDatWPF.ViewModels  5   	   0    *NguyenTienDatWPF.Views.RoomSelectionDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:NguyenTienDatWPF.Views     5   	   8vm)clr-namespace:NguyenTienDatWPF.ViewModels     5   	     � Title$  Chọn phòng��5	   	   $	��400��6   $	��500��6)    � WindowStartupLocation$ CenterOwner=�5
   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   .+�5      �� $��Chọn ngày��6   $
��Bold"�6)   $��0,0,0,5q�6;   � 5       � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $��* �6'   �� 5      $
��Auto �6'   �� 5      $��* �6'   .+�5      �� $��0��6   $��Từ ngày:��6,   $��Center=�6<   $��0,0,5,0q�6W   (  "System.Windows.Controls.DatePicker  5      $��1��6   $��0,0,10,0q�6P      SelectedDate 6-   �� *	StartDate+6P   �� 5       $��2��6   $��Đến ngày:��6,   $��Center=�6=   $��0,0,5,0q�6X     5!      $��3��6    6-   �� *	EndDate+5"      5#      �� 5%   
   $��1��6   $��0,10,0,5q�6"   .+�5&      �� $��Danh sách phòng trống��6   $
��Bold"�65   $��0,0,0,5q�6G   �� 5'      $��0,0,0,5q�6W   ��6   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�.��6h   ��5(      �� 5)       �� 
TargetType" ��6    �� Triggers 5*      P� 5+       P� Property � ��	 P� Value$	  ��66   . �5,   "   �� 
 �� Property
 �@�Tag �� Value$ Tìm kiếm...��68   5-      5/      .��50   !   51      52      �� 54   
   $��2��6   ��6    �� *AvailableRooms+ �� SelectedItem 6G   �� *SelectedRoom+ �� View 55      �� 56      .P�57      �� $��ID��6%    �� Width$ 50��6Y    �� DisplayMemberBinding 61   �� *RoomID+6Y   �� 58      $��Số phòng��6%   $ 80��6c    67   �� *
RoomNumber+6c   �� 59      $��Loại phòng��6%   $	 120��6p    69   �� *RoomType.RoomTypeName+6p   �� 5:      $��Sức chứa��6%   $ 70��6h    67   �� *RoomMaxCapacity+6h   �� 5;      $��
Giá/ngày��6%   $	 120��6�    67   �� *RoomPricePerDay+ �� StringFormat$ 
{0:N0} VND��6�   5<      5>      �� 5@   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,10,0,0q�6W   .+�5A      �� -   5        $��Chọn��5A      $��80��6$   $��0,0,5,0q�6/   6@   �� 5B      -   5        $��Hủy��5B      $��80��6#   $��5,0,0,0q�6.   6?   5C      5D      5E      