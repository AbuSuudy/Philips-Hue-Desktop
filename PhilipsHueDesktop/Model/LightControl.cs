using PhilipsHueDesktop.Colour_Logic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Media;
namespace PhilipsHueDesktop.Model
{
    public class LightControl : INotifyPropertyChanged
    {

        private SolidColorBrush _backgroundColour;
        public SolidColorBrush BackgroundColour
        {
            get { return _backgroundColour; }
            set
            {
                _backgroundColour = value;
                this.OnPropertyChanged();
            }
        }

        private SolidColorBrush _textColour;
        public SolidColorBrush TextColour
        {
            get { return _textColour; }
            set
            {
                _textColour = value;
                this.OnPropertyChanged();
            }
        }


        private bool _state;
        public bool State
        {
            get { return _state; }
            set
            {
                _state = value;
                PhilipsHueService.PhilipsHueService.LightState(1, _state, Kelvin, Brightness);
                this.OnPropertyChanged();
            }
        }

        private int _kelvin;
        public int Kelvin
        {
            get => _kelvin;
            set
            {

                _kelvin = value;
                BackgroundColour = KelvinToRGB.KelvinToRGBValue(_kelvin);
                PhilipsHueService.PhilipsHueService.LightState(1, _state, Kelvin, Brightness);

            }
        }

        private int _brightness;
        public int Brightness
        {
            get => _brightness;
            set
            {

                _brightness = value;
                var colours = KelvinToRGB.Dim(_brightness);
                PhilipsHueService.PhilipsHueService.LightState(1, _state, Kelvin, Brightness);
                BackgroundColour = colours.FirstOrDefault(x => x.Key == KelvinToRGB.AppColours.Backgroud).Value;
                TextColour = colours.FirstOrDefault(x => x.Key == KelvinToRGB.AppColours.Text).Value;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
