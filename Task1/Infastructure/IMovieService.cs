using Domain;

namespace Infastructure;

public interface IMovieService
{
    public int CreateMovie(Movie movie);
    public List<Movie> GetMovies();
    public int UpdateMovie(Movie movie);
    public int DeleteMovie(int id);
}