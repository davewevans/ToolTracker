   M S B A M L   `   `   `  ����F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ToolTracker.ViewsToolTracker.Views  5   	   &     ToolTracker.Views.SettingsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ToolTracker.Views     5   	   -   5          � Title$  Tool Tracker Settings��5   	   $	��500��6'   $	��500��64    � WindowStartupLocation$ CenterScreen=�6@    � Icon$< 6/ToolTracker;component/Assests/Icons/Settings_48px.png��6e    � 
ResizeMode$ NoResize=�6�    � 	Resources 5
       �� 
TargetType   
PushButton �� BasedOn��%0   '��       7   �� 5   
   " ��6   8   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��50 �6   �� 5      $	��200 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6!   $��2��61   $��Tool Tracker Settings��6E   $��Center=�6b   $
��Bold"�6   $��16(�6�   �� 5    
   -   5        $��CheckBoxSkipRow��5    D   $��2��6   $��1��6    $��2��60   $��30��6[   $��DemiBold"�6g   $��14(�6}   $#��Leave First Row on Form Blank��6�   �� 5!   
   -   5        $"��CheckBoxLeaveReceivedByBlank��5!   D   $��3��6   $��1��6    $��2��60   $��30��6h   $��DemiBold"�6t   $��14(�6�   $%��Leave Received By Officer Blank��6�   �� 5"   
   -   5        	 ��Name$	 groupBoxFormInfo��5"      $��1��6-   $��4��6=   $��2��6J   $*��$Form Information (top right on form)��6^   $
��Left=�6�   $	��Top=�6�   $��DemiBold"�6�   $��14(�6�   $��2q�6�   
�����p�.��5$      �  5%      �� 5&      $��50 �6$   �� 5'      $��50 �6$   �� 5(      $��50 �6$    5*      �� 5+      $	��100 �6'   �� 5,      $	��300 �6'   .+�5/      �� $��0��6   $��0��6%   $��Form Number:��65   $��30��6L   $��DemiBold"�6X   $��12(�6n   $��2��6|   $
��0,10q�6�   �� 50      -   5        $��TextBoxFormNumber��50   7   $��0��6   $��2��6'   $��30��6P   $	��250��6\   $
��Left=�6h   $��10,10q�6�   $	��5,5q�6�   $��12(�6�   
 �� 	MaxLength$	
 100��6�   �� 52      $��1��6   $��0��6%   $��Line 2:��65   $��30��6G   $��DemiBold"�6S   $��12(�6i   $��2��6w   $
��0,10q�6�   �� 53      -   5        $��TextBoxFormInfoLine2��53   7   $��1��6   $��2��6'   $��30��6S   $	��250��6_   $
��Left=�6k   $��10,10q�6�   $	��5,5q�6�   $��12(�6�   $	
 100��6�   �� 55      $��2��6   $��0��6%   $��
Form Date:��65   $��30��6J   $��DemiBold"�6V   $��12(�6l   $
��Left=�6z   $
��0,10q�6�   �� 56      -   5         ��Name$ TextBoxFormDate��56   7   $��2��6   $��2��6'   $��30��6P   $	��100��6\   $
��Left=�6h   $��10,10q�6�   $	��5,5q�6�   $��12(�6�   $
 50��6�   58      59      �� 5:   
   -   5        $��TextBlockStatus��5:   1   $��6��6   $��1��6!   $	��400��6H   $��40��6T   $��DemiBold"�6`   $��Center=�6v   �� 5;   
   $��5��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Center=�6K   .+�5<      �� -	   5        $��btnSave��5<       �� 	IsDefault . $��30��65   $	��125��6A   $��Save Settings��6M   $
��Left=�6e   $��Center=�6�   6�   �� 5=      2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve6        64   �� 5>      -
   5        $��
btnRestore��5>      $��30��6'   $	��150��63   $��Restore Default Settings��6?   $
��Left=�6b   $��Center=�6}   6�   �� 5?       preserve6        64   �� 5@      -   5        $��	btnCancel��5@       �� IsCancel . $��30��66   $	��125��6B   $��Cancel��6N   $
��Left=�6_   $��Center=�6z   6�   5A      5C      5D      