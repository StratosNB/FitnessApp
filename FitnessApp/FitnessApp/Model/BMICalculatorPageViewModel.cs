using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FitnessApp.Model
{
    public class BMICalculatorPageViewModel : INotifyPropertyChanged
    {
        string height = string.Empty;
        string weight = string.Empty;
        string bmi = string.Empty;

        public string Height
        {
            get
            {
                return height;
            }

            set
            {
                if (height == value)
                {
                    return;
                }
                height = value;
                onActivateSwitch(nameof(Height));
            }
        }

        public string Weight
        {
            get
            {
                return weight;
            }

            set
            {
                if (weight == value)
                {
                    return;
                }
                weight = value;
                onActivateSwitch(nameof(Weight));
            }
        }

        public string BMI
        {
            get
            {
                return bmi;
            }

            set 
            {

            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        void onActivateSwitch(string a)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(a));
        }

        public String CmToFeetAndInches(double HeightCm)
        {
            double totalInches = (HeightCm / 2.54); // This will take a floor function of Centimetres/2.54
            double Feet = (totalInches - totalInches % 12) / 12; // This will make it divisible by 12
            double Inches = Math.Round(totalInches % 12); // This will give you the remainder after you divide by 12

            return Feet + "'" + Inches;
        } 

        public string KgToLbs(double Kg)
        {
            double lbs = Math.Round(Kg * 2.22, 1);
            return lbs.ToString() + " lbs";
        }
    }
}
