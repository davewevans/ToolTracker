   M S B A M L   `   `   `  ����F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ToolTracker.ViewsToolTracker.Views  5   	   )    #ToolTracker.Views.EditOfficerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ToolTracker.Views     5   	   -   5          � Title$  Edit Officer��5   	   $	��230��6   $	��350��6+    � WindowStartupLocation$ CenterScreen=�67    � 
ResizeMode$ NoResize=�6\    � Icon$8 2/ToolTracker;component/Assests/Icons/kgpg_edit.png��6�    � 	Resources 5
       �� 
TargetType   
PushButton �� BasedOn��%0   '��       7   �� 5   
   " ��6   8   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��40 �6   �� 5      $��50 �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6!   $��Edit Officer��61   $��16(�6E   $
��Bold"�6S   $��Center=�6e   �� 5   
   	 �� Orientation$	 
Horizontal=�6   $��2��6.   $��1��6;   .+�5      �� $��Enter Your Name��6   $��14(�6/   $��DemiBold"�6=   
 �� Padding$

 0,10q�6S   $��Center=�6b   �� 5      $+��%(as it should be printed on the form)��6   $��10(�6E   $��DemiBold"�6S   $

 3,13q�6i   $��Center=�6x   5       �� 5"   
   -   5        $��TextBoxName��5"      $��3��6%   $��1��62   $
��Left=�6B   $��25��6]   $	��275��6i    �� 	MaxLength$	 100��6u   �� 5$   
   $	 
Horizontal=�6   $��4��6.   $��1��6;   $��Center=�6K   .+�5%      �� -   5        $��btnSave��5%       �� 	IsDefault . $
��Save��65   $��30��6D   $��75��6P   6[   �� 5&      -   5        $��	btnCancel��5&       �� IsCancel . $��Cancel��66   $��30��6G   $��75��6S   $
��10,0q�6^   6l   5'      5(      5)      