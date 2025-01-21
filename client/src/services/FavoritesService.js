import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Favorite } from "@/models/Favorite.js"
import { AppState } from "@/AppState.js"



class FavoritesService {
  async getMyFavorites() {
    const response = await api.get('account/favorites')
    logger.log('getting favorites', response.data)
    const favorites = response.data.map(favoritePojo => new Favorite(response.data))
    AppState.favorites = favorites
  }
  async createFavorite(favData) {
    const response = await api.post('api/favorites', favData)
    logger.log('created favorite', response.data)
    const favorite = new Favorite(response.data)
    AppState.favorites.push(favorite)
  }


}

export const favoritesService = new FavoritesService()