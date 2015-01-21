using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Crystalbyte.Converters
{
    [ValueConversion(typeof(BitmapImage), typeof(BitmapImage))]
    public class BitmapColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            Color targetColor;
            if (value is Color)
                targetColor = (Color)value;
            else if (value is SolidColorBrush)
                targetColor = ((SolidColorBrush)value).Color;
            else
                throw new ArgumentException("Cannot convert color from type " + value.GetType(), "value");
            var image = (BitmapImage)parameter;
            byte[] pixels = new byte[image.PixelWidth * image.PixelHeight * 4];
            image.CopyPixels(pixels, image.PixelWidth * 4, 0);

            for (int i = 0; i < pixels.Length; i += 4)
            {
                byte a = pixels[i + 3];

                pixels[i + 2] = (byte)(targetColor.R * a / 255);
                pixels[i + 1] = (byte)(targetColor.G * a / 255);
                pixels[i] = (byte)(targetColor.B * a / 255);
            }
            // Write the modified pixels into a new bitmap and use that as the source of an Image
            var bmp = new WriteableBitmap(image.PixelWidth, image.PixelHeight, image.DpiX, image.DpiY, PixelFormats.Pbgra32, null);
            bmp.WritePixels(new Int32Rect(0, 0, image.PixelWidth, image.PixelHeight), pixels, image.PixelWidth * 4, 0);
            return bmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
