   M S B A M L   `   `   `  ����?  ;Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DemoDemo  5   	       Demo.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Demo     5   	   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  6*   $��14(�5   	     � 
ResizeMode$  NoResize=�5	   	    � Title$ True or False��5
   	   $	��450��6   $	��800��6,   .��5      ]� .+�5   
   o� $��25��6   $��14(�6   $	��Top=�6*   .@�5      m� $
��File��6   .@�5      m� -   5         m�Name$ NewDb��5   /   $	��New��6>   m� 5      -   5        $ OpenDb��5   0   $
��Open��6@   m� 5      -   5        $ SaveDB��5   0   $
��Save��6@   m� 5      -   5        $ DaveAsDb��5   2   $��SaveAS��6D   m� 5      -   5        $ SartGame��5   2   $��
Start Game��6D   �� 5      6   m� 5      -   5        $
 Exit��5   .   $
��Exit��6<   5      m� 5      $
��Edit��6   .@�5      m� -   5        $	 Cut��5   -   $	��Cut��6:   m� 5      -   5        $
 Copy��5   .   $
��Copy��6<   m� 5      -	   5        $
 Past��5   .   $
��Past��6<   5      5      � 5   
   $��12q�6   $��45��6   $��Bottom=�6'    � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��* �6#   .+�5!      �� $��0��6    �� Orientation$ 
Horizontal=�6)   .+�5"      �� -
   5         ��Name$ AddStatement��5"      $��3q�6/   $��80��6:   $	��Add��6E   6S   �� 5#      -   5        $ SaveStatement��5#      $��3q�60   $��80��6;   $
��Save��6F   6U   �� 5$      -   5        $ RemoveStatement��5$      $��3q�62   $��80��6=   $��Remove��6H   6Y   5%      �� 5&      $��1��6   $ 
Horizontal=�6)   $��Center=�6B   .+�5'      %  Xceed.Wpf.Toolkit.IntegerUpDown  -   5          Name$ StatementNumber��5'   %   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 1X�6>      DefaultValue$ 1X�6J   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase	   Text$	 1��6[   $��3q�6d   $��60��6o   6z   �� 5(      -   5        
 ��Name$
 TrueFalseMark��5(   6   $��Center=�6   6M   5)      5*      �� 5+   
   -   5         ��Name$ StatementText��5+      6*   5-      5.      