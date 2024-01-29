using Gastos.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gastos.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listaregistros : ContentPage
    {
        VMlista vM;
        //public Listarregistros()
        //{
        //    InitializeComponent();
        //    BindingContext = new VMlistar(Navigation);
        //}
        public Listaregistros()
        {
            InitializeComponent();
            vM = new VMlista(Navigation);
            BindingContext = vM;
            this.Appearing += async (sender, e) => await Listargastos_Appearing();
        }
        private async Task Listargastos_Appearing()
        {
            await vM.MostrarRegistros();
        }
    }
}