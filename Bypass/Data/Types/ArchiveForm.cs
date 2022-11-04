using System;

namespace Bypass.Data.Types
{
    public class ArchiveForm
    {
        DateTime from;
        DateTime to;
        public string DateFrom
        {
            get { return from.ToString("d"); }
            set
            {
                if (!DateTime.TryParse(value, out from))
                    from = DateTime.Now.Date.AddMonths(-12);
            }
        }
        public string DateTo
        {
            get { return to.ToString("d"); }
            set
            {
                if (!DateTime.TryParse(value, out to))
                    to = DateTime.Now.Date;
            }
        }
        public string Fio { get; set; }
        public string DateFromSql
        {
            get { return from.ToString("yyyy-MM-dd"); }
        }
        public string DateToSql
        {
            get { return to.ToString("yyyy-MM-dd"); }
        }
    }
}
