using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using ModbusSlave.ViewModels;

namespace ModbusSlave
{
    class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper() : base(true)
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
