


namespace all_spice.Services;

public class RecipesService
{
  public RecipesService(RecipesRepository recipesRepository)
  {
    _recipesRepository = recipesRepository;
  }
  private readonly RecipesRepository _recipesRepository;



  internal Recipe CreateRecipe(Recipe recipeData)
  {
    Recipe recipe = _recipesRepository.CreateRecipe(recipeData);
    return recipe;
  }

  internal List<Recipe> GetAllRecipes()
  {
    List<Recipe> recipes = _recipesRepository.GetAllRecipes();
    return recipes;
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    Recipe recipe = _recipesRepository.GetRecipeById(recipeId);
    if (recipe == null) throw new Exception($"Invalid recipe id: {recipeId}");
    return recipe;
  }

  internal Recipe UpdateRecipe(int recipeId, string userId, Recipe recipeUpdateData)
  {
    Recipe recipe = GetRecipeById(recipeId);
    if (recipe.CreatorId != userId) throw new Exception("NOPE. AINT YOURS BRAH");

    recipe.Title = recipeUpdateData.Title ?? recipe.Title;
    recipe.Instructions = recipeUpdateData.Instructions ?? recipe.Instructions;
    recipe.Img = recipeUpdateData.Img ?? recipe.Img;
    recipe.Category = recipeUpdateData.Category ?? recipe.Category;

    _recipesRepository.UpdateRecipe(recipe);
    return recipe;
  }
}