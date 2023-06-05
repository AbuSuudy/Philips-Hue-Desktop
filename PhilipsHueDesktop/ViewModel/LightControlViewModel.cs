using PhilipsHueDesktop.Model;
using System.Threading.Tasks;

namespace PhilipsHueDesktop.ViewModel
{
    public class LightControlViewModel
    {
        public LightControlViewModel()
        {
            lightControl = new LightControl
            {
                Kelvin = 2000,
                State = true,          
                Brightness = 100
            };
        }

        public LightControl lightControl {get; set;}
    }
}

