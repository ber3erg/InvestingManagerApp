   M S B A M L   `   `   `  ����  InvestingManagerApp2    ,InvestingManagerApp.Views.SecurityEditorView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$:  4Редактировать ценную бумагу��5   	   $	��300��6-   $	��400��6:    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�6-   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0,0,0,10q�6,   .+�5      �� $��Название:��6   $
��Bold"�6)   �� 5      -   5         ��Name$ NameTextBlock��5      5      �� 5   
   $��1��6   $ Vertical=�6"   $��	0,10,0,10q�69   .+�5      �� $��Тикер:��6   $
��Bold"�6&   �� 5      -   5        $ TickerTextBlock��5      5      �� 5   
   $��2��6   $ Vertical=�6"   .+�5      �� $$��Новая стоимость:��6   $
��Bold"�60   �� 5      -   5         ��Name$ PriceTextBox��5      $	��200��6,   $��0,0,0,10q�68   �� 5      $ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5        $��Сохранить��5      $	��100��6-   $��0,0,10,0q�69   6K   �� 5      -   5        $��Отмена��5      $	��100��6*   66   5      5      5      5       