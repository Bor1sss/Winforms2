using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace RGB_MVVM.Model
{
    class ARGB:DependencyObject
    {
        private static readonly DependencyProperty AlphaProperty;

        private static readonly DependencyProperty RedProperty;

        private static readonly DependencyProperty GreenProperty;

        private static readonly DependencyProperty BlueProperty;

        private static readonly DependencyProperty ColorARGB_Property;

       

        public int Alpha
        {
            get { return (int)GetValue(AlphaProperty); }
            set { SetValue(AlphaProperty, value); }
        }

        public int Red
        {
            get { return (int)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }

        public int Green    
        {
            get { return (int)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        public int Blue
        {
            get { return (int)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        public SolidColorBrush Col
        {
            get { return (SolidColorBrush)GetValue(ColorARGB_Property); }
            set { SetValue(ColorARGB_Property, value); }
        }

        public ARGB(int alpha, int red, int green, int blue, SolidColorBrush col)
        {
            Alpha = alpha;
            Red = red;
            Green = green;
            Blue = blue;
            Col = col;
        }

        static ARGB()
        {
            AlphaProperty = DependencyProperty.Register("Alpha", typeof(int), typeof(ARGB));
            RedProperty = DependencyProperty.Register("Red", typeof(int), typeof(ARGB));
            GreenProperty = DependencyProperty.Register("Green", typeof(int), typeof(ARGB));
            BlueProperty = DependencyProperty.Register("Blue", typeof(int), typeof(ARGB));
            ColorARGB_Property = DependencyProperty.Register("Col", typeof(SolidColorBrush), typeof(ARGB));


        }

    }
}
