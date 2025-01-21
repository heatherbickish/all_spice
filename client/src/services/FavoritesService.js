import { api } from "./AxiosService.js"
import { Favorite } from "@/models/Favorite.js"
import { AppState } from "@/AppState.js"



class FavoritesService {
  async getMyFavorites() {
    const response = await api.get('account/favorites')
    const favorites = response.data.map(favoritePojo => new Favorite(favoritePojo))
    AppState.favorites = favorites
  }
  async createFavorite(favData) {
    const response = await api.post('api/favorites', favData)
    const favorite = new Favorite(response.data)
    AppState.favorites.push(favorite)
  }


}

export const favoritesService = new FavoritesService()