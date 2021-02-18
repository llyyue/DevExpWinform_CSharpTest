using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace DevExpWinform_CSharpTest.DataModel
{
    public class Option : InstrumentBase
    {
        #region Option Basic

        [Display(Name = "underlying_symbol")]
        public virtual string UnderlyingSymbol { get => underlyingSymbol; set { underlyingSymbol = value; NotifyPropertyChanged(); } }
        private string underlyingSymbol;
        
        public enum ExpirationTypeEnum
        {
            Weekly, Monthly, Quarterly
        }
        [Display(Name = "expiration_type")] 
        public virtual ExpirationTypeEnum ExpirationType { get => expirationType; set { expirationType = value; NotifyPropertyChanged(); } }
        private ExpirationTypeEnum expirationType;
        
        public enum OptionTypeEnum
        {
            Call, Put
        }
        [Display(Name = "type")] 
        public virtual OptionTypeEnum OptionType { get => optionTyp; set { optionTyp = value; NotifyPropertyChanged(); } }
        private OptionTypeEnum optionTyp;

        [Key, Display(Name = "symbol")]
        public virtual string Symbol { get => symbol; set { symbol = value; NotifyPropertyChanged(); } }
        private string symbol;

        [Display(Name = "strike")]
        public virtual double Strike { get => strike; set { strike = value; NotifyPropertyChanged(); } }
        private double strike;

        #endregion

        #region Option Price

        [Display(Name = "currency")]
        public virtual string Currency { get => currency; set { currency = value; NotifyPropertyChanged(); } }
        private string currency;

        [Display(Name = "last")]
        public virtual double Last { get => close; set { close = value; NotifyPropertyChanged(); } }


        [Display(Name = "last_size")]
        public virtual int LastSize { get => lastSize; set { lastSize = value; NotifyPropertyChanged(); } }
        private int lastSize;

        [Display(Name = "change")]
        public virtual double Change { get => change; set { change = value; NotifyPropertyChanged(); } }
        private double change;

        [Display(Name = "pctchange")]
        public virtual double PctChange { get => pctChange; set { pctChange = value; NotifyPropertyChanged(); } }
        private double pctChange;

        [Display(Name = "previous")]
        public virtual double Previous { get => previous; set { previous = value; NotifyPropertyChanged(); } }
        private double previous;

        [Display(Name = "previous_date")]
        public virtual DateTime PreviousDate { get => previousDate; set { previousDate = value; NotifyPropertyChanged(); } }
        private DateTime previousDate;

        #endregion

        #region bid/ask Quote
        [Display(Name = "bid")]
        public virtual double Bid { get => bid; set { bid = value; NotifyPropertyChanged(); } }
        private double bid;

        [Display(Name = "bid_date")]
        public virtual DateTime BidDate { get => bidDate; set { bidDate = value; NotifyPropertyChanged(); } }
        private DateTime bidDate;

        [Display(Name = "bid_size")]
        public virtual int BidSize { get => bidSize; set { bidSize = value; NotifyPropertyChanged(); } }
        private int bidSize;

        [Display(Name = "ask")]
        public virtual double Ask { get => ask; set { ask = value; NotifyPropertyChanged(); } }
        private double ask;

        [Display(Name = "ask_date")]
        public virtual DateTime AskDate { get => askDate; set { askDate = value; NotifyPropertyChanged(); } }
        private DateTime askDate;

        [Display(Name = "ask_size")]
        public virtual int AskSize { get => askSize; set { askSize = value; NotifyPropertyChanged(); } }
        private int askSize;

        #endregion

        [Display(Name = "moneyness")]
        public virtual double Moneyness { get => moneyness; set { moneyness = value; NotifyPropertyChanged(); } }
        private double moneyness;

        #region Volume & Open Interest

        [Display(Name = "volume_change")]
        public virtual ulong VolumeChange { get => volumeChange; set { volumeChange = value; NotifyPropertyChanged(); } }
        private ulong volumeChange;
        
        [Display(Name = "volume_pctchange")]
        public virtual double VolumePctchange { get => volumePctchange; set { volumePctchange = value; NotifyPropertyChanged(); } }
        private double volumePctchange;

        [Display(Name = "open_interest")]
        public virtual ulong OpenInterest { get => openInterest; set { openInterest = value; NotifyPropertyChanged(); } }
        private ulong openInterest;

        [Display(Name = "open_interest_change")]
        public virtual ulong OpenInterestChange { get => openInterestChange; set { openInterestChange = value; NotifyPropertyChanged(); } }
        private ulong openInterestChange;

        [Display(Name = "open_interest_pctchange")]
        public virtual double OpenInterestPctchange { get => openInterestPctchange; set { openInterestPctchange = value; NotifyPropertyChanged(); } }
        private double openInterestPctchange;

        #endregion

        #region Volatility & Greeks
        [Display(Name = "volatility")]
        public virtual double Volatility { get => volatility; set { volatility = value; NotifyPropertyChanged(); } }
        private double volatility;

        [Display(Name = "volatility_change")]
        public virtual double VolatilityChange { get => volatilityChange; set { volatilityChange = value; NotifyPropertyChanged(); } }
        private double volatilityChange;

        [Display(Name = "volatility_pctchange")]
        public virtual double VolatilityPctchange { get => volatilityPctchange; set { volatilityPctchange = value; NotifyPropertyChanged(); } }
        private double volatilityPctchange;

 
        [Display(Name = "theoretical")]
        public virtual double Theoretical { get => theoretical; set { theoretical = value; NotifyPropertyChanged(); } }
        private double theoretical;

        [Display(Name = "delta")]
        public virtual double Delta { get => delta; set { delta = value; NotifyPropertyChanged(); } }
        private double delta;

        [Display(Name = "gamma")]
        public virtual double Gamma { get => gamma; set { gamma = value; NotifyPropertyChanged(); } }
        private double gamma;

        [Display(Name = "theta")]
        public virtual double Theta { get => theta; set { theta = value; NotifyPropertyChanged(); } }
        private double theta;

        [Display(Name = "vega")]
        public virtual double Vega { get => vega; set { vega = value; NotifyPropertyChanged(); } }
        private double vega;

        [Display(Name = "rho")]
        public virtual double Rho { get => rho; set { rho = value; NotifyPropertyChanged(); } }
        private double rho;

        #endregion

        [Display(Name = "tradetime")]
        public virtual DateTime Tradetime { get => tradetime; set { tradetime = value; NotifyPropertyChanged(); } }
        private DateTime tradetime;

        [Display(Name = "vol_oi_ratio")]
        public virtual double VolOiRatio { get => volOiRatio; set { volOiRatio = value; NotifyPropertyChanged(); } }
        private double volOiRatio;

        [Display(Name = "dte")]
        public virtual int Dte { get => dte; set { dte = value; NotifyPropertyChanged(); } }
        private int dte;

        [Display(Name = "midpoint")]
        public virtual double Midpoint { get => midpoint; set { midpoint = value; NotifyPropertyChanged(); } }
        private double midpoint;

        public Option(string symbol)
        {
            this.Symbol = symbol.Trim();
        }

        public Option(string symbol, DateTime date, double open, double high, double low, double close, ulong volumne, string exch,
                        string underlyingSymbol,
                        ExpirationTypeEnum expirationType,
                        OptionTypeEnum optionTyp,
                        double strike,
                        string currency,
                        int lastSize,
                        double change,
                        double pctChange,
                        double previous,
                        DateTime previousDate,
                        double bid,
                        DateTime bidDate,
                        int bidSize,
                        double ask,
                        DateTime askDate,
                        int askSize,
                        double moneyness,
                        ulong volumeChange,
                        double volumePctchange,
                        ulong openInterest,
                        ulong openInterestChange,
                        double openInterestPctchange,
                        double volatility,
                        double volatilityChange,
                        double volatilityPctchange,
                        double theoretical,
                        double delta,
                        double gamma,
                        double theta,
                        double vega,
                        double rho,
                        DateTime tradetime,
                        double volOiRatio,
                        int dte,
                        double midpoint)
            :this(symbol)
        {

            this.date = date;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.volume = volumne;
            this.exch = exch.Trim();

            this.underlyingSymbol = underlyingSymbol.Trim();
            this.expirationType = expirationType;
            this.optionTyp = optionTyp;
            this.strike = strike;
            this.currency = currency.Trim();
            this.lastSize = lastSize;
            this.change = change;
            this.pctChange = pctChange;
            this.previous = previous;
            this.previousDate = previousDate;
            this.bid = bid;
            this.bidDate = bidDate;
            this.bidSize = bidSize;
            this.ask = ask;
            this.askDate = askDate;
            this.askSize = askSize;
            this.moneyness = moneyness;
            this.volumeChange = volumeChange;
            this.volumePctchange = volumePctchange;
            this.openInterest = openInterest;
            this.openInterestChange = openInterestChange;
            this.openInterestPctchange = openInterestPctchange;
            this.volatility = volatility;
            this.volatilityChange = volatilityChange;
            this.volatilityPctchange = volatilityPctchange;
            this.theoretical = theoretical;
            this.delta = delta;
            this.gamma = gamma;
            this.theta = theta;
            this.vega = vega;
            this.rho = rho;
            this.tradetime = tradetime;
            this.volOiRatio = volOiRatio;
            this.dte = dte;
            this.midpoint = midpoint;

        }

        /// <summary>
        /// Data in CSV file, 42 columns
        ///	0	underlying_symbol
        ///	1	date
        ///	2	expiration_type
        ///	3	type
        ///	4	symbol
        ///	5	strike
        ///	6	exchange
        ///	7	currency
        ///	8	open
        ///	9	high
        ///	10	low
        ///	11	last
        ///	12	last_size
        ///	13	change
        ///	14	pctchange
        ///	15	previous
        ///	16	previous_date
        ///	17	bid
        ///	18	bid_date
        ///	19	bid_size
        ///	20	ask
        ///	21	ask_date
        ///	22	ask_size
        ///	23	moneyness
        ///	24	volume
        ///	25	volume_change
        ///	26	volume_pctchange
        ///	27	open_interest
        ///	28	open_interest_change
        ///	29	open_interest_pctchange
        ///	30	volatility
        ///	31	volatility_change
        ///	32	volatility_pctchange
        ///	33	theoretical
        ///	34	delta
        ///	35	gamma
        ///	36	theta
        ///	37	vega
        ///	38	rho
        ///	39	tradetime
        ///	40	vol_oi_ratio
        ///	41	dte
        ///	42	midpoint
        /// </summary>
        /// <param name="strArr"></param>
        public Option (string[] strArr)
        {
            try
            {
                this.underlyingSymbol = strArr[0];
                this.date = ParseDateTime(strArr[1]);
                switch (strArr[2].Trim().ToUpper())
                {
                    case "WEEKLY":
                        this.expirationType = ExpirationTypeEnum.Weekly;
                        break;
                    case "MONTHLY":
                        this.expirationType = ExpirationTypeEnum.Monthly;
                        break;
                    case "QUARTERLY":
                        this.expirationType = ExpirationTypeEnum.Quarterly;
                        break;
                }

                switch (strArr[3].Trim().ToUpper())
                {
                    case "CALL":
                        this.optionTyp = OptionTypeEnum.Call;
                        break;
                    case "PUT":
                        this.optionTyp = OptionTypeEnum.Put;
                        break;
                }

                this.symbol = strArr[4].Trim();
                this.strike = Convert.ToDouble(strArr[5]);
                this.exch = strArr[6].Trim();
                this.currency = strArr[7].Trim();
                this.open = Convert.ToDouble(strArr[8]);
                this.high = Convert.ToDouble(strArr[9]);
                this.low = Convert.ToDouble(strArr[10]);
                this.close = Convert.ToDouble(strArr[11]);
                this.lastSize = Convert.ToInt32(strArr[12]);
                this.change = Convert.ToDouble(strArr[13]);
                this.pctChange = Convert.ToDouble(strArr[14]);
                this.previous = Convert.ToDouble(strArr[15]);
                this.previousDate = ParseDateTime(strArr[16]);

                this.bid = Convert.ToDouble(strArr[17]);
                this.bidDate = ParseDateTime(strArr[18], "yyyy-MM-dd HH:mm:ss");
                this.bidSize = Convert.ToInt32(strArr[19]);
                this.ask = Convert.ToDouble(strArr[20]);
                this.askDate = ParseDateTime(strArr[21], "yyyy-MM-ddy HH:mm:ss");
                this.askSize = Convert.ToInt32(strArr[22]);

                this.moneyness = Convert.ToDouble(strArr[23]);
                this.volume = Convert.ToUInt64(strArr[24]);
                this.volumeChange = Convert.ToUInt64(strArr[25]);
                this.volumePctchange = Convert.ToDouble(strArr[26]);
                this.openInterest = Convert.ToUInt64(strArr[27]);
                this.openInterestChange = Convert.ToUInt64(strArr[28]);
                this.openInterestPctchange = Convert.ToDouble(strArr[29]);
                this.volatility = Convert.ToDouble(strArr[30]);
                this.volatilityChange = Convert.ToDouble(strArr[31]);
                this.volatilityPctchange = Convert.ToDouble(strArr[32]);
                this.theoretical = Convert.ToDouble(strArr[33]);
                this.delta = Convert.ToDouble(strArr[34]);
                this.gamma = Convert.ToDouble(strArr[35]);
                this.theta = Convert.ToDouble(strArr[36]);
                this.vega = Convert.ToDouble(strArr[37]);
                this.rho = Convert.ToDouble(strArr[38]);
                this.tradetime = ParseDateTime(strArr[39]);
                this.volOiRatio = Convert.ToDouble(strArr[40]);
                this.dte = Convert.ToInt32(strArr[41]);
                this.midpoint = Convert.ToDouble(strArr[42]);
            }
            catch (Exception ex)
            {
                log.Error("Parsing Stock Data Error\n" + ex.Message, ex);
                throw ex;
            }
        }

    }

}
