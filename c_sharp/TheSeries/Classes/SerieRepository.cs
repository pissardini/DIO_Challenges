using System;
using System.Collections.Generic;
using Series.Interfaces; //import interfaces

namespace TheSeries
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> seriesList = new List<Serie>();

        public void Exclude(int id)
        {
            seriesList[id].Exclude();
        }

        public void Insert(Serie entity)
        {
            seriesList.Add(entity);
        }

        public System.Collections.Generic.List<Serie> List()
        {
            return seriesList;
        }

        public int NextId()
        {
            return seriesList.Count;
        }

        public Serie ReturnById(int id)
        {
            return seriesList[id];
        }

        public void Update(int id, Serie entity)
        {
            seriesList[id] = entity;
        }
    }
}