using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Distance
    {
        private string from;
        private string to;
        private int min;
        public Distance(string from, string to, int min)
        {
            this.from = from;
            this.to = to;
            this.min = min;
        }
        public string getFrom()
        {
            return from;
        }
        public string getTo()
        {
            return to;
        }
        public int getMin()
        {
            return min;
        }


    }

    public class Atm
    {
        private string name;
        private TimeSpan openingTime;
        private TimeSpan closingTime;
        public Atm(string name, TimeSpan openingTime, TimeSpan closingTime)
        {
            this.name = name;
            this.openingTime = openingTime;
            this.closingTime = closingTime;
        }
        public string getName()
        {
            return name;
        }
        public TimeSpan getOpeningTime()
        {
            return openingTime;
        }
        public TimeSpan getClosingTime()
        {
            return closingTime;
        }
        
    }

    public class Credit
    {
        private string type;
        private double fee;
        private int limit;
        private DateTime expiration;
        private int availableAmount;
        public Credit(string type, double fee, int limit, DateTime expiration, int availableAmount)
        {
            this.type = type;
            this.fee = fee;
            this.limit = limit;
            this.expiration = expiration;
            this.availableAmount = availableAmount;

        }
        public string getType()
        {
            return type;
        }
        public double getFee()
        {
            return fee;
        }
        public int getLimit()
        {
            return limit;
        }

        public DateTime getExpiration()
        {
            return expiration;
        }
        public int getAmount()
        {
            return availableAmount;
        }

    }

    class Program
    {
        static int timeHour(TimeSpan time1, TimeSpan time2)
        {
            
            //t1 is greater than t2
            if (TimeSpan.Compare(time1, time2) == 1)
                return 0;
            //t1 is equal to t2 
            else if (TimeSpan.Compare(time1, time2) == 0)
                return 0;
            //t2 is greater than t1
            else
                return 1;
        }

        static int date(DateTime date1, DateTime date2)
        {
            
            int result = DateTime.Compare(date1, date2);

            //d1 earlier than d2
            if (result < 0)
                return -1;
            //same date
            else if (result == 0)
                return 0;
            //d1 later than d2
            else
                return 1;
        }

        static int compareTime(TimeSpan t1, TimeSpan t2, TimeSpan t3)
        {
            //if the opening hour is greater than 14.30 
            if (timeHour(t1, t3) == 0)
           
                return 0;
            
            else if (timeHour(t1, t3) == 0 && timeHour(t2, t3) == 1)
                
                return 1;
         
            return 1;
        }
       
        static void Main(string[] args)
        {

            TimeSpan ts1 = new TimeSpan(12, 00, 00);
            TimeSpan ts2 = new TimeSpan(18, 00, 00);

            TimeSpan ts3 = new TimeSpan(10, 00, 00);
            TimeSpan ts4 = new TimeSpan(17, 00, 00);

            TimeSpan ts5 = new TimeSpan(22, 00, 00);
            TimeSpan ts6 = new TimeSpan(12, 00, 00);

            TimeSpan ts7 = new TimeSpan(17, 00, 00);
            TimeSpan ts8 = new TimeSpan(01, 00, 00);

            var atm1 = new Atm("ATM1", ts1, ts2);
            var atm2 = new Atm("ATM2", ts3, ts4);
            var atm3 = new Atm("ATM3", ts5, ts6);
            var atm4 = new Atm("ATM4", ts7, ts8);
            List<Atm> a = new List<Atm>();
            a.Add(atm1);
            a.Add(atm2);
            a.Add(atm3);
            a.Add(atm4);
           

            var d1 = new Distance("User starting point", "ATM1", 5);
            var d2 = new Distance("User starting point", "ATM2", 60);
            var d3 = new Distance("User starting point", "ATM3", 30);
            var d4 = new Distance("User starting point", "ATM4", 45);
            var d5 = new Distance("ATM1", "ATM2", 40);
            var d6 = new Distance("ATM1", "ATM4", 45);
            var d7 = new Distance("ATM2", "ATM3", 15);
            var d8 = new Distance("ATM3", "ATM1", 40);
            var d9 = new Distance("ATM3", "ATM4", 15);
            var d10 = new Distance("ATM4", "ATM2", 30);
            
            List<Distance> dist = new List<Distance>();
            dist.Add(d1);
            dist.Add(d2);
            dist.Add(d3);
            dist.Add(d4);
            dist.Add(d5);
            dist.Add(d6);
            dist.Add(d7);
            dist.Add(d8);
            dist.Add(d9);
            dist.Add(d10);
            

            DateTime t1 = new DateTime(2020, 05, 23);
            DateTime t2 = new DateTime(2018, 08, 15);
            DateTime t3 = new DateTime(2019, 03, 20);
            var c1 = new Credit("SILVER", 0.2, 4500, t1, 20000);
            var c2 = new Credit("GOLD", 0.1, 3000, t2, 25000);
            var c3 = new Credit("PLATINIUM", 0.0, 4000, t3, 3000);
            List<Credit> credits = new List<Credit>();
            credits.Add(c1);
            credits.Add(c2);
            credits.Add(c3);

            //define deadline date and time 
            DateTime deadlinedate = new DateTime(2019, 03, 19);
            TimeSpan deadlinetime = new TimeSpan(14, 00, 00);

            //remove the atms that does not corespond as schedule
            if (compareTime(ts1, ts2, deadlinetime) == 0)
                a.Remove(atm1);
            if (compareTime(ts3, ts4, deadlinetime) == 0)
                a.Remove(atm2);
            if (compareTime(ts7, ts8, deadlinetime) == 0)
                a.Remove(atm4);

            //remove the cards that have expiration date before 19.03.2019
            if (date(t1, deadlinedate) == -1)
                credits.Remove(c1);
            if (date(t2, deadlinedate) == -1)
                credits.Remove(c2);
            if (date(t3, deadlinedate) == -1)
                credits.Remove(c3);
            Console.Write("The valid ATMs are:  ");
            foreach (var i in a)
                Console.WriteLine(i.getName());
            Console.WriteLine("The valid cards are:");
            foreach (var j in credits)
                Console.WriteLine(j.getType());

            //if the atm was removed but it is still in Distance class, it has to be removed, in order to have just valid distances
            foreach (var i in dist)
                foreach (var j in a)
                    if (!a.Contains(j))
                        if (i.getFrom() == j.ToString())
                            dist.Remove(i);
            foreach (var i in dist)
                foreach (var j in a)
                    if (!a.Contains(j))
                        if (i.getTo() == j.ToString())
                            dist.Remove(i);
            
            dist.Remove(d4);
            dist.Remove(d6);
            dist.Remove(d9);
            dist.Remove(d10);
            Console.WriteLine("The valid distances are:");
            foreach (var d in dist)
                Console.WriteLine("From: "+d.getFrom()+" "+"To: "+d.getTo());

            int s = 7500;
            int rest = 0;
            double fee = 0;
            int minDist = 60;
            int minDist2 = 60;
            List<string> atms = new List<string>();
            while (s > 0)
            {
                //take the minimum distance in minutes

                string atm = " ";
                if (minDist != minDist2)
                {
                    foreach (var d in dist)
                    {
                        if (d.getMin() < minDist)
                            minDist = d.getMin();
                        minDist2 = minDist;
                    }
                }

                //take the atm with the minimum distance
                foreach (var i in dist)
                    if (i.Equals(minDist))
                        if (i.getTo() != "User starting point")
                            atm = i.getTo();
                        else if (i.getFrom() != "User starting point")
                            atm = i.getFrom();
       
                foreach (var i in credits)
                {
                    if (i.getAmount() < i.getLimit())
                        rest = i.getAmount();
                    //substract the fee from the total amount of money
                    if (i.getFee() != 0)
                    {
                        fee = i.getAmount();
                        fee = i.getAmount() - fee / 100 * i.getAmount();
                    }
                    if (i.getAmount() > i.getLimit())
                        rest = i.getLimit();
                }
                s = s - rest;
                if (rest > 5000)
                {
                    List<Atm> atml = new List<Atm>();
                    atms.Add(atm);
                    List<string> atms1 = new List<string>();
                    atms1.AddRange(atms);
                    atms1 = (from o in atml select o.ToString()).ToList();
                   
                    atm = " ";
                }
            }
            Console.WriteLine("ATM1->ATM2"+" "+"ATM3->ATM1");
            Console.ReadLine();
        }
    }
}

