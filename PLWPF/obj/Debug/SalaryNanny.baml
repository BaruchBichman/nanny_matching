   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.SalaryNanny   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	   $	��360��5   	   $	��500��6   $��Berlin Sans FB Demi)�6"   .��5	      � .+�5
   
   � 
�������  � RowDefinitions  5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��Center=�6   $
��0,20q�6/   $��0��6=   $��center=�6K   $��0��6h   $��Choose the nanny's ID:��6x   $
��auto��6�   $
��auto��6�   $��25(�6�   $��Berlin Sans FB Demi)�6�   �� 5      -   5         ��Name$ idNannyComboBox��5       �� DisplayMemberPath$ Id��60   
�������$��0,0,0,10q�6^   $��1��6p   $	��200��6}   $��50��6�   $��28(�6�   $��Center=�6�   $��Center=�6  $��3q�67  
������� �� Text 6�   �� *ID+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6K  �� 5      -   5        $��Caclculate Salary��5      $��2��61   
����·�$	��Top=�6X   $��Center=�6p   $��40��6�   $��16(�6�   $	��150��6�   $��3q�6�   ��5      �� 5       �� Triggers 5      �� 5       �� Binding 6*   �� 	 �� ElementName$	 idNannyTextBox��
 �� Path$

 Text� �� Value  6d   .a�5   "   ��  �� Property � {� �� Value .  6E   5      5      5      �� 5       -   5         ��Name$ SalaryTextBox��5       $	��Top=�6,   $��0,0,0,20q�6D   $��3��6V   $��center=�6d   $��0��6�   $
��auto��6�   $
��auto��6�   $��25(�6�   $��Berlin Sans FB Demi)�6�   $��Center=�6�   $��Center=�6   �� 5"      -   5         ��Name$ image��5"      $ ��Images/nannyBackground.png��6#   $��2��6G   $��170,51,166.333,0q�6T   $��2��6n   �� 5#      -   5         ��Name$ close��5#      $��Close��6$   $��3��64   
����·�$��Bottom=�6[   $��Center=�6v   $��40��6�   $��16(�6�   $	��150��6�   $y�Hidden=�6�   $��3q�6�   5%      5'      5(      