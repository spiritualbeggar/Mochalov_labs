   M S B A M L   `   `   `  ���� 	  lab_3    lab_3.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$c  ]Интегральный Калькулятор - Иванов Иван И., Группа XYZ��$	��450��$	��800��.���  � RowDefinitions �� $
��Auto ��� $��* �.+���  �� Orientation$ Vertical=�$��10q�.+��� $/��)Результаты вычислений��$
��Bold"�$��16(�$��0,0,0,10q��� $<��6Последовательные вычисления:��$
��Bold"��� -    ��Name$ SequentialResult��$��	10,0,0,10q�$
��Wrap=��� $4��.Параллельные вычисления:��$
��Bold"��� -   $ ParallelResult��$��	10,0,0,10q�$
��Wrap=��� $=��7Сравнение времени выполнения:��$
��Bold"��� -   $ TimeComparison��$��	10,0,0,10q�$
��Wrap=�