   M S B A M L   `   `   `  ����e  aMicrosoft.Web.WebView2.Wpf, Version=1.0.2210.55, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf  5   	   D @NavIgnite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NavIgnite	NavIgnite 5   	      NavIgnite.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   \wv2Lclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf     5   	   )localclr-namespace:NavIgnite     5   	     � Title$  	NavIgnite��5	   	   $	��600��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�64    � WindowState$ 	Maximized=�6Y    � 	Resources 5
         ByomIconsFontFamily��%_   &	        *�5   
   A=/NavIgnite;Assets/Fonts/Byom-Icons-Trial.ttf#Byom Icons Trial)�6p   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� $��0��6   .@�5      m� $��
Historique��6   m� 5      $��Options��6   5      ]� 5"   
   $��1��6   ���	#FF383737.+�5#      �� -   5         ��Name$ ButtonBackPage��5#      $
��Left=�6-   $��<��6`   �� 5$      -   5        $ ButtonNextPage��5$      $
��Left=�6-   $��>��6`   $��10,0,0,0q�6l   �� 5%      -   5        $ ButtonRefreshPage��5%      $
��Left=�60   $��Refresh��6f   $��10,0,0,0q�6x   �� 5&      -   5        $ AddToFavButton��5&      .��5'      ��  �� Orientation$ 
Horizontal=�6   .+�5(      �� #��[  6    $����6R   $��16(�6b   $��5q�6p   �� 5)      $����6    $��5q�60   5*      5+      �� 5,      -   5        $ ButtonGo��5,      $��Right=�6'   $��Go��6U   �� 5-      -   5        $��
addressBar��5-      $	��520��6E   $��Right=�6Q   $��0,0,10,0q�6m   5.      � 51   
   -   5        $��favoritesWrapPanel��51   !   $��2��6   $��	10,5,10,0q�6;   $��Stretch=�6N   $	��Top=�6l   )   #Microsoft.Web.WebView2.Wpf.WebView2  54   
   -   5        $��webView��54      $��4��6&   $��0,10,0,0q�63      Source$ https://www.google.fr?�6E   55      56      