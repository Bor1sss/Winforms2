   M S B A M L   `   `   `  ����F  BBindingData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:BindingData.VIEWMODELBindingData.VIEWMODEL  5   	       BindingData.Window1   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:BindingData.VIEWMODEL     5   	     � Title$  Window1��5   	   $	��220��6   $	��553��6&   $	��190��62   $	��300��6B   $	��220��6Q   $	��553��6b    � 	Resources 5	      '   !BindingData.VIEWMODEL.ContactList   ContactList   NameList   SurnameList   
AdressList   	PhoneList��%H   &	          5   
   $  ��60   $  ��6<   $  ��6K   $  ��6Y   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��141* �6   6.   �� 5      $
��200* �6   6.   �� 5      $	��82* �6   .+�5   
   �� $��0,5,0,0q�6   $��Right=�6'    �� Orientation$ Vertical=�6C   $��0��6[   .+�5      ��  �� 
IsReadOnly$
 True��6   $��20(�6(   $��30��66   $��0 5 0 0q�6B   	 �� TextAlignment$	 Right=�6S   $
��Name��6i   $��0q�6u   6�   �� 5      $
 True��6   $��20(�6(   $��30��66   $��0 5 0 0q�6B   $	 Right=�6S   $��Surname��6i   $��0q�6x   6�   �� 5      $
 True��6   $��20(�6)   $��30��67   $��0 5 0 0q�6C   $	 Right=�6T   $��Adress��6k   $��0q�6y   6�   �� 5      $
 True��6   $��20(�6(   $��30��66   $��0 5 0 0q�6B   $	 Right=�6S   $��Phone��6i   $��0q�6v   6�   5      �� 5    
   $��5,0,0,0q�6   $
��Left=�6&   $ Vertical=�6A   $��1��6Y   
 � DataContext#
 [  6i   .+�5"      �� -   5        $��tName��5"   A   $��20(�6   $��30��6$   $��0 5 0 0q�60   $	��150��6N   ��6Z   �� *
NameList+6v   �� 5$      -   5        $��tSurname��5$   A   $��20(�6   $��30��6$   $��0 5 0 0q�60   $	��150��6Q   ��6]   �� *SurnameList+6|   �� 5&      -   5        $��tAddress��5&   A   $��20(�6   $��30��6$   $��0 5 0 0q�60   $	��150��6Q   ��6]   �� *
AdressList+6{   �� 5(      -   5        $��tPhone��5(   B   $��20(�6   $��30��6%   $��0 5 0 0q�61   $	��150��6P   ��6\   �� *	PhoneList+6z   �� 5)      $ 
Horizontal=�6   .+�5+      �� -   5         ��Name$ bt��5+      $��Добавить��6"   $��15 5 0 0q�65   6G   �� 5,      -   5        $ 	bt_cancel��5,      $��Cancel��6)   $��	15 5 15 0q�6:   6M   5-      5.      5/      50      