   M S B A M L   `   `   `  ����  InvestingManagerApp1    +InvestingManagerApp.Views.PortfolioListView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$%  Список портфелей��5   	   $	��500��6"   $	��850��6/   .��5      ]� .+�5   
   o� $	��Top=�6   .@�5	      m� $��Навигация��6   .@�5
      m� $��Портфели��6   ${�False��6-   m� 5      -   5        $)��#История транзакций��5      67   5      5      � 5   
   $��10q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� $��Ваши портфели��6   $��20(�5      $
��Bold"�5      $��Center=�5      $��0,0,0,10q�5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ DataGrid��5"      $��1��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5       $��	0,10,0,10q�5!      ��5      �� *
Portfolios+   Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6L     5%      $ Название��6)   $ * 6T    6;   �� *Name+6T     5&      $# Общая стоимость��6)   $
 Auto 6a    6B   �� *
TotalValue+6a     5'      $ Дата создания��6)   $
 Auto 6    6@   �� *CreatedDate+	 �� StringFormat$	 {0:dd.MM.yyyy}��6   5)      �� 5+      -   5        $��2��5+      $1��+Редактировать портфель��6"   $	��150��5,      $��30��6!   $
��Left=�5-      5.      �� 50      $��2��6   $��
Назад��6"   $	��100��51      $��30��6!   $��Right=�52      54      55      56      