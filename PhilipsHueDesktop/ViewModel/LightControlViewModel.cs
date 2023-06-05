using PhilipsHueDesktop.Model;
using System.Threading.Tasks;

namespace PhilipsHueDesktop.ViewModel
{
    public class LightControlViewModel
    {
        public LightControlViewModel()
        {
            lightControl = new LightControl();
            lightControl.Kelvin = 2000;
            lightControl.Brightness = 100;
            lightControl.State = true;
            
        }

        public LightControl lightControl {get; set;}
    }
}

