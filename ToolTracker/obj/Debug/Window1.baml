   M S B A M L   `   `   `  ����F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ToolTrackerToolTracker  5   	       ToolTracker.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ToolTracker     5   	     � Title$  Window1��5   	   $	��300��6   $	��300��6&    � 	Resources 5         WaitStoryboard �� 
TargetName �� TargetProperty W� From	 W� To g� Duration g� RepeatBehavior��%�   &	        �� 5   
   .��5      W� $
 Wait��5      $5 /(Image.RenderTransform).(RotateTransform.Angle)�5      $ 0X�5      $	 360X�5      $ 0:0:2D�5      $ Forever��5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��10* �6   �� 5      $	��45* �6   	 � RowDefinitions	 5   
   �� 5      $	��20* �6   �� 5       $	��98* �6   .+�5+   
   �� -   5        $
��Wait��5+      $��1��6   $��1��6)   $
��Left=�69   $	��100��6T   $	��Top=�6a   $	��100��6y   $��Assests/Images/Fly 7.png��6�   
 J� RenderTransformOrigin$
 0.5,0.5&�6�   z�5,      �� 5-       �� Angle$ 0Q�6"   5/      �� 51   
   -   5         ��Name$ button��51      $��Start��6!   $
��Left=�61   $��
36,193,0,0q�6L   $��1��6`   $	��Top=�6m   $��75��6�   $��2��6�   �� 52   
   -   5        $ button1��52      $
��Stop��6"   $��1��61   $
��Left=�6A   $��100,193,0,0q�6\   $��1��6q   $	��Top=�6~   $��75��6�   6�   54      55      