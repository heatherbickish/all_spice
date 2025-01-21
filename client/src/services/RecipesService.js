import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Recipe } from "@/models/Recipe.js"
import { AppState } from "@/AppState.js"


class RecipesService {
  async deleteRecipe(recipeId) {
    const response = await api.delete(`api/recipes/${recipeId}`)
    logger.log('deleted recipe', response.data)
  }
  async editInstructions(instructionData, recipeId) {
    const response = await api.put(`api/recipes/${recipeId}`, instructionData)
    const updatedRecipe = new Recipe(response.data)
    AppState.activeRecipe = updatedRecipe
  }

  async createRecipe(recipeDate) {
    const response = await api.post('api/recipes', recipeDate)
    const createdRecipe = new Recipe(response.data)
    AppState.recipes.push(createdRecipe)
    AppState.activeRecipe = createdRecipe
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