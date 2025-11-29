using API_01.DAL.Models;

namespace API_01.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMoviesAsync();
        Task<Movie?> GetMovieAsync(int id);

        Task<bool> CreateMovieAsync(Movie movie);
        Task<bool> UpdateMovieAsync(Movie movie);
        Task<bool> DeleteMovieAsync(int id);

        Task<bool> MovieExistByIdAsync(int id);
        Task<bool> MovieExistByNameAsync(string name);
    }
}

