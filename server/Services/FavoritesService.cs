


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

  private Favorite GetFavById(int favoriteId)
  {
    Favorite favorite = _favoritesRepository.GetFavById(favoriteId);
    if (favorite == null) throw new Exception($"Invalid fav id: {favoriteId}");
    return favorite;
  }

  internal string DeleteFav(int favoriteId, string userId)
  {
    Favorite favorite = GetFavById(favoriteId);

    if (favorite.AccountId != userId) throw new Exception("STOP FRIEND! CANNOT DO THAT");

    _favoritesRepository.DeleteFav(favoriteId);

    return "No longer favoriting that recipe";
  }
}