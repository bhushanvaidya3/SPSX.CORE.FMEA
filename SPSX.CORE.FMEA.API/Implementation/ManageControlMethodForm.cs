using SPSX.CORE.FMEA.API.Interfaces;

namespace SPSX.CORE.FMEA.API.Implementation
{
    public class ManageControlMethodForm : IControlMethodForm
    {
        public string GetMessage()
        {
            return "Hello from interface!";
        }
    }
}