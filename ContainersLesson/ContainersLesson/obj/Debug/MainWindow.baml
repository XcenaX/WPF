   M S B A M L   `   `   `  ����K  GContainersLesson, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ContainersLessonContainersLesson  5   	   !    ContainersLesson.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ContainersLesson     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5      �  � ColumnDefinitions 5   
   �� 5       $
��256* �6   �� 5!      $
��249* �6   �� 5"      $
��287* �6    � RowDefinitions 5$   
   �� 5%      $	��26* �6   �� 5&      $	��34* �6   �� 5'      $	��24* �6   �� 5(      $
��335* �6   .+�5*   
   �� -   5        $
��City��5*   �   $��1��6   $��0��6#    �� TextWrapping$
 Wrap=�62   $3��-Введите город или страну��6F   $��14(�6�   $
��Bold"�6�    �� TextAlignment$ Center=�6�   6�   �� 5+   
   -   5        $)��#Просмотреть погоду��5+      $��1��6.   $��2��6>   $
��53,0q�6K   6Y   �� 5-      -   5        $
��Days��5-   U   $��2��6   $��0��6!   $	��100��6.   $
��Left=�6:    �� SelectedValuePath$ Content��6a   .@�5.      �� .��5/      �� 
1 День6    50      �� 51   
    �� 
IsSelected . .��52      �� 
5 Дня6#   53      �� 54   
   .��55      �� 10 Дней6%   56      �� 57   
   .��58      �� 15 Дней6   59      5:      �� 5<   
   -   5        $��listBox1��5<   H   $��Visible=�6   $��3��6Z   $��4��6n   ��5=      �� 5>      .R�5?      �  K� IsItemsHost . 6   5@      5B      5D      5E      