   M S B A M L   `   `   `  ����L  HLibraryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LibraryManagementLibraryManagement  5      (    "LibraryManagement.AdminReservation   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:LibraryManagement     5      .��5	      � .+�5
   
   � .+�5      �� $
��Left=�6   $	��332��64   $	��Top=�6A   $	��655��6Y   $��10,30,-10,0q�6e   .+�5      &   System.Windows.Controls.DataGrid  -   5           Name$  dgBooks��5   L      
IsReadOnly$
 True��6   $	��333��6-   $��0,0,24,0q�6:      AutoGenerateColumns$ False��6]   #��� ��6y      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *ReservationID+6]     5      $ 	Adhérent��6-    6?   �� *
AdherentID+6`     5      $ Livre��6-    6<   �� *BookID+6Y     5      $ Date de reservation��6-    6J   �� *ReservationDate+ �� StringFormat$ {0:dd/MM/yyyy}��6�     5      $ Date de retour��6-    6E   �� *
ReturnDate+$ {0:dd/MM/yyyy}��6�     5      $ 	retourné��6-    6?   �� *
IsReturned+6`   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Actions��61      CellTemplate 5      �� 5   "   .R�5   &   ��  ��Name$ BtnEdit��6-   -   5        $��
 Modifier ��5   >   6k   5   #   5        5      $  ��61    5      �� 5   "   .R�5   &   �� $ 	BtnDelete��6-   -   5        $�� Supprimer ��5   @   6p   5   #   5!      5#      5$      �� 5%      -   5        $��BtnAdd��5%   �   $��Ajouter Reservation��6   $
��Left=�63   $	��Top=�6N   $	��101��6f   $��10,0,0,0q�6r   6�   �� 5&      $�� ��6   $
��Left=�6   $��
521,-7,0,0q�6:   $	��Top=�6N   
�������$��NORTHEN)�6�   $��20(�6�   ��6f   Z� 6�   �� 5'      -   5        $��
btnRefresh��5'   x   $��Refresh��6   $
��Left=�6'   $��	130,0,0,0q�6B   $	��Top=�6U   $��72��6m   6�   5*      5+      5,      