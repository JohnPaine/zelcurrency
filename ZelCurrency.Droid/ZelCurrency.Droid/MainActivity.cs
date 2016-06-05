using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Java.Lang;
using ZelCurrency.Core;
using ZelCurrency.Droid.Adapters;

namespace ZelCurrency.Droid
{
    [Activity(Label = "ZelCurrency.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ICurrencyProvider CurrencyProvider { get; set; }

        private int AmountToExchange { get; set; }
        private ExchangeDirection ExhangeDirection { get; set; }

        private ToggleButton ShowSellCurrencyViewButton { get; set; }
        private ToggleButton ShowBuyCurrencyViewButton { get; set; }
        private ListView CurrencyListView { get; set; }
        private EditText AmountToExchangeEditText { get; set; }
        private Button ShowViewForAmountButton { get; set; }

        private void FindViews () {
            CurrencyListView = FindViewById<ListView>(Resource.Id.currencyListView);
            AmountToExchangeEditText = FindViewById<EditText>(Resource.Id.amountToExchangeEditText);
            AmountToExchangeEditText.Text = AmountToExchange.ToString ();
            ShowViewForAmountButton = FindViewById<Button>(Resource.Id.showViewForAmountButton);
            ShowViewForAmountButton.Click += delegate {
                var mainActivityIntent = new Intent(this, typeof(MainActivity));

                int amount;
                if (!int.TryParse (AmountToExchangeEditText.Text, out amount)) {
                    // TODO: show notification or restrict input with integers only
                    return;
                }
                if (AmountToExchange == 1)
                    AmountToExchangeEditText.Text = "1";

                mainActivityIntent.PutExtra ("amount_to_exchange", amount);
                StartActivity(mainActivityIntent);
                if (AmountToExchange != 1)
                    Finish();
            };

            ShowSellCurrencyViewButton = FindViewById<ToggleButton> (Resource.Id.sellCurrencyViewToggleButton);
            ShowSellCurrencyViewButton.CheckedChange +=
                async delegate (object sender, CompoundButton.CheckedChangeEventArgs args) {
                    if (!ShowBuyCurrencyViewButton.Checked && !args.IsChecked)
                        return;

                    if (!args.IsChecked)
                        return;

                    ShowBuyCurrencyViewButton.Checked = false;
                    await SwitchExcangeDirectionView (ExchangeDirection.Sell);
                };
            ShowBuyCurrencyViewButton = FindViewById<ToggleButton> (Resource.Id.buyCurrencyViewToggleButton);
            ShowBuyCurrencyViewButton.CheckedChange +=
                async delegate (object sender, CompoundButton.CheckedChangeEventArgs args) {
                    if (!ShowSellCurrencyViewButton.Checked && !args.IsChecked)
                        return;

                    if (!args.IsChecked)
                        return;

                    ShowSellCurrencyViewButton.Checked = false;
                    await SwitchExcangeDirectionView(ExchangeDirection.Sell);
                };
        }

        private async Task SwitchExcangeDirectionView(ExchangeDirection direction) {
            ExhangeDirection = direction;

            CurrencyProvider = new FakeCurrencyProvider();

            var infos = CurrencyProvider.CurrencyInfos().ToList();

            var adapter = new CurrencyViewAdapter(this, infos, AmountToExchange, direction);
            CurrencyListView.Adapter = adapter;

            foreach (var info in infos) {
                await info.LoadExchangeRates ();
                CurrencyListView.InvalidateViews ();
            }
        }


        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            AmountToExchange = Intent.Extras != null && !Intent.Extras.IsEmpty ? Intent.Extras.GetInt ("amount_to_exchange", 1) : 1;
            FindViews ();

            ShowSellCurrencyViewButton.Toggle ();
        }
    }
}

