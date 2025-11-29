using API_01.DAL.Models.Dtos.Movie;

namespace API_01.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync();
        Task<MovieDto?> GetMovieAsync(int id);

        Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieCreateDto);
        Task<MovieDto?> UpdateMovieAsync(int id, MovieCreateUpdateDto movieUpdateDto);
        Task<bool> DeleteMovieAsync(int id);

        Task<bool> MovieExistByIdAsync(int id);
        Task<bool> MovieExistByNameAsync(string name);
    }
}

