   M S B A M L   `   `   `  ����E  AH9Bookshop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:H9Bookshop
H9Bookshop  5   	       H9Bookshop.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:H9Bookshop     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��525��6)   .��5	      � .+�5
   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $ Vertical=�6   .+�5      �� -   5         ��Name$ btnGetTestbooks��5      $��Get testbooks��66   $��
5, 5, 5, 0q�6N   6b   �� 5      -   5        $ btnGetSQLbooks��5      $��Get SQLbooks��65   $��
5, 5, 5, 0q�6L   6`   5      �� 5      -   5         ��Name$ 	spContent��5      $ 
Horizontal=�60   
����ح�$	��400��6`   .+�5      �� $ Vertical=�6!   $��20, 0, 0, 0q�68   .+�5      �� $��Product��6$   $��5q�63   �� 5      $
��Name��6$   $��5q�60   �� 5      $��Author��6$   $��5q�62   �� 5      $��Country��6$   $��5q�63   �� 5      $
��Year��6$   $��5q�60   5      �� 5      .+�5      �� -   5         ��Name$ 	tbProduct��5   $   $	��300��67   $��
5, 5, 0, 5q�6C   $
��Left=�6t   ��6W   ��  �� Mode$ OneWay=�6t   �� 5      -   5         ��Name$ txtName��5   "   $	��200��63   $��
5, 5, 0, 3q�6?   $
��Left=�6�   ��6S   ��  �� Path$
 Name� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      -   5        $ 	txtAuthor��5   "   $	��200��65   $��
5, 4, 0, 4q�6A   $
��Left=�6�   ��6U   �� $ Author�$ PropertyChanged=�6�   �� 5      -   5        $ 
txtCountry��5   "   $	��200��66   $��
5, 5, 0, 3q�6B   $
��Left=�6t   ��6V   �� $ Country�6t   �� 5      -   5        $ txtYear��5   "   $��50��63   $��
5, 4, 0, 5q�6>   $
��Left=�6m   ��6R   �� $
 Year�6m   �� 5      -	   5        $ btnSave��5   !   $
��Save��62   $��
5, 0, 0, 5q�6A   $	��125��6U   $
��Left=�6a   6|   �� 5      -
   5        $ btnNew��5   !   $	��New��61   $��
5, 0, 0, 5q�6?   $	��125��6S   $
��Left=�6_   6z   �� 5       -   5        $ 	btnDelete��5    !   $��Delete��64   $��5, 0, 0, 10q�6E   $	��125��6Z   $
��Left=�6f   6�   5!      5"      5#      �� 5$      .+�5%      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 dgBooks��5%      $	��150��6,   
   AutoGenerateColumns
 . ��. $��Visible=�6�   ��6T   �� 5'      5(      5)      5*      5+      