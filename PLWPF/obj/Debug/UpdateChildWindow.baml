   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.UpdateChildWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	   $��605.157��5   	   $	��500��6   $��Berlin Sans FB Demi)�6&   
�������  � Icon$   Images/nannyBackground.png��6^   .��5	      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��6* �6   .+�5   
   �� $��Center=�6   $��0��6+   $��center=�69   $&�� Choose the child's ID to update:��6V   $��25(�6�   $��Berlin Sans FB Demi)�6�   �� 5   
   -   5         ��Name$ idChildComboBox��5       �� DisplayMemberPath$ Id��6`   
�������$��0,0,0,10q�6�   $��1��6�   $	��200��6�   $��50��6�   $��28(�6�   $��Center=�6�   $��Center=�6J  $��3q�6g  
������� �� Text 6�   �� *ID+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6{  �� 5   
   -   5        $��Update Child��5      $��2��6(   
����·�$	��Top=�6O   $��Center=�6g   $��40��6�   $��16(�6�   $	��150��6�   $��3q�6�   ��5      �� 5       �� Triggers 5      �� 5      	 �� Binding	 6&   �� 
 �� ElementName$
 idChildComboBox�� �� Path$
 Text� �� Value  6a   .a�5      ��  �� Property � {� �� Value .  6A   5      5      5      �� 5   
   $ ��Images/nannyBackground.png��6   $��2��64   $	��300��6A   $
�� 300��6N   �� 5    
   -   5         ��Name$ c��5       $��2��6&   .��5!      � .+�5"         PLWPF.UpdateChildControl  -   5          Name$ update��5"   +   $y�Hidden=�6;   5#      5$      5&      5'      