   M S B A M L   `   `   `  ����F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ToolTracker.ViewsToolTracker.Views  5   	   +    %ToolTracker.Views.AddNewOfficerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ToolTracker.Views     5   	   -   5          � Title$  Add New Officer��5   	   $	��230��6!   $	��350��6.    � 
ResizeMode$ NoResize=�6:    � WindowStartupLocation$ CenterScreen=�6P    � Icon$7 1/ToolTracker;component/Assests/Icons/list-add.png��6�    � 	Resources 5	       �� 
TargetType   
PushButton �� BasedOn��%0   '��       7   �� 5
   
   " ��6   8   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��40 �6   �� 5      $��50 �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6!   $��Add New Officer��61   $��16(�6H   $
��Bold"�6V   $��Center=�6h   �� 5   
   	 �� Orientation$	 
Horizontal=�6   $��2��6.   $��1��6;   .+�5      �� $��Enter Your Name��6   $��14(�62   $��DemiBold"�6@   
 �� Padding$

 0,10q�6V   $��Center=�6e   �� 5      $+��%(as it should be printed on the form)��6   $��10(�6H   $��DemiBold"�6V   $

 3,13q�6l   $��Center=�6{   5      �� 5!   
   -   5        $��TextBoxName��5!      $��3��6%   $��1��62   $
��Left=�6B   $��25��6]   $	��275��6i    �� 	MaxLength$	 100��6u   �� 5#   
   $	 
Horizontal=�6   $��4��6.   $��1��6;   $��Center=�6K   .+�5$      �� -   5        $��btnAdd��5$       �� 	IsDefault . $	��Add��64   $��30��6B   $��75��6N   6Y   �� 5%      -   5        $��	btnCancel��5%       �� IsCancel . $��Cancel��66   $��30��6G   $��75��6S   $
��10,0q�6x   5&      5)      5*      