



namespace all_spice.Repositories;

public class RecipesRepository
{
  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;



  internal Recipe CreateRecipe(Recipe recipeData)
  {
    string sql = @"
      INSERT INTO
      recipes(title, instructions, img, category, creator_id)
      VALUES(@Title, @Instructions, @Img, @Category, @CreatorId);
      
      SELECT
      recipes. *,
      accounts.*
      FROM recipes
      JOIN accounts On recipes.creator_id = accounts.id
      WHERE recipes.id = LAST_INSERT_ID();";

    Recipe recipe = _db.Query(sql, (Recipe recipe, Profile account) =>
    {
      recipe.Creator = account;
      return recipe;
    }, recipeData).SingleOrDefault();
    return recipe;
  }

  internal List<Recipe> GetAllRecipes()
  {
    string sql = @"
      SELECT 
      recipes.*,
      accounts.*
      FROM recipes
      JOIN accounts ON recipes.creator_id = accounts.id;";

    List<Recipe> recipes = _db.Query(sql, (Recipe recipe, Profile account) =>
    {
      recipe.Creator = account;
      return recipe;
    }).ToList();
    return recipes;
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    string sql = @"
      SELECT
      recipes. *,
      accounts. *
      FROM recipes
      JOIN accounts ON recipes.creator_id = accounts.id
      WHERE recipes.id = @recipeId;";

    Recipe recipe = _db.Query(sql, (Recipe recipe, Profile account) =>
    {
      recipe.Creator = account;
      return recipe;
    }, new { recipeId }).SingleOrDefault();
    return recipe;
  }

  internal void UpdateRecipe(Recipe recipeData)
  {
    string sql = @"
      UPDATE recipes
      SET
      title =@Title,
      instructions = @Instructions,
      img = @Img,
      category = @Category
      WHERE id = @Id LIMIT 1;";

    int rowsAffected = _db.Execute(sql, recipeData);

    if (rowsAffected == 0) throw new Exception("UPDATE WAS SUCCESSFUL");
    if (rowsAffected > 1) throw new Exception("UPDATE WAS TOO SUCCESSFUL");
  }

  internal void DeleteRecipe(int recipeId)
  {
    string sql = "DELETE FROM recipes WHERE id = @recipeId LIMIT 1";

    int rowsAffected = _db.Execute(sql, new { recipeId });

    switch (rowsAffected)
    {
      case 1: return;
      case 0: throw new Exception("NO ROWS UPDATED");
      default: throw new Exception($"{rowsAffected} ROWS WERE UPDATED AND THAT WAS NO BUENO");
    }
  }
}