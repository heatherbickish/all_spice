import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"


class FavoritesService {
  // async createFavorite() {
  //   const response = await api.post('api/favorites')
  //   logger.log('favoriting recipe', response.data)
  // }


}

export const favoritesService = new FavoritesService()