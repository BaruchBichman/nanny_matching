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
using System.Windows.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for DownloadAnimationControl.xaml
    /// </summary>
    public partial class DownloadAnimationControl : UserControl
    {
        private int i;
        private double startPos;
        private DispatcherTimer timer;
        public DownloadAnimationControl()
        {
            i = 0;
            InitializeComponent();

            // Store start position of sliding canvas
            startPos = Canvas.GetLeft(SlidingCanvas);

            // Create animation timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        

        private void timer_Tick(object sender, EventArgs e)
        {
            i++;

            if (i < 16)
            {
                // Move SlidingCanvas containing the three colored dots 14 units to the right
                Canvas.SetLeft(SlidingCanvas, Canvas.GetLeft(SlidingCanvas) + 14);
            }
            else
            {
                // Move SlidingCanvas back to its starting position and reset counter
                i = 0;
                Canvas.SetLeft(SlidingCanvas, startPos);
            }
        }
    }
}
