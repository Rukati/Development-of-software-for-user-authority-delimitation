   M S B A M L   `   `   `  ����?  ;_1lb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:_1lb_1lb  5   	       	_1lb.Menu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   $localclr-namespace:_1lb     5   	     � Title$
  Menu��5   	   $	��450��6   $	��800��6#    � 
ResizeMode$ NoResize=�6/   ���#F0F4F8 � WindowStartupLocation$ CenterScreen=�5
   	    � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value��%�  '��       �� 5   
   " ��6   .�5      ��  � �� �#4CAF506+   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       �@��Padding$ 	15,5,10,5q�6(   �� 5       � ��$ 10,10,10,10q�6'   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$	 150��6)   �� 5       � ��$ 50��6*   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 Wrap=�6-   �� 5       �@�Cursor$
 Hand��6'    5      P� 5       �@J�IsMouseOver	 . . �5      ��  � �� �#388E3C63   �� 5       � ��
 �����63   5      5       5!      .��5#      � 
 � RowDefinitions
 5$   
   �� 5%      $	��100 �6   �� 5&      $��* �6   .+�5)   
   �� -   5         ��Name$ 	Greetings��5.      
������ $��0,20,0,0q�5+      $��Center=�5,      $��Center=�5-      $��30(�5/      $
��Bold"�50      ���#2C3E50 � Cursor$ Arrow��52      A� 53   
   -   5         A�Name$ UniformGrid��53      $��1��6+    A� Rows$ 2��68    A� Columns$ 5��6A   $��Center=�6M   $	��Top=�6j   $��10q�6�   .+�54      �� -   5        $��
View Users��54      6*   �� 55      -   5        $��Add User��55      6(   �� 56      -   5        $��	Lock User��56      6)   �� 57      -   5        $��Unlock User��57      6+   �� 58      -   5        $��Change Password��58      6/   �� 59      -   5        $��Set Certificate File��59      64   �� 5:      -	   5        $��Enable Certificate��5:      62   �� 5;      -
   5        $��Disable Certificate��5;      63   �� 5<      -   5        $��Set Min Password Length��5<      67   �� 5=      -   5        $��Logout��5=      ���#E74C3C6;   5>      5?      5@      