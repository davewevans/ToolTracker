   M S B A M L   `   `   `  ���� F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ToolTracker.ViewsToolTracker.Views  &     ToolTracker.Views.SettingsWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:ToolTracker.Views     -     � Title$  Tool Tracker Settings��$	��500��$	��500�� � WindowStartupLocation$ CenterScreen=� � Icon$< 6/ToolTracker;component/Assests/Icons/Settings_48px.png�� � 
ResizeMode$ NoResize=� � 	Resources  �� 
TargetType   
PushButton �� BasedOn��%   '��       7   �� " ��8   .���  � RowDefinitions �� $��20 ��� $��40 ��� $��40 ��� $��50 ��� $	��200 ��� $��50 ��� $��50 ��� $��20 � � ColumnDefinitions �� $��20 ��� $��* ��� $��20 �.+��� $��1��$��1��$��2��$��Tool Tracker Settings��$��Center=�$
��Bold"�$��16(��� -   $��CheckBoxSkipRow��$��2��$��1��$��2��$��30��$��DemiBold"�$��14(�$#��Leave First Row on Form Blank���� -   $"��CheckBoxLeaveReceivedByBlank��$��3��$��1��$��2��$��30��$��DemiBold"�$��14(�$%��Leave Received By Officer Blank���� -   	 ��Name$	 groupBoxFormInfo��$��1��$��4��$��2��$*��$Form Information (top right on form)��$
��Left=�$	��Top=�$��DemiBold"�$��14(�$��2q�
�����p�.���  �� $��50 ��� $��50 ��� $��50 � �� $	��100 ��� $	��300 �.+��� $��0��$��0��$��Form Number:��$��30��$��DemiBold"�$��12(�$��2��$
��0,10q��� -   $��TextBoxFormNumber��$��0��$��2��$��30��$	��250��$
��Left=�$��10,10q�$	��5,5q�$��12(�
 �� 	MaxLength$	
 100���� $��1��$��0��$��Line 2:��$��30��$��DemiBold"�$��12(�$��2��$
��0,10q��� -   $��TextBoxFormInfoLine2��$��1��$��2��$��30��$	��250��$
��Left=�$��10,10q�$	��5,5q�$��12(�$	
 100���� $��2��$��0��$��
Form Date:��$��30��$��DemiBold"�$��12(�$
��Left=�$
��0,10q��� -    ��Name$ TextBoxFormDate��$��2��$��2��$��30��$	��100��$
��Left=�$��10,10q�$	��5,5q�$��12(�$
 50���� -   $��TextBlockStatus��$��6��$��1��$	��400��$��40��$��DemiBold"�$��Center=��� $��5��$��1�� �� Orientation$ 
Horizontal=�$��Center=�.+��� -	   $��btnSave�� �� 	IsDefault . $��30��$	��125��$��Save Settings��$
��Left=�$��Center=��� 2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve     �� -
   $��
btnRestore��$��30��$	��150��$��Restore Default Settings��$
��Left=�$��Center=���  preserve     �� -   $��	btnCancel�� �� IsCancel . $��30��$	��125��$��Cancel��$
��Left=�$��Center=�