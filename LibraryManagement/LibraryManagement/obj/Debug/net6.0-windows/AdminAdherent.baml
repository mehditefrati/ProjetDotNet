   M S B A M L   `   `   `  ����L  HLibraryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LibraryManagementLibraryManagement  5      %    LibraryManagement.AdminAdherent   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:LibraryManagement     5      .��5	      � .+�5
   
   �� $
��Left=�6   $	��332��60   $	��Top=�6=   $	��655��6U   $��10,30,-10,0q�6a   .+�5      &   System.Windows.Controls.DataGrid  -   5           Name$  dgBooks��5   H      
IsReadOnly$
 True��6   $	��333��6)   $��0,0,24,0q�66      AutoGenerateColumns$ False��6Y   #��� ��6u      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
AdherentID+6V     5      $ Prénom��6)    69   �� *	FirstName+6Y     5      $	 Nom��6)    66   �� *
LastName+6U     5      $ Email��6)    68   �� *Email+6T     5      $ 	Telephone��6)    6<   �� *	Telephone+6\     5      $ Password��6)    6;   �� *
Password+6Z   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Actions��6-      CellTemplate 5      �� 5      .R�5   "   ��  ��Name$ BtnEdit��6)   -   5        $��
 Modifier ��5   :   6g   5      5        5      $  ��6-    5      �� 5      .R�5   "   �� $ 	BtnDelete��6)   -   5        $�� Supprimer ��5   <   6l   5      5       5"      5#      �� 5$   
   -   5        $��BtnAdd��5$   }   $��Ajouter Adhérent��6   $
��Left=�6,   $	��Top=�6G   $	��101��6_   $��10,0,0,0q�6k   6�   �� 5%   
   $�� ��6   $
��Left=�6   $��
521,-7,0,0q�66   $	��Top=�6J   
�������$��NORTHEN)�6�   $��20(�6�   ��6b   Z� 6�   �� 5&   
   -   5        $��
btnRefresh��5&   t   $��Refresh��6   $
��Left=�6#   $��	130,0,0,0q�6>   $	��Top=�6Q   $��72��6i   6�   �� 5'   
   -   5        $��	btnImport��5'   s   $��Import��6   $
��Left=�6"   $��	229,0,0,0q�6=   $	��Top=�6P   $��78��6h   6�   5*      5+      