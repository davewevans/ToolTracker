   M S B A M L   `   `   `  ����F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ToolTrackerToolTracker  5   	   ?$clr-namespace:ToolTracker.ViewModelsToolTracker.ViewModels  5   	   +clr-namespace:SimpleSampleSimpleSample  5   	   "    ToolTracker.TestLoaderWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ToolTracker     5   	   ;
viewModels$clr-namespace:ToolTracker.ViewModels     5   	   3simpleSampleclr-namespace:SimpleSample     5   	   X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44wpfx)http://schemas.xceed.com/wpf/xaml/toolkit  5	   	   -   5          � Title$  TestLoaderWindow��5   	   $	��500��6"   $	��500��6/    � 	Resources 5         WaitStoryboard �� 
TargetName �� TargetProperty W� From	 W� To g� Duration g� RepeatBehavior  ToolsDataTemplate �� DataType*  $ToolTracker.ViewModels.ToolViewModel	 �� Orientation
 �� Path �� Mode2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace �� DisplayMemberPath �� SelectedIndex
 � Tag��%S  &	        &	 �     �� 5   
   .��5      W� $
 Wait��5      $5 /(Image.RenderTransform).(RotateTransform.Angle)�5      $ 0X�5      $
 -360X�5      $ 0:0:1D�5      $ Forever��5      5      �� 5   
   "  61   .R�5       �� $	 
Horizontal=�6   .+�5!      �� $��30��6H   $	��100��6T   $��12(�6`   $��1,5,0,0q�6n   ��6   �� $
 
ToolNumber�$ TwoWay=�6n   �� 5"       preserve6   63   �� 5#      $��30��6I   $	��350��6U   $��12(�6a   $��1,5,0,0q�6o   ��6   �� $
 Description�$ TwoWay=�6o   �� 5$       preserve6   63   �� 5%      $��ComboBoxShopsForTools��6   -   5        $
 Name��5%   8   $��30��6�   $	��200��6�   $��Center=�6�   ��6Q   �� *Shops+ 6o   �� $
 	ShopIndex�$ OneWay=� 6  �� $
 Id��� 5&       preserve6   63   �� 5'      $��btnSaveUpdateTool��6   -   5        $��30��5'   J   $��60��6V    62   �� $
 Id�.��5(      �� $	 
Horizontal=�6!   .+�5)      �� $��12(�6$   $
��Save��62   $��0,0,5,0q�6>   �� 5*      $��14(�6$   $#��../Assests/Fonts/#FontAwesome)�62   $	����6]   
��� � �$��Center=�6�   5+      5,      �� 5-       preserve6   63   �� 5.      $��btnDeleteTool��6   -   5        $��30��5.   F   $��60��6R    6.   �� $
 Id�.��5/      �� $	 
Horizontal=�6!   .+�50      �� $��12(�6$   $��Delete��62   $��0,0,5,0q�6@   �� 51      $��14(�6$   $#��../Assests/Fonts/#FontAwesome)�62   $	����6]   
���  ��$��Center=�6�   52      53      54      55      57      .��5:      �  � RowDefinitions 5;   
   �� 5<      $��20 �6   �� 5=      $��60 �6   �� 5>      $��40 �6   �� 5?      $��* �6   �� 5@      $��40 �6   �� 5A      $��20 �6    � ColumnDefinitions 5C   
   �� 5D      $��20 �6   �� 5E      $��* �6   �� 5F      $��75 �6   �� 5G      $��20 �6   .+�5K   
   %  Xceed.Wpf.Toolkit.BusyIndicator  -   5        $��BusyBar��5K      $��1��6,   $��1��69      IsBusy .  6I   �� 5O   
   $	 
Horizontal=�6   $��Bottom=�6.   $��2��6I   $��1��6V   .+�5P   
   �� $��Tool No.��6   $��30��6#   $	��100��6/   $��5,10,0,0q�6;   $��12(�6N   $��SemiBold"�6\   �� 5Q       preserve6   6/   �� 5R      $��Description��6   $��30��6*   $	��350��66   $��5,10,0,0q�6B   $��12(�6U   $��SemiBold"�6c   �� 5S       preserve6   6/   �� 5T      $��	Shop Name��6   $��30��6(   $	��125��64   $��5,10,0,0q�6@   $��12(�6S   $��SemiBold"�6a   5U      �� 5_      -   5        $��ScrollViewerTools��5_      $��3��64   $��1��6A   .��5`      �� -   5        $��listBoxUpdateTools��5`   L   #��[ 6   $��center=�6f   $	��400��6�   $��	0,0,10,10q�6�   6c  5a      �� 5g   
   -   5        $
��Wait��5g      $��2��6   $��2��6)   $��Assests/Images/Fly 7.png��69    J� RenderTransformOrigin$ 0.5,0.5&�6[   z�5h      �� 5i       �� Angle$ 0Q�6"   5k      �� 5m   
   $��4��6   $��1��6"   $	 
Horizontal=�62   .+�5n      �� -	   5        $��btnTest1��5n      $��30��6&   $��50��62   $
��Load��6=   6L   �� 5o      -
   5        $��btnTest2��5o      $��30��6&   $��50��62   $��5,0,0,0q�6=   $��Start��6N   6^   �� 5p      -   5        $��btnTest3��5p      $��30��6&   $��50��62   $��5,0,0,0q�6=   $
��Stop��6N   6]   5q      5u      5v      