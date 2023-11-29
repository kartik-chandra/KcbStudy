using Kcb.Logger;
using KcbStudy.Api.Patterns.FactoryPattern;
using Microsoft.AspNetCore.Mvc;

namespace KcbStudy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatternController : ControllerBase
    {
        private IKcbLogger _Logger;

        public PatternController(IKcbLogger logger)
        {
            _Logger = logger;

            _Logger.Info("Pattern controller initialized!");
        }

        [HttpGet("factorypattern")]
        public dynamic FactoryPatternByType(string type)
        {
            try
            {
                VehicleFactory factory = new VehicleFactory();
                IVehicle vehicle = factory.CreateVehicle(type);
                vehicle.Drive();

                return new { IsSuccessful = true, Data = vehicle, Message = "Factory Pattern Implimented" };
            }
            catch (Exception ex) {
                return new { IsSuccessful = false, Data = ex, Message = ex.Message };
            }
        }

        [HttpGet("abstractfactorypattern")]
        public dynamic AbstractFactoryPatternByType(string type)
        {
            try
            {
                AbstractFactoryPatternHelper abstractFactory = new AbstractFactoryPatternHelper();
                IAbstractFactory factory = abstractFactory.GetAbstractFactory(type);
                IButton button = factory.CreateButton();
                ITextBox textBox = factory.CreateTextBox();

                button.Show();
                textBox.Show();

                return new { IsSuccessful = true, Data = new { Button = button, TextBox = textBox }, Message = "Abstract Factory Pattern Implimented" };
            }
            catch (Exception ex)
            {
                return new { IsSuccessful = false, Data = ex, Message = ex.Message };
            }
        }
    }
}
