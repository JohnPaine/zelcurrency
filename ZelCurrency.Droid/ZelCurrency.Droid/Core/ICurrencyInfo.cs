﻿using System.Threading.Tasks;

namespace ZelCurrency.Droid.Core
{
    public interface ICurrencyInfo
    {
//        ICurrency

        string BankName { get; set; } 
        string BankUri { get; set; }
        string BankAddress { get; set; }

        decimal? CurrentSellingCurrency { get; }
        decimal? CurrentBuyingCurrency { get; }
    
        Task<decimal> GetBuyingCurrency();

        Task<decimal> GetSellingCurrency();
    }

    class SberCurrencyInfo : ICurrencyInfo
    {
        public string BankName { get; set; }
        public string BankUri { get; set; }
        public string BankAddress { get; set; }

        public decimal? CurrentSellingCurrency { get; } = null;
        public decimal? CurrentBuyingCurrency { get; } = null;


        public Task<decimal> GetBuyingCurrency()
        {
            throw new System.NotImplementedException();
        }

        public Task<decimal> GetSellingCurrency()
        {
            throw new System.NotImplementedException();
        }
    }
}