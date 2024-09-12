namespace MauiProjekt
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }
        string translatedNumber;
        private void onTranslate(object sender, EventArgs e)
        {
            string enteredNumber = PhoneNumberText.Text;
            translatedNumber = Core.PhonewordTranslator.ToNumber(enteredNumber);

            if (!string.IsNullOrEmpty(translatedNumber))
            {
                {
                    CallButton.IsEnabled = true;
                    CallButton.Text = "Zadzwoń: " + translatedNumber;
                }
            
            } else
            {
                CallButton.IsEnabled = false;
                CallButton.Text = "Zadzwoń";
            }
        }

        async void onCall(object sender, EventArgs e)
        {
            if (await this.DisplayAlert("Zadzwoń","Czy chciałbyś zadzwonić pod numer: " + translatedNumber + "?","Tak","Nie"))
            {
                try
                {
                    if (PhoneDialer.Default.IsSupported)
                        PhoneDialer.Default.Open(translatedNumber);
                }
                catch (ArgumentNullException)
                {
                    await DisplayAlert("Nie udało się zadzwonić", "Zły numer telefomu", "OK");
                }
                catch(Exception)
                {
                    await DisplayAlert("Nie udało się zadzwonić", "Nie udalo się połączyć", "OK");
                }
            }
        }
    }

}
