   M S B A M L   `   `   `  ���� F  BClicker.GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Clicker.GUIClicker.GUI      Clicker.GUI.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:Clicker.GUI       � Title$  
MainWindow��$	��600��$	��950�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � 	Resources  �� Source�� $# Resources\Lang\string_tr.xaml?�%    '  !System.Windows.Shell.WindowChrome   WindowChrome      CaptionHeight$ 0Q�.���  � RowDefinitions �� $��30 ��� .+��� -    K� ZIndex$ 1��	 �� Orientation$	 
Horizontal=�$
��10,0q�.+���    appFullName#���   $��13(�
�������$��Center=�$��Center=��� -   $��
MyTitleBar��$	��Top=�.+��� ���#240246$��30��._��� $	 
Horizontal=�$��Right=�.+��� -   $��btnMin��$	��—��$��0,-2,0,0q�$	��Top=�$
��Bold"�  TitleButton#��[ $��40���� -   $��	btnNormal��$	��❐��$��0,-2,0,0q�$	��Top=�#��[ $��40���� -   $��btnClose��$
��🗙��$��0,-2,0,0q�#��[ $��40�� � -   $��frame��$��1��
  � NavigationUIVisibility$
 Hidden=�