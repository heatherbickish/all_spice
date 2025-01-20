export class Ingredient {
  constructor(data) {
    this.id = data.is
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.name = data.name || 'No ingredients to add'
    this.quantity = data.quantity || 'No ingredients to add'
    this.recipeId = data.recipeId
  }
}