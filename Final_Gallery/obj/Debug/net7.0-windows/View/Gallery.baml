   M S B A M L   `   `   `  ����H  DFinal_Gallery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Final_Gallery.ViewModelFinal_Gallery.ViewModel  5   	        Final_Gallery.View.Gallery   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   6view%clr-namespace:Final_Gallery.ViewModel     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Photo Gallery��5	   	   $	��708��6   $	��908��6,   $	��450��68   $	��645��6H      MaterialDesignBody#���   5
   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � DataContext 5      (  "Final_Gallery.ViewModel.VM_Gallery  5   
    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBox.xaml?�6%   �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�6%   %    5      .��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5       $��150px �6#   63   �� 5!      $��* �6#   6/    � RowDefinitions 5#      �� 5$      $
��50px �6    60   �� 5%      6"   �� 5&      $
��50px �6    60   .+�5(      �� $��2��6   .+�5)      o� $��50��6     PrimaryHueLightBrush#���  6%   .@�5*      m� $��Файл��6   .@�5+      m� $��	Add Photo��6#    m� Command 5,   #   �� *
AddCommand+m� 5.      $��
Save Album��6#    5/   #   �� *SaveCommand+m� 50      $��
Load Album��6#    51   #   �� *LoadCommand+m� 52      $��Delete Photo��6#    53   "   �� *
DelCommand+m� 54      $��	New Album��6#    56      �� *NewAlbumCommand+�� 57      m� 58      $��
Выход��6#    59   #   �� *ExitCommand+5:      5;      5<      �� 5>      #���  6   $��1��6M   $��0��6[   $
��Left=�6k   $	��Top=�6�   $��	20,10,0,0q�6�   $	��105��6�    J� RenderTransformOrigin$ 0.504,0.378&�6�   $
��Auto��6�   .+�5?      �� 	 �� TextWrapping$
	 Wrap=�6   $��0,0,0,5q�6N   $��18(�6_   
 �� 
IsReadOnly$

 True��6m   ��6/   �� *PhotoFileName+6m   �� 5@      $
	 Wrap=�6   $��0,0,0,5q�6J   $��18(�6[   $
 False��6i   ��6.   �� *
PhotoOwner+6i   �� 5A      $
	 Wrap=�6   $��0,0,0,5q�6P   $
 False��6a   $��18(�6t   ��6.   �� *PhotoDescription+6t   5B      ]� 5D      $��1��6   $��1��6(   $��	0,0,10,25q�65   $
��1000��5E      $
��1000��6   .+�5F      �� $
��Auto=�6   $
��Auto=�5G      .��5H      �� $
��Left=�6!   $	��Top=�6<   .+�5J      �� $��Uniform=�6@   $��10q�6R   ��6    �� *CurrentPhoto+ � LayoutTransform 5K      �� 5L   "    �� ScaleX 61   �� *
PhotoScale+ �� ScaleY 6O   �� *
PhotoScale+5N      5O      5P      5Q      �� 5U      $��0��6   $��1��6%    �� Orientation$ Vertical=�62    � Minimum$
 0.05Q�6I    � Maximum$ 2Q�6X   $��Right=�5V      $��Center=�61   $	��200��6L    � Value 5U   d   �� *
PhotoScale+5V   L   �� 5_      $��2��6   $��2��6&    �� Orientation$ 
Horizontal=�6:     MaterialDesignBackground#���  6S   $��70��6�   $��2��6�   $��Bottom=�6�   .+�5`      �� $
��Left=�6   $��Bottom=�68   $ 
Horizontal=�6S   $��10q�6l   .+�5a      �� $��Оценка:��6    $��Center=�6/   $��18(�6J   �� 5b       ) %MaterialDesignChoiceChipAccentListBox#���  6   $��Center=�6^   $��15(�6�    �� SelectedIndex 6y   �� *PhotoRating+ �� Mode$ TwoWay=�.@�5c      �� .��6&   1☆6*   �� 5d      .��6&   2☆6*   �� 5e      .��6&   3☆6*   �� 5f      .��6&   4☆6*   �� 5g      .��6&   5☆6*   5h      5j      �� 5k      $��Center=�6   $��Bottom=�6;   $ 
Horizontal=�6V   $��
0 ,0,10,10q�6o   .+�5l      �� $��Пред. фото��6     MaterialDesignRaisedButton#���  62   $	��120��6�   ��6g   �� *PrevCommand+6�   �� 5m      $��След. фото��6   #���  62   $	��120��6g   $��10,0,0,0q�6�   ��6s   �� *NextCommand+6�   5n      5o      5p      5r      5s      