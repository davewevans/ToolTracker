   M S B A M L   `   `   `  ����F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ToolTracker.ViewModelsToolTracker.ViewModels  5   	   %    ToolTracker.Views.AddToolWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ToolTracker.ViewModels     5   	   -   5          � Title$  Add Tool��5   	   $	��350��6   $	��400��6'    � WindowStartupLocation$ CenterScreen=�63    � 
ResizeMode$ NoResize=�6X    � 	Resources 5
       �� 
TargetType   
PushButton �� BasedOn��%0   '��       7   �� 5   
   " ��6   8   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��10 �6    � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $	��120 �6   �� 5      $	��240 �6   �� 5      $��10 �6   .+�5    
   �� $��Add Tool��6   $��Center=�6$   $��1��6A   $��1��6N   $��2��6^   $��25��6r   $��DemiBold"�6~   $��18(�6�   �� 5!   
   $��2��6   $��1��6   $��25��6-   $��Right=�69   $��Tool ID��6U   �� 5"   
   $��3��6   $��1��6   $��25��6-   $��Right=�69   $��Tool Description��6U   �� 5#   
   -   5        $��textBoxToolNo��5#   /   $��2��6   $��2��6   $��25��6D    �� 	MaxLength$	 100��6P   6`   �� 5$   
   -   5        $��textBoxToolDesc��5$   /   $��3��6   $��2��6   $��25��6F   $	 100��6R   6b   �� 5%   
   -   5        $��textBlockStatus��5%      $��4��6+   $��1��68   $��25��6H   $��2��6T   $��Center=�6h   �� 5&   
   $��4��6   $��1��6   $��25��6-   $��Right=�69   $
��Shop��6U   6f   �� 5'   
   -   5        $��ComboBoxShops��5'      $��4��6(   $��2��65   $	��240��6E   $��30��6Q   $��6,6,0,0q�6]   $��14(�6o   6}   �� 5(   
   -   5        $��TextBlockStatus��5(      $��5��6+   $��1��68   $��2��6H   $��Center=�6\   $��14(�6y   �� 5*   
   	 �� Orientation$	 
Horizontal=�6   $��6��6.   $��1��6;   $��2��6K   $��Center=�6_   .+�5+      �� -   5        $��btnSave��5+      $��25��6$   $��75��60   
 �� 	IsDefault
 . .��6e   Save5-      �� 5.      2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve6       63   �� 5/      -   5        $��	btnCancel��5/      $��25��6&   $��75��62    �� IsCancel . .��6g   Cancel51      52      54      55      