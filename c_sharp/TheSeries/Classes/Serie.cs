using System;

namespace TheSeries
{
    public class Serie : BaseEntity
    {
        private Genre Genre {get;set;}
        private string Title {get;set;}
        private string Description {get;set;}
        private int Year {get;set;}
        private bool Excluded {get;set;}
        
        public Serie(int id, Genre genre, string title, string description, int year){
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description= description;
            this.Year = year;
            this.Excluded = false;
        } 

        //toString in a pretty format
        public override string ToString()
        {
            string pretty_format = "";
            pretty_format +="Title: " + this.Title + Environment.NewLine;
            pretty_format +="Description: " + this.Description + Environment.NewLine;
            pretty_format +="Year: " + this.Year + Environment.NewLine;
            pretty_format +="Genre: " + this.Genre + Environment.NewLine;
            return pretty_format;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }

        public void Exclude()
        {
            this.Excluded = true;
        }

        public bool returnExcluded()
        {
                return this.Excluded;
            }
            
        }
}