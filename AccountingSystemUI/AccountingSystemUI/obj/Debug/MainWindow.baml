   M S B A M L   `   `   `  ����M  IAccountingSystemUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AccountingSystemUIAccountingSystemUI  5   	   #    AccountingSystemUI.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:AccountingSystemUI     5   	     � Title$  AccountingSystem��5   	   $	��480��6#   $	��800��60    � AllowsTransparency .  � WindowStyle$
 None=�6V   ���	#FF23252B � 
ResizeMode$ NoResize=�5
   	    � 	Resources 5         FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background	 �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 TittleButtonStyle
 �� 
TargetType �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 7    &	 \    &	     &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $	 	#FFDDDDDD��6;   �� 5   
   $	 	#FF707070��67   �� 5   
   $	 
DodgerBlue��6>   �� 5   
   $	 	#FF3C7FB1��6:   �� 5   
   $	 DeepSkyBlue��6<   �� 5   
   $	 	#FF2C628B��68   �� 5   
   $	 	#FFF4F4F4��6=   �� 5   
   $	 	#FFADB2B5��69   �� 5   
   $	 	#FF838383��6=   �� 5   
   "
 ��6*   .�5       ��  �@�FocusVisualStyle8   61   �� 5!       � ��8  6+   �� 5"       � ��8  6,   �� 5#       � ��# � ��6+   �� 5$       � ��$ 1q�60   �� 5%       � ��$ 1q�6(   �� 5&       � �� 5'      �� 5(      " ��6&   .R�5)      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5*      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5+       5,      P� 5-       �@��IsDefaulted . . �5.   "   �� $ border��6@   # � ��6T    � ��5/      P� 50       �@J�IsMouseOver . . �51   "   �� $ border��6?   8   � ��6S   �� 52   "   $ border��6@   8   � ��6T   53      P� 54       � �� . . �55   "   �� $ border��6?   8   � ��6S   �� 56   "   $ border��6@   8   � ��6T   57      P� 58       � {� .  . �59   "   �� $ border��6?   8   � ��6S   �� 5:   "   $ border��6@   8   � ��6T   �� 5;   "   $ contentPresenter��6K   8 	  � ��6i   5<      5>      5@      5A      5B      .��5C      �  � RowDefinitions 5D   
   �� 5E      �� 5F      $	��14* �6   �� 5G       � ColumnDefinitions 5I   
   �� 5J      $	��17* �6   �� 5K      �� 5L      �� 5M      .+�5O   
   �� -   5        ���	#FF1C2121$��0��5O   L   $��4��6]   $��0��6q   $��30��6~   $	��Top=�6�   �� 5P   
   -   5        
�������$
��____��5P   $   $��18(�63   
������ 
������ $��Segoe UI Emoji)�6u   #��� 
 6�   $��1��6�   $��0��6�   $��30��6�   $	��Top=�6�   �� 5Q   
   -   5        
�������$��X��5Q   $   $��18(�60   
������ 
������ $��Segoe UI Emoji)�6�   #��� 
 6�   $��3��6�   $��0��6�   $��30��6�   $	��Top=�6�   �� 5R   
   -   5        
�������$��[___]��5R   $   $��18(�64   
������ 
������ $��Segoe UI Emoji)�6�   #��� 
 6�   $��2��6�   $��0��6�   $��30��6�   $	��Top=�6�    � 5S   
   -   5        $��	MainFrame��5S        � NavigationUIVisibility$ Hidden=�6!     � Source$ AuthorizationPage.xaml?�6A   $��1��6a   $��0��6n   $��4��6~   5T      5V      