   M S B A M L   `   `   `  ����F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ToolTracker.ViewsToolTracker.Views  5   	   #    ToolTracker.Views.AboutWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ToolTracker.Views     5   	     � Title$  About Tool Tracker��5   	   $	��400��6$   $	��400��61    � WindowStartupLocation$ CenterScreen=�6=    � 
ResizeMode$ NoResize=�6b    � Icon$; 5/ToolTracker;component/Assests/Icons/help-about-3.png��6x    � 	Resources 5
       �� 
TargetType   
PushButton �� BasedOn��%0   '��       7   �� 5   
   " ��6   8   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��75 �6   �� 5      $
��200* �6   �� 5      $��50 �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��180* �6   �� 5      $	��180 �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6   $��50��6-   $��Center=�69   $)��#/Assests/Images/ToolTrackerLogo.png��6T   �� 5    
   $��2��6   $��1��6   $	��130��6-   $��Bottom=�6:   $��0,0,0,25q�6U   $-��'/Assests/Images/SmallHelloWorldLogo.png��6g   �� 5"   
   $��1��6   $��2��6!   $��2��61   $��14(�6B   $��10,10q�6P   $
��Wrap=�6_   
���������Tool Tracker helps tool officers check out/in tools by saving the necessary information with just a click. This frees them from hours of tedious paper work.�� 5&      �� 6   b`Tool Tracker was developed by the Hello World computer programming class founded by Paul Bolden.5)      �� 5*   
   -   5        $��btnClose��5*      $��75��6!   $��30��6,   $��3��68   $��1��6E   $��2��6U   $��Close��6i   $��14(�6y   $��DemiBold"�6�   6�   5+      5,      