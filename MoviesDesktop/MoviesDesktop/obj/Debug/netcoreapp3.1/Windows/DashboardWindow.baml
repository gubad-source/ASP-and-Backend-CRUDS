   M S B A M L   `   `   `  ����H  DMoviesDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MoviesDesktop.WindowsMoviesDesktop.Windows  5   	   +    %MoviesDesktop.Windows.DashboardWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:MoviesDesktop.Windows     5   	     � Title$  DashboardWindow��5   	   $	��450��6!   $	��800��6.    � WindowState$ 	Maximized=�5	   	   .��5
      � $��10,0,0,0q�6   .+�5   
   � $��	0,0,548,0q�6   .+�5      �� -   5         ��Name$ LblName��5      $��
Movie Name��6%   $
��Left=�6:   $��	35,31,0,0q�6U   $	��Top=�6h    J� RenderTransformOrigin$ 0.319,-1.503&�6�   �� 5      -   5         ��Name$ TxtName��5      $
��Left=�6'   $��	35,77,0,0q�6B    �� TextWrapping$
 Wrap=�6U   $	��Top=�6i   $	��120��6�   �� 5      -   5        $ LblDate��5      $��Release Date��6%   $
��Left=�6<   $��
38,127,0,0q�6W   $	��Top=�6k   $	��120��6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ CmbDate��5      $
��Left=�6*   $��
35,174,0,0q�6E   $ -0.381,-1.19&�6Y   $	��118��6~   $	��Top=�6�   �� 5      -   5        $ 
LblCountry��5      $��Country��6(   $
��Left=�6:   $��
38,217,0,0q�6U   $	��Top=�6i   �� 5      -   5         ��Name$ 
CmbCountry��5      $	��120��6+   $��33,265,99,0q�67   $	��Top=�6L    �� DisplayMemberPath$
 Name��6�   	 �� SelectedValuePath$	 Id��6�   ��6d   �� 
 �� Path$
 Country� �� SelectedValue 6�   �� $
 Country��� 5      -   5         ��Name$ 	BtnCreate��5      $��Create��6(   $
��Left=�69   $��
35,326,0,0q�6T   $	��Top=�6h   6�   �� 5      -   5        $ 
BtnUpgrade��5      $��Upgrade��6)   $
��Left=�6;   $��
33,363,0,0q�6V   $	��Top=�6j   $ 0.177,1.018&�6�   $y�Hidden=�6�   6�   �� 5      -	   5        $ 	BtnDelete��5      $��Delete��6)   $
��Left=�6:   $��126,363,0,0q�6U   $	��Top=�6j   $y�Hidden=�6�   6�   5      � 5   
   $��	270,0,0,0q�6   .+�5      &   System.Windows.Controls.DataGrid  -
   5          Name$ 	DgvMovies��5   ]      AutoGenerateColumns$ False��6      CanUserAddRows$ False��63   $��	0,292,0,0q�6J      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 0.08* 6)      Header$ Id��67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *Id+  5      $ 0.15* 6)   $
 Name��67    6E   �� *Name+  5      $ 0.30* 6)   $ Release Date��67    6M   �� *ReleaseDate+  5      $ 0.30* 6)   $ Country��67    6H   �� *Country.Name+ �� StringFormat$ {0:dd.MM.yyyy }��5      5       5!      5"      