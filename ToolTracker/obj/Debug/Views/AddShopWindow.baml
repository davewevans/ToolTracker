   M S B A M L   `   `   `  ����F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ToolTracker.ViewsToolTracker.Views  5   	   %    ToolTracker.Views.AddShopWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ToolTracker.Views     5   	     � Title$  AddShopWindow��5   	   $	��300��6   $	��400��6,    � WindowStartupLocation$ CenterScreen=�68    � 
ResizeMode$ NoResize=�6]    � 	Resources 5
       �� 
TargetType   
PushButton �� BasedOn��%0   '��       7   �� 5   
   " ��6   8   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��10 �6    � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $	��120 �6   �� 5      $	��240 �6   �� 5      $��10 �6   .+�5   
   �� $��Add Shop��6   $��Center=�6$   $��1��6A   $��1��6N   $��2��6^   $��25��6r   $��DemiBold"�6~   $��18(�6�   �� 5   
   $��2��6   $��1��6   $��25��6-   $��Right=�69   $��	Shop Name��6U   �� 5!   
   -   5        $��textBoxShopName��5!   /   $��2��6   $��2��6   $��25��6F    �� 	MaxLength$	 100��6R   6b   �� 5#   
   -   5        $��textBlockStatus��5#      $��3��6+   $��1��68   $��25��6H   $��2��6T   $��Center=�6h   �� 5$   
   	 �� Orientation$	 
Horizontal=�6   $��4��6.   $��1��6;   $��2��6K   $��Center=�6_   .+�5%      �� -   5        $��btnSave��5%      $��25��6$   $��75��60   
 �� 	IsDefault
 . .��6d   Save5'      �� 5(      2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve6       63   �� 5)      -   5        $��	btnCancel��5)      $��25��6&   $��75��62    �� IsCancel . .��6g   Cancel5+      5,      5.      5/      