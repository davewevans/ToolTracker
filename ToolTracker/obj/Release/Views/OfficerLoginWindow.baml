   M S B A M L   `   `   `  ���� F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ToolTracker.ViewsToolTracker.Views  *    $ToolTracker.Views.OfficerLoginWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:ToolTracker.Views     -     � Title$  Officer Login��$	��500��$	��400�� � WindowStartupLocation$ CenterScreen=� � Icon$J D/ToolTracker;component/Assests/Icons/Login Rounded Right_49x49px.png�� � 
ResizeMode$ NoResize=� � 	Resources  �� 
TargetType   
PushButton �� BasedOn��%   '��       7   �� " ��8   .���  � RowDefinitions �� $��20 ��� $��* ��� $��20 � � ColumnDefinitions �� $��20 ��� $��* ��� $��20 �.+�� $��1��$��1�� �� $��30 ��� $	��300 ��� $	��100 � �� $	��260 ��� $	��100 �.+��� $��0��$��2��$��Officer Login��$
��Bold"�$��18(�$��30��$��Center=��� $��1��$��0��	 �� Orientation$	 Vertical=�.+��� $��Select Your Name:��$��DemiBold"�$��14(�$��25���� -   $��ListBoxNames��$	��260��$��12(��� $��1��$��1��$	 Vertical=�$
��0,25q�.+��� -   $��btnAddOfficer��$��30��$��60��$��10,10q�$��DemiBold"�$
��Left=�.���� $	 
Horizontal=�.+��� $��12(�$	��ADD��$��0,0,10,0q��� $��12(�$#��../Assests/Fonts/#FontAwesome)�$	����
��� � �$��Center=��� -   $��btnEditOfficer��$��30��$��60��$
��10,0q�$��DemiBold"�$
��Left=�.���� $	 
Horizontal=�.+��� $��12(�$
��EDIT��$��0,0,10,0q��� $��12(�$#��../Assests/Fonts/#FontAwesome)�$	����
��� ���$��Center=��� $��2��$��0��$	 
Horizontal=�$��Center=�.+��� -   $��btnLogin��$��40��$	��100��$��16(�$
��Bold"�$
��0,20q�$	��Top=�.���� $	 
Horizontal=�.+��� $��16(�$��Login��$��0,0,10,0q��� $��20(�$#��../Assests/Fonts/#FontAwesome)�$��0,2,0,0q�$	����
����=H�$��Center=��� -   $��btnClose��$��40��$	��100��$��Close��
 �� IsCancel
 . $��16(�$
��Bold"�$��10,20q�$	��Top=�