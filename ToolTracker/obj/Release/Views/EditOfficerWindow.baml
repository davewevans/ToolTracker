   M S B A M L   `   `   `  ���� F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ToolTracker.ViewsToolTracker.Views  )    #ToolTracker.Views.EditOfficerWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:ToolTracker.Views     -     � Title$  Edit Officer��$	��230��$	��350�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � Icon$8 2/ToolTracker;component/Assests/Icons/kgpg_edit.png�� � 	Resources  �� 
TargetType   
PushButton �� BasedOn��%   '��       7   �� " ��8   .���  � RowDefinitions �� $��20 ��� $��30 ��� $��30 ��� $��40 ��� $��50 ��� $��20 � � ColumnDefinitions �� $��20 ��� $��* ��� $��20 �.+��� $��1��$��1��$��Edit Officer��$��16(�$
��Bold"�$��Center=��� 	 �� Orientation$	 
Horizontal=�$��2��$��1��.+��� $��Enter Your Name��$��14(�$��DemiBold"�
 �� Padding$

 0,10q�$��Center=��� $+��%(as it should be printed on the form)��$��10(�$��DemiBold"�$

 3,13q�$��Center=��� -   $��TextBoxName��$��3��$��1��$
��Left=�$��25��$	��275�� �� 	MaxLength$	 100���� $	 
Horizontal=�$��4��$��1��$��Center=�.+��� -   $��btnSave�� �� 	IsDefault . $
��Save��$��30��$��75���� -   $��	btnCancel�� �� IsCancel . $��Cancel��$��30��$��75��$
��10,0q�