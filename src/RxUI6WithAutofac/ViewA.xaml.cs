using System;
using System.Reactive.Linq;
using System.Windows;
using ReactiveUI;

namespace RxUI6WithAutofac
{
    public partial class ViewA : IViewFor<ViewModelA>
    {
        public ViewA()
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

        static ViewA()
        {
            ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(ViewModelA), typeof(ViewA));
        }

        public static readonly DependencyProperty ViewModelProperty;

        public ViewModelA ViewModel
        {
            get { return (ViewModelA)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ViewModelA)value; }
        }
    }
}
