using Tourist.Common.Models;

namespace Tourist.Common.Services
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
