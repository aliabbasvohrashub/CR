using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bajaj.Dinesh.Biller.Datasets;

namespace Bajaj.Dinesh.Biller
{
    internal sealed class FinancialYear
    {
        private int hashCode = 0;

        public FinancialYear(int startYear, DateTime booksStartDate, string filePath)
        {
            StartYear = startYear;
            BooksStartDate = booksStartDate;
            FilePath = filePath;
        }

        public int StartYear
        {
            get;
            set;
        }

        public DateTime BooksStartDate
        {
            get;
            set;
        }

        public int EndYear
        {
            get
            {
                return StartYear + 1;
            }
        }

        public string FilePath
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get
            {
                return new DateTime(EndYear, 3, 31);
            }
        }

        public override string ToString()
        {
            return StartYear + "-" + EndYear;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            FinancialYear fy = obj as FinancialYear;
            if (fy == null)
            {
                return false;
            }

            return this.StartYear == fy.StartYear;
        }

        public override int GetHashCode()
        {
            if (hashCode != 0)
            {
                return hashCode;
            }

            hashCode = StartYear.GetHashCode();
            return hashCode;
        }

        public int CompareTo(FinancialYear fy)
        {
            return this.StartYear - fy.StartYear;
        }

        public DateTime MinDate
        {
            get
            {
                return this.BooksStartDate;
            }
        }

        public DateTime MaxDate
        {
            get
            {
                if (DateTime.Today.CompareTo(this.EndDate.Date) < 0)
                {
                    return DateTime.Today;
                }
                else
                {
                    return this.EndDate.Date;
                }
            }
        }
    }
}