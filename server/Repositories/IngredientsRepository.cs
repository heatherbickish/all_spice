
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
}