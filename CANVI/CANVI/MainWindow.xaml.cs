using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CANVI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = null;
        private int x;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        Point targetPoint;
        Point newPoint;
        ComboBox mine;
        private List<MyTextBox> textboxlist = new List<MyTextBox>();
        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {

            var targetElement = e.Source as IInputElement;
            if (targetElement != null)
            {
                targetPoint = e.GetPosition(targetElement);
                targetElement.CaptureMouse();
            }
        }

        private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            var targetElement = Mouse.Captured as UIElement;
            if (e.LeftButton == MouseButtonState.Pressed && targetElement != null)
            {
                var pCanvas = e.GetPosition(canvas);
                Canvas.SetLeft(targetElement, pCanvas.X - targetPoint.X);
                Canvas.SetTop(targetElement, pCanvas.Y - targetPoint.Y);
            }
        }

        private void timering(double x, double y)
        {
            var customControl = new CustomControls(x-10, y-50);
            canvas.Children.Add(customControl);
            timer = new DispatcherTimer();
            timer.Tick += (sender, e) => { canvas.Children.Remove(customControl); };
            timer.Interval = new TimeSpan(0, 0, 0, 2, 0);
            timer.Start();
        }
        private void first_Click(object sender, RoutedEventArgs e)
        {
            var capybara = new Capybara();
            canvas.Children.Add(capybara);
        }
        private void second_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Add(name());
            mine.PreviewMouseRightButtonDown += Mine_PreviewMouseRightButtonDown;
        }

        private void Mine_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            string s = mine.Text;
            if (s != "")
            {
                int count = int.Parse(s);
                for (int i = 0; i < count; i++)
                {
                    var capybara = new Capybara();
                    canvas.Children.Add(capybara);
                }
            }
        }

        private ComboBox name()
        {
            mine = new ComboBox();
            mine.Width = 60;
            mine.Height = 20;
            mine.Items.Add("1");
            mine.Items.Add("2");
            mine.Items.Add("3");
            mine.Items.Add("4");    
            mine.Items.Add("5");
            mine.Items.Add("6");
            mine.Items.Add("7");
            mine.Items.Add("8");
            mine.Items.Add("9");
            mine.Items.Add("10");
            Canvas.SetLeft(mine, 350);
            Canvas.SetTop(mine, 180);
            return mine;
        }
        private void third_Click(object sender, RoutedEventArgs e)
        {
            var label = new Labeling();
            canvas.Children.Add(label);
            label.MouseRightButtonDown += new MouseButtonEventHandler(Yellow_Click);
            double x = Canvas.GetLeft(label);
            double y = Canvas.GetTop(label);
            newPoint = new Point(x, y);
        }

        private void Yellow_Click(object sender, MouseButtonEventArgs e)
        {
            Point clickPosition = e.GetPosition(this);
            double x = clickPosition.X;
            double y = clickPosition.Y;
            timering(x, y);
        }

    }
}
