   M S B A M L   `   `   `  ����G  CCursachFront, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CursachFrontCursachFront  5   	       CursachFront.Autorization   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:CursachFront  5   	     � Title$  Autorization��5	   	   $	��500��6   $	��400��6,    � WindowStyle$
 None=�68   
������� � 
ResizeMode$ NoResize=�6c    � WindowStartupLocation$ CenterScreen=�6y    � 	Resources 5
         CustomBorder �� 
TargetType - )MaterialDesignToolBarMainPanelBorderStyle �� BasedOn �� Property �� Value  CustomButton1  MaterialDesignFlatButton��%�  &	        7  &	 �     7  �� 5   
   " ��6%   8   .�5      ��  � �� �#1013176,   �� 5       � ��$ 1q�60   �� 5       �@��CornerRadius$ 10��6-   �� 5       � ��$ 10q�6'   �� 5       �@��Padding$ 4q�6(   5      �� 5   
   " ��6&   8   .�5      ��  � �� �#1e33576,   �� 5       � ��
 �   �6,   �� 5       � ��$ 1q�60   �� 5       � ��$ 5q�6(   5      5      .��5      � -   5        	 �Name$	 MainRoot��5      
 � ColumnDefinitions
 5   
   �� 5      �� 5       � RowDefinitions 5    
   �� 5!      $	��20* �6   �� 5"      $
��231* �6   �� 5#      $
��135* �6   �� 5$      $
��140* �6   .+�5&   
   �� -   5         ��Name$ WindowBorder��5&      ���#101317 J� Opacity$	 0.9Q�6<   $��0��6K   $��0��6X   $��2��6h   ._�5'      � 
 5(      �� 5)      $
��161* �6'   �� 5*      $	��39* �6'   .+�5,      �� $��1��6    �� Orientation$ 
Horizontal=�6-   $��Right=�6F   .+�5-      �� -   5          MaterialDesignIconButton#��[ 5.      ���#8f8c88$��18��6`   $��39��6l   .��5/      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minimize=�62   $��18��6B   $��29��6N   50      �� 51      -   5        #��[ 52      ���#8f8c88$��18��6_   $��39��6k   .��53        $ Close=�62   $��18��6?   $��29��6K   54      55      56      57      �� 58   
   $��1��6   $��0��6   $��2��6.   $��Source\interpollog.png��6B   $��20q�6b   6p   �� 59   
   -   5        $ PasportBorder��59      $��2��6(   $��0��65   $��2��6E   ._�5:      �  5;      �� 5<      �� 5=      .+�5?      �� -   5        $ BarderLogin��5?      $��0��6.   #���   6;   ._�5@      �� $ 
Horizontal=�6!   .+�5A      �� $��Login : ��6$   $��Center=�6<   6Z   �� 5B      -   5        $��Login��5B   "   $	��290��6/   $��Center=�6<   6Z   5C      5E      �� 5F      -   5        $ BarderPassword��5F      $��1��61   #���   6>   ._�5G      �� $ 
Horizontal=�6!   .+�5H      �� $��Password : ��6$   $��Center=�69   6W   G� 5I      -	   5         G�Name$ passwordBox��5I   &   $	��270��6;   $y�Visible=�6G   $��Center=�6\   �� 5J      -
   5        $��PasswordTextBox��5J   "   $	��270��69   $y�	Collapsed=�6E   $��Center=�6\   6z   �� 5K      $y�	Collapsed=�6$   #��[ 5L      ���#8f8c88$��18��6`   $��39��6l   .��5M        $ 	EyeClosed=�66   $��18��6G   $��29��6S   5N      �� 5O      -   5         ��Name$ 
ViewButton��5O   !   #��[ 5P      ���#8f8c88$��18��6`   $��39��6l   ��5O   R   �� *!TogglePasswordVisibilityCommand+.��5Q        $	 Eye=�66   $��18��6A   $��29��6M   5R      5S      5T      5U      5V      �� 5W   
   $��3��6   $��0��6   $��2��6.   $��5q�6B   ._�5X      �  5Y      �� 5Z      $	��27* �6$   �� 5[      $	��40* �6$   �� 5\      $	��56* �6$   
 5^      �� 5_      $	��77* �6'   �� 5`      $
��212* �6'   �� 5a      $	��77* �6'   .+�5c      �� -   5         ��Name$ 
RememberMe��5c      $��Remember me��60   $��2��6F   ���#101317���#1013176q   �� 5d      -   5        $ logIN��5d   K   $��1��6   $��1��6&   $��Log in��6Z     MaterialDesignPaperButton#���  6k   ���#1e3357���#1e3357
�������6�   �� 5e      -   5        $
 viEW��5e   L   $��2��6   $��1��6&   $
��View��6[   #���  6l   6�   5f      5g      5h      5i      