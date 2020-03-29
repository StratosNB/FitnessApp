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
        BMICalculatorPageViewModel bmiPVM = new BMICalculatorPageViewModel();
        public BMICalculatorPage()
        {
            InitializeComponent();
            BindingContext = bmiPVM;

            bmiPVM.Height = $"{Math.Round(Height_Slider.Value, 1)} cm";
            bmiPVM.Weight = $"{Math.Round(Weight_Slider.Value, 1)} kg";
        }
        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                bmiPVM.Height = bmiPVM.CmToFeetAndInches(Height_Slider.Value);
                bmiPVM.Weight = bmiPVM.KgToLbs(Weight_Slider.Value);

            }
            else
            {
                bmiPVM.Height = $"{Math.Round(Height_Slider.Value, 1)} cm";
                bmiPVM.Weight = $"{Math.Round(Weight_Slider.Value, 1)} kg";
            }

        }

        private void Height_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (bmiPVM.Height.Contains("'"))
            {
                bmiPVM.Height = bmiPVM.CmToFeetAndInches(e.NewValue);
            }
            else
            {
                bmiPVM.Height = Math.Round(e.NewValue, 1).ToString() + "cm";
            }

        }
        private void Weight_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (bmiPVM.Weight.Contains("lbs"))
            {
                bmiPVM.Weight = bmiPVM.KgToLbs(e.NewValue);
            }
            else
            {
                bmiPVM.Weight = Math.Round(e.NewValue, 1).ToString() + "kg";
            }

        }

        private async void CalculateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BMIResultPage());
        }
    }
}