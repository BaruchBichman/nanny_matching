   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	   = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5   	       PLWPF.AddChildWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	   +BEclr-namespace:BE;assembly=BE     5   	   
�������$	��450��5	      $	��400��6   $��16(�6    $��Berlin Sans FB Demi)�6.     � Icon$   Images/nannyBackground.png��6O   .��5      � .+�5   
   � -   5         �Name$ grid1��5      $��50,60,50,30q�6   $	��Top=�63   $��center=�6L    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��Center=�6   $��3��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��
Dob Child:��6r   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dobChildDatePicker��5      
�������$��Center=�6L      DisplayDate$ 1.1.2018��6g   $��3��6�   $��3q�6�   $
��Left=�6�   $��1��6     SelectedDate 6~   �� *
DobChild+ �� Mode$ TwoWay=� �� NotifyOnValidationError . 	 �� ValidatesOnExceptions	 . 6  �� 5      $��Center=�6   $��2��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��First Name:��6r   �� 5      -   5        
 ��Name$
 firstNameTextBox��5      
�������$	��120��6G   $��Center=�6S   $��2��6�   $��3q�6�   $��23��6�   $
��Left=�6�   $��1��6  ��6n   �� *	FirstName+$ TwoWay=� . 	 . 6  �� 5      $��Center=�6   $��1��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $	��Id:��6r   �� 5       -   5        $
 	idTextBox��5       $	��120��6)   
�������$��Center=�6�   $��1��6  $��3q�6+  $��23��66  $
��Left=�6B  $��1��6]   �� 	MaxLength$ 9��6m  ��6�   �� *Id+$ TwoWay=� . 	 .  �� UpdateSourceTrigger$ Explicit=�6m  �� 5!      $��Center=�6   $��4��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��Is Special Needs:��6r   �� 5"      -   5         ��Name$ isSpecialNeedsCheckBox��5"      
�������$��Center=�6N   $��4��6i   $��3q�6v   $
��Left=�6�   $��1��6  $�� ��6   d� 	IsChecked 6�   �� *IsSpecialNeeds+$ TwoWay=� . 	 . 6  �� 5#      $��Center=�6   $��0��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��
Mother Id:��6r   �� 5$      -   5         ��Name$ motherIdComboBox��5$       �� DisplayMemberPath$ Id��62   $	��120��6I   
�������$��Center=�6l   $��0��6�   $��3q�6�   $��23��6   $
��Left=�6  $��1��6'   �� Text 6�   �� *
MotherId+$ TwoWay=� . 	 . 6'  �� 5%      $��Center=�6   $��5��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��Special Needs:��6r   �� 5&      -   5        $
 specialNeedsTextBox��5&      $	��120��63   
�������$��Center=�6V   $��5��6�   $��3q�6�   $��23��6�   $
��Left=�6�   $��1��6  ��6q   �� *SpecialNeeds+$ TwoWay=� . 	 . {�6%  ��  �� ElementName$ isSpecialNeedsCheckBox�� �� Path$ 	IsChecked�5'      �� 5(   
   -   5         ��Name$ AddChildButton��5(      $��	0,0,0,100q�6)   $��	Add Child��6<   $��18(�6P   
����·�$��center=�6x   $��Bottom=�6�   $	��120��6�   $��40��6�   ��5)      �� 5*       �� Triggers 5+      �� 5,       �� Binding 6&   �� $ dobChildDatePicker��$
 Text� �� Value  6d   .a�5-      ��  �� Property � {� �� Value .  6A   5.      �� 5/       6&   �� $ firstNameTextBox��$
 Text�  6d   .a�50      ��  � {� .  6A   51      �� 52       6&   �� $ motherIdComboBox��$
 Text�  6d   .a�53      ��  � {� .  6A   54      �� 55       6&   �� $ 	idTextBox��$
 Text�  6]   .a�56      ��  � {� .  6A   57      59      5<      �� 5=   
   -	   5         ��Name$ 	textBlock��5=      $��Center=�6'   $��0,25,0,0q�6D   $
��Wrap=�6V   $$��Fill the details of the child:��6j   $��18(�6�   $��Medium"�6�   $	��Top=�6�   �� 5>   
   -
   5         ��Name$ image��5>      $ ��Images\nannyBackground.png��6   $
��Left=�6C   $��	150,0,0,5q�6^   $��90��6q   $��Bottom=�6~   $	��100��6�   5A      5B      