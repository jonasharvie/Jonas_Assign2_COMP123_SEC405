using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Jonas_Assign2_COMP123_SEC405
{
    enum DayEnum { Sun, Mon, Tues, Wed, Thu, Fri, Sat }
    [Flags]
    enum GenreEnum { Unrated = 0, Action = 1, Comedy = 2, Horror = 4, Fantasy = 8, Musical = 16, Mystery = 32, Romance = 64, Adventure = 128, Animation = 256, Documentary = 512}
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GenreEnum.Action|GenreEnum.Horror);
            Console.WriteLine(DayEnum.Sun);
        }
    }

    struct Time
    {
        public int Hour { get; }
        public int Minute { get; }
        public Time(int hours, int minutes = 0)
        {
            Hour = hours;
            Minute = minutes;
        }

        public override string ToString()
        {
            return $"Hour: {Hour}, Minute: {Minute}";
        }
        public static bool operator ==(Time lhs, Time rhs)
            {
            int Hour = Math.Abs(lhs.Hour - rhs.Hour)*60;
            int Minute = Math.Abs(lhs.Minute - rhs.Minute);
            int difference = Hour - Minute;
            return difference <= 15*60;
        }
        public static bool operator !=(Time lhs, Time rhs)
        {
            int Hour = Math.Abs(lhs.Hour - rhs.Hour) * 60;
            int Minute = Math.Abs(lhs.Minute - rhs.Minute);
            int difference = Hour - Minute;
            return difference > 15 * 60;
        }
    }
    class Movie
    {
        public int Length { get; }
        public int Year { get; }
        public string Title { get; }
        public GenreEnum Genre { get; private set; }
        public List<string> Cast { get; }
        public Movie(string name, int year, int length)
        {
            Length = length;
            Year= year;
            Title = name;
            Cast = new List<string>();
        }
        public void AddActor(string actor)
        {
            Cast.Add(actor);
        }
        public void SetGenre(GenreEnum genre) 
        {
            Genre |= genre;  
        }
    }
    struct Show
    {
        public double Price { get; }
        public DayEnum Day { get; }
        public Movie Movie { get; }
        public Time Time { get; }
        public Show(Movie movie, Time time, DayEnum day, double price)
        {
            Movie = movie;
            Time= time;
            Day = day;
            Price = price;

        }
        public override string ToString()
        {
            return $"Movie: {Movie}, Time: {Time} Day: {Day}, Price: {Price}";
        }
    }


}

