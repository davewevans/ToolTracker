   M S B A M L   `   `   `  ���� F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ToolTrackerToolTracker  ?$clr-namespace:ToolTracker.ViewModelsToolTracker.ViewModels  +clr-namespace:SimpleSampleSimpleSample  "    ToolTracker.TestLoaderWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:ToolTracker     ;
viewModels$clr-namespace:ToolTracker.ViewModels     3simpleSampleclr-namespace:SimpleSample     X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44wpfx)http://schemas.xceed.com/wpf/xaml/toolkit  -     � Title$  TestLoaderWindow��$	��500��$	��500�� � 	Resources    WaitStoryboard �� 
TargetName �� TargetProperty W� From	 W� To g� Duration g� RepeatBehavior  ToolsDataTemplate �� DataType*  $ToolTracker.ViewModels.ToolViewModel	 �� Orientation
 �� Path �� Mode2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace �� DisplayMemberPath �� SelectedIndex
 � Tag��%�  &	        &	 {     �� .��W� $
 Wait��$5 /(Image.RenderTransform).(RotateTransform.Angle)�$ 0X�$
 -360X�$ 0:0:1D�$ Forever���� "  .R��� $	 
Horizontal=�.+��� $��30��$	��100��$��12(�$��1,5,0,0q����� $
 
ToolNumber�$ TwoWay=���  preserve�� $��30��$	��350��$��12(�$��1,5,0,0q����� $
 Description�$ TwoWay=���  preserve�� $��ComboBoxShopsForTools��-   $
 Name��$��30��$	��200��$��Center=����� *Shops+ �� $
 	ShopIndex�$ OneWay=� �� $
 Id���  preserve�� $��btnSaveUpdateTool��-   $��30��$��60�� �� $
 Id�.���� $	 
Horizontal=�.+��� $��12(�$
��Save��$��0,0,5,0q��� $��14(�$#��../Assests/Fonts/#FontAwesome)�$	����
��� � �$��Center=���  preserve�� $��btnDeleteTool��-   $��30��$��60�� �� $
 Id�.���� $	 
Horizontal=�.+��� $��12(�$��Delete��$��0,0,5,0q��� $��14(�$#��../Assests/Fonts/#FontAwesome)�$	����
���  ��$��Center=�.���  � RowDefinitions �� $��20 ��� $��60 ��� $��40 ��� $��* ��� $��40 ��� $��20 � � ColumnDefinitions �� $��20 ��� $��* ��� $��75 ��� $��20 �.+�%  Xceed.Wpf.Toolkit.BusyIndicator  -   $��BusyBar��$��1��$��1��   IsBusy .  �� $	 
Horizontal=�$��Bottom=�$��2��$��1��.+��� $��Tool No.��$��30��$	��100��$��5,10,0,0q�$��12(�$��SemiBold"���  preserve�� $��Description��$��30��$	��350��$��5,10,0,0q�$��12(�$��SemiBold"���  preserve�� $��	Shop Name��$��30��$	��125��$��5,10,0,0q�$��12(�$��SemiBold"��� -   $��ScrollViewerTools��$��3��$��1��.���� -   $��listBoxUpdateTools��#��[ $��center=�$	��400��$��	0,0,10,10q��� -   $
��Wait��$��2��$��2��$��Assests/Images/Fly 7.png�� J� RenderTransformOrigin$ 0.5,0.5&�z���  �� Angle$ 0Q��� $��4��$��1��$	 
Horizontal=�.+��� -	   $��btnTest1��$��30��$��50��$
��Load���� -
   $��btnTest2��$��30��$��50��$��5,0,0,0q�$��Start���� -   $��btnTest3��$��30��$��50��$��5,0,0,0q�$
��Stop��