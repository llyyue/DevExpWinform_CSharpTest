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
    public class Stock : InstrumentBase
    {
        [Key, Display(Name = "STOCK")]
        public virtual string Symbol { get => symbol; set { symbol = value; NotifyPropertyChanged(); } }
        private string symbol;

        public Stock(string symbol)
        {
            this.symbol = symbol.Trim();
        }

        public Stock(string symbol, DateTime date, double open, double high, double low, double close, ulong volumne, string exch)
            : this(symbol)
        {
            this.date = date;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.volume = volumne;
            this.exch = exch.Trim();
        }

        /// <summary>
        /// Data in CSV file, 8 columns
        /// STOCK,DATE,OPEN,HIGH,LOW,CLOSE,VOLUME,EXCHANGE 
        /// </summary>
        /// <param name="strArr"></param>
        public Stock(string[] strArr)
            :this(strArr[0])
        {
            try
            {
                this.date = ParseDateTime(strArr[1]);
                this.open = Convert.ToDouble(strArr[2]);
                this.high = Convert.ToDouble(strArr[3]);
                this.low = Convert.ToDouble(strArr[4]);
                this.close = Convert.ToDouble(strArr[5]);
                this.volume = Convert.ToUInt64(strArr[6]);
                this.exch = strArr[7].Trim();
            }
            catch (Exception ex)
            {
                log.Error("Parsing Stock Data Error\n"+ ex.Message, ex);
                throw ex;
            }
        }
    }
}
