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

using szachy_console_No_xaml;

namespace szachy_console_No_xaml
{
    class App
    {
        [STAThread]
        static void Main()
        {
            Window newWindow = Creation.CreateWindow(700,900);

            DockPanel newDockPanel = new DockPanel();

            int[] NGRandC = new int[2];      
            NGRandC[0] = Convert.ToInt16(Console.ReadLine());
            NGRandC[1] = Convert.ToInt16(Console.ReadLine());

            bool NGbool = true;

            int NGsize = 0;

            if (newWindow.Width >= newWindow.Height) { NGsize = Convert.ToInt16(newWindow.Height); }
            if(newWindow.Width < newWindow.Height) { NGsize = Convert.ToInt16(newWindow.Width); }  

            Grid NewGrid = Creation.CreateGrid(NGsize, NGRandC[0], NGRandC[1], NGbool);

            Button piece1 = piece.piece_creation((((Convert.ToInt16(newWindow.Width) * 2) / 3) / NGRandC[0]),1);

            piece.SetRandConForButtonGrid( ref piece1, 2, 2);

            NewGrid.Children.Add( piece1 );

            newDockPanel.Children.Add(NewGrid);

            newWindow.Content = newDockPanel;

            newWindow.Show();

            System.Windows.Application app = new System.Windows.Application();
            app.Run();

            
        }

    }
}


