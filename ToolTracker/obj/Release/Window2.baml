   M S B A M L   `   `   `  ���� F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ToolTrackerToolTracker      ToolTracker.Window2   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:ToolTracker       � Title$  Window2��$	��600��$	��600�� � 	Resources    WaitStoryboard �� 
TargetName �� TargetProperty W� From	 W� To g� Duration g� RepeatBehavior��%�   &	        �� .��W� $
 Wait��$9 3(TextBlock.RenderTransform).(RotateTransform.Angle)�$ 0X�$	 360X�$ 0:0:2D�$ Forever��.��� .+��� $��Center=�$	��100��$	��100��.+��� -    ��Name$ 
WaitCircle��$��Center=�$��75��$��Center=�$��75��$��Assests/Images/Fly 7.png��	 J� RenderTransformOrigin$	 0.5,0.5&�
 �� Left$
 10��
 �� Top$ 10��z���  �� Angle$ 0Q��� -   $ WaitPic��$��Center=�$��50��$��Center=�$��50��$.��(Assests/Images/ToolTrackerIcon_64x64.png��$	 0.5,0.5&�$
 25��$ 24��z��� $ 0Q��� -    ��Name$ button��$��Start��$
��Left=�$��135,475,0,0q�$	��Top=�$��75���� -   $ button1��$
��Stop��$
��Left=�$��225,475,0,0q�$	��Top=�$��75��