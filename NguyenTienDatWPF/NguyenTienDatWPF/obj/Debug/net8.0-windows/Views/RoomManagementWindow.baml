   M S B A M L   `   `   `  ����K  GNguyenTienDatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:NguyenTienDatWPF.ViewsNguyenTienDatWPF.Views  5   	   I)clr-namespace:NguyenTienDatWPF.ViewModelsNguyenTienDatWPF.ViewModels  5   	   1    +NguyenTienDatWPF.Views.RoomManagementWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:NguyenTienDatWPF.Views     5   	   8vm)clr-namespace:NguyenTienDatWPF.ViewModels     5   	     � Title$'  !Quản lý phòng - FU Mini Hotel��5	   	   $	��450��6/   $	��800��6<    � 	Resources 5
      =   7NguyenTienDatWPF.ViewModels.RoomManagementViewViewModel   	ViewModel��%   &	          5   
   6)   5      .��5      �  � DataContext# [  6   $��10q�64    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      �� $��Tìm kiếm:��6   $��Center=�6)   $��0,0,5,0q�6D   �� 5      $	��200��6   $��0,0,10,0q�6c   ��6"   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�6c   �� 5      $	��150��6    �� DisplayMemberPath$ RoomTypeName��6E   $��0,0,10,0q�5   A   ��5   #   �� *	RoomTypes+ �� SelectedItem 5      �� *SelectedRoomType+6A   �� 5      -   5        $��Thêm phòng mới��5      $	��120��6.   6:   5      �� 5   
   $��1��6   ��6    �� *Rooms+ 6>   �� *SelectedRoom+ �� View 5      �� 5      .P�5      �� $��ID��6%   	 �� Width$	 50��6Y   
 �� DisplayMemberBinding
 61   �� *RoomID+6Y   �� 5       $��Số phòng��6%   $	 80��6c   
 67   �� *
RoomNumber+6c   �� 5!      $��Loại phòng��6%   $		 120��6p   
 69   �� *RoomType.RoomTypeName+6p   �� 5"      $��Sức chứa��6%   $	 80��6h   
 67   �� *RoomMaxCapacity+6h   �� 5#      $��
Giá/ngày��6%   $		 120��6�   
 67   �� *RoomPricePerDay+ �� StringFormat$ 
{0:N0} VND��6�   �� 5$      $��Trạng thái��6%   $	 80��69    �� CellTemplate 5%      �� 5&      .R�5'   "   �� ��5(   &   `� 5)   *   $	 {0}��67   .1�5*   .   ��  �� Path$ 
RoomStatus�66   5+   +   5-   #   5.      50      �� 51      $��	Thao tác��6%   $		 180��67    52      �� 53      .R�54   "   �� $ 
Horizontal=�6-   .+�55   &   �� -   5        $��Sửa��55   -   $��60��6;   $��0,0,5,0q�6F   6W   �� 56   &   -   5        $
��Xóa��56   -   $��60��6;   $��5,0,0,0q�6F   6W   57   #   58      5:      5;      5=      �� 5?   
   -   5        $��2��5?      $��Đóng��6   $��80��6-   $��Right=�68   $��0,10,0,0q�6T   6f   5@      5A      