using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.MVVM.ViewModel
{
    
    public partial class HelioKickerViewModel : ObservableObject
    {
        private readonly ContadorDeKikadasModel _contadorDeKikadasModel;

        [ObservableProperty]
        private int _kikadasCount;

        public HelioKickerViewModel(ContadorDeKikadasModel contadorDeKikadasModel)
        {
            _contadorDeKikadasModel = contadorDeKikadasModel;
            
        }

        [RelayCommand]
        public void ContarKikada()
        {
            KikadasCount = _contadorDeKikadasModel.contar();
        }

    }
}
