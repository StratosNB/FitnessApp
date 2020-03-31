using Android.Content;
using FitnessApp.Droid;
using FitnessApp;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content.Res;

[assembly: ExportRenderer(typeof(TransparentEntry), typeof(CustomEntryRenderer))]
namespace FitnessApp.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            //Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            Control.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.White);
        }
    }
}