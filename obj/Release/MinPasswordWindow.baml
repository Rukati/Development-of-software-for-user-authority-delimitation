   M S B A M L   `   `   `  ����   _1lb    _1lb.MinPasswordWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$'  !Выбор сертификата��$	��200��$	��400�� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=�.��� $��10q�.+��� $&�� Имя пользователя:��$
��Left=�$	��Top=�$��14(��� -    ��Name$ UsernameTextBox��$
��Left=�$	��Top=�$��0,30,0,0q�$	��320��$��15(��� $��Длина пароля:��$
��Left=�$	��Top=�$��0,70,0,0q�$��14(��� -    ��Name$ PasswordLengthSlider�� � Minimum$ 6Q� � Maximum$ 20Q� � Value$ 8Q�	 �� TickFrequency$	 1Q�
 �� IsSnapToTickEnabled
 . $
��Left=�$	��Top=�$��	0,100,0,0q�$	��250���� $��Right=�$	��Top=�$��
0,100,10,0q�$��14(�$��50������  �� ElementName$ PasswordLengthSlider�� �� Path$ Value��� -   $��OK��$��Right=�$��Bottom=�$��	0,10,10,0q�$��75���� -   $��Отмена��$
��Left=�$��Bottom=�$��	0,10,10,0q�$��75��