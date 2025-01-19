import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Recipe } from "@/models/Recipe.js"
import { AppState } from "@/AppState.js"


class RecipesService {

  async createRecipe(recipeDate) {
    const response = await api.post('api/recipes', recipeDate)
    logger.log('created recipe', response.data)
    const createdRecipe = new Recipe(response.data)
    AppState.recipes.unshift(createdRecipe)
    return createdRecipe
  }

  async getRecipeById(recipeId) {
    const response = await api.get(`api/recipes/${recipeId}`)
    const recipe = new Recipe(response.data)
    AppState.activeRecipe = recipe
  }

  async getAllRecipes() {
    const response = await api.get('api/recipes');
    const recipes = response.data.map(recipePojo => new Recipe(recipePojo));
    AppState.recipes = recipes;
  }

}

export const recipesService = new RecipesService()