using Autofac;
using ReactiveUI;
using Splat;

namespace RxUI6WithAutofac
{
    public class AppBootstrapper
    {
        public void Run()
        {
            var builder = new ContainerBuilder();
            builder.Register<IViewFor<ViewModelA>>(c => new ViewA());
            builder.Register<IViewFor<ViewModelB>>(c => new ViewB());

            builder.RegisterType<ViewModelA>().AsSelf().AsImplementedInterfaces();
            builder.RegisterType<ViewModelB>().AsSelf().AsImplementedInterfaces();

            builder.RegisterType<MainWindowViewModel>().AsSelf().As<IScreen>().SingleInstance();
            builder.RegisterType<MainWindowView>().AsSelf();

            RxAppAutofacExtension.UseAutofacDependencyResolver(builder.Build());
            var view = (MainWindowView)Locator.CurrentMutable.GetService(typeof (MainWindowView));
            view.Show();
        }

    }
}