namespace all_spice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
  public FavoritesController(Auth0Provider auth0Provider, FavoritesService favoritesService)
  {
    _auth0Provider = auth0Provider;
    _favoritesService = favoritesService;
  }
  private readonly Auth0Provider _auth0Provider;
  private readonly FavoritesService _favoritesService;


  [Authorize]
  [HttpPost]
  public async Task<ActionResult<FavoriteRecipe>> CreateFavorite([FromBody] Favorite favData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      favData.AccountId = userInfo.Id;
      FavoriteRecipe favorite = _favoritesService.CreateFavorite(favData);
      return Ok(favorite);
    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);

    }
  }


  [Authorize]
  [HttpDelete("{favoriteId}")]
  public async Task<ActionResult<string>> DeleteFav(int favoriteId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _favoritesService.DeleteFav(favoriteId, userInfo.Id);
      return Ok(message);
    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);
    }
  }


}