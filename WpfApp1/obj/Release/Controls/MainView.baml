   M S B A M L   `   `   `  ����   TicketSystem$    TicketSystem.Controls.MainView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     R NMahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  .���   � ColumnDefinitions  �� $��* �$	��350���� $��10 ��� $��* �$	��350�� � RowDefinitions �� $
��Auto ��� $��* �.+��� $��ENTRANCE MONITORING��$��Center=�$��Center=�$��16(�$
��Bold"�� $��1��$��0�� �� $
��Auto ��� $��* �.+�&   System.Windows.Controls.DataGrid  $��1��   AutoGenerateColumns .     CanUserAddRows .     CanUserResizeRows .     EnableRowVirtualization .    HeadersVisibility$ Column=�   
IsReadOnly .    SelectionMode$ Single=�	   SelectionUnit$	 FullRow=�
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * $��5q�   AccentColorBrush4   AlternatingRowBackground# �   ���� *MonitoringList+ �� SelectedItem �� *SelectedMonitoringItem+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Entry ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	EntryID+  $ 
Entry Time��   Width$ 90  �� *EntryTimeDisplay+  $
 Time��$ 60  �� *Time+$ PropertyChanged=�  $ Total Price��$	 100  �� *ActualPrice+ �� StringFormat$ N2���� $��1��$��0��$��2�� �� ResizeDirection$ Columns=� �� ResizeBehavior$ PreviousAndNext=�$��Stretch=�$��5��  AccentColorBrush3#���  $	��1,5q��� $��LOGGED��$��Center=�$��Center=�$��16(�$
��Bold"�$��0��$��2��� $��1��$��2�� �� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto �.+�  $��0��$��0�� .   .   .   . $ Column=� . $ Single=�$	 FullRow=�$
 * $   HorizontalScrollBarVisibility$ Hidden=�$��5q�$��80������ *LoggedUsersList+   $ Surname�� �� *	Surname+  $ 	Firstname�� �� *	Firstname+  $  Login Time��$ 60  �� *Session.LoginTimeText+  $ 	Work Time��$	 100  �� *Session.WorkTime+$ PropertyChanged=��� $��1��$
��Left=�$
��Left=�$��Center=�.+���   DashButtonStyle#���  $��20��$��5q�$	��200��$
��Left=�$
��30,0q����� *RegisterCommand+.���   �� $
��Auto ��� $��* �.+�1  +MahApps.Metro.IconPacks.PackIconFontAwesome  E AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null�  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconFontAwesomeKind, MahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null]]   Kind$ RegisteredRegular=�$��Stretch=�$��30��$��30��$
��Left=�
��� � ��� $��1��$��Register��$��Center=�$��Center=�$��20(�$
��10,0q��� #���  $
��Left=�$��21��$��5q�$	��200��$
��Left=�$
��30,0q����� *ExitEntryCommand+.��]� .+��   �� $
��Auto ��� $��* �.+�  $ TimesCircleSolid=�$��Stretch=�$��30��$��30��$
��Left=�
���  ��$��Center=��� $��1��$
��Exit��$��Center=�$��Center=�$��20(�$
��10,0q��� $��Monitoring Information��$��2��$��5q�.��]� ��.  .+�]� $	��Top=�.+��� $��People count��  CommonTextRightAlignStyle#���  $	��150����   CommonTextBoxStyle#���   �� 
IsReadOnly . ���� *TerminalData.PeoplesCount+$ PropertyChanged=�$ OneWay=�]� $	��Top=�.+��� $��Average length of stay��#���  $	��150���� #���   . ���� *&$TerminalData.AverageLengthOfStayText+$ PropertyChanged=�$ OneWay=��� $��Terminal Information��$��3��$��5q�.��]� ��.  .+�]� $	��Top=�.+��� $
��Name��#���  $	��150���� #���   . ���� *TerminalData.Name+$ PropertyChanged=�$ OneWay=�]� $	��Top=�.+��� $��Total Income ($)��#���  $	��150���� #���   . ���� *TerminalData.TotalIncome+$ N2��$ PropertyChanged=�$ OneWay=�