   M S B A M L   `   `   `  ����C  ?H5Movies, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:H5MoviesH5Movies  5   	       H5Movies.Movies2   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:H5Movies     5   	     � Title$
  Edit��5   	   $	��300��6   $	��370��6#    � 	Resources 5	         	movieName �� XPath��%`   &	        �� 5
   
   .R�5      �� $	��150��64   ��6   �� $ @Name��64   5      5      .��5      �  � DataContext 5   
   � 5      -   5        	xdpMovies�� � Source$ D:\\Movies.xml?�5   1    � XPath$ /Movies/Movie��6I   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��5, 10, 10, 0q�6   .+�5      �� -   5         ��Name$ lbMovies��5      #��[  6D   $	��238��6n    �� SelectionMode$ Single=�6{   $	 �� IsSynchronizedWithCurrentItem$
	 TrueY�6�   $��Visible=�6�   ��. ��6,   �� 6�   5      �� 5      $��0, 10, 10, 0q�6   .+�5      �� Movie6#   �� 5      -   5        
 ��Name$
 txtName��5      $��
0, 0, 0, 5q�6H   $	��150��6\   ��6+   �� $ @Name��6\   �� 5      	Country6%   �� 5      -   5        $
 
txtCountry��5      $��
0, 0, 0, 5q�6N   $	��150��6b   ��6.   �� $ @Country��6b   �� 5      
Director6&   �� 5      -   5        $
 txtDirector��5      $��
0, 0, 0, 5q�6P   $	��150��6d   ��6/   �� $ 	@Director��6d   �� 5      
Director6&   �� 5      -   5         ��Name$ 
chkWatched��5      $��
0, 0, 0, 5q�6T    d� 	IsChecked 6/   �� $ @Checked��6T   �� 5      -   5         ��Name$ btnAdd��5      $��	Add movie��6)   $��
0, 5, 0, 5q�6=   6Q   �� 5       -   5        $ 	btnDelete��5       $��Delete movie��6,   $��
0, 5, 0, 5q�6C   6W   �� 5!      -	   5        $ btnSave��5!      $��Save changes��6*   $��
0, 5, 0, 5q�6A   6U   5"      5#      5$      5%      