   M S B A M L   `   `   `  ����G  CWPFPozoriste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFPozoriste.FormeWPFPozoriste.Forme  5   	   )    #WPFPozoriste.Forme.FrmČlanskaKarta   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPFPozoriste.Forme     5   	     � Title$#  Dodaj/Izmijeni člansku kartu��5   	   $	��450��6.   $	��800��6;   .��5	      � ��5
   
   �� 5       �� ImageSource$) #C:\Users\S\Downloads\pozoriste1.jpg��6   6M   .+�5   
   �� $��Popust:��6   
�������$��20(�65   $
��Left=�6C   $��	63,70,0,0q�6^   $	��Top=�6q   $	��137��6�   $��48��6�   �� 5   
   -   5        $��	txtPopust��5      $
��Left=�6#   $��48��6>   $��
231,70,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��244��6�    J� RenderTransformOrigin$ 0.444,-0.146&�6�   �� 5   
   $��Datum Preuzimanja:��6   
�������$��20(�6@   $
��Left=�6N   $��
63,156,0,0q�6i   $	��Top=�6}   $	��195��6�   $��39��6�   �� 5   
   -   5        $��
btnSacuvaj��5      $��20(�6   $��Sačuvaj��61   $
��Left=�6C   $��462,335,0,0q�6^   $	��Top=�6s   $	��111��6�   $��57��6�   6�   �� 5   
   -   5        $��	btnOtkazi��5      $��20(�6   $��Otkaži��60   $
��Left=�6A   $��646,335,0,0q�6\   $	��Top=�6q   $	��107��6�   $��57��6�   6�   �� 5   
   $��Posjetilac:��6   $��20(�6&   
�������$
��Left=�6G   $��
63,235,0,0q�6b   $	��Top=�6v   $	��176��6�   $��43��6�   �� 5   
   -   5        $��cbPosjetilac��5      $
��Left=�6'   $��294,235,0,0q�6B   $	��Top=�6W   $	��146��6o   $��47��6{    �� DisplayMemberPath$ 
Posjetilac��6�    �� SelectedValuePath$ PosjetilacID��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDatumPreuzimanja��5      
�������$��20(�6B   $
��Left=�6P   $��294,156,0,0q�6k   $	��Top=�6�   $��39��6�   $	��202��6�   5      5      