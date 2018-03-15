using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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



namespace FullScreenWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public Image image { get; set; }
        public BitmapImage bitImage { get; set; }
        public BitmapSource btS { get; set; }

        /*  public MainWindow(BitmapImage im)
          {
              InitializeComponent();
              bitImage = im;
              INIT();
          }*/

        /*public MainWindow(BitmapImage im)
        {
            InitializeComponent();
            bitImage = im;
            INIT();
        }

        public MainWindow(Image im)
        {
            InitializeComponent();
            image = im;
            INIT();
        }*/

        public MainWindow(BitmapSource btS)
        {
            InitializeComponent();
            this.btS = btS;
            INIT();
            
        }
        // FirstPoint use to move image
        private Point firsPoint = new Point();


       
        public void INIT()
        {
           
            //image = new Image { Source = btS };
            //imgSource.= image;
            //cavRoot.Children.Add(image);
            /// imgSource = image;
            //image = new Image();
            image.Height = 200;
            image.Width = 200;
            image.Source = btS;
            
            //this.Content = image;
            //cavRoot.Children.Add(image);
            
          
            image.MouseLeftButtonDown += (ss, ee) =>
            {
                firsPoint = ee.GetPosition(this);
                image.CaptureMouse();

            };



            image.MouseMove += (ss, ee) =>
            {
                if (ee.LeftButton == MouseButtonState.Pressed)
                {
                    // Creat temp point
                    Point temp = ee.GetPosition(this);
                    Point res = new Point(firsPoint.X - temp.X, firsPoint.Y - temp.Y);

                    //Update image location
                    Canvas.SetLeft(image, Canvas.GetLeft(image) - res.X);
                    Canvas.SetTop(image, Canvas.GetTop(image) - res.Y);

                    //Update first point
                    firsPoint = temp;
                }
            };

            image.MouseWheel += (ss, ee) =>
            {
                Matrix mat = image.RenderTransform.Value;
                Point mouse = ee.GetPosition(image);

                if (ee.RightButton == MouseButtonState.Pressed)
                {
                    //Rotate
                    if (ee.Delta > 0)
                        mat.RotateAtPrepend(2, mouse.X, mouse.Y);
                    else
                        mat.RotateAtPrepend(-2, mouse.X, mouse.Y);
                }
                else
                {
                    //--ZOOM
                    if (ee.Delta > 0)
                        mat.ScaleAtPrepend(1.15, 1.15, mouse.X, mouse.Y);
                    else
                        mat.ScaleAtPrepend(1 / 1.15, 1 / 1.15, mouse.X, mouse.Y);
                }
                MatrixTransform mtf = new MatrixTransform(mat);
                image.RenderTransform = mtf;
            };
            image.MouseUp += (ss, ee) =>
            {
                image.ReleaseMouseCapture();
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(System.Windows.Forms.Screen.AllScreens.Length >= 2)
            {
                System.Drawing.Rectangle screenBounds = System.Windows.Forms.Screen.AllScreens[1].Bounds;
                this.Left = screenBounds.Left;
                this.Top = screenBounds.Top;
            }
            this.WindowState = WindowState.Maximized;
        }
    }
}
