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
                    CallButton.Text = "Call" + translatedNumber;
                }
            
            } else
            {
                CallButton.IsEnabled = false;
                CallButton.Text = "Call";
            }
        }

        async void onCall(object sender, EventArgs e)
        {
            if (await this.DisplayAlert("Dial A number","Would you like to call " + translatedNumber + "?","Yes","No"))
            {

            }
        }
    }

}
