   M S B A M L   `   `   `  ����N  JInvestingManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:InvestingManagerAppInvestingManagerApp  5   	   %    InvestingManagerApp.LoginWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:InvestingManagerApp     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� $	��250��6    �� Orientation$ Vertical=�5      $��80q�5      .+�5      �� $��
Войти��6   $��
Montserrat)�5      $��24(�5      $��
ExtraBlack"�5      $��Center=�5      �� 5      $��Login��6   $��12(�5      $��
Montserrat)�5      $
��Bold"�5      $��12, 20, 12, 6q�5      �� 5      -   5         ��Name$ EnteredLogin��5      $��
Montserrat)�5      $��Medium"�5      $��24��5      $��12(�5      ��5      �� *
Username+5      �� 5      $��Password��6   $��12(�5      $��
Montserrat)�5       $
��Bold"�5!      $��12, 12, 12, 6q�5"      �� 5#      -   5        $ EnteredPassword��5#      $��
Montserrat)�5%      $��Medium"�5&      $��24��5'      $��12(�5(      $��10, 8, 10, 8q�5)      �� 5*      ���#D7596D$��8(�5,      $��Medium"�5-      $��12, 0, 12, 0q�5.      $
��Wrap=�5/      ��5*      �� *ErrorMessage+5/      �� 51      -   5        $��0q�52      $��
Войти��53      ���#fff���#532267$��
Montserrat)�56      $��Medium"�57      $��10(�58      $	��100��59      $��32��5:       � Cursor$
 Hand��5;      $��12,8, 12, 8q�5=      ��51      �� *LoginCommand+5=   ,   �� 5?      -   5         ��Name$ 	btnSignUp��5?      $��0q�5@      $*��$Зарегестрироваться��5A      ���#532267���#fff$��
Montserrat)�5D      $��10(�5E      $��Medium"�5F      $	��140��5G      $
 Hand��5H      $��0q�5J      6"   5K      5L      5M      