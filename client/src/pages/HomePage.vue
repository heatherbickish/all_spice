<script setup>
import { AppState } from "@/AppState";
import AddRecipeModal from "@/components/AddRecipeModal.vue";
import Login from "@/components/Login.vue";
import RecipeCard from "@/components/RecipeCard.vue";
import { favoritesService } from "@/services/FavoritesService";
import { recipesService } from "@/services/RecipesService";
import { logger } from "@/utils/Logger";
import Pop from "@/utils/Pop";
import { computed, onMounted, ref, watch } from "vue";

const account = computed(() => AppState.account)
const recipes = computed(() => {
  if (activeFilterCategory.value == 'home') return AppState.recipes
  else if (activeFilterCategory.value == 'my recipes') return AppState.recipes.filter(recipe => recipe.creatorId == account.value.id)
  else if (activeFilterCategory.value == 'favorites') return AppState.favorites
  return AppState.recipes.filter(recipe => recipe.category == activeFilterCategory.value)
})

const activeFilterCategory = ref('home')
const editableSearchQuery = ref('')

const categories = [
  { name: 'home' },
  { name: 'my recipes' },
  { name: 'favorites' }
]

onMounted(() => {
  getAllRecipes()
})

watch(account, () => {
  getMyFavorites()

})

async function getAllRecipes() {
  try {
    await recipesService.getAllRecipes()
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

async function getMyFavorites() {
  try {
    await favoritesService.getMyFavorites()
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

async function searchRecipes() {
  try {
    await recipesService.searchRecipes(editableSearchQuery.value)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

</script>

<template>
  <section class="container">
    <div class="row hero justify-content-end mt-4 shadow">
      <div class="col-md-4">
        <div>
          <form @submit.prevent="searchRecipes()">
            <div class="mt-2 d-flex align-items-center">
              <button @click="getAllRecipes()" class="btn text-light fs-4"><i
                  class="mdi mdi-home text-white"></i></button>
              <button class="btn text-light fs-4" type="submit"><i class="mdi mdi-magnify text-white"></i></button>
              <label for="searchQuery"></label>
              <input v-model="editableSearchQuery" id="searchQuery" type="text" class="form-control me-3"
                placeholder="Search...">
              <Login />
            </div>
          </form>
          <div class="mt-2">
          </div>
        </div>
      </div>
      <div class="row justify-content-center">
        <div class="col-md-2">
          <div class="text-light text-center text ">
            <h1>All-Spice</h1>
            <h5>Cherish Your Family And Their Cooking</h5>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- SECTION  menu buttons -->
  <section v-if="account" class="container">
    <div class="row justify-content-center">
      <div class="col-md-5 text-center menu-box">
        <div class="bg-light rounded py-2 shadow d-flex justify-content-around">
          <button @click="activeFilterCategory = category.name" v-for="category in categories"
            :key="'filter-' + category.name" class="btn text-secondary fs-5 selectable text-capitalize">{{ category.name
            }}</button>
        </div>
      </div>
    </div>
  </section>

  <!-- SECTION recipe cards -->
  <section class="container">
    <div class="row">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-md-4 mt-4">
        <RecipeCard :recipe="recipe" />
      </div>
      <div>
        <button v-if="account" data-bs-toggle="modal" data-bs-target="#addRecipeModal" class="btn add-button"><i
            class="mdi mdi-plus-circle text-secondary"></i></button>
        <AddRecipeModal />
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
@import url('https://fonts.googleapis.com/css2?family=Oranienbaum&display=swap');

h1,
h5 {
  font-family: "Oranienbaum", serif;
}

.hero {
  background-image: url(https://images.unsplash.com/photo-1690983322070-22861e13ce47?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  height: 500px;
  width: auto;
  background-size: cover;
  background-position: center;
  border-radius: 5px;
}

.shadow {
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2), 2px 2px 5px rgba(0, 0, 0, 0.1);

}

.text {
  text-shadow: 1px 1px black;
}

.add-button {
  font-size: 5rem;
  position: fixed;
  right: 0;
  bottom: 0;
  margin-right: 1rem;
}


@media screen and (min-width: 768px) {
  .menu-box {
    position: relative;
    bottom: 2em;
  }
}
</style>
