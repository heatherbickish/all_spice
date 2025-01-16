namespace all_spice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
  public IngredientsController(IngredientsService ingredientsService)
  {
    _ingredientsService = ingredientsService;
  }
  private readonly IngredientsService _ingredientsService;

}