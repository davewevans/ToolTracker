   M S B A M L   `   `   `  ���� F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ToolTracker.ViewsToolTracker.Views  -    'ToolTracker.Views.NotifyExceptionWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:ToolTracker.Views     -   $��windowNotifyException��  � Title$  Error��$	��300��$	��400�� � Icon$) #/Assests/Icons/dialog-important.ico�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � 	Resources  �� 
TargetType   
PushButton �� BasedOn  menuIconStyle �� Property �� Value��%{   '��       7   &	      �� " ��8   �� " ��.���  � ��$ 16����  � ��$ 16����  � ��$ Uniform=�.��� 	 � ColumnDefinitions	 �� $
��102* ��� $
��276* �
 � RowDefinitions
 �� $��21 ��� $��23 ��� $��47 ��� $��27 ��� $��* �.+��� -   $��textBlockCaption��$
��Auto��$
��Left=�$!��Oh no! Something Went Wrong��$	��Top=�$
��Auto��$��1��$��16(�$��DemiBold"�$��0,1,0,0q�$��1���� -   $��textBlockErrMsg��$��1��$��2��$��45��$
��Left=�$��0,2,0,0q�$��Error Message��$	��Top=�$��14(�$��CharacterEllipsis=�$
��Wrap=�$	��276���� -   $��image1��$��3��$��97��$
��Left=�$��1,0,0,0q�$��Uniform=�$	��Top=�$��92��$%��/Assests/Images/Cry-icon-48.png��$��1���� -   $��buttonClose��#��[  $��Close��$��1��$��3��$��23��$
��Left=�$��	201,1,0,0q�$��Bottom=�$��75��9� -   $��expanderDetails��$��4��$��Technical Details��$	��140��$
��Left=�$��1,0,0,0q�$	��Top=�$��2��$	��377��$��2��.����  �� Orientation$ Vertical=�.+��� -   $��scrollViewerDetails��$	��375��$��90��$	��Top=�$��0,0,0,0q�.���� -   $��textBoxTechDetails��$
��Auto��$
��Auto�� �� 
IsReadOnly .  �� TextWrapping$ WrapWithOverflow=�$��3q�$��3q�.�� � ContextMenu �� .@�m� $
��Copy�� m� Command$
 Copy�� m� Icon �� #��[ $!��/Assests/Icons/EditCopy.png��.���� -	   $��buttonCopyToClipboard��#��[  $��23��$	��132��$��0,3,0,0q�.���� $ 
Horizontal=�$
��Left=�.+��� $!��/Assests/Icons/EditCopy.png���� $��Copy to Clipboard�� �� Padding$ 4,0,0,0q�