   M S B A M L   `   `   `  ����G  CTicketSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:TicketSystem.Controls.DialogsTicketSystem.Controls.Dialogs  5      ;"clr-namespace:TicketSystem.ClassesTicketSystem.Classes  5      0    *TicketSystem.Controls.Dialogs.RegisterView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:TicketSystem.Controls.Dialogs     5      R NMahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5      0classes"clr-namespace:TicketSystem.Classes  5      .��5      ��    TextBoxBorderBrush#���   6	   $��1q�6<     WindowBackgroundBrush#���  6P     J� Effect  5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Opacity$ .3Q�6   ._�5      �  � RowDefinitions 5      �� 5      $��30 �6   �� 5      $��60 �6   �� 5      $��* �6   .+�5      �� $��Register��6   $��0��6   $��0��6,     CommonTextStyle#���  6<   $��80��6f   $��18(�5      $
��Bold"�6   �� 5      $��1��6     AccentColorBrush4#���  6   $��0��6J   ._�5      � .+�5      ]� ��.  .+�5      ��   DashButtonStyle#���  6   $
��Left=�69   ��6O   �� *AcceptCommand+.��5   	   ]� .+�5   
   .  (MahApps.Metro.IconPacks.PackIconMaterial  E AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null�  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null]]   Kind$ CheckboxMarkedCircle=�6%   $��Stretch=�6A   $��26��6_   $��30��6j   $	��Top=�6v   
��� � �5   %   �� 5    
   $��Accept��6   $��Center=�6"   5!   
   5"   	   �� 5#      #���  6   $
��Left=�69   ��6O   �� *CancelCommand+.��5$   	   ]� .+�5%   
     $ Cancel=�6%   $��Stretch=�63   $��30��6Q   $��30��6\   $	��Top=�6h   
���  ��5&   %   �� 5'   
   $��Cancel��6   $��Center=�6"   5(   
   5)   	   5*      5+      5,      �� 5-      $��2��6   $��Disabled=�6   $
��Auto=�6H   .��5.      �  5/      �� 50      $
��Auto �6   �� 51      $
��Auto �6   �� 52      $
��Auto �6   �� 53      $��* �6   �� 54      $
��Auto �6   �� 55      $
��Auto �6   �� 56      $
��Auto �6    � ColumnDefinitions 58      �� 59      $��* �6   �� 5:      $��* �6   .+�5<   
   �� $��Ticket type��6   $��2��6'   $��0��64   #���  6D   $��80��6n   �� 5=      $��Ticket name��6   $��2��6"   $��1��6/   #���  6?   $��80��6i   �� 5?      -   5        $��listBox��5@   M   $��3��5?      $��0��6   $��5q�6*    �� DisplayMemberPath$
 Name��5@       �� SelectedValuePath$ ID��6&   $	��150��6=   ��5?   5   �� *
GroupsList+ �� SelectedItem 6X   �� *SelectedGroup+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=�5A      �� 5C      $��3��6   $��1��6   $��5q�6*   $
 Name��5D      $ ID��6&   $	��150��5E      ��5C   5   �� *TicketsList+ 6Y   �� *SelectedTicket+$ PropertyChanged=�$	 TwoWay=�
 �� SelectedValue
 5D   =   �� *Item.TicketItemID+$ PropertyChanged=�5F      �� 5H      $��3��6   $��2��6   $��0��62   $��Center=�6B   $��Center=�6]   $>��8There are no tickets available for this day of the week!��5I      $��28(�6Q   $
��Bold"�6_   
���  ��y�5J   "   �� *NoTicketsWarningVisibility+$ PropertyChanged=�$	 OneWay=�]� 5L      $��4��6   $��2��6   $��0��60   ��.  $
��45,5q�6V   .+�5M      ]� $	��Top=�6   .+�5N      �� $��Entry ID��6     CommonTextRightAlignStyle#���  6!   $	��100��6U   �� 5O        CommonComboBoxStyle#���  6    �� 
IsEditable .  �� Text 6>   �� *Item.EntryID+$ PropertyChanged=�$	 TwoWay=���5P   "   �� *	ItemsList+5Q      ]� 5R      $	��Top=�6   .+�5S      �� $��	Deposit $��6   #���  6"   $	��100��6V   �� 5T        CommonTextBoxStyle#���  6   $	��150��5U      $
��Left=�6   (   "TicketSystem.Classes.TextBoxHelper   OnlyNumeric$
 Uint=�66   ��5T   <   �� *Item.Deposit+$ PropertyChanged=�$	 TwoWay=�5U   6   5V      ]� 5W      $	��Top=�6   ��.  .+�5X      ]� $
��Left=�6   .+�5Y      �� $��Payment method��6   #���  6(   $	��100��6\   �� 5Z      #���  6   $	 Key��5[      $ Value��6(   $	��150��6B   
 5Z   ?   �� *Item.PaymentMethod+$ PropertyChanged=�$	 TwoWay=���5[   N   �� *PaymentMethodsList+5\      ]� 5]      $	��Top=�6   .+�5^      �� $��Number of tickets��6   #���  6+   $	��100��6_   �� 5_      #���  6   $	��150��5`      $
��Left=�6   $
 Uint=�67   ��5_   =   �� *Item.NumberOfTickets+$ PropertyChanged=�$	 TwoWay=�5`   7   5a      5c      5d      ]� 5f      $��5��6   $��2��6   $��0��60   ��.  $��155,5q�6V   .+�5g      ��   CommonCheckboxStyle#���  6   $;��5permission for the child to take drinks independently��6=   $	��Top=�5h   7    d� 	IsChecked 6	   �� *Item.PermForChildDrinks+67   �� 5i      #���  6   $7��1permission for the child to take food for himself��6=   $	��Top=�5j   5    6	   �� *Item.PermForChildFood+65   5k      �� 5m      $��6��6   $��2��6   $��0��6/   $��5q�6?   $��Ticket details��5n      .��5o      ]� ��.  {�.  .+�5p      ]� $	��Top=�6   .+�5q      �� $��Calculating time type��6   #���  6/   $	��120��6c   �� 5r      #���  6   ��6=   �� *SelectedTicket.TimeTypeText+$ PropertyChanged=�$	 OneWay=�5s      ]� 5t      $	��Top=�6   ��.  y�6<   �� *RegisterMinutesVisibility+ �� FallbackValue$ 	Collapsed��.+�5u      ]� $	��Top=�6   ��.  .+�5v   	   ]� $
��Left=�6   .+�5w   
   �� $��Gross price��6   #���  6'   $	��120��6[   �� 5x   
   #���  6   $	��150��5y      ��5x   ?   �� *SelectedTicket.GrossPrice+$ PropertyChanged=�$	 OneWay=�5y      5z   
   ]� 5{   	   $	��Top=�6   ��.  .+�5|   
   �� $	��For��6   #���  6   $��70��6S   �� 5}   
   #���  6   $	��150��5~      $
��Left=�6   ��5}   ?   �� *SelectedTicket.ForMinutes+$ PropertyChanged=�$	 OneWay=�5~      �� 5   
   $��minutes��6   #���  6#   $��80��6M   5�   
   5�   	   ]� 5�      $	��Top=�6   ��.  .+�5�   	   ]� $
��Left=�6   .+�5�   
   �� $��	Extra pay��6   #���  6%   $	��120��6Y   �� 5�   
   #���  6   $	��150��5�      ��5�   ?   �� *SelectedTicket.ExtraPay+$ PropertyChanged=�$	 OneWay=�5�      5�   
   ]� 5�   	   $	��Top=�6   ��.  .+�5�   
   �� $��For next��6   #���  6$   $��70��6X   �� 5�   
   #���  6   $	��150��5�      $
��Left=�6   ��5�   ?   �� *SelectedTicket.ForNext+$ PropertyChanged=�$	 OneWay=�5�      �� 5�   
   $��minutes��6   #���  6#   $��80��6M   5�   
   5�   	   5�      ]� 5�      $	��Top=�6   ��.  y�6<   �� *RegisterIntervalVisibility+$ 	Collapsed��.+�5�      � $��40,0,0,0q�6    5�   	   �� 5�   
   $
��Auto �6   �� 5�   
   $
��Auto �6   .+�5�   	   ]� $��0��6   ��.  .+�5�   
   ]� $	��Top=�6   y�6)   �� *(&SelectedTicket.TypeIntervalItem.ThingA+$ Visible��$	 OneWay=�  	 BooleanToVisibilityConverter �� 	Converter# [	 .+�5�      �� $
��From��6   #���  6!   $��80��6U   �� 5�      $��minutes��6   #���  6$   $��80��6N   $��Right=�6\   �� 5�      #���  6   $	��100��5�      $
��Left=�6   $
 Uint=�64   ��5�   @   �� *.,SelectedTicket.TypeIntervalItem.FromMinutes1+$ PropertyChanged=�$	 OneWay=�.��5�   ]   5�      5�      ]� 5�   
   $	��Top=�6   y�6)   �� *(&SelectedTicket.TypeIntervalItem.ThingB+$ Visible��$	 OneWay=�# [	 .+�5�      �� $
��From��6   #���  6!   $��80��6U   �� 5�      $��minutes��6   #���  6$   $��80��6N   $��Right=�6\   �� 5�      #���  6   $	��100��5�      $
��Left=�6   $
 Uint=�64   ��5�   @   �� *.,SelectedTicket.TypeIntervalItem.FromMinutes2+$ PropertyChanged=�$	 OneWay=�5�   4   5�      ]� 5�   
   $	��Top=�6   y�6)   �� *(&SelectedTicket.TypeIntervalItem.ThingC+$ Visible��$	 OneWay=�# [	 .+�5�      �� $
��From��6   #���  6!   $��80��6U   �� 5�      $��minutes��6   #���  6$   $��80��6N   $��Right=�6\   �� 5�      #���  6   $	��100��5�      $
��Left=�6   $
 Uint=�64   ��5�   @   �� *.,SelectedTicket.TypeIntervalItem.FromMinutes3+$ PropertyChanged=�$	 OneWay=�5�   4   5�      ]� 5�   
   $	��Top=�6   y�6*   �� *(&SelectedTicket.TypeIntervalItem.ThingD+$ Visible��$	 OneWay=�# [	 .+�5�      �� $
��From��6   #���  6!   $��80��6U   �� 5�      $��minutes��6   #���  6$   $��80��6N   $��Right=�6\   �� 5�      #���  6   $	��100��5�      $
��Left=�6   $
 Uint=�64   ��5�   @   �� *.,SelectedTicket.TypeIntervalItem.FromMinutes4+$ PropertyChanged=�$	 OneWay=�5�   4   5�      ]� 5�   
   $	��Top=�6   .+�5�      �� $��Above��6   #���  6"   $��80��6V   �� 5�      $��minutes��6   #���  6$   $��80��6N   $��Right=�6\   �� 5�      #���  6   $	��100��5�      $
��Left=�6   $
 Uint=�64   ��5�   @   �� *20SelectedTicket.TypeIntervalItem.FromMinutesAbove+$ PropertyChanged=�$	 OneWay=�5�   4   5�      ]� 5�   
   $	��Top=�6   $��0,10,0,0q�6)   .+�5�      �� $��VAT (%)��6   #���  6$   $��80��6X   �� 5�      #���  6   $	��100��5�      $
��Left=�6    .  5�   B   �� *%#SelectedTicket.TypeIntervalItem.VAT+ �� StringFormat$ N0��$ PropertyChanged=�$	 OneWay=�5�   4   5�      5�   
   ]� 5�   	   $��1��6   ��.  .+�5�   
   ]� $	��Top=�6   y�6)   �� *(&SelectedTicket.TypeIntervalItem.ThingA+$ Visible��$	 OneWay=�# [	 .+�5�      �� $��Gross Price��6   #���  6(   $��80��6\   �� 5�      #���  6   $	��100��5�      $
��Left=�6   $
 Uint=�64   ��5�   @   �� *-+SelectedTicket.TypeIntervalItem.GrossPrice1+$ PropertyChanged=�$	 OneWay=�.��5�   ]   5�      5�      ]� 5�   
   $	��Top=�6   y�6)   �� *(&SelectedTicket.TypeIntervalItem.ThingB+$ Visible��$	 OneWay=�# [	 .+�5�      �� $��Gross Price��6   #���  6(   $��80��6\   �� 5�      #���  6   $	��100��5�      $
��Left=�6   $
 Uint=�64   ��5�   @   �� *-+SelectedTicket.TypeIntervalItem.GrossPrice2+$ PropertyChanged=�$	 OneWay=�5�   4   5�      ]� 5�   
   $	��Top=�6   y�6)   �� *(&SelectedTicket.TypeIntervalItem.ThingC+$ Visible��$	 OneWay=�# [	 .+�5�      �� $��Gross Price��6   #���  6(   $��80��6\   �� 5�      #���  6   $	��100��5�      $
��Left=�6   $
 Uint=�64   ��5�   @   �� *-+SelectedTicket.TypeIntervalItem.GrossPrice3+$ PropertyChanged=�$	 OneWay=�5�   4   5�      ]� 5�   
   $	��Top=�6   y�6)   �� *(&SelectedTicket.TypeIntervalItem.ThingD+$ Visible��$	 OneWay=�# [	 .+�5�      �� $��Gross Price��6   #���  6(   $��80��6\   �� 5�      #���  6   $	��100��5�      $
��Left=�6   $
 Uint=�64   ��5�   @   �� *-+SelectedTicket.TypeIntervalItem.GrossPrice4+$ PropertyChanged=�$	 OneWay=�5�   4   5�      ]� 5�   
   $	��Top=�6   .+�5�      �� $��Gross Price��6   #���  6(   $��80��6\   �� 5�      #���  6   $	��100��5�      $
��Left=�6   $
 Uint=�64   ��5�   @   �� *1/SelectedTicket.TypeIntervalItem.GrossPriceAbove+$ PropertyChanged=�$	 OneWay=�5�   4   5�      ]� 5�   
   $	��Top=�6   $��0,10,0,0q�6)   .+�5�      �� $��Discount (%)��6   #���  6)   $��80��6]   �� 5�      #���  6   $	��100��5�      $
��Left=�6    .  5�   B   �� **(SelectedTicket.TypeIntervalItem.Discount+$ N0��$ PropertyChanged=�$	 OneWay=�5�   4   5�      5�   
   5�   	   5�      ]� 5�      $	��Top=�6   ��.  $��40,0,0,0q�5�      y�5�   <   �� *RegisterNoLimitVisibility+$ Visible��.+�5�      ]� $
��Left=�6   .+�5�   	   �� $��Gross price��6   #���  6&   $��80��6Z   �� 5�   	   #���  6   $	��100��5�      $
��Left=�6   $
 Uint=�68   ��5�   >   �� *+)SelectedTicket.TypeNoLimitItem.GrossPrice+$ PropertyChanged=�$	 OneWay=�5�   8   5�   	   ]� 5�      $
��Left=�6   .+�5�   	   �� $��VAT (%)��6   #���  6"   $��80��6V   �� 5�   	   #���  6   $	��100��5�      $
��Left=�6    .  5�   @   �� *$"SelectedTicket.TypeNoLimitItem.VAT+$ N0��$ PropertyChanged=�$	 OneWay=�5�   9   5�   	   ]� 5�      $
��Left=�6   .+�5�   	   �� $��Discount (%)��6   #���  6'   $��80��6[   �� 5�   	   #���  6   $	��100��5�      $
��Left=�6    .  5�   @   �� *)'SelectedTicket.TypeNoLimitItem.Discount+$ N0��$ PropertyChanged=�$	 OneWay=�5�   9   5�   	   5�      5�      5�      5�      5�      5�      5�      5�      