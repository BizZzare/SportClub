   M S B A M L   `   `   `  ����K  GSportClubDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:SportClubDesktop.OtherWindows.Trainings'SportClubDesktop.OtherWindows.Trainings  5   	   :    4SportClubDesktop.OtherWindows.Trainings.EditTraining   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:SportClubDesktop.OtherWindows.Trainings     5   	   -   5          � Title$  EditTraining��5   	   $��490.601��6   $��393.985��6/   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��52* �6   �� 5      $
��141* �6   .+�5   
   �� $��Edit Training:��6   $��Center=�6)   $
��Left=�6M   $��	10,10,0,0q�6h   $	��Top=�6{   $	��355��6�   $��24(�6�   $��48��6�   $��2��6�   �� 5   
   $��Date: ��6   $
��Left=�6!   $��	10,58,0,0q�6<   $	��Top=�6O   $��99��6g   $��2��6r   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dtDate��5      $
��Left=�6%   $��9.729,59,0,0q�6@   $	��Top=�6V   $	��251��6n   $��1��6z   �� 5   
   $��Time: ��6   $
��Left=�6!   $��	10,93,0,0q�6<   $	��Top=�6O   $��99��6g   $��2��6r   �� 5   
   -   5         ��Name$ cbHours��5      $
��Left=�6$   $��9.729,93,0,0q�6?   $	��Top=�6U   $	��113��6m   $��1��6y   �� 5   
   $��:��6   $
��Left=�6   $��127.729,93,0,0q�67   $	��Top=�6O   $��17��6g   $��1��6r   �� 5   
   -   5        $ 	cbMinutes��5      $
��Left=�6&   $��150.729,93,0,0q�6A   $	��Top=�6Y   $	��113��6q   $��1��6}   �� 5   
   $��Member: ��6   $
��Left=�6#   $��
10,124,0,0q�6>   $	��Top=�6R   $��99��6j   $��2��6u   �� 5   
   -   5         ��Name$ 
lstMembers��5       �� SelectionMode$ Single=�6&   $
��Left=�6=   $	��105��6X   $��9.729,124,0,0q�6e   $	��Top=�6|   $	��251��6�   $��1��6�   �� 5   
   $��	Trainer: ��6   $
��Left=�6$   $��
10,243,0,0q�6?   $	��Top=�6S   $��99��6k   $��2��6v   �� 5   
   -   5        $ lstTrainers��5      $ Single=�6'   $
��Left=�6>   $	��105��6Y   $��9.729,243,0,0q�6f   $	��Top=�6}   $	��251��6�   $��1��6�   �� 5   
   $��Cost: ��6   $
��Left=�6!   $��
10,359,0,0q�6<   $	��Top=�6P   $��99��6h   $��2��6s   �� 5   
   -   5         ��Name$ txtCost��5   >   $
��Left=�6P   $��23��6k   $��9.729,359,0,0q�6w    �� TextWrapping$
 Wrap=�6�   $��0��6�   $	��Top=�6�   $	��251��6�   $��1��6�   �� 5   
   -   5         ��Name$ 	btnCancel��5   )   $��Cancel��6<   $
��Left=�6M   $��183.729,416,0,0q�6h   $	��Top=�6�   $��75��6�   $��1��6�   �� 5   
   -	   5        $ btnSave��5   '   $
��Save��68   $
��Left=�6G   $��103.729,416,0,0q�6b   $	��Top=�6{   $��75��6�   $��1��6�   5      5       