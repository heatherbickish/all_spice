<script setup>
import { Recipe } from "@/models/Recipe";
import RecipeDetailsModal from "./RecipeDetailsModal.vue";
import Pop from "@/utils/Pop";
import { logger } from "@/utils/Logger";
import { recipesService } from "@/services/RecipesService";
import { ingredientsService } from "@/services/IngredientsService";
import { favoritesService } from "@/services/FavoritesService";
import { computed } from "vue";
import { AppState } from "@/AppState";



const props = defineProps({
  recipe: { type: Recipe, required: true }
})

const favorites = computed(() => AppState.favorites)
const foundFavorite = computed(() => favorites.value.find(favorite => props.recipe.id == favorite.recipeId))

async function getRecipeById(recipeId) {
  try {
    await recipesService.getRecipeById(recipeId)
    await ingredientsService.getIngredientsByRecipeId(recipeId)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

async function createFavorite(recipeId) {
  try {
    const favData = { recipeId: props.recipe.id }
    await favoritesService.createFavorite(favData)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

async function deleteFavorite(favoriteId) {
  try {
    const confirmed = await Pop.confirm(`Are you sure you want to unfavorite the ${props.recipe.title} recipe?`)
    if (!confirmed) return

    await favoritesService.deleteFavorite(favoriteId)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

</script>


<template>
  <div class="mb-5 recipe-box" :style="{ backgroundImage: `url(${recipe.img})` }">
    <div class="d-flex align-items-center justify-content-between">
      <h5 class="text-light ms-4 mt-2 rounded-pill glass-box px-3 text-capitalize ">{{ recipe.category }}</h5>
      <button v-if="!foundFavorite" @click="createFavorite(recipe.id)"
        class="btn selectable glass-box p-0 px-2 me-2 mt-2"><i
          class="mdi mdi-heart-outline text-secondary fs-4"></i></button>
      <button v-else @click="deleteFavorite(foundFavorite.favoriteId)"
        class="btn selectable glass-box p-0 px-2 me-2 mt-2"><i class="mdi mdi-heart text-danger fs-4"></i></button>
    </div>
    <div class="ms-3">
      <h5 role="button" @click="getRecipeById(recipe.id)" data-bs-toggle="modal" data-bs-target="#recipeDetailsModal"
        class="text-light position-absolute bottom-0 title-box px-2 py-2 text">{{ recipe.title }}</h5>
    </div>
    <RecipeDetailsModal />
  </div>
</template>


<style lang="scss" scoped>
.recipe-box {
  height: 300px;
  width: auto;
  background-size: cover;
  background-position: center;
  border-radius: 5px;
  position: relative;
  box-shadow: 0 5px 8px rgba(0, 0, 0, 0.2), 5px 6px 4px rgba(0, 0, 0, 0.16);
}

.glass-box {
  border-radius: 5px;
  background-color: rgba(0, 0, 0, 0.0950);
  backdrop-filter: blur(10px);
}

.title-box {
  padding-left: 10px;
  padding-right: 100px;
  border-radius: 5px;
  background-color: rgba(0, 0, 0, 0.0950);
  backdrop-filter: blur(10px);
}

.text {
  text-shadow: 1px 1px black;
}
</style>