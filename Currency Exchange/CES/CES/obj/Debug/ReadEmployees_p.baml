   M S B A M L   `   `   `  ����>  :CES, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CESCES  5          CES.ReadEmployees_p   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:CES     5        N� Title$  	Employees��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��400 �6   �� 5      $	��350 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DGridReadEmployees��5         AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 28 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5      $ 	Full name��6%   $ * 6U    68   �� *
FullName+6U     5      $ Date of birth��6%   $ * 6\    6<   �� *DateOfBirth+6\     5      $ Passport��6%   $ * 6T    67   �� *
Passport+6T     5      $
 Post��6%   $ * 6L    63   �� *Post+6L     5      $ Number phone��6%   $ * 6[    6;   �� *NumberPhone+6[     5      $ Address��6%   $ * 6R    66   �� *	Address+6R   5      �� 5   
   -   5        	 ��Name$	 	SearchBox��5      $
��Left=�6I   $��	78,10,0,0q�6d   
 �� TextWrapping$

 Wrap=�6w   $	��Top=�6�   $	��307��6�   $��1��6�   $��31��6�   ���	#FF48739A���	#FF6D7386$��Arial)�6�   $��14(�6
  $��1,1,1,2q�6  �� 5   
   $��SEARCH��6   $
��Left=�6!   $��	10,10,0,0q�6<   $��1��6O   $	��Top=�6\   ���	#FF48739A$��Arial)�6�   $��14(�6�   
�������$��31��6�   5      5      