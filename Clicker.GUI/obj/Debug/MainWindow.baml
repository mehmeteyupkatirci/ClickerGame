   M S B A M L   `   `   `  ����F  BClicker.GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Clicker.GUIClicker.GUI  5   	       Clicker.GUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Clicker.GUI     5   	     � Title$  
MainWindow��5   	   $	��600��5	   	   $	��950��5
   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5       �� Source�� 5   
   $# Resources\Lang\string_tr.xaml?�6   %    '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�6   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      .+�5   
   �� -   5         K� ZIndex$ 1��5      	 �� Orientation$	 
Horizontal=�6&   $
��10,0q�6`   .+�5      ��    appFullName#���   6   $��13(�6=   
�������$��Center=�6^   $��Center=�6y   6�   5      �� 5   
   -   5        $��
MyTitleBar��5      $	��Top=�6'   .+�5      �� ���#C6C6C6$��30��6*   ._�5      �� $	 
Horizontal=�6   $��Right=�66   .+�5       �� -   5        $��btnMin��5       $	��—��6+   $��0,-2,0,0q�67   $	��Top=�6I   $
��Bold"�6h     TitleButton#��[ 6�   $��40��6�   6�   �� 5!      -   5        $��	btnNormal��5!      $	��❐��6.   $��0,-2,0,0q�6:   $	��Top=�6L   #��[ 6�   $��40��6�   6�   �� 5"      -   5        $��btnClose��5"      $
��🗙��6-   $��0,-2,0,0q�6:   #��[ 6c   $��40��6�   6�   5#      5$      5%       � 5&   
   -   5        $��frame��5&      $��1��6   
  � NavigationUIVisibility$
 Hidden=�6*   5'      5(      