   M S B A M L   `   `   `  ����F  BBindingData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:BindingData.VIEWMODELBindingData.VIEWMODEL  5   	       BindingData.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:BindingData.VIEWMODEL     5   	     � Title$  
MainWindow��5   	   $	��478��6   $	��497��6)   $	��450��65   $	��450��6E    � 	Resources 5	      '   !BindingData.VIEWMODEL.ContactList   ContactList��%   &	          5
   
   6   5      .��5      �� .��5   
   ��  � DataContext# [  6   .+�5      o� $��25��6   $��15(�6   $	��Top=�6-   
�������.@�5      m� $
��Menu��6   .@�5      m� $	��Add��6     m� Command 6-   �� *
AddCommand+6N   m� 5      $��Delete��6     60   �� *Del+6K   m� 5      $��Change��6     60   �� *Change+6N   m� 5      $
��Save��6     6.   �� *Save+6J   m� 5      $
��Load��6     6.   �� *Load+6J   m� 5      -   5        $
��Exit��5      6>   5      5      �� 5      -   5         ��Name$ ls��5      $��Disabled=�5   :   ��5   "   �� *
Contacts+ �� SelectedIndex 6C   �� *SelectedIndex+ �� Mode$ TwoWay=���5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � ��	 �� Value	 5       �� 5!   "   
 �� 
TargetType"
 ��62   .R�5"   &   �� $	��100��6-   $	��300��6:   
�������$��1q�6[   $��10q�6o    �� CornerRadius$ 30��6{   ._�5#   *   �� 5$   '    �� Triggers 5'   &   P� 5(   *    P� Property �@��
IsSelected P� Value$
 True��6H   . �5)   .   ��  � ��
	 �  ��6L   �� 5*   .    � ��
	 �  ��6K   �� 5,   .    � ��$	 13(�6S   6`   5-   +   P� 5.   *    �@��
IsSelected$ False��6H   . �5/   .   ��  � ��$	 35(�6S   50   +   53   #   56      57      ��59      �� 5:      .R�5;      �� $��1q�6!   $��10q�65   $ 30��6A   ._�5<      �� $��10q�6)   .+�5>   "   �� ��5?   &   `� 5@   *    �� StringFormat$ {0} {1}��67   .1�5A   .   ��  �� Path$
 Name�66   �� 5B   .   $ Surname�66   5C   +   5E   #   �� 5G   "   ��6,   �� *Adress+�� 5H   "   ��6,   �� *PhoneNumber+5I      5J      5K      ��5M      �� 5N      .R�5O      �� $
��Left=�6%   5P       � ContextMenu 5R      �� 5S      .@�5T      m� $��Удалить��6#    64   �� *DeleteCommand+6X   m� 5U      $��Изменить��6#    65   �� *Change+6R   5V      5X      5Y      5Z      5[      