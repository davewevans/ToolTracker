   M S B A M L   `   `   `  ���� F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ToolTrackerToolTracker      ToolTracker.Window1   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:ToolTracker       � Title$  Window1��$	��300��$	��300�� � 	Resources    WaitStoryboard �� 
TargetName �� TargetProperty W� From	 W� To g� Duration g� RepeatBehavior��%�   &	        �� .��W� $
 Wait��$5 /(Image.RenderTransform).(RotateTransform.Angle)�$ 0X�$	 360X�$ 0:0:2D�$ Forever��.���  � ColumnDefinitions �� $	��10* ��� $	��45* �	 � RowDefinitions	 �� $	��20* ��� $	��98* �.+��� -   $
��Wait��$��1��$��1��$
��Left=�$	��100��$	��Top=�$	��100��$��Assests/Images/Fly 7.png��
 J� RenderTransformOrigin$
 0.5,0.5&�z���  �� Angle$ 0Q��� -    ��Name$ button��$��Start��$
��Left=�$��
36,193,0,0q�$��1��$	��Top=�$��75��$��2���� -   $ button1��$
��Stop��$��1��$
��Left=�$��100,193,0,0q�$��1��$	��Top=�$��75��