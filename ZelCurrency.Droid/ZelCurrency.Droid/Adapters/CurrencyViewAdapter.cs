using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using ZelCurrency.Core;

namespace ZelCurrency.Droid.Adapters
{
    public class CurrencyViewAdapter : BaseAdapter<ICurrencyInfo>
    {
        private readonly Activity _context;
        private readonly List<ICurrencyInfo> _currencyInfos;
        private int _amountToExchange;
        private readonly ExchangeDirection _exchangeDirection;


        public CurrencyViewAdapter(Activity context, List<ICurrencyInfo> currencyInfos, int amountToExchange, ExchangeDirection exchangeDirection) {
            _currencyInfos = currencyInfos;
            _amountToExchange = amountToExchange;
            _exchangeDirection = exchangeDirection;
            _context = context;
        }

        private TextView CurrencyTextView { get; set; }
        private TextView CurrencyDiffTextView { get; set; }
        private TextView BankInfoTextView { get; set; }

        public override int Count => _currencyInfos.Count;

        public override ICurrencyInfo this[int position] => null;

        private void FindViews(View convertView)
        {
            CurrencyTextView = convertView.FindViewById<TextView>(Resource.Id.currencyTextView);
            CurrencyDiffTextView = convertView.FindViewById<TextView>(Resource.Id.currencyDiffTextView);
            BankInfoTextView = convertView.FindViewById<TextView>(Resource.Id.bankInfoTextView);
        }

        public override long GetItemId(int position) {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent) {
            var init = false;
            if (null == convertView) {
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.CurrencyListItem, null);
                init = true;
            }

            FindViews(convertView);

            var sortedInfoes = _exchangeDirection == ExchangeDirection.Buy ? 
                _currencyInfos.OrderBy (r => r.BuyRate).ToList () : 
                _currencyInfos.OrderBy (r => r.SellRate).ToList();
            var currencyInfo = sortedInfoes[position];

            if (_exchangeDirection == ExchangeDirection.Buy) {
                CurrencyTextView.Text = currencyInfo.BuyRate != null ? (currencyInfo.BuyRate.Value * _amountToExchange).ToString ("0.00") : "...";
                var diff = sortedInfoes.First () == currencyInfo
                               ? "(...)"
                               : $"(+{(currencyInfo.BuyRate - sortedInfoes.First ().BuyRate) * _amountToExchange:0.00})";
                CurrencyDiffTextView.Text = diff;
            }
            else {
                CurrencyTextView.Text = currencyInfo.SellRate != null ? (currencyInfo.SellRate.Value * _amountToExchange).ToString("0.00") : "...";
                var diff = sortedInfoes.First() == currencyInfo
                               ? "(...)"
                               : $"(+{(currencyInfo.SellRate - sortedInfoes.First().SellRate) * _amountToExchange:0.00})";
                CurrencyDiffTextView.Text = diff;
            }


            BankInfoTextView.Text = currencyInfo.BankName;
            if (init)
            {
                BankInfoTextView.Click += delegate
                {
                    // TODO: start activity with webview for this bank
                };
            }

            return convertView;
        }
    }
}