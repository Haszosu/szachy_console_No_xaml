using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace szachy_console_No_xaml
{
    public static class Creation
    {
        public static Window CreateWindow(int Height, int Width)
        {
            Window NewWindow = new Window();
            NewWindow.Width = Width;
            NewWindow.Height = Height;
            NewWindow.ResizeMode = ResizeMode.NoResize;

            return NewWindow;
        }

        public static Grid CreateGrid(int size,int rows, int collums,bool SGLbool)
        {
            Grid newG = new Grid();
            newG.ShowGridLines = SGLbool;
            newG.Width = (size*2) / 3;
            newG.Height = (size * 2) / 3;

            for (int i = 0; i<rows; i++)
            {
                newG.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i<collums; i++)
            {
                newG.ColumnDefinitions.Add(new ColumnDefinition());
            }

            return newG;
        }
    }

}
