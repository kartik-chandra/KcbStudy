using Kcb.Common;

namespace KcbStudy.Api.Patterns.FactoryPattern
{
    public class AbstractFactoryPatternHelper
    {
        public IAbstractFactory GetAbstractFactory(string type)
        {
            if (type.ToLower() == "mac")
                return new MacFactory();
            else
                return new WindowsFactory();
        }
    }

    public interface IButton
    {
        string Type { get; set; }
        string Name { get; set; }
        void Show();
    }

    public class WindowsButton:IButton
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public WindowsButton()
        {
            Type = "Windows-Button";
            Name = CommonMethods.GenerateRandomString(5);
        }

        public void Show()
        {
            Console.WriteLine($"{Type} - {Name} is in Action");
        }
    }

    public class MacButton : IButton
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public MacButton()
        {
            Type = "Mac-Button";
            Name = CommonMethods.GenerateRandomString(5);
        }

        public void Show()
        {
            Console.WriteLine($"{Type} - {Name} is in Action");
        }
    }

    public interface ITextBox
    {
        string Type { get; set; }
        string Name { get; set; }
        void Show();
    }

    public class WindowsTextBox: ITextBox
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public WindowsTextBox()
        {
            Type = "Windows-TextBox";
            Name = CommonMethods.GenerateRandomString(5);
        }

        public void Show()
        {
            Console.WriteLine($"{Type} - {Name} is in Action");
        }
    }

    public class MacTextBox : ITextBox
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public MacTextBox()
        {
            Type = "Mac-TextBox";
            Name = CommonMethods.GenerateRandomString(5);
        }

        public void Show()
        {
            Console.WriteLine($"{Type} - {Name} is in Action");
        }
    }

    public interface IAbstractFactory
    {
        IButton CreateButton();
        ITextBox CreateTextBox();
    }
    
    public class WindowsFactory : IAbstractFactory
    {
        public IButton Button;
        public ITextBox TextBox;

        public WindowsFactory()
        {
            CreateButton();
            CreateTextBox();
        }

        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public ITextBox CreateTextBox()
        {
            return new WindowsTextBox();
        }
    }

    public class MacFactory : IAbstractFactory
    {
        public IButton Button;
        public ITextBox TextBox;

        public MacFactory()
        {
            CreateButton();
            CreateTextBox();
        }

        public IButton CreateButton()
        {
            return new MacButton();
        }

        public ITextBox CreateTextBox()
        {
            return new MacTextBox();
        }
    }
}
