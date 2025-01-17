namespace all_spice.Controllers;

public class FavoritesController : ControllerBase
{
  public FavoritesController(FavoritesController favoritesController, Auth0Provider auth0Provider)
  {
    _auth0Provider = auth0Provider;
    _favoritesController = favoritesController;
  }
  private readonly Auth0Provider _auth0Provider;
  private readonly FavoritesController _favoritesController;

}