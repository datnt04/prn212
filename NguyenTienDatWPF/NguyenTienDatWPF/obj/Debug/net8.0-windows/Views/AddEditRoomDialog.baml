   M S B A M L   `   `   `  ����K  GNguyenTienDatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:NguyenTienDatWPF.ViewsNguyenTienDatWPF.Views  5   	   I)clr-namespace:NguyenTienDatWPF.ViewModelsNguyenTienDatWPF.ViewModels  5   	   .    (NguyenTienDatWPF.Views.AddEditRoomDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:NguyenTienDatWPF.Views     5   	   8vm)clr-namespace:NguyenTienDatWPF.ViewModels     5   	     � Title$  Thêm/Sửa Phòng��5	   	   $	��450��6    $	��500��6-    � 	Resources 5
      :   4NguyenTienDatWPF.ViewModels.AddEditRoomViewViewModel   	ViewModel��%   &	          5   
   6&   5      .��5      �  � DataContext# [  6   $��10q�64    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��120 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Số phòng:��6-   �� 5   
   $��0��6   $��1��6   $��5q�6p   ��6/   �� *
RoomNumber+ �� UpdateSourceTrigger$ PropertyChanged=�6p   �� 5    
   $��1��6   $��0��6   $��	Mô tả:��6-   �� 5!   
   $��1��6   $��1��6   $��5q�6V    �� TextWrapping$
 Wrap=�6a    �� AcceptsReturn$
 True��6u   $��60��6�   ��6/   �� *RoomDetailDescription+6�   �� 5#   
   $��2��6   $��0��6   $��Sức chứa tối đa:��6-   �� 5$   
   $��2��6   $��1��6   $��5q�6P   ��6/   �� *RoomMaxCapacity+6P   �� 5&   
   $��3��6   $��0��6   $��Loại phòng:��6-   �� 5'   
   $��3��6   $��1��6     �� DisplayMemberPath$ RoomTypeName��5*      $��5q�5+      ��5(      �� *	RoomTypes+	 �� SelectedItem	 5)      �� *SelectedRoomType+5+      �� 5-   
   $��4��6   $��0��6   $��Trạng thái:��6-   �� 5.   
   $��4��6   $��1��6    $��5q�6T   	 60   �� *
RoomStatus+.@�5/      �� $��	Có sẵn��6   

 � Tag$
 1��6,   �� 50      $��Đang bảo trì��6   $
 0��62   51      �� 53   
   $��5��6   $��0��6   $��Giá phòng/ngày:��6-   �� 54   
   $��5��6   $��1��6   $��5q�6P   ��6/   �� *RoomPricePerDay+6P   �� 56   
   $��7��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Right=�6K   $��0,20,0,0q�6g   .+�57      �� $
��Lưu��6   $��80��6#   $	��5,0q�6.   �� 58      $��Hủy��6   $��80��6#   $	��5,0q�6.    �� IsCancel$
 True��6;   59      5:      5;      