   M S B A M L   `   `   `  ����G  CTicketSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:TicketSystem.Classes.EnumsTicketSystem.Classes.Enums  5      ;"clr-namespace:TicketSystem.ClassesTicketSystem.Classes  5      4    .TicketSystem.Controls.Dialogs.CreateTicketView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NMahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5      4enums(clr-namespace:TicketSystem.Classes.Enums  5      0classes"clr-namespace:TicketSystem.Classes  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      $��20q�5   7     � 	Resources  5      ��%    5      .��5      ��    TextBoxBorderBrush#���   6   $��1q�6>     WindowBackgroundBrush#���  6R    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Opacity$ .3Q�6   ._�5      �  � RowDefinitions 5      �� 5      $��30 �6   �� 5      $��60 �6   �� 5      $��* �6   .+�5      �� $��Create or Edit ticket��6   $��0��6-   $��0��6:     CommonTextStyle#���  6J   $��80��6t   $��18(�5      $
��Bold"�6   �� 5      $��1��6     AccentColorBrush4#���  6   ._�5      � .+�5      ]� ��.  .+�5   	   ��   DashButtonStyle#���  6   $
��Left=�6:   ��6P   �� *AcceptCommand+.��5    
   ]� .+�5!      .  (MahApps.Metro.IconPacks.PackIconMaterial  E AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null�  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null]]   Kind$ CheckboxMarkedCircle=�6&   $��Stretch=�6B   $��26��6`   $��30��6k   $	��Top=�6w   
��� � �5"   &   �� 5#      $��Accept��6   $��Center=�6#   5$      5%   
   �� 5&   	   #���  6   $
��Left=�6:   ��6P   �� *CancelCommand+.��5'   
   ]� .+�5(        $ Cancel=�6&   $��Stretch=�64   $��30��6R   $��30��6]   $	��Top=�6i   
���  ��5)   &   �� 5*      $��Cancel��6   $��Center=�6#   5+      5,   
   5-   	   5.      5/      �� 51      $��Disabled=�6   $
��Auto=�6<   $��2��6_   .��52      �  53      �� 54   	   $
��Auto �6   �� 55   	   $
��Auto �6   �� 56   	   $��* �6   �� 57   	   $
��Auto �6   .+�5:      ]� $��0��6   ��.  $��20,15q�65   .+�5;   	   ]� $	��Top=�6   .+�5<   
   �� $��Ticket Name��6     CommonTextRightAlignStyle#���  6'   $��80��6[   �� 5=   
   -   5        $��textBox��5>        CommonTextBoxStyle#���  5=      ��6?   �� *TicketData.Name+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5>      5?   
   ]� 5@   	   $	��Top=�6   .+�5A   
   �� $��Ticket type��6   #���  6'   $��80��6[   �� 5B   
     CommonComboBoxStyle#���  6    �� DisplayMemberPath$
 Name��6A    �� SelectedValuePath$ ID��6Z   ��6q   �� *
GroupsList+	 �� SelectedValue	 5C      �� *TicketData.GroupID+
 �� SelectedItem
 6:   �� *SelectedGroup+$ PropertyChanged=�$ TwoWay=�5D   
   5E   	   �� 5G      $��1��6   $��Calculating time type��6   $��5q�6=   .��5H   	   ��  �� Orientation$ Vertical=�6   $
��Left=�6+   $��100,0q�6F   .+�5I   
   	� -   5        $��Minute��5I      $��3q�6'    	� 	GroupName$ timeType��62    d� 	IsChecked 5J      ��  �� Path$ TicketData.TimeType�  EnumBooleanConverter �� 	Converter# [ .   (TicketSystem.Classes.Enums.TimerTypeEnum   Minute �� ConverterParameter# Z $ TwoWay=�5K      	� 5L   
   -   5        $��	Intervals��5L      $��3q�6*   $ timeType��65    5M      �� $ TicketData.TimeType�# [    Interval# Z $ TwoWay=�5N      	� 5O   
   -   5        $��No limit��5O      $��3q�6)   $ timeType��64    5P      �� $ TicketData.TimeType�# [    NoLimit# Z $ TwoWay=�5Q      5R   
   5S   	   �� 5U      $��2��6   $��5q�6   ��6)   �� *TimeTypeHeaderText+ �� FallbackValue$ No Limit��.��5V   	   � .+�5W   
   ]� ��.  $
��10,0q�6�   y�6   �� *TimerTypeMinuteVisibility+$ PropertyChanged=�$ 	Collapsed��.+�5X      �  � ColumnDefinitions 5Y      �� 5Z      $��* �6   �� 5[      $��* �6    5]      �� 5^      $
��Auto �6   �� 5_      $
��Auto �6   �� 5`      $
��Auto �6   .+�5b      ]� $��0��6   ��.  .+�5c      ]� $	��Top=�6   .+�5d      �� $��Gross price��6   #���  6,   $��80��6`   �� 5e      #���  6   $	��100��5f      $
��Left=�6#   (   "TicketSystem.Classes.TextBoxHelper   OnlyNumeric$
 Uint=�6>   ��5e   D   �� *&$TicketData.TypeMinuteItem.GrossPrice+$ PropertyChanged=�$ TwoWay=�5f   >   5g      ]� 5h      $	��Top=�6   .+�5i      �� $��	Extra pay��6   #���  6*   $��80��6^   �� 5j      #���  6   $	��100��5k      $
��Left=�6#   $
 Uint=�6>   ��5j   D   �� *$"TicketData.TypeMinuteItem.ExtraPay+$ PropertyChanged=�$ TwoWay=�5k   >   5l      ]� 5m      $	��Top=�6   .+�5n      �� $��VAT (%)��6   #���  6(   $��80��6\   �� 5o      #���  6   $	��100��5p      $
��Left=�6$    �� 
IsEditable .  �� Text 5o   F   �� *TicketData.TypeMinuteItem.VAT+ �� StringFormat$ N0��$ PropertyChanged=�$ TwoWay=���5p   ?   �� *	VatList+6_   5q      5r      ]� 5t      $��1��6   ��.  .+�5u      ]� $	��Top=�6   .+�5v      �� $	��For��6   #���  6$   $��80��6X   �� 5w      $��minutes��6   #���  6(   $��80��6R   $��Right=�6`   �� 5x      #���  6   $	��100��5y      $
��Left=�6#   $
 Uint=�6>   ��5x   D   �� *&$TicketData.TypeMinuteItem.ForMinutes+$ PropertyChanged=�$ TwoWay=�5y   >   5z      ]� 5{      $	��Top=�6   .+�5|      �� $��For next��6   #���  6)   $��80��6]   �� 5}      $��minutes��6   #���  6(   $��80��6R   $��Right=�6`   �� 5~      #���  6   $	��100��5      $
��Left=�6#   $
 Uint=�6>   ��5~   D   �� **(TicketData.TypeMinuteItem.ForNextMinutes+$ PropertyChanged=�$ TwoWay=�5   >   5�      ]� 5�      $	��Top=�6   .+�5�      �� $��Discount (%)��6   #���  6-   $��80��6a   �� 5�      #���  6   $	��100��5�      $
��Left=�6$    .  5�   F   �� *$"TicketData.TypeMinuteItem.Discount+$ N0��$ PropertyChanged=�$ TwoWay=���5�   ?   �� *	VatList+6_   5�      5�      �� 5�       	 CommonCheckboxStyle#��� 	 6   $=��7Fixed price after exceeding a certain number of minutes��6D   $��2��5�      $��0��6*   $��1��6:   $
��95,5q�6G    6U   �� *(&TicketData.TypeMinuteItem.IsFixedPrice+]� 5�      $��2��6   $��0��6$   ��.  {�6J   �� *(&TicketData.TypeMinuteItem.IsFixedPrice+$ PropertyChanged=�$ OneWay=�.+�5�      ]� $	��Top=�6   .+�5�      �� $��Above��6   #���  6&   $��80��6Z   �� 5�      $��minutes��6   #���  6(   $��80��6R   $��Right=�6`   �� 5�      #���  6   $	��100��5�      $
��Left=�6#   $
 Uint=�6>   ��5�   D   �� *,*TicketData.TypeMinuteItem.FromMinutesAbove+$ PropertyChanged=�$ TwoWay=�5�   >   5�      5�      ]� 5�      $��2��6   $��1��6$   ��.  {�6J   �� *(&TicketData.TypeMinuteItem.IsFixedPrice+$ PropertyChanged=�$ OneWay=�.+�5�      ]� $	��Top=�6   .+�5�      �� $��Gross price��6   #���  6,   $��80��6`   �� 5�      #���  6   $	��100��5�      $
��Left=�6#   $
 Uint=�6>   ��5�   D   �� *+)TicketData.TypeMinuteItem.GrossPriceAbove+$ PropertyChanged=�$ TwoWay=�5�   >   5�      5�      5�      5�      ]� 5�   
   ��.  $
��10,0q�6�   y�6   �� *TimerTypeIntervalVisibility+$ PropertyChanged=�$ Visible��.+�5�      �  5�      �� 5�      $
��Auto �6   �� 5�      $
��Auto �6   �� 5�      $
��Auto �6   .+�5�      ]� $��0��6   ��.  .+�5�      ]� $	��Top=�6   {�6,   �� *$"TicketData.TypeIntervalItem.ThingA+$
 true��.+�5�      �� $
��From��6   #���  6$   $��80��6X   �� 5�      $��minutes��6   #���  6'   $��80��6Q   $��Right=�6_   �� 5�      #���  6   $	��100��5�      $
��Left=�6"   $
 Uint=�6=   ��5�   C   �� **(TicketData.TypeIntervalItem.FromMinutes1+$ PropertyChanged=�$ TwoWay=�.��5�   f   5�      5�      ]� 5�      $	��Top=�6   {�6,   �� *$"TicketData.TypeIntervalItem.ThingB+$
 true��.+�5�      �� $
��From��6   #���  6$   $��80��6X   �� 5�      $��minutes��6   #���  6'   $��80��6Q   $��Right=�6_   �� 5�      #���  6   $	��100��5�      $
��Left=�6"   $
 Uint=�6=   ��5�   C   �� **(TicketData.TypeIntervalItem.FromMinutes2+$ PropertyChanged=�$ TwoWay=�5�   =   5�      ]� 5�      $	��Top=�6   {�6,   �� *$"TicketData.TypeIntervalItem.ThingC+$
 true��.+�5�      �� $
��From��6   #���  6$   $��80��6X   �� 5�      $��minutes��6   #���  6'   $��80��6Q   $��Right=�6_   �� 5�      #���  6   $	��100��5�      $
��Left=�6"   $
 Uint=�6=   ��5�   C   �� **(TicketData.TypeIntervalItem.FromMinutes3+$ PropertyChanged=�$ TwoWay=�5�   =   5�      ]� 5�      $	��Top=�6   {�6-   �� *$"TicketData.TypeIntervalItem.ThingD+$
 true��.+�5�      �� $
��From��6   #���  6$   $��80��6X   �� 5�      $��minutes��6   #���  6'   $��80��6Q   $��Right=�6_   �� 5�      #���  6   $	��100��5�      $
��Left=�6"   $
 Uint=�6=   ��5�   C   �� **(TicketData.TypeIntervalItem.FromMinutes4+$ PropertyChanged=�$ TwoWay=�5�   =   5�      ]� 5�      $	��Top=�6   .+�5�      �� $��Above��6   #���  6%   $��80��6Y   �� 5�      $��minutes��6   #���  6'   $��80��6Q   $��Right=�6_   �� 5�      #���  6   $	��100��5�      $
��Left=�6"   $
 Uint=�6=   ��5�   C   �� *.,TicketData.TypeIntervalItem.FromMinutesAbove+$ PropertyChanged=�$ TwoWay=�5�   =   5�      ]� 5�      $	��Top=�6   $��0,10,0,0q�6,   .+�5�      �� $��VAT (%)��6   #���  6'   $��80��6[   �� 5�      #���  6   $	��100��5�      $
��Left=�6#    .  5�   E   �� *!TicketData.TypeIntervalItem.VAT+$ N0��$ PropertyChanged=�$ TwoWay=���5�   >   �� *	VatList+6^   5�      5�      ]� 5�      $��1��6   ��.  .+�5�      ]� $	��Top=�6   {�6,   �� *$"TicketData.TypeIntervalItem.ThingA+$
 true��.+�5�      �� $��Gross Price��6   #���  6+   $��80��6_   �� 5�      #���  6   $	��100��5�      $
��Left=�6"   $
 Uint=�6=   ��5�   C   �� *)'TicketData.TypeIntervalItem.GrossPrice1+$ PropertyChanged=�$ TwoWay=�.��5�   f   5�      5�      ]� 5�      $	��Top=�6   {�6,   �� *$"TicketData.TypeIntervalItem.ThingB+$
 true��.+�5�      �� $��Gross Price��6   #���  6+   $��80��6_   �� 5�      #���  6   $	��100��5�      $
��Left=�6"   $
 Uint=�6=   ��5�   C   �� *)'TicketData.TypeIntervalItem.GrossPrice2+$ PropertyChanged=�$ TwoWay=�5�   =   5�      ]� 5�      $	��Top=�6   {�6,   �� *$"TicketData.TypeIntervalItem.ThingC+$
 true��.+�5�      �� $��Gross Price��6   #���  6+   $��80��6_   �� 5�      #���  6   $	��100��5�      $
��Left=�6"   $
 Uint=�6=   ��5�   C   �� *)'TicketData.TypeIntervalItem.GrossPrice3+$ PropertyChanged=�$ TwoWay=�5�   =   5�      ]� 5�      $	��Top=�6   {�6,   �� *$"TicketData.TypeIntervalItem.ThingD+$
 true��.+�5�      �� $��Gross Price��6   #���  6+   $��80��6_   �� 5�      #���  6   $	��100��5�      $
��Left=�6"   $
 Uint=�6=   ��5�   C   �� *)'TicketData.TypeIntervalItem.GrossPrice4+$ PropertyChanged=�$ TwoWay=�5�   =   5�      ]� 5�      $	��Top=�6   .+�5�      �� $��Gross Price��6   #���  6+   $��80��6_   �� 5�      #���  6   $	��100��5�      $
��Left=�6"   $
 Uint=�6=   ��5�   C   �� *-+TicketData.TypeIntervalItem.GrossPriceAbove+$ PropertyChanged=�$ TwoWay=�5�   =   5�      ]� 5�      $	��Top=�6   $��0,10,0,0q�6,   .+�5�      �� $��Discount (%)��6   #���  6,   $��80��6`   �� 5�      #���  6   $	��100��5�      $
��Left=�6#    .  5�   E   �� *&$TicketData.TypeIntervalItem.Discount+$ N0��$ PropertyChanged=�$ TwoWay=���5�   >   �� *DiscountList+6c   5�      5�      ]� 5�      $��2��6   ��.  $	��Top=�6<   $��20,0,0,0q�6T   .+�5�      �� #��� 	 6   $��
Interval A��6D   $	��Top=�5�   O    6   �� *$"TicketData.TypeIntervalItem.ThingA+6O   �� 5�      #��� 	 6   $��
Interval B��6D   $	��Top=�5�   O    6   �� *$"TicketData.TypeIntervalItem.ThingB+6O   �� 5�      #��� 	 6   $��
Interval C��6D   $	��Top=�5�   O    6   �� *$"TicketData.TypeIntervalItem.ThingC+6O   �� 5�      #��� 	 6   $��
Interval D��6D   $	��Top=�5�   O    6   �� *$"TicketData.TypeIntervalItem.ThingD+6O   5�      5�      5�      ]� 5�   
   ��.  $��100,0q�6�   y�6   �� *TimerTypeNoLimitVisibility+$ PropertyChanged=�$ 	Collapsed��.+�5�      ]� $	��Top=�6   .+�5�      �� $��Gross price��6   #���  6)   $��80��6]   �� 5�      #���  6   $	��100��5      $
��Left=�6   $
 Uint=�65   ��5�   A   �� *'%TicketData.TypeNoLimitItem.GrossPrice+$ PropertyChanged=�$ TwoWay=�5   5   5     ]� 5     $	��Top=�6   .+�5     �� $��VAT (%)��6   #���  6%   $��80��6Y   �� 5     #���  6   $	��100��5     $
��Left=�6    .  5  C   �� * TicketData.TypeNoLimitItem.VAT+$ N0��$ PropertyChanged=�$ TwoWay=���5  6   �� *	VatList+6V   5     ]� 5     $	��Top=�6   .+�5     �� $��Discount (%)��6   #���  6*   $��80��6^   �� 5	     #���  6   $	��100��5
     $
��Left=�6    .  5	  C   �� *%#TicketData.TypeNoLimitItem.Discount+$ N0��$ PropertyChanged=�$ TwoWay=���5
  6   �� *DiscountList+6[   5     5     5  
   5  	   �� 5     $��3��6   $��5q�6   $��Applies to days��6)   .��5  	   �  5  
   �� 5     $��* �6   �� 5     $��* �6   �� 5     $��* �6   .+�5  
   ]� $��0��6   ��.  $��	100,0,0,0q�6:   .+�5     �� #��� 	 6   $��Monday��6B   $	��Top=�5  <    6   �� *TicketData.Monday+6<   �� 5     #��� 	 6   $��Tuesday��6B   $	��Top=�5  =    6   �� *TicketData.Tuesday+6=   �� 5     #��� 	 6   $��	Wednesday��6B   $	��Top=�5  ?    6   �� *TicketData.Wednesday+6?   5     ]� 5  
   $��1��6   ��.  $��50,0,0,0q�6:   .+�5     �� #��� 	 6   $��Thursday��6B   $	��Top=�5   >    6   �� *TicketData.Thursday+6>   �� 5!     #��� 	 6   $��Friday��6B   $	��Top=�5"  <    6   �� *TicketData.Friday+6<   �� 5#     #��� 	 6   $��Saturday��6B   $	��Top=�5$  >    6   �� *TicketData.Saturday+6>   5%     ]� 5&  
   $��2��6   ��.  .+�5'     �� #��� 	 6   $��Sunday��6B   $	��Top=�5(  <    6   �� *TicketData.Sunday+6<   �� 5)     #��� 	 6   $	��All��6B   $	��Top=�5*  =    6   �� *TicketData.AllDays+6=   5+     5-  
   5.  	   5/     50     52     53     55     