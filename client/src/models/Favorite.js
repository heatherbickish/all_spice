

export class Favorite {
  constructor(data) {
    this.id = data.id
    this.createdAt = data.createdAt
    this.updatedAt = data.updatedAt
    this.recipeId = data.recipeId
    this.accountId = data.accountId
  }
}