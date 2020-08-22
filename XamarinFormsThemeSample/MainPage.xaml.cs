using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsThemeSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

    }
    public class RegistPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ThemeOptions:RegistPropertyChanged
    {

        private bool _useDarkMode;
        public bool UseDarkMode
        {
            get => _useDarkMode;
            set
            {
                _useDarkMode = value;
                RaisePropertyChanged();
                if (_useDarkMode)
                {
                    UseLightMode = UseDeviceThemeSettings = false;

                    App.Current.UserAppTheme = OSAppTheme.Dark;
                }
            }
        }
        private bool _useLightMode;
        public bool UseLightMode
        {
            get => _useLightMode;
            set
            {
                _useLightMode = value;
                RaisePropertyChanged();
                if (_useLightMode)
                {
                    UseDarkMode = UseDeviceThemeSettings = false;

                    App.Current.UserAppTheme = OSAppTheme.Light;
                }
            }
        }
        private bool _useDeviceThemeSettings;
        public bool UseDeviceThemeSettings
        {
            get => _useDeviceThemeSettings;
            set
            {
                _useDeviceThemeSettings = value;
                RaisePropertyChanged();
                if (_useDeviceThemeSettings)
                {
                    UseLightMode = UseDarkMode = false;

                    App.Current.UserAppTheme = OSAppTheme.Unspecified;
                }
            }
        }
    }
}
