   M S B A M L   `   `   `  ����M  IStockMarketMonitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:StockMarketMonitorStockMarketMonitor  5   	   #    StockMarketMonitor.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:StockMarketMonitor     5   	     � Title$  Stock Market Monitor��5   	   $	��450��6&   $	��800��63    � 	Resources 5	         
CompanyRed �� 
TargetType �� Property �� Value  CompanyBorderRed  CompanyGreen  CompanyBorderGreen  CompanyGray  CompanyBorderGray��%p  &	        &	 J     &	 �     &	     &	 x    &	 �    �� 5
   
   " ��6$   .�5      ��  � ��
 �  ��69   5      �� 5   
   " ��6*   .�5      ��  � ��
 �����6A   �� 5       � ��$ 4q�60   6<   5      �� 5   
   " ��6&   .�5      ��  � ��
 � � �6;   5      �� 5   
   " ��6,   .�5      ��  � ��
 ����6A   �� 5       � ��$ 4q�60   6<   5      �� 5   
   " ��6%   .�5      ��  � ��
 �����6:   5      �� 5   
   " ��6+   .�5      ��  � ��
 �����6@   �� 5       � ��$ 4q�60   6<   5      5      .��5!      �  � RowDefinitions 5"   
   �� 5#      6   �� 5$      6    � ColumnDefinitions 5&   
   �� 5'      6!   �� 5(      6!   .+�5+   
   �� -   5         ��Name$ Company0Border��5+      $��0��6)   $��0��66   #���  6F   ._�5,      �� -   5         ��Name$ Company0��5,      $��0��6+   $��0��68   #���   6H   .+�5-      �� 	 �� Orientation$	 Vertical=�6   $��Center=�64   $��Center=�6Q   $��0,10,0,0q�6l   .+�5.      �� $��Apple��6    $��45(�6-   $
��Bold"�6;   $��Center=�6M   $��Center=�6h   6�   �� 5/      $	 
Horizontal=�6!   .+�50      �� -   5        
 ��Name$
 Company0Price��50   $   $��162.41��6;   $��40(�6I   $��Center=�6W   $��Center=�6r   6�   �� 51      $
�� USD��6$   $��40(�60   $��Center=�6>   $��Center=�6Y   6x   52      �� 53      $	 
Horizontal=�6!   $��Center=�6:   .+�54      �� -   5        $
 Company0Change��54   $   $��-0.40��6<   $��30(�6I   6Y   �� 55      $
�� USD��6$   $��30(�60   6@   56      57      58      59      �� 5:   
   -   5        $ Company1Border��5:      $��0��6)   $��1��66   #���  6F   ._�5;      �� -   5        $ Company1��5;      $��0��6+   $��1��68   #���  6H   .+�5<      �� $	 Vertical=�6   $��Center=�64   $��Center=�6Q   $��0,7,0,0q�6l   .+�5=      �� $��	Microsoft��6    $��45(�61   $
��Bold"�6?   $��Center=�6Q   $��Center=�6l   6�   �� 5>      $	 
Horizontal=�6!   .+�5?      �� -   5        $
 Company1Price��5?   $   $��296.03��6;   $��40(�6I   $��Center=�6W   $��Center=�6r   6�   �� 5@      $
�� USD��6$   $��40(�60   $��Center=�6>   $��Center=�6Y   6x   5A      �� 5B      $	 
Horizontal=�6!   $��Center=�6:   .+�5C      �� -   5        $
 Company1Change��5C   $   $
��0.85��6<   $��30(�6H   6X   �� 5D      $
�� USD��6$   $��30(�60   6@   5E      5F      5G      5H      �� 5I   
   -	   5        $ Company2Border��5I      $��1��6)   $��0��66   #���  6F   ._�5J      �� -
   5        $ Company2��5J      $��1��6+   $��0��68   #���  6H   .+�5K      �� $	 Vertical=�6   $��Center=�64   $��Center=�6Q   $��0,10,0,0q�6l   .+�5L      �� $��Alphabet��6    $��45(�60   $
��Bold"�6>   $��Center=�6P   $��Center=�6k   6�   �� 5M      $	 
Horizontal=�6!   .+�5N      �� -   5        $
 Company2Price��5N   $   $��2602.05��6;   $��40(�6J   $��Center=�6X   $��Center=�6s   6�   �� 5O      $
�� USD��6$   $��40(�60   $��Center=�6>   $��Center=�6Y   6x   5P      �� 5Q      $	 
Horizontal=�6!   $��Center=�6:   .+�5R      �� -   5        $
 Company2Change��5R   $   $
��0.31��6<   $��30(�6H   6X   �� 5S      $
�� USD��6$   $��30(�60   6@   5T      5U      5V      5W      �� 5X   
   -   5        $ Company3Border��5X      $��1��6)   $��1��66   #���  6F   ._�5Y      �� -   5        $ Company3��5Y      $��1��6+   $��1��68   #���   6H   .+�5Z      �� $	 Vertical=�6   $��Center=�64   $��Center=�6Q   $��0,10,0,0q�6l   .+�5[      �� $��Samsung��6    $��45(�6/   $
��Bold"�6=   $��Center=�6O   $��Center=�6j   6�   �� 5\      $	 
Horizontal=�6!   .+�5]      �� -   5        $
 Company3Price��5]   $   $��63.40��6;   $��40(�6H   $��Center=�6V   $��Center=�6q   6�   �� 5^      $
�� USD��6$   $��40(�60   $��Center=�6>   $��Center=�6Y   6x   5_      �� 5`      $	 
Horizontal=�6!   $��Center=�6:   .+�5a      �� -   5        $
 Company3Change��5a   $   $��-0.23��6<   $��30(�6I   6Y   �� 5b      $
�� USD��6$   $��30(�60   6@   5c      5d      5e      5f      5h      5i      