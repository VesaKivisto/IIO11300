   M S B A M L   `   `   `  ����C  ?Tehtava2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Tehtava2Tehtava2  5   	       Tehtava2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Tehtava2     5   	     � Title$  Lottery��5   	   $��403.846��6   $��310.576��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��47* �6   �� 5      $
��256* �6   .+�5   
   �� -   5         ��Name$ btnClose��5      $��Close��6#   $
��Left=�63   $��157.038,335,0,0q�6N   $	��Top=�6g   $��76��6   $��1��6�   �� 5   
   -   5         ��Name$ lblGame��5      $��Choose the game��6!   $
��Left=�6;   $��	15,20,0,0q�6V   $	��Top=�6i   $��2��6�   �� 5   
   -   5        $ lblDraws��5      $��Number of draws��6"   $
��Left=�6<   $��	15,52,0,0q�6W   $	��Top=�6j   $��2��6�   �� 5   
   -   5         ��Name$ cboGames��5      $
��Left=�6%   $��113.038,24,0,0q�6@   $	��Top=�6X   $	��120��6p   $��1��6|   .@�5      �� -   5        $��cbiSuomi��5      .��6+   Suomi62   �� 5      -   5        $��	cbiViking��5      .��6,   Viking Lotto6:   �� 5      -   5        $��cbiEurojackpot��5      .��61   Eurojackpot6>   5      �� 5   
   -   5         ��Name$ 
txtResults��5      $
��Left=�6&   $	��170��6A   $��
20,150,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��260��6�   $��2��6�    �� AcceptsReturn . 6�   �� 5   
   -	   5        $ btnDraw��5      $
��Draw��6"   $
��Left=�61   $��	20,90,0,0q�6L   $	��Top=�6_   $	��120��6w   $��2��6�   �� 5   
   -
   5        $ btnClear��5      $��Clear��6#   $
��Left=�63   $��113.038,90,0,0q�6N   $	��Top=�6f   $	��120��6~   $��1��6�   6�   �� 5   
   -   5        $ txtDraws��5      $
��Left=�6$   $��23��6?   $��113.038,55,0,0q�6K   $
 Wrap=�6c   $��1��6w   $	��Top=�6�   $��40��6�   $��1��6�   �� 5   
   -   5        $ lblRandomNumbers��5      $��Randomly drawn numbers:��6*   $
��Left=�6L   $��
15,120,0,0q�6g   $	��Top=�6{   $��2��6�   5      5      