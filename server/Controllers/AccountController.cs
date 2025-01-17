namespace all_spice.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  public AccountController(AccountService accountService, Auth0Provider auth0Provider, FavoritesService favoritesService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _favoritesService = favoritesService;
  }
  private readonly AccountService _accountService;
  private readonly FavoritesService _favoritesService;
  private readonly Auth0Provider _auth0Provider;


  [HttpGet]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateAccount(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("favorites")]
  public async Task<ActionResult<FavoriteRecipe>> GetMyFavRecipes()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<FavoriteRecipe> favoriteRecipes = _favoritesService.GetMyFavRecipes(userInfo.Id);
      return Ok(favoriteRecipes);
    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);
    }
  }
}
