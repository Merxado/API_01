using API_01.DAL;
using API_01.DAL.Models;
using API_01.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API_01.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Movie>> GetMoviesAsync()
        {
            return await _context.Movies
                .AsNoTracking().OrderBy(m => m.Name).ToListAsync();
        }

        public async Task<Movie?> GetMovieAsync(int id)
        {
            return await _context.Movies.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            movie.CreatedDate = DateTime.UtcNow;

            await _context.Movies.AddAsync(movie);
            return await SaveAsync();
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            movie.ModifiedDate = DateTime.UtcNow;

            _context.Movies.Update(movie);
            return await SaveAsync();
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await GetMovieAsync(id);

            if (movie is null)
                return false;

            _context.Movies.Remove(movie);
            return await SaveAsync();
        }

        public async Task<bool> MovieExistByIdAsync(int id)
        {
            return await _context.Movies.AsNoTracking().AnyAsync(m => m.Id == id);
        }

        public async Task<bool> MovieExistByNameAsync(string name)
        {
            return await _context.Movies.AsNoTracking().AnyAsync(m => m.Name == name);
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}

