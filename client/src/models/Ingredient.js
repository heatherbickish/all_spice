export class Ingredient {
  constructor(data) {
    this.id = data.is
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.name = data.name || ''
    this.quantity = data.quantity || ''
    this.recipeId = data.recipeId
  }
}