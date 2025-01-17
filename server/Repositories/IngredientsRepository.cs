



namespace all_spice.Repositories;

public class IngredientsRepository
{
  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;


  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    string sql = @"
      INSERT INTO
      ingredients(name, quantity, recipe_id)
      VALUES(@Name, @Quantity, @RecipeId);

      SELECT * FROM ingredients 
      JOIN recipes ON recipes.id = ingredients.recipe_id
      WHERE ingredients.id = LAST_INSERT_ID();";

    Ingredient ingredient = _db.Query(sql, (Ingredient ingredient, Recipe recipe) =>
    {
      ingredient.RecipeId = recipe.Id;
      return ingredient;
    }, ingredientData).SingleOrDefault();
    return ingredient;
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    string sql = @"
      SELECT
      ingredients.*,
      recipes.*
      FROM ingredients
      JOIN recipes ON recipes.id = ingredients.recipe_id
      WHERE recipe_id = @recipeId;";

    List<Ingredient> ingredients = _db.Query(sql, (Ingredient ingredient, Recipe recipe) =>
    {
      ingredient.RecipeId = recipe.Id;
      return ingredient;
    }, new { recipeId }).ToList();
    return ingredients;
  }

  internal Ingredient GetIngredientById(int ingredientId)
  {
    string sql = "SELECT * FROM ingredients WHERE id = @ingredientId;";
    Ingredient ingredient = _db.Query<Ingredient>(sql, new { ingredientId }).SingleOrDefault();
    return ingredient;
  }

  internal void DeleteIngredient(int ingredientId)
  {
    string sql = "DELETE FROM ingredients WHERE id = @ingredientId LIMIT 1;";
    int rowsAffected = _db.Execute(sql, new { ingredientId });
    switch (rowsAffected)
    {
      case 1: return;
      case 0: throw new Exception("NO ROWS UPDATED");
      default: throw new Exception($"{rowsAffected} ROWS WERE UPDATED AND THAT WAS A MISTAKE");
    }
  }
}