using API_01.DAL.Models;
using API_01.DAL.Models.Dtos.Movie;
using API_01.Repository.IRepository;
using API_01.Services.IServices;
using AutoMapper;

namespace API_01.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto?> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);

            if (movie is null)
                return null;

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieCreateDto)
        {
            // Validar que no exista una película con el mismo nombre
            var exists = await _movieRepository.MovieExistByNameAsync(movieCreateDto.Name);

            if (exists)
            {
                throw new InvalidOperationException(
                    $"Ya existe una película con el nombre '{movieCreateDto.Name}'.");
            }

            // Mapear DTO -> entidad
            var movie = _mapper.Map<Movie>(movieCreateDto);

            var created = await _movieRepository.CreateMovieAsync(movie);

            if (!created)
            {
                throw new Exception("Ocurrió un error al crear la película.");
            }

            // Mapear entidad con Id -> DTO de salida
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto?> UpdateMovieAsync(int id, MovieCreateUpdateDto movieUpdateDto)
        {
            // Verificar que exista la movie
            var movie = await _movieRepository.GetMovieAsync(id);

            if (movie is null)
                return null; 

            // validar nombre duplicado
            var existsOtherWithSameName = await _movieRepository.MovieExistByNameAsync(movieUpdateDto.Name);

            if (existsOtherWithSameName && !string.Equals(movie.Name, movieUpdateDto.Name, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    $"Ya existe una película con el nombre '{movieUpdateDto.Name}'.");
            }

            // Actualizar campos
            movie.Name = movieUpdateDto.Name;
            movie.Duration = movieUpdateDto.Duration;
            movie.Clasification = movieUpdateDto.Clasification;

            var updated = await _movieRepository.UpdateMovieAsync(movie);

            if (!updated)
            {
                throw new Exception("Ocurrió un error al actualizar la película.");
            }

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            return await _movieRepository.DeleteMovieAsync(id);
        }

        public async Task<bool> MovieExistByIdAsync(int id)
        {
            return await _movieRepository.MovieExistByIdAsync(id);
        }

        public async Task<bool> MovieExistByNameAsync(string name)
        {
            return await _movieRepository.MovieExistByNameAsync(name);
        }
    }
}

