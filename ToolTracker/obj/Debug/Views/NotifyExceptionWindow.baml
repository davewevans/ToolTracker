   M S B A M L   `   `   `  ����F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ToolTracker.ViewsToolTracker.Views  5   	   -    'ToolTracker.Views.NotifyExceptionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ToolTracker.Views     5   	   -   5        $��windowNotifyException��5   0     � Title$  Error��6	   $	��300��6   $	��400��6$    � Icon$) #/Assests/Icons/dialog-important.ico��6u    � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ NoResize=�6�    � 	Resources 5       �� 
TargetType   
PushButton �� BasedOn  menuIconStyle �� Property �� Value��%�   '��       7   &	 "     �� 5   
   " ��6   8   6$   �� 5   
   " ��6   .�5      ��  � ��$ 16��6&   �� 5       � ��$ 16��6'   �� 5       � ��$ Uniform=�6(   5      5      .��5      � 	 � ColumnDefinitions	 5   
   �� 5      $
��102* �6   �� 5      $
��276* �6   
 � RowDefinitions
 5   
   �� 5      $��21 �6   �� 5      $��23 �6   �� 5       $��47 �6   �� 5!      $��27 �6   �� 5"      $��* �6   .+�5$   
   �� -   5        $��textBlockCaption��5$   =   $
��Auto��6   $
��Left=�6"   $!��Oh no! Something Went Wrong��6U   $	��Top=�6x   $
��Auto��6�   $��1��6�   $��16(�6�   $��DemiBold"�6�   $��0,1,0,0q�6�   $��1��6�   �� 5%   
   -   5        $��textBlockErrMsg��5%   i   $��1��6   $��2��6$   $��45��61   $
��Left=�6=   $��0,2,0,0q�6X   $��Error Message��6�   $	��Top=�6�   $��14(�6�   $��CharacterEllipsis=�6�   $
��Wrap=�6�   $	��276��6�   �� 5'   
   -   5        $��image1��5'   Y   $��3��6   $��97��6!   $
��Left=�6-   $��1,0,0,0q�6H   $��Uniform=�6g   $	��Top=�6y   $��92��6�   $%��/Assests/Images/Cry-icon-48.png��6�   $��1��6�   �� 5)   
   -   5        $��buttonClose��5)   �   #��[  6   $��Close��6A   $��1��6Q   $��3��6a   $��23��6n   $
��Left=�6z   $��	201,1,0,0q�6�   $��Bottom=�6�   $��75��6�   6�   9� 5*   
   -   5        $��expanderDetails��5*   t   $��4��6   $��Technical Details��6    $	��140��6;   $
��Left=�6H   $��1,0,0,0q�6c   $	��Top=�6�   $��2��6�   $	��377��6�   $��2��6�   .��5+      ��  �� Orientation$ Vertical=�6   .+�5,      �� -   5        $��scrollViewerDetails��5,      $	��375��6:   $��90��6F   $	��Top=�6R   $��0,0,0,0q�6j   .��5-      �� -   5        $��textBoxTechDetails��5-      $
��Auto��68   $
��Auto��6F    �� 
IsReadOnly .  �� TextWrapping$ WrapWithOverflow=�6e   $��3q�6�   $��3q�6�   .��6�    � ContextMenu 5.      �� 5/      .@�50   "   m� $
��Copy��6+    m� Command$
 Copy��69    m� Icon 51   &   �� 52   *   #��[ 60   $!��/Assests/Icons/EditCopy.png��6W   54   #   55      .��56   /   57      58      �� 5:      -	   5        $��buttonCopyToClipboard��5:   I   #��[  6   $��23��6f   $	��132��6r   $��0,3,0,0q�6~   .��5;      �� $ 
Horizontal=�6!   $
��Left=�6:   .+�5<      �� $!��/Assests/Icons/EditCopy.png��6    �� 5=      $��Copy to Clipboard��6$    �� Padding$ 4,0,0,0q�6=   5>      5?      5@      5A      5B      5C      