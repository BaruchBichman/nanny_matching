   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5      = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5          PLWPF.UpdateChildControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:PLWPF     5      +BEclr-namespace:BE;assembly=BE     5      
�������$��16(�5	   N   $��Berlin Sans FB Demi)�6\   .��5
      � .+�5   
   � -   5          �Name$  grid1��5      $��50,60,50,30q�6   $	��Top=�63   $��center=�6L    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��Center=�6   $��3��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��
Dob Child:��6r   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dobChildDatePicker��5      
�������$��Center=�6L      DisplayDate$ 1.1.2018��6g   $��3��6  $��3q�6  $
��Left=�6  $��1��68     SelectedDate 6~   �� *
DobChild+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 	 �� UpdateSourceTrigger$	 Explicit=�68  �� 5      $��Center=�6   $��2��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��First Name:��6r   �� 5      -   5        
 ��Name$
 firstNameTextBox��5      
�������$	��120��6G   $��Center=�6S   $��2��6�   $��3q�6�   $��23��6  $
��Left=�6  $��1��6-  ��6n   �� *	FirstName+$ TwoWay=� .  . $	 Explicit=�6-  �� 5      $��Center=�6   $��1��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $	��Id:��6r   �� 5      -   5        $
 	idTextBox��5      $	��120��6)   
�������$��Center=�6L   $��1��6�   $��3q�6�   $��23��6�   $
��Left=�6  $��1��6   �� 	MaxLength$ 9��6/  {�.  ��6g   �� *Id+$ TwoWay=� .  . $	 Explicit=�6=  �� 5!      $��Center=�6   $��4��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��Is Special Needs:��6r   �� 5"      -   5         ��Name$ isSpecialNeedsCheckBox��5"      
�������$��Center=�6N   $��4��6i   $��3q�6v   $
��Left=�6  $��1��6&  $�� ��66   d� 	IsChecked 6�   �� *IsSpecialNeeds+$ TwoWay=� .  . $	 Explicit=�66  �� 5$      $��Center=�6   $��0��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��
Mother Id:��6r   �� 5%      -   5        $
 motherIdTextBox��5%      $	��120��6/   
�������$��Center=�6R   $��0��6�   $��3q�6�   $��23��6  $
��Left=�6  $��1��6+  {�.  ��6m   �� *
MotherId+$ TwoWay=� .  . $	 Explicit=�6;  �� 5'      $��Center=�6   $��5��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��Special Needs:��6r   �� 5(      -   5        $
 specialNeedsTextBox��5(      $	��120��63   
�������$��Center=�6V   $��5��6�   $��3q�6  $��23��6  $
��Left=�6  $��1��63  ��6q   �� *SpecialNeeds+$ TwoWay=� .  . $	 Explicit=�{�6C  ��  �� ElementName$ isSpecialNeedsCheckBox�� �� Path$ 	IsChecked�5)      �� 5*   
   -   5         ��Name$ UpdateChildButton��5*      $��	0,0,0,110q�6,   $��Update Child��6?   $��18(�6V   
����·�$��center=�6~   $��Bottom=�6�   $	��120��6�   $��40��6�   6�   �� 5+   
   -	   5         ��Name$ 	textBlock��5+      $��Center=�6'   $��0,25,0,0q�6D   $
��Wrap=�6V   $&�� Update the details of the child:��6j   $��18(�6�   $��Medium"�6�   $	��Top=�6�   �� 5,   
   -
   5         ��Name$ image��5,      $ ��Images\nannyBackground.png��6   $��Center=�6C   $��4��6`   $��90��6m   $��Bottom=�6z   $	��100��6�   $��0,0,0,10q�6�   5/      50      