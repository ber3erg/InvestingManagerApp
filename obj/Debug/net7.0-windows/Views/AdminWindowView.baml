   M S B A M L   `   `   `  ����  InvestingManagerApp/    )InvestingManagerApp.Views.AdminWindowView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$:  4Управление ценными бумагами��5   	   $	��500��6-   $	��850��6:   .��5      ]� .+�5   
   � $��10q�6    � RowDefinitions 5	      �� 5
      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� $:��4Управление ценными бумагами��6   $��20(�5      $
��Bold"�5      $��Center=�5      $��0,0,0,10q�5      �� 5      $��0��6   $��	0,10,0,10q�6&    �� Orientation$ 
Horizontal=�69   .+�5      �� -   5         ��Name$ TickerTextBox��5      $	��150��61   $��0,0,10,0q�6=   �� 5      -   5        $ NameTextBox��5      $	��200��6/   $��0,0,10,0q�6;   �� 5      -   5         ��Name$ TypeComboBox��5      $	��150��61   $��0,0,10,0q�6=   .@�5      �� $��
Акция��6#   �� 5      $��Облигация��6#   �� 5      $��Фонд��6#   5      �� 5      -   5        $ PriceTextBox��5      $	��100��60   $��0,0,10,0q�6<   �� 5      -   5        $��Добавить��5      $	��100��6,   $��30��68   6D   5       &   System.Windows.Controls.DataGrid  5#      -   5          Name$ DataGrid��5(      $��1��5#         AutoGenerateColumns$ False��5%         
IsReadOnly$
 True��5&      $��	0,10,0,10q�5'      ��5$      �� *
Securities+   Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Тикер��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *Ticker+6S     5+      $	 Название��6)   $
 * 6T    6;   �� *Name+6T     5,      $	 Тип��6)   $

 Auto 6O    66   �� *Type+6O     5-      $'	 !Текущая стоимость��6)   $

 Auto 6{    6D   �� *CurrentPrice+ �� StringFormat$ {0:C}��6{   4  .System.Windows.Controls.DataGridTemplateColumn  5.      $	 Действия��6-      CellTemplate 5/      �� 50      .R�51   "   �� $ 
Horizontal=�6-   .+�52   &   �� -   5        $ ��Редактировать��52   -   $��80��6E   6P   �� 53   &   -   5        $��Удалить��53   -   $��80��6?   $��10,0,0,0q�6J   6\   54   #   55      57      59      �� 5<      $��2��6   $ 
Horizontal=�6&   $��Right=�6?   .+�5=      �� -	   5        $ EditPriceTextBox��5=      $	��100��64   $��0,0,10,0q�6@   �� 5>      -
   5        $��Изменить цену��5>      $	��120��61   $��30��6=   6I   5?      5@      5A      5B      