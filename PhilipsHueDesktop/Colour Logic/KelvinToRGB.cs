using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace PhilipsHueDesktop.Colour_Logic
{
    public static class KelvinToRGB
    {
        //https://tannerhelland.com/2012/09/18/convert-temperature-rgb-algorithm-code.html
        
		public  enum AppColours
		{
			Backgroud,
			Text
		}

		private static Color backgroudcolor;

		private static SolidColorBrush textColor;

        public static List<KeyValuePair<AppColours, SolidColorBrush>> Dim(double brightness)
        {
			if (brightness < 70)
            {
				textColor = new SolidColorBrush(Colors.White);
			}
            else
            {
				textColor = new SolidColorBrush(Colors.Black);
			}

			double alpha = 255 * (brightness/100);

			backgroudcolor = Color.FromArgb(Convert.ToByte(alpha), backgroudcolor.R, backgroudcolor.G, backgroudcolor.B);

            return new  List<KeyValuePair<AppColours, SolidColorBrush>>() {
                    new KeyValuePair<AppColours, SolidColorBrush>(AppColours.Backgroud, new SolidColorBrush(backgroudcolor)),
					new KeyValuePair<AppColours, SolidColorBrush>(AppColours.Text, textColor),
				};

		}


		public static SolidColorBrush KelvinToRGBValue(double temperature)
		{
			// Temperature must fit between 1000 and 40000 degrees.
			temperature = MathUtils.Clamp(temperature, 1000, 40000);

			// All calculations require temperature / 100, so only do the conversion once.
			temperature /= 100;

			// Compute each color in turn.
			int red, green, blue;

			// First: red.
			if (temperature <= 66)
			{
				red = 255;
			}
			else
			{
				// Note: the R-squared value for this approximation is 0.988.
				red = (int)(329.698727446 * (Math.Pow(temperature - 60, -0.1332047592)));
				red = MathUtils.Clamp(red, 0, 255);
			}

			// Second: green.
			if (temperature <= 66)
			{
				// Note: the R-squared value for this approximation is 0.996.
				green = (int)(99.4708025861 * Math.Log(temperature) - 161.1195681661);
			}
			else
			{
				// Note: the R-squared value for this approximation is 0.987.
				green = (int)(288.1221695283 * (Math.Pow(temperature - 60, -0.0755148492)));
			}

			green = MathUtils.Clamp(green, 0, 255);

			// Third: blue.
			if (temperature >= 66)
			{
				blue = 255;
			}
			else if (temperature <= 19)
			{
				blue = 0;
			}
			else
			{
				// Note: the R-squared value for this approximation is 0.998.
				blue = (int)(138.5177312231 * Math.Log(temperature - 10) - 305.0447927307);
				blue = MathUtils.Clamp(blue, 0, 255);
			}

			backgroudcolor = Color.FromArgb(backgroudcolor.A, Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue));


            return new SolidColorBrush(backgroudcolor);
		}

	}

	public static class MathUtils
	{
		public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
		{
			if (value.CompareTo(min) < 0)
			{
				value = min;
			}
			else if (value.CompareTo(max) > 0)
			{
				value = max;
			}

			return value;
		}
	}
}
