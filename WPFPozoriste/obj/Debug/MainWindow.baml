   M S B A M L   `   `   `  ����G  CWPFPozoriste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WPFPozoristeWPFPozoriste  5   	       WPFPozoriste.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WPFPozoriste     5   	     � Title$  	Pozoriste��5      $	��350��6   $	��700��6+   .��5	      � ��5
   
   �� 5       �� ImageSource$) #C:\Users\S\Downloads\pozoriste1.jpg��6   6M   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridCentralni��5      $��Center=�6,   $��Center=�6I   $
��auto��6d   $
��auto��6r      
IsReadOnly .    AlternatingRowBackground
 �  ��   CanUserAddRows .     SelectionUnit$ FullRow=�5   I      SelectionMode$ Single=�6a   �� 5   
   $��Center=�6   $��30��62   $	��Top=�6?   $
��auto��6W    �� Orientation$ 
Horizontal=�6d   .+�5      �� -   5         ��Name$ btnBlagajnik��5      $��	Blagajnik��6,   $
��Left=�6@   $��30��6[   $	��Top=�6g   $��75��6   6�   �� 5      -   5        $ btnCin��5      $
��Čin��6%   $
��Left=�64   $��30��6O   $	��Top=�6[   $��75��6s   6~   �� 5      -   5        $ btnClanskaKarta��5      $��Članska karta��6.   $
��Left=�6F   $��30��6a   $	��Top=�6m   $��75��6�   6�   �� 5      -   5        $ btnKarta��5      $��Karte��6'   $
��Left=�67   $��30��6R   $	��Top=�6^   $��75��6v   6�   �� 5      -   5        $ btnPosjetilac��5      $��
Posjetilac��6,   $
��Left=�6A   $��30��6\   $	��Top=�6h   $��75��6�   6�   �� 5      -   5        $ btnPredstava��5      $��	Predstava��6+   $
��Left=�6?   $��30��6Z   $	��Top=�6f   $��75��6~   6�   �� 5      -   5        $ btnProducent��5      $��	Producent��6+   $
��Left=�6?   $��75��6Z   $��	0,0,0,0.4q�6�   �� 5      -	   5        $ btnRezervacija��5      $��Rezervacija��6-   $
��Left=�6C   $	��Top=�6_   $��75��6w   $��30��6�   6�   �� 5      -
   5        $ btnZanrPredstave��5      $��Žanr��6/   $
��Left=�6>   $	��Top=�6Z   $��75��6r   $��30��6}   6�   5      �� 5   
   $��Center=�6   $��30��62   $��Bottom=�6?   $	��360��6Z   $ 
Horizontal=�6f   .+�5      �� -   5        $ btnDodaj��5      $��Dodaj��6'   $	��120��67   6C   �� 5      -   5        $ 	btnIzmeni��5      $��Izmeni��6(   $	��120��69   6E   �� 5      -   5        $ 	btnObrisi��5      $��Obriši��6(   $	��120��69   6E   5      5&      5'      