using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Rotate_A_Pix
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TimeAttack_Lv2 : Page
    {
        Image[] imgarr = new Image[16];
        int[] winarr = new int[16];
        int counter = 30;
        DispatcherTimer newTimer = new DispatcherTimer();
        public TimeAttack_Lv2()
        {
            int i;
            Random rnd = new Random();
            this.InitializeComponent();
            imgarr[0] = image;
            imgarr[1] = image1;
            imgarr[2] = image3;
            imgarr[3] = image4;
            imgarr[4] = image5;
            imgarr[5] = image6;
            imgarr[6] = image7;
            imgarr[7] = image8;
            imgarr[8] = image9;
            imgarr[9] = image10;
            imgarr[10] = image11;
            imgarr[11] = image12;
            imgarr[12] = image13;
            imgarr[13] = image14;
            imgarr[14] = image15;
            imgarr[15] = image16;
            for (i = 0; i < 16; i++)
            {
                winarr[i] = rnd.Next(0, 4);
                ((RotateTransform)imgarr[i].RenderTransform).Angle = /*Convert.ToDouble*/90 * winarr[i];
                //wintext.Text = winarr[i].ToString();
            }
            Lv2grid.Visibility = Visibility.Collapsed;
        }
        public void animateImage(int index)
        {
            Storyboard s = new Storyboard();
            DoubleAnimation anim = new DoubleAnimation();
            if (Convert.ToInt32(((RotateTransform)imgarr[index].RenderTransform).Angle) % 90 == 0)
                anim.To = ((RotateTransform)imgarr[index].RenderTransform).Angle + 90;
            anim.Duration = new Duration(TimeSpan.FromMilliseconds(90));
            Storyboard.SetTarget(anim, imgarr[index]);
            Storyboard.SetTargetProperty(anim, "(UIElement.RenderTransform).(RotateTransform.Angle)");
            s.Children.Add(anim);
            imgarr[index].IsTapEnabled = false;
            s.Begin();
            /*if (((RotateTransform)imgarr[index].RenderTransform).Angle > 270)//else
                ((RotateTransform)imgarr[index].RenderTransform).Angle = 0;*/
            //wintext.Text = ((RotateTransform)imgarr[index].RenderTransform).Angle.ToString();
            //wintext.Text = winarr[index].ToString();
            //wintext.Text = Convert.ToString(((RotateTransform)imgarr[index].RenderTransform).Angle);
        }
        public async void fade()
        {
            Storyboard fadestoryboard = new Storyboard();
            DoubleAnimation fadeanim = new DoubleAnimation();
            fadeanim.To = 0;
            fadeanim.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            Storyboard.SetTarget(fadeanim, Lv2grid);
            Storyboard.SetTargetProperty(fadeanim, "Opacity");
            fadestoryboard.Children.Add(fadeanim);
            fadestoryboard.Begin();
            wintext.Text = "Level Completed";
            await Task.Delay(1000);
            //Delay(1000);
            //fadestoryboard.Stop();
            /*Image Lv1_main = new Image();
            Lv1_main.Source = new BitmapImage(new Uri("ms-appx:///Assets/3_main.png"));
            Lv1_main.Margin = new Thickness(32, 130, 0, 0);
            Lv1_main.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
            Lv1_main.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top;
            Lv1_main.Height = 334;
            Lv1_main.Width = 339;
            Lv1_main.Opacity = 0;
            */
            Storyboard appearstoryboard = new Storyboard();
            DoubleAnimation appearanim = new DoubleAnimation();
            appearanim.To = 1;
            appearanim.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            Storyboard.SetTarget(appearanim, Lv2_main);
            Storyboard.SetTargetProperty(appearanim, "Opacity");
            appearstoryboard.Children.Add(appearanim);
            appearstoryboard.Begin();
            newTimer.Stop();
            NextButton.Visibility = Visibility.Visible;
        }
        public void appearpic()
        {
            Image Lv2_main = new Image();
            Lv2_main.Source = new BitmapImage(new Uri("ms-appx:///Assets/8_main.png"));
            Lv2_main.Margin = new Thickness(32, 130, 0, 0);
            Lv2_main.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
            Lv2_main.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top;
            Lv2_main.Height = 334;
            Lv2_main.Width = 339;
            Lv2_main.Opacity = 0;
            Storyboard appearstoryboard = new Storyboard();
            DoubleAnimation appearanim = new DoubleAnimation();
            appearanim.To = 1;
            appearanim.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            Storyboard.SetTarget(appearanim, Lv2_main);
            Storyboard.SetTargetProperty(appearanim, "Opacity");
            appearstoryboard.Children.Add(appearanim);
            appearstoryboard.Begin();
        }
        public async void Delay(int millisec)
        {
            await Task.Delay(millisec);
        }
        public int iswin()
        {
            // Delay(100);
            int i, num = 0, count = 0;
            for (i = 0; i < 16; i++)
            {
                if ((Convert.ToInt32(((RotateTransform)imgarr[i].RenderTransform).Angle)) % 360 == 0)
                {
                    count++;
                }
                else
                {
                    num = Convert.ToInt32(((RotateTransform)imgarr[i].RenderTransform).Angle);
                }
            }
            if (count == 15 && num == 270)
                return 1;
            else
                return 0;
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            counter = counter + (int)e.Parameter;
            CountdownTimer.Text = "Time Remaining: " + counter.ToString();
        }

        private void image_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(0);
            if (iswin() == 1)
                fade();
        }

        private void image1_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(1);
            if (iswin() == 1)
                fade();
        }

        private void image3_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(2);
            if (iswin() == 1)
                fade();
        }

        private void image4_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(3);
            if (iswin() == 1)
                fade();
        }

        private void image5_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(4);
            if (iswin() == 1)
                fade();
        }

        private void image6_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(5);
            if (iswin() == 1)
                fade();
        }

        private void image7_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(6);
            if (iswin() == 1)
                fade();
        }

        private void image8_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(7);
            if (iswin() == 1)
                fade();
        }

        private void image9_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(8);
            if (iswin() == 1)
                fade();
        }

        private void image10_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(9);
            if (iswin() == 1)
                fade();
        }

        private void image11_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(10);
            if (iswin() == 1)
                fade();
        }

        private void image12_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(11);
            if (iswin() == 1)
                fade();
        }

        private void image13_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(12);
            if (iswin() == 1)
                fade();
        }

        private void image14_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(13);
            if (iswin() == 1)
                fade();
        }

        private void image15_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(14);
            if (iswin() == 1)
                fade();
        }

        private void image16_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            animateImage(15);
            if (iswin() == 1)
                fade();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Start.Opacity = 0;
            /*glb+=1;
            wintext.Text = glb.ToString();*/
            Start.IsTapEnabled = false;
            Start.IsRightTapEnabled = false;
            Start.IsHoldingEnabled = false;
            Start.IsDoubleTapEnabled = false;
            Start.Visibility = Visibility.Collapsed;
            Lv2grid.Visibility = Visibility.Visible;
            newTimer.Interval = TimeSpan.FromSeconds(1);
            newTimer.Tick += OnTimerTick;

            newTimer.Start();
        }

        private void OnTimerTick(object sender, object e)
        {
            counter--;
            if (counter < 0)
            {
                newTimer.Stop();
                lose();
                //counter = 30;
            }
            else
            {
                CountdownTimer.Text = "Time Remaining: " + counter.ToString();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TimeAttack_Lv3), counter);
        }

        private void TryAgain_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TimeAttack_Lv2),0);
        }
        public void lose()
        {
            Storyboard fadestoryboard = new Storyboard();
            DoubleAnimation fadeanim = new DoubleAnimation();
            fadeanim.To = 0;
            fadeanim.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            Storyboard.SetTarget(fadeanim, Lv2grid);
            Storyboard.SetTargetProperty(fadeanim, "Opacity");
            fadestoryboard.Children.Add(fadeanim);
            fadestoryboard.Begin();
            Lv2grid.Visibility = Visibility.Collapsed;
            LoseMessage.Visibility = Visibility.Visible;
            TryAgain.Visibility = Visibility.Visible;
        }
    }
}
