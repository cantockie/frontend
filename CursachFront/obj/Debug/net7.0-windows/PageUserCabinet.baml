   M S B A M L   `   `   `  ����G  CCursachFront, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CursachFrontCursachFront  5      "    CursachFront.PageUserCabinet   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      &localclr-namespace:CursachFront  5        N� Title$  PageUserCabinet��5
       N� 
Background
 ����  � 	Resources 5         Transparent �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius��%�  &	        �� 5   
   " ��6$   .�5      ��  � ��
 ���� 6+   �� 5       � ��$ 1q�60   �� 5       �@�Cursor$
 Hand��6'   �� 5       �@J�IsHitTestVisible$
 True��61   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   #��z��5      #��z��5      #��z��5      $ 4��5      ._�5      �� $��Center=�6/   $��Center=�5   %   5      5       5"      5#      5%      .��5(      � 	 � ColumnDefinitions	 5)   
   �� 5*      �� 5+      
 � RowDefinitions
 5-   
   �� 5.      �� 5/      .+�52   
   �� $��2��6   $��2��6%    �� Padding$ 20q�67   ���#1e3357$��1q�6Z   
���   �._�53      � 	 54      �� 55      �� 56      
 58      �� 59      �� 5:      .+�5<      �� ���#12161f$��2��6.   $��2��6B   $ 20��6T   6j   �� 5=   
   $��1��6    �� Orientation$ Vertical=�6"   .+�5>      �� $
��Name��6    
������� �� TextAlignment$
 Left=�6L   $��20(�6e   $��5q�6u   �� 5?      $��	FirstName��6    
�������$
 Left=�6K   $��20(�6d   $��5q�6t   �� 5@      $��Status��6    
�������$
 Left=�6L   $��20(�6e   $��5q�6u   �� 5A      $��	Education��6    
�������$
 Left=�6K   $��20(�6d   $��5q�6t   �� 5B      $��Contry��6    
�������$
 Left=�6L   $��20(�6e   $��5q�6u   �� 5C      $��Level��6!   
�������$
 Left=�6L   $��20(�6e   $��5q�6u   5D      �� 5E   
   $��1��6   $��1��6"   $ Vertical=�63   .+�5F      �� -   5         ��Name$
 Name��5F      $�� ��6,   
������� �� TextAlignment$
 Left=�6T   $��20(�6j   $��2q�6y   �� 5G      -   5        $ Sname��5G      $�� ��6-   
�������$
 Left=�6T   $��20(�6j   �� 5H      -   5        $ Status��5H      $�� ��6.   
�������$
 Left=�6U   $��20(�6k   �� 5I      -   5        $ 
Experience��5I      $�� ��62   
�������$
 Left=�6U   $��20(�6k   �� 5J      -   5        $ ContryOficer��5J      $�� ��64   
�������$
 Left=�6X   $��20(�6n   �� 5K      -   5        $ Level��5K      $��3��6-   
�������$
 Left=�6[   $��20(�6q   5L      5M      5N      �� 5P   
   $��2��6   $��Center=�6%   $��10q�6B   $	��200��6N   $	��300��6^   $	��400��6k   $	��100��6|   $	��250��6�   $	��350��6�   ._�5Q      � .+�5R      �� -   5        $
 Mask��5R      $��20q�6'   $ 10��64   
�������6F   �� 5S      -   5        $ FotocartBorder��5S      $ 10��6�   
�������$��1q�6�   $ 0q�6�   ��61   �� *Width+ �� ElementName$
 Mask����6[   �� *Height+$
 Mask��._�5T      � .+�5U      �� -	   5        $ 	ImageMask��5U   !   
������ ._�5V      �� -
   5         ��Name$ FotocarOficer��5V   $   $
��Fill=�6;    J� OpacityMask 5W   "   !� 5X   &    !� Visual 62   �� $
 Mask��5Z      5[      5\      5]      5^      5_      �� 5a   
   -   5         ��Name$ 
CloseCabin��5a      $��2��6%   $��2��67   #���   6L   6s   �� 5c   
   -   5        $ SetingProfile��5c      $��1��6(   $��1��65   $��Center=�6E   $��Bottom=�6b   $��0,0,0,40q�6�     MaterialDesignIconButton#��[ 5d      .��5e      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Settings=�6&   $��54��66   $��48��6B   5f      5g      5h      