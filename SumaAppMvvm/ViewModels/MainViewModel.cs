using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SumaAppMvvm.ViewModels;

public partial class MainViewModel : INotifyPropertyChanged
{
    private double _valor1;
    private double _valor2;
    private double _resultado;

    public double Valor1
    {
        get => _valor1;
        set
        {
            _valor1 = value;
            OnPropertyChanged();
        }
    }

    public double Valor2
    {
        get => _valor2;
        set
        {
            _valor2 = value;
            OnPropertyChanged();
        }
    }

    public double Resultado
    {
        get => _resultado;
        set
        {
            _resultado = value;
            OnPropertyChanged();
        }
    }

    public ICommand SumCommand { get; }
    public ICommand ClearCommand { get; }

    public MainViewModel()
    {
        SumCommand = new Command(OnSum);
        ClearCommand = new Command(OnClear);
    }

    private void OnSum()
    {
        if (Valor1 != 0 && Valor2 != 0)
        {
            Application.Current.MainPage.DisplayAlert("Error", "Por favor, ingrese ambos valores.", "OK");
            return;
        }
        {
            Resultado = Valor1 + Valor2;
        }
    }

    private void OnClear()
    {
        Valor1 = 0;
        Valor2 = 0;
        Resultado = 0;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
