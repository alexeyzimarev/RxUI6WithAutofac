namespace RxUI6WithAutofac
{
    public partial class App
    {
        public App()
        {
            var bootstrapper = new AppBootstrapper();
            bootstrapper.Run();
        }
    }
}
