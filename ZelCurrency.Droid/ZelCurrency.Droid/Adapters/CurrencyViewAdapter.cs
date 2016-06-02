using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using ZelCurrency.Droid.Core;

namespace ZelCurrency.Droid.Adapters
{
    public class CurrencyViewAdapter : BaseAdapter<ICurrencyInfo>
    {
        private readonly Activity _context;
        private readonly List<ICurrencyInfo> _currencyInfos;
        private int _amountToExchange;


        public CurrencyViewAdapter(Activity context, List<ICurrencyInfo> currencyInfos, int amountToExchange)
        {
            _currencyInfos = currencyInfos;
            _amountToExchange = amountToExchange;
            _context = context;
        }

        private EditText CurrencyEditText { get; set; }
        private EditText CurrencyDiffEditText { get; set; }
        private TextView BankInfoTextView { get; set; }

        public override int Count => _currencyInfos.Count;

        public override ICurrencyInfo this[int position] => _currencyInfos[position];

        private void FindViews(View convertView)
        {
            CurrencyEditText = convertView.FindViewById<EditText>(Resource.Id.currencyEditText);
            CurrencyDiffEditText = convertView.FindViewById<EditText>(Resource.Id.currencyDiffEditText);
            BankInfoTextView = convertView.FindViewById<EditText>(Resource.Id.bankInfoTextView);
        }

        public override long GetItemId(int position) {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // TODO: change sorting param
            var infos = _currencyInfos.OrderBy(r => r.BankAddress).ToList();
            var currencyInfo = infos[position];
            var init = false;

            if (null == convertView) {
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.CurrencyListItem, null);
                init = true;
            }

            FindViews(convertView);

//            CurrencyEditText.Text = currencyInfo.CurrentBuyingCurrency?.ToString() ?? "...";
//            CurrencyDiffEditText.Text = currencyInfo.CurrentSellingCurrency?.ToString() ?? "...";
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