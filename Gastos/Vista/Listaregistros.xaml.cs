﻿using Gastos.VistaModelo;
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
        public Listaregistros()
        {
            InitializeComponent();
            BindingContext = new VMlista(Navigation);
        }
    }
}