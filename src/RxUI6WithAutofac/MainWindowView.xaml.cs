using System.Windows;
using ReactiveUI;

namespace RxUI6WithAutofac
{
    public partial class MainWindowView : IViewFor<MainWindowViewModel>
    {
        public MainWindowView(MainWindowViewModel viewModel)
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                d(this.Bind(ViewModel, vm => vm.Router, v => v.ViewHost.Router));

                d(this.BindCommand(ViewModel, vm => vm.NavigateToACommand, v => v.NavigateToA));
                d(this.BindCommand(ViewModel, vm => vm.NavigateToBCommand, v => v.NavigateToB));
                d(this.BindCommand(ViewModel, vm => vm.BackCommand, v => v.BackButton));
            });

            ViewModel = viewModel;
        }

        static MainWindowView()
        {
            ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(MainWindowViewModel), typeof(MainWindowView));
        }

        public static readonly DependencyProperty ViewModelProperty;

        public MainWindowViewModel ViewModel
        {
            get { return (MainWindowViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MainWindowViewModel)value; }
        }
    }
}
