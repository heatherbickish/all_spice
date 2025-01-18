<script setup>
import { Recipe } from "@/models/Recipe";
import RecipeDetailsModal from "./RecipeDetailsModal.vue";
import Pop from "@/utils/Pop";
import { logger } from "@/utils/Logger";
import { recipesService } from "@/services/RecipesService";

defineProps({
  recipe: { type: Recipe, required: true }
})


async function getRecipeById(recipeId) {
  try {
    await recipesService.getRecipeById(recipeId)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}


</script>


<template>
  <div role="button" @click="getRecipeById(recipe.id)" data-bs-toggle="modal" data-bs-target="#recipeDetailsModal"
    class="mb-5 shadow recipe-box" :style="{ backgroundImage: `url(${recipe.img})` }">
    <div class="d-flex align-items-center justify-content-between">
      <h5 class="text-light ms-4 mt-2 rounded-pill glass-box px-3">{{ recipe.category }}</h5>
      <button class="btn selectable glass-box p-0 px-2 me-2 mt-2"><i
          class="mdi mdi-heart text-danger fs-4"></i></button>
    </div>
    <div class="ms-3">
      <h5 class="text-light position-absolute bottom-0 glass-box px-2 py-2">{{ recipe.title }}</h5>
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
}

.glass-box {
  border-radius: 5px;
  background-color: rgba(0, 0, 0, 0.0950);
  backdrop-filter: blur(10px);
}
</style>