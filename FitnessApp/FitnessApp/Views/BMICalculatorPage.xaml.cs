using FitnessApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BMICalculatorPage : ContentPage
    {
        BMICalculatorPageViewModel BmiPVM = new BMICalculatorPageViewModel();
        public BMICalculatorPage()
        {
            InitializeComponent();
            BindingContext = BmiPVM;

            BmiPVM.Height = $"{Math.Round(Height_Slider.Value, 1)} cm";
            BmiPVM.Weight = $"{Math.Round(Weight_Slider.Value, 1)} kg";
        }
        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                BmiPVM.Height = BmiPVM.CmToFeetAndInches(Height_Slider.Value);
                BmiPVM.Weight = BmiPVM.KgToLbs(Weight_Slider.Value);

            }
            else
            {
                BmiPVM.Height = $"{Math.Round(Height_Slider.Value, 1)} cm";
                BmiPVM.Weight = $"{Math.Round(Weight_Slider.Value, 1)} kg";
            }

        }

        private void Height_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (BmiPVM.Height.Contains("'"))
            {
                BmiPVM.Height = BmiPVM.CmToFeetAndInches(e.NewValue);
            }
            else
            {
                BmiPVM.Height = Math.Round(e.NewValue, 1).ToString() + "cm";
            }

        }
        private void Weight_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (BmiPVM.Weight.Contains("lbs"))
            {
                BmiPVM.Weight = BmiPVM.KgToLbs(e.NewValue);
            }
            else
            {
                BmiPVM.Weight = Math.Round(e.NewValue, 1).ToString() + "kg";
            }

        }

        private async void CalculateButton_OnClicked(object sender, EventArgs e)
        {
           // BmiPVM.BMI = 0;
            await Navigation.PushAsync(new BMIResultPage());
        }
    }
}