   M S B A M L   `   `   `  ����F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ToolTracker.ViewsToolTracker.Views  5   	   *    $ToolTracker.Views.OfficerLoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ToolTracker.Views     5   	   -   5          � Title$  Officer Login��5   	   $	��500��6   $	��400��6,    � WindowStartupLocation$ CenterScreen=�68    � Icon$J D/ToolTracker;component/Assests/Icons/Login Rounded Right_49x49px.png��6�    � 
ResizeMode$ NoResize=�6�    � 	Resources 5
       �� 
TargetType   
PushButton �� BasedOn��%0   '��       7   �� 5   
   " ��6   8   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   � $��1��6   $��1��6    5      �� 5      $��30 �6    �� 5      $	��300 �6    �� 5      $	��100 �6     5       �� 5!      $	��260 �6#   �� 5"      $	��100 �6#   .+�5%      �� $��0��6   $��2��6%   $��Officer Login��69   $
��Bold"�6N   $��18(�6`   $��30��6n   $��Center=�6z   �� 5&      $��1��6   $��0��6&   	 �� Orientation$	 Vertical=�66   .+�5'      �� $��Select Your Name:��6   $��DemiBold"�65   $��14(�6K   $��25��6Y   �� 5(      -   5        $��ListBoxNames��5(      $	��260��6.   $��12(�6;   6I   5)      �� 5*      $��1��6   $��1��6&   $	 Vertical=�66   $
��0,25q�6M   .+�5+      �� -   5        $��btnAddOfficer��5+      $��30��6.   $��60��6:   $��10,10q�6E   $��DemiBold"�6T   $
��Left=�6j   .��5,      �� $	 
Horizontal=�6!   .+�5-      �� $��12(�6$   $	��ADD��62   $��0,0,10,0q�6=   �� 5.      $��12(�6$   $#��../Assests/Fonts/#FontAwesome)�62   $	����6]   
��� � �$��Center=�6�   5/      50      �� 51      -   5        $��btnEditOfficer��51      $��30��6/   $��60��6;   $
��10,0q�6F   $��DemiBold"�6T   $
��Left=�6j   .��52      �� $	 
Horizontal=�6!   .+�53      �� $��12(�6$   $
��EDIT��62   $��0,0,10,0q�6>   �� 54      $��12(�6$   $#��../Assests/Fonts/#FontAwesome)�62   $	����6]   
��� ���$��Center=�6�   55      56      57      �� 58      $��2��6   $��0��6&   $	 
Horizontal=�66   $��Center=�6O   .+�59      �� -   5        $��btnLogin��59      $��40��6)   $	��100��65   $��16(�6A   $
��Bold"�6O   $
��0,20q�6a   $	��Top=�6o   .��5:      �� $	 
Horizontal=�6!   .+�5;      �� $��16(�6$   $��Login��62   $��0,0,10,0q�6?   �� 5<      $��20(�6$   $#��../Assests/Fonts/#FontAwesome)�62   $��0,2,0,0q�6]   $	����6n   
����=H�$��Center=�6�   5=      5>      �� 5?      -   5        $��btnClose��5?      $��40��6)   $	��100��65   $��Close��6A   
 �� IsCancel
 . $��16(�6a   $
��Bold"�6o   $��10,20q�6�   $	��Top=�6�   6�   5@      5B      5C      5D      