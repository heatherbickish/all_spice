


namespace all_spice.Services;

public class IngredientsService
{
  public IngredientsService(IngredientsRepository ingredientsRepository, RecipesService recipesService)
  {
    _ingredientsRepository = ingredientsRepository;
    _recipesService = recipesService;
  }
  private readonly IngredientsRepository _ingredientsRepository;
  private readonly RecipesService _recipesService;


  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    Ingredient ingredient = _ingredientsRepository.CreateIngredient(ingredientData);
    return ingredient;
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    List<Ingredient> ingredients = _ingredientsRepository.GetIngredientsByRecipeId(recipeId);
    return ingredients;
  }

  private Ingredient GetIngredientById(int ingredientId)
  {
    Ingredient ingredient = _ingredientsRepository.GetIngredientById(ingredientId);
    if (ingredient == null) throw new Exception($"Invalid ingredient id: {ingredientId}");
    return ingredient;
  }

  internal string DeleteIngredient(int ingredientId, string userId)
  {
    Ingredient ingredient = GetIngredientById(ingredientId);
    Recipe recipe = _recipesService.GetRecipeById(ingredient.RecipeId);

    if (ingredient.RecipeId != recipe.Id) throw new Exception("GET OUTTA HERE BOO");
    if (recipe.CreatorId != userId) throw new Exception("NOOOOOOOOOOOO! AINT HAPPENING");

    _ingredientsRepository.DeleteIngredient(ingredientId);
    return "Ingredient was removed!";
  }
}