   M S B A M L   `   `   `  ����K  GNguyenTienDatWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NguyenTienDatWPFNguyenTienDatWPF  5   	   !    NguyenTienDatWPF.RoomDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NguyenTienDatWPF     5   	     � Title$  
RoomDialog��5   	   $	��450��6   $	��800��6)   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Số Phòng��6   $��5q�6$   �� 5   
   $��1��6   $��5q�6e   ��6   �� *Room.RoomNumber+ �� UpdateSourceTrigger$ PropertyChanged=�6e   �� 5   
   $��2��6   $��Mô Tả��6!   $��5q�6.   �� 5   
   $��3��6   $��5q�6j   ��6   �� *Room.RoomDescription+$ PropertyChanged=�6j   �� 5   
   $��4��6   $��Sức Chứa Tối Đa��6!   $��5q�68   �� 5   
   $��5��6   $��5q�6j   ��6   �� *Room.RoomMaxCapacity+$ PropertyChanged=�6j   �� 5   
   $��6��6   $��Giá Mỗi Ngày��6!   $��5q�65   �� 5   
   $��7��6   $��5q�6k   ��6   �� *Room.RoomPricePerDate+$ PropertyChanged=�6k   �� 5    
   $��8��6   $��Loại Phòng��6!   $��5q�63   �� 5!   
   $��9��6    �� SelectedValuePath$ 
RoomTypeID��5$       �� DisplayMemberPath$ RoomTypeName��5%      $��5q�5&      ��5"      �� *	RoomTypes+ �� SelectedValue 5#      �� *Room.RoomTypeID+5&      �� 5'   
   $��10��6    �� Orientation$ 
Horizontal=�6#   $��Center=�6<   $��5q�6Y   .+�5(      �� $
��Lưu��6   $��5q�6C   ��6#   �� *SaveCommand+6C   �� 5)      $��Hủy��6   $��5q�6E   ��6#   �� *CancelCommand+6E   5*      5+      5,      