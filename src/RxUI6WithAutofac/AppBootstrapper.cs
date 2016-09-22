using System.Reflection;
using Autofac;
using ReactiveUI;
using ReactiveUI.Autofac;
using Splat;

namespace RxUI6WithAutofac
{
    public class AppBootstrapper
    {
        public void Run()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var builder = new ContainerBuilder();
            builder.RegisterViews(assembly);
            builder.RegisterViewModels(assembly);
            builder.RegisterScreen(assembly);

            RxAppAutofacExtension.UseAutofacDependencyResolver(builder.Build());
            var view = (MainWindowView)Locator.CurrentMutable.GetService(typeof (IViewFor<MainWindowViewModel>));
            view.Show();
        }

    }
}