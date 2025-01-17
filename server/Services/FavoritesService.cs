

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

  internal List<FavoriteRecipe> GetMyFavRecipes(string userId)
  {
    List<FavoriteRecipe> favoriteRecipes = _favoritesRepository.GetMyFavRecipe(userId);
    return favoriteRecipes;
  }
}