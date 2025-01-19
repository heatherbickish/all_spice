import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,
  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,
  /** @type {import('./models/Recipe.js').Recipe[]} user info from the database*/
  recipes: [],
  /** @type {import('./models/Recipe.js').Recipe} user info from the database*/
  activeRecipe: null,
  /** @type {import('./models/Recipe.js').Recipe[]} user info from the database*/
  favoriteRecipes: [],
})

