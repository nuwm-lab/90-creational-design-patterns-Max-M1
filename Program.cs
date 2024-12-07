using System;
using System.Text;

namespace WebsiteBuilderPattern
{
    public class Website
    {
        public string MainPage { get; set; }
        public string ContactPage { get; set; }
        public string ServicesPage { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("=== Вмiст сайту ===");
            if (!string.IsNullOrEmpty(MainPage)) builder.AppendLine($"Головна сторiнка: {MainPage}");
            if (!string.IsNullOrEmpty(ContactPage)) builder.AppendLine($"Сторiнка контактiв: {ContactPage}");
            if (!string.IsNullOrEmpty(ServicesPage)) builder.AppendLine($"Сторiнка послуг: {ServicesPage}");
            return builder.ToString();
        }
    }

    public abstract class WebsiteBuilder
    {
        protected Website website;

        public void CreateWebsite()
        {
            website = new Website();
        }

        public Website GetWebsite()
        {
            return website;
        }

        public abstract void BuildMainPage();
        public abstract void BuildContactPage();
        public abstract void BuildServicesPage();
    }

    public class StandardWebsiteBuilder : WebsiteBuilder
    {
        public override void BuildMainPage()
        {
            website.MainPage = "Ласкаво просимо на наш сайт! Ми пропонуємо найкращi послуги.";
        }

        public override void BuildContactPage()
        {
            website.ContactPage = "Зв'яжiться з нами за адресою: example@example.com або телефонуйте +123456789.";
        }

        public override void BuildServicesPage()
        {
            website.ServicesPage = "Нашi послуги включають розробку веб-сайтiв, мобiльних додаткiв та консалтинг.";
        }
    }

    public class SimpleWebsiteBuilder : WebsiteBuilder
    {
        public override void BuildMainPage()
        {
            website.MainPage = "Ласкаво просимо на наш простий сайт!";
        }

        public override void BuildContactPage()
        {
            website.ContactPage = "Зв'яжiться з нами через email: simple@example.com.";
        }

        public override void BuildServicesPage()
        {
            website.ServicesPage = "Ми пропонуємо простi послуги розробки веб-сайтiв.";
        }
    }

    public class Director
    {
        private WebsiteBuilder builder;

        public void SetBuilder(WebsiteBuilder builder)
        {
            this.builder = builder;
        }

        public Website BuildWebsite()
        {
            builder.CreateWebsite();
            builder.BuildMainPage();
            builder.BuildContactPage();
            builder.BuildServicesPage();
            return builder.GetWebsite();
        }
    }

    class Program
    {
        static void Main()
        {
            Director director = new Director();

            Console.WriteLine("Створення стандартного сайту:");
            WebsiteBuilder standardBuilder = new StandardWebsiteBuilder();
            director.SetBuilder(standardBuilder);
            Website standardWebsite = director.BuildWebsite();
            Console.WriteLine(standardWebsite);

            Console.WriteLine("\nСтворення простого сайту:");
            WebsiteBuilder simpleBuilder = new SimpleWebsiteBuilder();
            director.SetBuilder(simpleBuilder);
            Website simpleWebsite = director.BuildWebsite();
            Console.WriteLine(simpleWebsite);
        }
    }
}
