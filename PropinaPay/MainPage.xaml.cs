namespace PropinaPay;

public partial class MainPage : ContentPage
{
    int count = 0;
    int numPersons = 1;
    int tip = 0;
    decimal bill = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void TxtBill_OnCompleted(object? sender, EventArgs e)
    {
        bill = decimal.Parse(TxtBill.Text);
        CalculateTotal();
    }

    /// <summary>
    /// Calculates the total bill including tip and splits it among the number of persons.
    /// </summary>
    private void CalculateTotal()
    {
        if (tip != 0)
        {
            decimal tipAmount = (bill / tip * 100);
            decimal total = bill + tipAmount;
            decimal totalPerPerson = total / numPersons;
        }
        else
        {
            decimal totalPerPerson = bill / numPersons;
        }
        
    }

    /// <summary>
    /// Called when the number of persons slider value changes.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void SldTip__OnValueChanged(object? sender, ValueChangedEventArgs e)
    {
        tip = (int)sldTip.Value;
        lblTip.Text = $"Tip: {tip}%";
        CalculateTotal();
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        if (sender is Button)
        {
            var btn = (Button)sender;
            var tipText = btn.Text.Replace("%", "");
            var percentage = int.Parse(tipText);
            sldTip.Value = percentage;
            lblTip.Text = $"Tip: {percentage}%";
            CalculateTotal();
        }
    }
}