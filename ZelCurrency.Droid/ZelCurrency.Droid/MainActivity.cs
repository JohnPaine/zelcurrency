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
using ZelCurrency.Core;
using ZelCurrency.Droid.Adapters;

namespace ZelCurrency.Droid
{
    [Activity(Label = "ZelCurrency.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public enum CurrencyDirection
        {
            
        }

        private ICurrencyProvider CurrencyProvider { get; set; }

        private int AmountToExchange { get; set; }

        private Button ShowSellCurrencyViewButton { get; set; }
        private Button ShowBuyCurrencyViewButton { get; set; }
        private ListView CurrencyListView { get; set; }
        private EditText AmountToExchangeEditText { get; set; }
        private Button ShowViewForAmountButton { get; set; }

        private void SwitchCurrencyDirectionView(CurrencyDirection direction)
        {
            
        }


        protected override async void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            AmountToExchange = Intent.GetIntExtra("amount_to_change", 1);

            CurrencyProvider = new FakeCurrencyProvider();

            var infos = CurrencyProvider.CurrencyInfos().ToList();

            var adapter = new CurrencyViewAdapter(this, infos, AmountToExchange);
             
            var tasks = infos.Select(info=> info.LoadExchangeRates().ContinueWith((t) => CurrencyListView.InvalidateViews()));
            await  Task.WhenAll(tasks);
        }
    }
}

