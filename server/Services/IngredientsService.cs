
namespace all_spice.Services;

public class IngredientsService
{
  public IngredientsService(IngredientsRepository ingredientsRepository)
  {
    _ingredientsRepository = ingredientsRepository;
  }
  private readonly IngredientsRepository _ingredientsRepository;


  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    Ingredient ingredient = _ingredientsRepository.CreateIngredient(ingredientData);
    return ingredient;
  }
}