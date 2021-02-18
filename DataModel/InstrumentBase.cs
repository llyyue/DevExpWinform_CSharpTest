using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using log4net;

namespace DevExpWinform_CSharpTest.DataModel
{
    public class InstrumentBase : INotifyPropertyChanged
    {
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        [Display(Name = "DATE")]
        public virtual DateTime Date { get => date; set { date = value; NotifyPropertyChanged(); } }
        protected DateTime date;

        [Display(Name = "OPEN")]
        public virtual double Open { get => open; set { open = value; NotifyPropertyChanged(); } }
        protected double open;

        [Display(Name = "HIGH")]
        public virtual double High { get => high; set { high = value; NotifyPropertyChanged(); } }
        protected double high;

        [Display(Name = "LOW")]
        public virtual double Low { get => low; set { low = value; NotifyPropertyChanged(); } }
        protected double low;

        [Display(Name = "CLOSE")]
        public virtual double Close { get => close; set { close = value; NotifyPropertyChanged(); } }
        protected double close;

        [Display(Name = "VOLUME")]
        public virtual ulong Volume { get => volume; set { volume = value; NotifyPropertyChanged(); } }
        protected ulong volume;

        [Display(Name = "EXCHANGE")]
        public virtual string Exch { get => exch; set { exch = value; NotifyPropertyChanged(); } }
        protected string exch;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static DateTime ParseDateTime(string dateStr, string format = "MM/dd/yyyy")
        {
            DateTime date = default;
            dateStr = dateStr.Replace("\"","").Replace("\'","");
            if (DateTime.TryParseExact(dateStr, format, null, System.Globalization.DateTimeStyles.None, out DateTime dateTmp))
            {
                date = dateTmp;
            }
            else if (DateTime.TryParse(dateStr, out DateTime dateTmp2))
            {
                date = dateTmp2;
            }
            else
            {
                //Default Date when parsing with error, for "0000-00-00", "-0001-11-29" default as "0001-01-01"
                //throw new Exception("Parsing Date Err : " + dateStr);
                log.Error("Parsing Date Err : " + dateStr);
            }

            return date;
        }

    }
}
