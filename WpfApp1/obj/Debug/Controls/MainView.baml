   M S B A M L   `   `   `  ����  TicketSystem$    TicketSystem.Controls.MainView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NMahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��* �6   $	��350��6&   �� 5      $��10 �6   �� 5      $��* �6   $	��350��6&    � RowDefinitions 5      �� 5      $
��Auto �6   �� 5      $��* �6   .+�5      �� $��ENTRANCE MONITORING��6   $��Center=�6)   $��Center=�6F   $��16(�5      $
��Bold"�6   � 5      $��1��6	   $��0��6    5      �� 5      $
��Auto �6   �� 5      $��* �6   .+�5      &   System.Windows.Controls.DataGrid  $��1��6      AutoGenerateColumns .     CanUserAddRows .     CanUserResizeRows .     EnableRowVirtualization .    HeadersVisibility$ Column=�5         
IsReadOnly .    SelectionMode$ Single=�6;   	   SelectionUnit$	 FullRow=�6R   
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 5       $��5q�6      AccentColorBrush4   AlternatingRowBackground# �   6)   ��5      �� *MonitoringList+ �� SelectedItem 5!      �� *SelectedMonitoringItem+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ Entry ID��66   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6   �� *	EntryID+66     5$      $ 
Entry Time��6?      Width$ 90 6S    6   �� *EntryTimeDisplay+6S     5%      $
 Time��6X   $ 60 6f    6   �� *Time+$ PropertyChanged=�6f     5&      $ Total Price��6K   $	 100 6`    6   �� *ActualPrice+ �� StringFormat$ N2��6`   5(      5)      �� 5+      $��1��6   $��0��6$   $��2��61    �� ResizeDirection$ Columns=�6B    �� ResizeBehavior$ PreviousAndNext=�6\   $��Stretch=�5,      $��5��60     AccentColorBrush3#���  6:   $	��1,5q�6k   �� 5.      $��LOGGED��6   $��Center=�6   $��Center=�6<   $��16(�5/      $
��Bold"�6   $��0��61   $��2��6>   � 51      $��1��6	   $��2��6    52      �� 53      $
��Auto �6   �� 54      $��* �6   �� 55      $
��Auto �6   �� 56      $
��Auto �6   .+�58        $��0��6   $��0��6    .   .   .   . $ Column=�5:       . $ Single=�6;   $	 FullRow=�6R   $
 * 5;      $   HorizontalScrollBarVisibility$ Hidden=�6   $��5q�6E   $��80��6P   ��58   +   �� *LoggedUsersList+ 5<        5=      $ Surname��66    6   �� *	Surname+66     5>      $ 	Firstname��68    6   �� *	Firstname+68     5?      $  Login Time��6D   $ 60 6Y    6   �� *Session.LoginTimeText+6Y     5@      $ 	Work Time��6d   $	 100 6w    6   �� *Session.WorkTime+$ PropertyChanged=�6w   5B      �� 5D      $��1��6   $
��Left=�6   $
��Left=�68   $��Center=�6N   .+�5E      ��   DashButtonStyle#���  6   $��70��6i   $��5q�5F      $	��200��6   $
��Left=�6$   $
��30,0q�6F   ��5E   C   �� *ProductBuyCommand+.��5G      �   5H      �� 5I      $
��Auto �6/   �� 5J      $��* �6/   .+�5L      .  (MahApps.Metro.IconPacks.PackIconMaterial  E AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null�  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null]]   Kind$ CircleEditOutline=�65   $��Stretch=�6N   $��30��6l   $��30��6w   $
��Left=�6�   
��� � �5M   &   �� 5N      $��1��6$   $
��Edit��64   $��Center=�6@   $��Center=�6]   $��20(�6x   $
��10,0q�6�   5O      5P      �� 5Q      #���  6   $��20��6g   $��5q�5R      $	��200��6   $
��Left=�6$   $
��30,0q�6F   ��5Q   C   �� *RegisterCommand+.��5S      �   5T      �� 5U   	   $
��Auto �6   �� 5V   	   $��* �6   .+�5X      1  +MahApps.Metro.IconPacks.PackIconFontAwesome  �	  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconFontAwesomeKind, MahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null]] 	  Kind$ RegisteredRegular=�6&   $��Stretch=�6?   $��30��6]   $��30��6h   $
��Left=�6t   
��� � �5Y   &   �� 5Z      $��1��6   $��Register��6"   $��Center=�62   $��Center=�6O   $��20(�6j   $
��10,0q�6x   5[      5\      �� 5]      #���  6   $
��Left=�67   $��21��6r   $��5q�5^      $	��200��6   $
��Left=�6$   $
��30,0q�6F   ��5]   M   �� *ExitEntryCommand+.��5_      ]� .+�5`      �   5a   	   �� 5b   
   $
��Auto �6   �� 5c   
   $��* �6   .+�5e   	     $ TimesCircleSolid=�6'   $��Stretch=�6?   $��30��6]   $��30��6h   $
��Left=�6t   
���  ��$��Center=�5f   7   �� 5g   	   $��1��6   $
��Exit��6#   $��Center=�6/   $��Center=�6L   $��20(�6g   $
��10,0q�6u   5h   	   5i      5j      5k      �� 5o      $��Monitoring Information��6   $��2��6.   $��5q�6;   .��5p      ]� ��.  .+�5q      ]� $	��Top=�6   .+�5r      �� $��People count��6     CommonTextRightAlignStyle#���  6&   $	��150��6[   �� 5s        CommonTextBoxStyle#���  6    �� 
IsReadOnly . ��6=   �� *TerminalData.PeoplesCount+$ PropertyChanged=�$ OneWay=�6�   5t      ]� 5u      $	��Top=�6   .+�5v      �� $��Average length of stay��6   #���  60   $	��150��6d   �� 5w      #���  6    . ��6=   �� *&$TerminalData.AverageLengthOfStayText+$ PropertyChanged=�$ OneWay=�6�   5x      5y      5z      �� 5{      $��Terminal Information��6   $��3��6,   $��5q�69   .��5|      ]� ��.  .+�5}      ]� $	��Top=�6   .+�5~      �� $
��Name��6   #���  6   $	��150��6S   �� 5      #���  6    . ��6=   �� *TerminalData.Name+$ PropertyChanged=�$ OneWay=�6�   5�      ]� 5�      $	��Top=�6   .+�5�      �� $��Total Income ($)��6   #���  6*   $	��150��6_   �� 5�      #���  6    . ��6=   �� *TerminalData.TotalIncome+$ N2��$ PropertyChanged=�$ OneWay=�6�   5�      5�      5�      5�      5�      5�      