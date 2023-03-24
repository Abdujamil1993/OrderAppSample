using System;

namespace OrderAppSample.Specifications
{
    public class OrderSpecParams
    {

        
        private string _search;
        private string _oItemSearch;
        private string _providerName;
        private string _orderitemUnit;
        private DateTime _startDate = DateTime.Now.AddMonths(-1);
        private DateTime _endDate = DateTime.Now;

        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate =  value;
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => _endDate = value;
        }
        public int? ProviderId { get; set; }
        public string Search
        {
            get => _search;
            set => _search = value == null ? string.Empty : value.ToLower();
        }

        public string OrderItemSearch
        {
            get => _oItemSearch;
            set => _oItemSearch = value == null ? string.Empty : value.ToLower();
        }

        public string ProviderName
        {
            get => _providerName;
            set => _providerName = value == null ? string.Empty : value.ToLower();
        }

        public string OrderItemUnit
        {
            get => _orderitemUnit;
            set => _orderitemUnit = value == null ? string.Empty : value.ToLower();
        }
    }
}
