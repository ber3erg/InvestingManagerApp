   M S B A M L   `   `   `  ����  InvestingManagerApp6    0InvestingManagerApp.Views.TransactionHistoryView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$)  #История транзакций��5   	   $	��500��6$   $	��850��61   .��5      ]� .+�5   
   � $��10q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� $)��#История транзакций��6   $��20(�5      $
��Bold"�5      $��Center=�5      $��0,0,0,10q�5      &   System.Windows.Controls.DataGrid  5      $��1��6      AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5       $��	0,10,0,10q�5!      ��5      �� *Transactions+   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6L     5$      $ Тип��6)   $
 Auto 6O    66   �� *Type+6O     5%      $ 
Тикер��6)   $ * 6[    68   �� *SecurityTicker+6[     5&      $ Дата��6)   $
 Auto 6o    67   �� *Date+ �� StringFormat$ {0:dd.MM.yyyy}��6o     5'      $ Цена/ед.��6)   $
 Auto 6\    6;   �� *PricePerUnit+6\     5(      $ Количество��6)   $
 Auto 6Z    6=   �� *
Quantity+6Z     5)      $ Выплата/ед.��6)   $
 Auto 6a    6>   �� *PaymentPerUnit+6a   5+      �� 5-      $��2��6   $��
Назад��6"   $	��100��5.      $��30��6!   $
��Left=�5/      51      52      53      