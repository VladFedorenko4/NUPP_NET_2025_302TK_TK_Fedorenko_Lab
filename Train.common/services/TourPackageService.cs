using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourist.common.models;

namespace Tourist.common.services
{
    class TourPackageService
    {
        private List<TourPackage> _movies = new List<TourPackage>();

        public void Create(TourPackage movie) => _movies.Add(movie);
        public List<TourPackage> ReadAll() => _movies;
        public void Update(int index, TourPackage updatedMovie)
        {
            if (index >= 0 && index < _movies.Count)
                _movies[index] = updatedMovie;
        }
        public void Delete(int index)
        {
            if (index >= 0 && index < _movies.Count)
                _movies.RemoveAt(index);
        }
    }
}
