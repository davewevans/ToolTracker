   M S B A M L   `   `   `  ����F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ToolTrackerToolTracker  5   	       ToolTracker.Window2   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ToolTracker     5   	     � Title$  Window2��5   	   $	��600��6   $	��600��6&    � 	Resources 5         WaitStoryboard �� 
TargetName �� TargetProperty W� From	 W� To g� Duration g� RepeatBehavior��%�   &	        �� 5   
   .��5      W� $
 Wait��5      $9 3(TextBlock.RenderTransform).(RotateTransform.Angle)�5      $ 0X�5      $	 360X�5      $ 0:0:2D�5      $ Forever��5      5      5      .��5      � .+�5    
   �� $��Center=�6   $	��100��6.   $	��100��6:   .+�5!      �� -   5         ��Name$ 
WaitCircle��5!      $��Center=�6(   $��75��6E   $��Center=�6Q   $��75��6l   $��Assests/Images/Fly 7.png��6w   	 J� RenderTransformOrigin$	 0.5,0.5&�6�   
 �� Left$
 10��6�   
 �� Top$ 10��6�   z�5"      �� 5#       �� Angle$ 0Q�6&   5%      �� 5&      -   5        $ WaitPic��5&      $��Center=�6%   $��50��6B   $��Center=�6N   $��50��6i   $.��(Assests/Images/ToolTrackerIcon_64x64.png��6t   $	 0.5,0.5&�6�   $
 25��6�   $ 24��6�   z�5'      �� 5(      $ 0Q�6&   5*      5+      �� 53   
   -   5         ��Name$ button��53      $��Start��6!   $
��Left=�61   $��135,475,0,0q�6L   $	��Top=�6a   $��75��6y   6�   �� 54   
   -   5        $ button1��54      $
��Stop��6"   $
��Left=�61   $��225,475,0,0q�6L   $	��Top=�6a   $��75��6y   6�   55      56      