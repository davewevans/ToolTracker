   M S B A M L   `   `   `  ����F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ToolTracker.ViewsToolTracker.Views  5   	   '    !ToolTracker.Views.AddInmateWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ToolTracker.Views     5   	   -   5          � Title$  
Add Inmate��5   	   $	��425��6   $	��400��6)    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�6Z    � 	Resources 5
       �� 
TargetType   
PushButton �� BasedOn��%0   '��       7   �� 5   
   " ��6   8   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��10 �6    � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $	��120 �6   �� 5      $	��240 �6   �� 5      $��10 �6   .+�5!   
   �� $��
Add Inmate��6   $��Center=�6&   $��1��6C   $��1��6P   $��2��6`   $��25��6t   $��DemiBold"�6�   $��18(�6�   6�   �� 5"   
   $��2��6   $��1��6   $��25��6-   $��Right=�69   $��
First Name��6U   �� 5#   
   $��3��6   $��1��6   $��25��6-   $��Right=�69   $��	Last Name��6U   �� 5$   
   $��4��6   $��1��6   $��25��6-   $��Right=�69   $
��GDC#��6U   �� 5%   
   $��5��6   $��1��6   $��25��6-   $��Right=�69   $��Assigned Shop��6U   �� 5'   
   -   5        $��textBoxFirstName��5'   /   $��2��6   $��2��6   $��25��6G    �� 	MaxLength$	 100��6S   6c   �� 5(   
   -   5        $��textBoxLastName��5(   /   $��3��6   $��2��6   $��25��6F   $	 100��6S   �� 5)   
   -   5        $��
textBoxGDC��5)   /   $��4��6   $��2��6   $��25��6A   $ 15��6M   �� 5+   
   -   5        $��comboBoxShops��5+   0   $��5��6   $��2��6    $	��200��6E   $��30��6Q   $��6,6,0,0q�6]   $��12(�6o   �� 5-   
   -   5        $��textBlockStatus��5-      $��6��6+   $��1��68   $��25��6H   $��2��6T   $��Center=�6h   �� 5.   
   	 �� Orientation$	 
Horizontal=�6   $��7��6.   $��1��6;   $��2��6K   $��Center=�6_   .+�5/      �� -   5        $��btnSave��5/      $��25��6'   $��75��63   
 �� 	IsDefault
 . .��6g   Save51      �� 52      2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve6      62   �� 53   
   -   5        $��	btnCancel��53      $��25��6"   $��75��6.    �� IsCancel . .��6c   Cancel55      56      58      59      