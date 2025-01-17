

namespace all_spice.Repositories;

public class FavoritesRepository
{
  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;


  internal FavoriteRecipe CreateFavorite(Favorite favData)
  {
    string sql = @"
      INSERT INTO
      favorites(recipe_id, account_id)
      VALUES(@RecipeId, @AccountId);

      SELECT 
      favorites.*, 
      recipes.*,
      accounts.*
      FROM favorites
      JOIN recipes ON favorites.recipe_id = recipes.id
      JOIN accounts ON accounts.id = recipes.creator_id
      WHERE favorites.id = LAST_INSERT_ID();";

    FavoriteRecipe favorite = _db.Query(sql, (Favorite favorite, FavoriteRecipe recipe, Profile account) =>
    {
      recipe.FavoriteId = favorite.Id;
      recipe.AccountId = recipe.CreatorId;
      recipe.Creator = account;
      return recipe;
    }, favData).SingleOrDefault();
    return favorite;
  }

  internal List<FavoriteRecipe> GetMyFavRecipe(string userId)
  {
    string sql = @"
       SELECT 
      favorites.*, 
      recipes.*,
      accounts.*
      FROM favorites
      JOIN recipes ON favorites.recipe_id = recipes.id
      JOIN accounts ON accounts.id = recipes.creator_id
      WHERE favorites. account_id = @userId;";

    List<FavoriteRecipe> favoriteRecipes = _db.Query(sql, (Favorite favorite, FavoriteRecipe recipe, Profile account) =>
    {
      recipe.FavoriteId = favorite.Id;
      recipe.AccountId = recipe.CreatorId;
      recipe.Creator = account;
      return recipe;
    }, new { userId }).ToList();

    return favoriteRecipes;

  }
}