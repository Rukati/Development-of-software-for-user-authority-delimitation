   M S B A M L   `   `   `  ����  _1lb    _1lb.MinPasswordWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$'  !Выбор сертификата��5   	   $	��200��6#   $	��400��60    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��10q�6   .+�5	   
   �� $&�� Имя пользователя:��6   $
��Left=�6,   $	��Top=�6G   $��14(�6_   �� 5   
   -   5         ��Name$ UsernameTextBox��5      $
��Left=�6+   $	��Top=�6F   $��0,30,0,0q�6^   $	��320��6p   $��15(�6|   �� 5   
   $��Длина пароля:��6   $
��Left=�6(   $	��Top=�6C   $��0,70,0,0q�6[   $��14(�6m   �� 5   
   -   5         ��Name$ PasswordLengthSlider��5       � Minimum$ 6Q�6/    � Maximum$ 20Q�6;    � Value$ 8Q�6H   	 �� TickFrequency$	 1Q�6R   
 �� IsSnapToTickEnabled
 . $
��Left=�5      $	��Top=�6,   $��	0,100,0,0q�6D   $	��250��6W   �� 5   
   $��Right=�5      $	��Top=�60   $��
0,100,10,0q�6H   $��14(�6\   $��50��6j   ��5      ��  �� ElementName$ PasswordLengthSlider�� �� Path$ Value�5   j   �� 5   
   -   5        $��OK��5      $��Right=�6   $��Bottom=�6:   $��	0,10,10,0q�6U   $��75��6h   6s   �� 5   
   -   5        $��Отмена��5      $
��Left=�6"   $��Bottom=�6=   $��	0,10,10,0q�6X   $��75��6k   6v   5      5      