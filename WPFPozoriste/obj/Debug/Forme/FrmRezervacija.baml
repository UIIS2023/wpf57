   M S B A M L   `   `   `  ����G  CWPFPozoriste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFPozoriste.FormeWPFPozoriste.Forme  5   	   '    !WPFPozoriste.Forme.FrmRezervacija   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPFPozoriste.Forme     5   	     � Title$   Dodaj/Izmijeni rezervaciju��5   	   $	��500��6,   $	��800��69   .��5	      � ��5
   
   �� 5       �� ImageSource$) #C:\Users\S\Downloads\pozoriste1.jpg��6   6M   .+�5   
   �� $��Datum rezervacije:��6   
�������$��20(�6@   $
��Left=�6N   $��	48,57,0,0q�6i   $	��Top=�6|   $	��184��6�   $��50��6�   �� 5   
   $��Otkazivanje rezervacije��6   
�������$��20(�6E   $
��Left=�6S   $��
48,153,0,0q�6n   $	��Top=�6�   $��50��6�   $	��220��6�   �� 5   
   -   5        $��
btnSacuvaj��5      $��20(�6#   $��Sačuvaj��61   $
��Left=�6C   $��664,285,0,0q�6^   $	��Top=�6s   $	��100��6�   $��63��6�   6�   �� 5   
   -   5        $��	btnOtkazi��5      $��20(�6"   $��Otkaži��60   $
��Left=�6A   $��664,376,0,0q�6\   $	��Top=�6q   $	��100��6�   $��62��6�   6�   �� 5   
   $��
Blagajnik:��6   
�������$��20(�68   $
��Left=�6F   $��
48,244,0,0q�6a   $	��Top=�6u   $	��220��6�   $��51��6�   �� 5   
   $��
Predstava:��6   
�������$��20(�68   $
��Left=�6F   $��
48,328,0,0q�6a   $	��Top=�6u   $	��220��6�   $��49��6�   �� 5   
   -   5        $��cbBlagajnik��5      $
��Left=�6&   $��293,244,0,0q�6A   $	��Top=�6V   $	��252��6n   $��51��6z    �� DisplayMemberPath$ 	Blagajnik��6�    �� SelectedValuePath$ BlagajnikID��6�   �� 5   
   -   5        $��CbPredstava��5      $
��Left=�6&   $��293,328,0,0q�6A   $	��Top=�6V   $	��252��6n   $��49��6z   $ Naziv��6�   $ PredstavaID��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDatumRezervacije��5      
�������$��20(�6B   $
��Left=�6P   $��
293,57,0,0q�6k   $	��Top=�6   $��50��6�   $	��252��6�   �� 5   
   -   5        $��cbxOtkazivanje��5      $�� ��6)   
�������$
��Left=�6G   $��293,153,0,0q�6b   $	��Top=�6w   $��50��6�   $	��319��6�   5      5      