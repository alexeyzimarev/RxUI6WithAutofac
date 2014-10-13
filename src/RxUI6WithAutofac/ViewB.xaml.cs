using System;
using System.Reactive.Linq;
using System.Windows;
using ReactiveUI;

namespace RxUI6WithAutofac
{
    public partial class ViewB : IViewFor<ViewModelB>
    {
        public ViewB()
        {
            InitializeComponent();

            ViewInstanceCount.Increment();
            ViewInstanceId.Text = ViewInstanceCount.InstanceCount;

            this.WhenActivated(d =>
            {
                d(this.Bind(ViewModel, vm => vm.ViewModelInstanceId, v => v.ViewModelInstanceId.Text));

                d(this.WhenAnyValue(v => v.ViewModel)
                    .Where(v => v != null)
                    .Subscribe(vm => vm.GetDataAndStuffCommand.Execute(null)));
            });
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(ViewModelB), typeof(ViewB));

        public ViewModelB ViewModel
        {
            get { return (ViewModelB)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ViewModelB)value; }
        }
    }
}
