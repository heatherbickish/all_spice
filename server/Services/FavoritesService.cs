namespace all_spice.Services;

public class FavoritesService
{
  public FavoritesService(FavoritesService favoritesService)
  {
    _favoritesService = favoritesService;
  }
  private readonly FavoritesService _favoritesService;

}