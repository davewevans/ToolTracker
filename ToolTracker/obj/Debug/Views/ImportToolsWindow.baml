   M S B A M L   `   `   `  ����F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ToolTracker.ViewsToolTracker.Views  5   	   )    #ToolTracker.Views.ImportToolsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ToolTracker.Views     5   	   -   5          � Title$  Import Tools��5   	   $	��250��6   $	��300��6+    � 
ResizeMode$ NoResize=�67    � WindowStartupLocation$ CenterScreen=�6M    � Icon$> 8/ToolTracker;component/Assests/Icons/document-import.png��6r    � 	Resources 5
       �� 
TargetType   
PushButton �� BasedOn��%0   '��       7   �� 5   
   " ��6   8   6$   5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��40 �6   �� 5      $��30 �6   �� 5      $��40 �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6!   $��Center=�61   $��Import Tools��6N   $��16(�6b   $
��Bold"�6p   �� 5   
   -   5        $��TextBlockStatus��5      $��4��6+   $��1��68   $��Center=�6H   $��14(�6e   $��DemiBold"�6s   �� 5    
   -   5        $��TextBlockFileName��5       $��2��6-   $��1��6:   $��Center=�6J   $��14(�6g   $��DemiBold"�6u   �� 5!   
   $��3��6   $��1��6"   	 �� Orientation$	 
Horizontal=�62   $��Center=�6K   .+�5"      �� -   5        $��	btnBrowse��5"      $��Select Excel File��6&   
 �� 	IsDefault
 . $��30��6S   $	��100��6_   6k   �� 5#      -   5        $��	btnImport��5#      $��Import��6&   $��30��67   $	��100��6C   $
��10,0q�6O   {�.  6o   5$      �� 5%   
   -   5        $��btnClose��5%   .   $��5��6   $��1��6   $��Close��6>   $��30��6N   $	��100��6Z   6f   5&      5'      