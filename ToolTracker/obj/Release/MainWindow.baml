   M S B A M L   `   `   `  ���� F  BToolTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ToolTracker.ViewModelsToolTracker.ViewModels  7 clr-namespace:ToolTracker.ModelsToolTracker.Models  +clr-namespace:SimpleSampleSimpleSample      ToolTracker.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:ToolTracker.ViewModels     3Models clr-namespace:ToolTracker.Models     X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44wpfx)http://schemas.xceed.com/wpf/xaml/toolkit  -simpleSampleclr-namespace:SimpleSample  -     � Title$  Tool Tracker��$	��600��$
��1000�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � Icon$- 'Assests\Images\ToolTrackerIcon32x32.ico�� � 	Resources    WaitStoryboard �� 
TargetName �� TargetProperty W� From	 W� To	 g� Duration
 g� RepeatBehavior �� 
TargetType  
PushButton �� BasedOn  Tab_Border_Thickness % !TabItem_Border_Thickness_Selected  TabItem_Spacer_Between_Tabs  TabItem_Corner_Radius  TabConrol_Corner_Radius  Tab_Border_Color  Tab_Background_Color %	 !TabItem_Background_Color_Selected �� 
StartPoint �� EndPoint � Color � Offset !
 TabItem_Border_Color_Selected �� Property �� Value �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName � UseLayoutRounding � RowDefinitions K� IsItemsHost K� ZIndex  ListBoxToolCheckOutInStyle �� Triggers  CheckToolsOutInDataTemplate  �� DataType4  .ToolTracker.ViewModels.CheckToolOutInViewModel! �� Orientation" d� 	IsChecked# �� Path$ �� Mode
% � Tag2  ,System.Windows.Markup.XmlAttributeProperties&  XmlSpace' �� Triggers( P� 
SourceName  InmatesDataTemplate,   &ToolTracker.ViewModels.InmateViewModel) �� 	MaxLength* �� DisplayMemberPath+ �� SelectedIndex  ToolsIssuedDataTemplate0   *ToolTracker.ViewModels.ToolIssuedViewModel, �� Padding  ToolsDataTemplate*  $ToolTracker.ViewModels.ToolViewModel  ShopsDataTemplate   ToolTracker.Models.Shop��%  &	        '�� {     7  &	 �     &	 �     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
 W    '�� �    7  7  7  7  7  7  7 
 7 	 '��     7  7  &	     &	 �    &	 <    &	 H    &	 =    &	 �    �� .��W� $
 Wait��$5 /(Image.RenderTransform).(RotateTransform.Angle)�$ 0X�$
 -360X�$	 0:0:1D�$
 Forever���� " ��8   u�4,4,4,4q�u�4,4,4,0q�u�0,0,1,0q���4,4,0,0����0,4,4,4����	Black����#F6F6FF���� $ 0.5,0&�$ 0.5,9&�.��� $ #9FABED��$ 0Q�� $ #F0F0F0��$	 0.2Q��� $ 0.5,0&�$ 0.5,1&�.��� $ #7592FF��$ 0Q�� $ Black��$	 0.2Q��� " ��.���  � �� �� " ��.R��� $ 	tabBorder��$��30��$	��140��8��  8�� $��Bottom=�8�� 8  8�� ._��� $ 
tabContent��$��Header����. $��Center=�$��Center=� P�  �@��
IsSelected . . ��� $ 	tabBorder��8   � ���� $ 	tabBorder�� � ��$ 35���� $ 	tabBorder��8   � ���� $ 	tabBorder��8   � ���� " ��.���  � �� �� " ��.R��  .  �� $��31 ��� $��4 ��� $��* �.+���  . $��0��$��2��$ 1���� $��1��$��2��8   $ 0��8�� #��z��#��z��._��� $��4q�$��SelectedContent���� " ��.���  �@��AlternationCount$ 2����  � �� �� " ��.���  � ��
 ��İ���  � ��$ 5q���  � ��$ 5q� P�  �@��AlternationIndex$ 1��. ���  � ��
 ��ح��� "   .R��� $��StackPanelCheckOutIn��$! 
Horizontal=�.+��� ���#7592FF$��4q�
�������._��� $��CheckBoxCheckOutIn��-   $��30��$��40��$��0,12,0,0q�
�������$��2q�" �� $# IsCheckedOut�$$ TwoWay=�% �� $# ToolId��� & preserve�� $��30��$	��250��$��14(�$��10,5,0,0q�$��CharacterEllipsis=����� $# ToolDescription��� & preserve  �� $��30��$	��100��$��14(�$��0,5,0,0q�$��CharacterEllipsis=����� $# 
ToolNumber��� & preserve  �� $��30��$	��150��$��14(�$��0,5,0,0q�$��CharacterEllipsis=����� $# ShopName��� & preserve	       �� $��30��$	��250��$��14(�$��0,5,0,0q�$��CharacterEllipsis=����� $# InmateNameAndGDC�' P� $( CheckBoxCheckOutIn�� �@d�	IsChecked$
 TrueY�. ��� $ StackPanelCheckOutIn�� � ��
 �z����� "   .R��� $! 
Horizontal=�.+��� $��30��$	��200��$��12(�$��1,5,0,0q�$	) 100������ $# LastName�$$ TwoWay=��� & preserve  �� $��30��$	��200��$��12(�$��1,5,0,0q�$	) 100������ $# 	FirstName�$$ TwoWay=��� & preserve  �� $��30��$	��100��$��12(�$��1,5,0,0q�$) 20������ $# 	GDCNumber�$$ TwoWay=��� & preserve  �� $��comboBoxAssignedShops��-   $
* Name��$��30��$	��200��$��Center=����� *Shops++ �� $# 	ShopIndex�$$ OneWay=�% �� $# Id��� & preserve  �� $��btnSaveUpdateInmate��-   $��30��$��60��% �� $# Id�.���� $! 
Horizontal=�.+��� $��12(�$
��Save��$��0,0,5,0q��� $��14(�$#��../Assests/Fonts/#FontAwesome)�$	����
��� � �$��Center=��� & preserve  �� $��btnDeleteInmate��-   $��30��$��60��% �� $# Id�.���� $! 
Horizontal=�.+��� $��12(�$��Delete��$��0,0,5,0q��� $��14(�$#��../Assests/Fonts/#FontAwesome)�$	����
���  ��$��Center=��� "   .R��� $! 
Horizontal=�.+��� $��30��$��70��$��12(�$, 1,5,0,0q�$��CharacterEllipsis=����� $# 
ToolNumber��� & preserve�� $��30��$	��150��$��12(�$, 1,5,0,0q�$��CharacterEllipsis=����� $# ToolDescription��� & preserve�� $��30��$	��105��$��12(�$, 1,5,0,0q�$��CharacterEllipsis=����� $!# ReceivedByInmateDisplayName��� & preserve�� $��30��$	��105��$��12(�$, 1,5,0,0q�$��CharacterEllipsis=����� $# IssuedByName��� & preserve�� $��30��$	��100��$��12(�$, 1,5,0,0q�$��CharacterEllipsis=����� $# DateTimeOutStr��� & preserve�� $��30��$	��100��$��12(�$, 1,5,0,0q�$��CharacterEllipsis=����� $# DateTimeInStr��� & preserve�� $��30��$	��100��$��12(�$, 1,5,0,0q�$��CharacterEllipsis=����� $!# ReturnedByInmateDisplayName��� & preserve  �� $��30��$��95��$��12(�$, 1,5,0,0q�$��CharacterEllipsis=����� $# ReceivedByName��� & preserve�� "   .R��� $! 
Horizontal=�.+��� $��30��$	��100��$��12(�$��1,5,0,0q����� $# 
ToolNumber�$$ TwoWay=��� & preserve  �� $��30��$	��350��$��12(�$��1,5,0,0q����� $# Description�$$ TwoWay=��� & preserve  �� $��ComboBoxShopsForTools��-   $
* Name��$��30��$	��200��$��Center=����� *Shops++ �� $# 	ShopIndex�$$ OneWay=�% �� $# Id��� & preserve  �� $��btnSaveUpdateTool��-   $��30��$��60��% �� $# Id�.���� $! 
Horizontal=�.+��� $��12(�$
��Save��$��0,0,5,0q��� $��14(�$#��../Assests/Fonts/#FontAwesome)�$	����
��� � �$��Center=��� & preserve  �� $��btnDeleteTool��-   $��30��$��60��% �� $# Id�.���� $! 
Horizontal=�.+��� $��12(�$��Delete��$��0,0,5,0q��� $��14(�$#��../Assests/Fonts/#FontAwesome)�$	����
���  ��$��Center=��� "   .R��� $! 
Horizontal=�.+��� $��30��$	��250��$��12(�$��1,5,0,0q����� $
# Name�$$ TwoWay=��� & preserve  �� $��btnSaveUpdateShop��-	   $��30��$��60��% �� $# Id�.���� $! 
Horizontal=�.+��� $��12(�$
��Save��$��0,0,5,0q��� $��14(�$#��../Assests/Fonts/#FontAwesome)�$	����
��� � �$��Center=��� & preserve  �� $��btnDeleteShop��-
   $��30��$��60��% �� $# Id�.���� $! 
Horizontal=�.+��� $��12(�$��Delete��$��0,0,5,0q��� $��14(�$#��../Assests/Fonts/#FontAwesome)�$	����
���  ��$��Center=�.��� ���	#27005AFF �� $��30 ��� $��50 ��� $��* ��� $��25 �.+��� $��1��$��Center=�$��50��$��50��.+��� -   - ��Name$- 
WaitCircle��$��Center=�$��50��$��Center=�$��50��$y�Hidden=�$.��(Assests/Images/ToolTrackerIcon_64x64.png��. J� RenderTransformOrigin$. 0.5,0.5&�z��� / �� Angle$/ 0Q��� -   $
- Wait��$��Center=�$��50��$��Center=�$��50��$y�Hidden=�$.��(Assests/Images/ToolTrackerIcon_64x64.png��$. 0.5,0.5&�z��� $/ 0Q�]� $��0��.+�o� -   0 o�Name$
0 menu��$
��Left=�$��20��$��0,0,0,0q�$	��Top=�$
��1000��.@�m� -   $��MenuItemImportTools��$��Import Tools��1 m� Icon1 �� $'��!Assests/Icons/document-import.png��m� -   $��MenuItemSettings��$��Settings��1 �� $%��Assests/Icons/Settings_48px.png��m� -   $��MenuItemAbout��$��About��1 �� $$��Assests/Icons/help-about-3.png��m� -   $��MenuItemExit��$
��Exit��1 �� $*��$Assests/Icons/application-exit-4.png���� $��1��$(��"Assests/Images/ToolTrackerLogo.png��$
��Fill=�$��54��$	��250��$
��Left=�$��Bottom=�$��20,0,0,0q��� -   $��TextBlockTabHeader��$��1��$��24(�$��40��$��Center=�$��Center=��� $��1��$! 
Horizontal=�$��Right=�$	��Top=�.+��� $��Right=�$	��Top=�2 �� TextAlignment$2 Right=�$��30��$	��250��$��14(�$��DemiBold"�$��0,0,20,0q��� $!��/Assests/Fonts/#FontAwesome)�$��20(�$	����
���iii� �� -   $��TextBlockLoggedInName��$��CharacterEllipsis=��� -   3 ��Name$3 
tabControl��$��2��$��Center=�$��Bottom=�$	��450��$	��950��.@��� -   $��TabItemCheckOutInTools��$��CHECK OUT/IN TOOLS��$��DemiBold"�.���  �� $��10 ��� $��50 ��� $��* �4 � ColumnDefinitions4 �� $��10 ��� $��* ��� $��10 �.+��� $��1��$��1��$
��Left=�$! 
Horizontal=�.+��� $��Shop:��$��30��$��DemiBold"�$��16(��� -   $��comboBoxShops��$	��170��$��30��$��6,6,0,0q�$��0,0,5,5q�$��14(�$��DemiBold"��� $��Inmate:��$��30��$��DemiBold"�$��16(��� -   $��comboBoxInmates��$	��205��$��30��$+ 0��$��6,6,0,0q�$��14(�$��DemiBold"�{�.  �� $��Tool No:��$��30��$��DemiBold"�$��16(�$��5,0,0,0q��� -   $��TextBlockToolNo��$��75��$��30��$��12(�$) 50��$��Center=�$��0,5,0,0q��� -   $��BtnToolNoSearch��$��30��$��30��$��16(�$��DemiBold"�$ ��Assests/Fonts/#FontAwesome)�$	����5 �� 	IsDefault5 . �� $��Checked Out:��$��Center=�$��DemiBold"�$��16(�$��5,0,0,0q��� -   $��TextBlockCheckOutTotal��$
��Bold"�$��20(�
���<��$��2,0,0,0q�$��Center=��� -   $��StackPanelNextPrevButtons��$y�Hidden=�$! 
Horizontal=�$��10,0,0,0q�.+��� -   $��BtnToolCheckedOutBack��$��30��$��30��$��16(�$��DemiBold"�$ ��Assests/Fonts/#FontAwesome)�$	������ -   $��BtnToolCheckedOutNext��$��30��$��30��$��16(�$��5,0,0,0q�$��DemiBold"�$ ��Assests/Fonts/#FontAwesome)�$	����� $��2��$��1��
������� �� $��40 ��� $��* �4 �� $��* �.+��� $! 
Horizontal=�$��Bottom=�$��0��.+��� $��Out/In��$��30��$��50��$��5,10,0,0q�$��12(�$��SemiBold"��� & preserve�� $
��Tool��$��30��$	��250��$��	17,10,0,0q�$��12(�$��SemiBold"��� & preserve  �� $��Tool No.��$��30��$	��100��$��	18,10,0,0q�$��12(�$��SemiBold"��� & preserve  �� $
��Shop��$��30��$	��150��$��	19,10,0,0q�$��12(�$��SemiBold"��� & preserve	       �� $��Inmate��$��30��$	��250��$��	18,10,0,0q�$��12(�$��SemiBold"��� -   $!��ScrollViewerCheckOutInTools��$��1��.���� -   $��listBoxToolsCheckOutIn��#��[ #��[ $	��900��$
��Left=�$��Stretch=��� -    $��TabItemToolsIssued��$��TOOLS ISSUED�����	#FF5B61D6$��DemiBold"�.���  �� $��50 ��� $��* ��� $��40 �.+�� $��0��4 �� $	��375 ��� $��50 ��� $	��150 ��� $��* �.+��� $! 
Horizontal=�.+��� $��Shop:��$��30��$��DemiBold"�$��16(��� -!   $��comboBoxShopsToolsIssued��$	��300��$��30��$��6,6,0,0q�$��14(��� $��1��$��50��$��16(�$��Date:��$��Center=�$��Right=�$2 Right=�(  "System.Windows.Controls.DatePicker  -"   $��DatePickerDate��$��14(�$��2��$��Center=�$	��125��� $��1��
������� �� $��40 ��� $��* �4 �� $��* �.+��� $! 
Horizontal=�$��Bottom=�$��0��.+��� $��Tool No.��$��30��$��78��$��5,10,0,0q�$��12(�$��SemiBold"��� & preserve�� $��Description��$��30��$	��150��$��5,10,0,0q�$��12(�$��SemiBold"��� & preserve�� $��	Issued To��$��30��$	��110��$��5,10,0,0q�$��12(�$��SemiBold"��� & preserve�� $��	Issued By��$��30��$	��105��$��0,10,0,0q�$��12(�$��SemiBold"��� & preserve�� $��Date/Time Out��$��30��$	��100��$��0,10,0,0q�$��12(�$��SemiBold"��� & preserve�� $��Date/Time In��$��30��$	��100��$��0,10,0,0q�$��12(�$��SemiBold"��� & preserve�� $��Returned By��$��30��$	��100��$��0,10,0,0q�$��12(�$��SemiBold"��� & preserve  �� $��Received By��$��30��$��90��$��0,10,0,0q�$��12(�$��SemiBold"��� -#   $��ScrollViewerToolsIssued��$��1��.���� -$   $��ListBoxToolsIssued��#��[ $	��900��$
��Left=�$��Stretch=�$��5,0,0,5q��� $��2�����	#27005AFF�� -%   $��btnPrint��$��2��$��35��$	��125��$��Center=�.���� $! 
Horizontal=�.+��� $��40��$��30(�$��DemiBold"�$��Print��$��Center=��� $��40��$��20(�$��DemiBold"�$, 10,8,0,0q�$ ��Assests/Fonts/#FontAwesome)�
����=H�$	������ -&   $��TabItemInmates��$��INMATES��$��DemiBold"�.��� ���	#FFE5E5E5 �� $��40 ��� $��* �4 �� $��10 ��� $��* ��� $��10 �.+��� -'   6 ��Name$6 btnAddInmate��$��1��$��0��$��30��$	��200��$��20(�$
��Left=�$��Center=�.���� $! 
Horizontal=�.+��� $��20(�$��
ADD INMATE��$��0,0,10,0q��� $��20(�$ ��Assests/Fonts/#FontAwesome)�$	����
��� � �$��Center=�� $��1��$��1��
������� �� $��40 ��� $��* �4 �� $��* �.+��� $! 
Horizontal=�$��Bottom=�$��0��.+��� $��	Last Name��$��30��$	��200��$��5,10,0,0q�$��12(�$��SemiBold"��� & preserve�� $��
First Name��$��30��$	��200��$��5,10,0,0q�$��12(�$��SemiBold"��� & preserve�� $
��GDC#��$��30��$	��100��$��5,10,0,0q�$��12(�$��SemiBold"��� & preserve�� $��Assigned Shop��$��30��$	��200��$��5,10,0,0q�$��12(�$��SemiBold"��� -(   $��ScrollViewerInmates��$��1��.���� -)   $��listBoxUpdateInmates��#��[ $��center=�$	��900��$��	0,0,10,10q��� -*   $��TabItemTools��$��TOOLS��$��DemiBold"�.��� ���	#FFE5E5E5 �� $��40 ��� $��* �4 �� $��10 ��� $	��200 ��� $��* ��� $��10 �.+��� -+   $6 
btnAddTool��$��1��$��0��$��30��$	��200��$��20(�$
��Left=�.���� $! 
Horizontal=�.+��� $��20(�$��ADD TOOL��$��0,0,10,0q��� $��20(�$ ��Assests/Fonts/#FontAwesome)�$	����
��� � �$��Center=�� $��1��$��1��$��2��
������� �� $��40 ��� $��* �4 �� $��* �.+��� $! 
Horizontal=�$��Bottom=�$��0��.+��� $��Tool No.��$��30��$	��100��$��5,10,0,0q�$��12(�$��SemiBold"��� & preserve�� $��Description��$��30��$	��350��$��5,10,0,0q�$��12(�$��SemiBold"��� & preserve�� $��	Shop Name��$��30��$	��125��$��5,10,0,0q�$��12(�$��SemiBold"��� -,   $��ScrollViewerTools��$��1��.���� --   $��listBoxUpdateTools��#��[ $��center=�$	��900��$��	0,0,10,10q��� -.   $��TabItemShops��$��SHOPS��$��DemiBold"�.��� ���	#FFE5E5E5 �� $��40 ��� $��* �4 �� $��10 ��� $	��200 ��� $��* ��� $��10 �.+��� -/   $6 
btnAddShop��$��1��$��0��$��30��$	��200��$��20(�$
��Left=�.���� $! 
Horizontal=�.+��� $��20(�$��ADD SHOP��$��0,0,10,0q��� $��20(�$ ��Assests/Fonts/#FontAwesome)�$	����
��� � �$��Center=�� $��1��$��1��$��2��
������� �� $��40 ��� $��* �4 �� $��* �.+��� $! 
Horizontal=�$��Bottom=�$��0��.+��� $��	Shop Name��$��30��$	��250��$��5,10,0,0q�$��12(�$��SemiBold"��� -0   $��ScrollViewerShops��$��1��.���� -1   $��listBoxUpdateShops��#��[ $��center=�$	��900��$��	0,0,10,10q�