using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FitnessApp
{
    public class CustomStepper : StackLayout
    {
        Button PlusBtn;
        Button MinusBtn;
        TransparentEntry TransparentEntry;

        public static readonly BindableProperty TextProperty =
          BindableProperty.Create(
              propertyName: "Text",
              returnType: typeof(int),
              declaringType: typeof(CustomStepper),
              defaultValue: 20,
              defaultBindingMode: BindingMode.TwoWay);

        public int Text
        {
            get { return (int)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public CustomStepper()
        {
            PlusBtn = new Button { Text = "+", TextColor = Color.White, WidthRequest = 80, FontAttributes = FontAttributes.Bold};
            MinusBtn = new Button { Text = "-", TextColor = Color.White, WidthRequest = 80, FontAttributes = FontAttributes.Bold};
            switch (Device.RuntimePlatform)
            {

                case Device.UWP:
                case Device.Android:
                    {
                        PlusBtn.BackgroundColor = Color.Default;
                        MinusBtn.BackgroundColor = Color.Default;
                        break;
                    }
                case Device.iOS:
                    {
                        PlusBtn.BackgroundColor = Color.DarkGray;
                        MinusBtn.BackgroundColor = Color.DarkGray;
                        break;
                    }
            }

            Orientation = StackOrientation.Horizontal;
            PlusBtn.Clicked += PlusBtn_Clicked;
            MinusBtn.Clicked += MinusBtn_Clicked;
            TransparentEntry = new TransparentEntry
            {
                  PlaceholderColor = Color.White,
                  FontSize = 50,
                  Keyboard = Keyboard.Numeric,
                  WidthRequest = 65,
                  TextColor = Color.White,
                  

              };

            TransparentEntry.SetBinding(TransparentEntry.TextProperty, new Binding(nameof(Text), BindingMode.TwoWay, source: this));           
            TransparentEntry.TextChanged += Entry_TextChanged;

            this.BackgroundColor = Color.Black;
            this.Padding = 20;
            Children.Add(MinusBtn);
            Children.Add(TransparentEntry);
            Children.Add(PlusBtn);
            
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
                this.Text = int.Parse(e.NewTextValue);
        }

        private void MinusBtn_Clicked(object sender, EventArgs e)
        {
            if (Text > 1)
                Text--;
        }

        private void PlusBtn_Clicked(object sender, EventArgs e)
        {
            Text++;
        }

    }
}
