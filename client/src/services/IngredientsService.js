import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Ingredient } from "@/models/Ingredient.js"
import { AppState } from "@/AppState.js"


class IngredientsService {
  async createIngredients(ingredientData) {
    const response = await api.post('api/ingredients', ingredientData)
    const ingredients = new Ingredient(response.data)
    AppState.ingredients.push(ingredients)
  }
  async getIngredientsByRecipeId(recipeId) {
    const response = await api.get(`api/recipes/${recipeId}/ingredients`)
    const ingredients = response.data.map(ingredientPojo => new Ingredient(ingredientPojo))
    AppState.ingredients = ingredients
  }

}

export const ingredientsService = new IngredientsService()