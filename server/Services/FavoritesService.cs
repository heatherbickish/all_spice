
namespace all_spice.Services;

public class FavoritesService
{
  public FavoritesService(FavoritesRepository favoritesRepository)
  {
    _favoritesRepository = favoritesRepository;
  }
  private readonly FavoritesRepository _favoritesRepository;


  internal FavoriteRecipe CreateFavorite(Favorite favData)
  {
    FavoriteRecipe favorite = _favoritesRepository.CreateFavorite(favData);
    return favorite;
  }
}