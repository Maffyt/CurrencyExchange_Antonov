   M S B A M L   `   `   `  ����>  :CES, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CESCES  5          CES.Currency_p   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:CES     5        N� Title$  
Currencies��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��400 �6   �� 5      $	��350 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DGridCurrency��5         AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 35 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6Z     5      $
 Name��6%   $ * 6q    63   �� *Name+	 �� UpdateSourceTrigger$	 PropertyChanged=�6q     5      $ Quantity��6%   $ * 6y    67   �� *
Quantity+$	 PropertyChanged=�6y     5      $ Purchase rate��6%   $ * 6�    6<   �� *PurchaseRate+$	 PropertyChanged=�6�     5      $ Selling rate��6%   $ * 6�    6;   �� *SellingRate+$	 PropertyChanged=�6�   5      �� 5   
   -   5        $��BtnAdd��5      $	��ADD��64   $
��Left=�6B   $��	10,10,0,0q�6]   $��1��6p   $	��Top=�6}   $	��209��6�   $��31��6�   ���	#FF48739A$��18(�6�   $��Arial)�6�   
�������$��0,0,0,0q�6�   �� 5   
   -   5        $��BtnDel��5      $��DELETE��64   $
��Left=�6E   $��
243,10,0,0q�6`   $��1��6t   $	��Top=�6�   $	��209��6�   $��31��6�   ���	#FF48739A$��18(�6�   $��Arial)�6�   
�������$��0,0,0,0q�6�   �� 5   
   -   5        
 ��Name$
 	BtnExport��5      $��EXPORT (CSV)��6<   $
��Left=�6S   $��
981,10,0,0q�6n   $��1��6�   $	��Top=�6�   $	��209��6�   $��31��6�   ���	#FF48739A$��18(�6�   $��Arial)�6�   
�������$��0,0,0,0q�6
  �� 5   
   -   5        $��	SearchBox��5      $
��Left=�6G   $��
600,10,0,0q�6b    �� TextWrapping$
 Wrap=�6v   $	��Top=�6�   $	��307��6�   $��1��6�   $��31��6�   ���	#FF48739A���	#FF6D7386$��Arial)�6�   $��14(�6	  $��1,1,1,2q�6  �� 5   
   $��SEARCH��6   $
��Left=�6!   $��
532,10,0,0q�6<   $��1��6P   $	��Top=�6]   ���	#FF48739A$��Arial)�6�   $��14(�6�   
�������$��31��6�   5      5      