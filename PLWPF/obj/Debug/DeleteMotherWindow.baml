   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.DeleteMotherWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$  DeleteMotherWindow��5   	   $	��360��6$   $	��500��61   $��Berlin Sans FB Demi)�6=   .��5	      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Center=�6   $
��0,20q�6+   $��0��69   $��center=�6G   $��0��6d   $&�� Enter the mother's ID to remove:��6t   $
��auto��6�   $
��auto��6�   $��25(�6�   $��Berlin Sans FB Demi)�6�   �� 5   
   -   5         ��Name$ idMotherComboBox��5       �� DisplayMemberPath$ Id��6-   
�������$��0,0,0,10q�6[   $��1��6m   $	��200��6z   $��50��6�   $��28(�6�   $��Center=�6�   $��Center=�6  $��3q�64  
������� �� Text 6�   �� *ID+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6H  �� 5   
   -   5        $��Remove Mother��5      $��2��6)   
����·�$	��Top=�6P   $��Center=�6h   $��40��6�   $��16(�6�   $	��150��6�   $��3q�6�   ��5      �� 5       �� Triggers 5      �� 5      	 �� Binding	 6&   �� 
 �� ElementName$
 idMotherTextBox�� �� Path$
 Text� �� Value  6a   .a�5      ��  �� Property � {� �� Value .  6A   5      5      5      �� 5    
   $ ��Images/nannyBackground.png��6   $��2��64   $��170,51,166.333,0q�6A   $��2��6[   5"      5#      