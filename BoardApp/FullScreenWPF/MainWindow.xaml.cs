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
        public Image image { get; set; }
        public BitmapImage bitImage { get; set; }

        /*  public MainWindow(BitmapImage im)
          {
              InitializeComponent();
              bitImage = im;
              INIT();
          }*/

        public MainWindow(BitmapImage im)
        {
            InitializeComponent();
            bitImage = im;
            INIT();
        }
        // FirstPoint use to move image
        private Point firsPoint = new Point();



        public void INIT()
        {
            image = new Image { Source = bitImage };
            //imgSource.= image;
            //cavRoot.Children.Add(image);
            imgSource = image;

            imgSource.MouseLeftButtonDown += (ss, ee) =>
            {
                firsPoint = ee.GetPosition(this);
                imgSource.CaptureMouse();

            };


            imgSource.MouseWheel += (ss, ee) =>
            {
                Matrix mat = imgSource.RenderTransform.Value;
                Point mouse = ee.GetPosition(imgSource);

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
                imgSource.RenderTransform = mtf;
            };



            imgSource.MouseMove += (ss, ee) =>
            {
                if (ee.LeftButton == MouseButtonState.Pressed)
                {
                    // Creat temp point
                    Point temp = ee.GetPosition(this);
                    Point res = new Point(firsPoint.X - temp.X, firsPoint.Y - temp.Y);

                    //Update image location
                    Canvas.SetLeft(imgSource, Canvas.GetLeft(imgSource) - res.X);
                    Canvas.SetTop(imgSource, Canvas.GetTop(imgSource) - res.Y);

                    //Update first point
                    firsPoint = temp;
                }
            };
            imgSource.MouseUp += (ss, ee) =>
            {
                imgSource.ReleaseMouseCapture();
            };
        }
    }
}
