<script setup>
import { AppState } from "@/AppState";
import { ingredientsService } from "@/services/IngredientsService";
import { recipesService } from "@/services/RecipesService";
import { logger } from "@/utils/Logger";
import Pop from "@/utils/Pop";
import { Modal } from "bootstrap";
import { computed, ref } from "vue";


const recipe = computed(() => AppState.activeRecipe)
const account = computed(() => AppState.account)
const ingredients = computed(() => AppState.ingredients)
const favorites = computed(() => AppState.favorites)
const foundFavorite = computed(() => favorites.value.find(favorite => recipe.value.id == favorite.recipeId))

const editMode = ref(false)

const editableInstructions = ref({ instructions: '' })
const editableIngredients = ref({ quantity: '', name: '', recipeId: 0 })

async function editInstructions() {
  try {
    const recipeId = recipe.value.id
    await recipesService.editInstructions(editableInstructions.value, recipeId)
    editableInstructions.value = { instructions: '' }
    editMode.value = false
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

async function createIngredients() {
  try {
    editableIngredients.value.recipeId = recipe.value.id
    await ingredientsService.createIngredients(editableIngredients.value)
    editableIngredients.value = { quantity: '', name: '', recipeId: 0 }
    editMode.value = false
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

async function deleteRecipe(recipeId) {
  try {
    const confirmed = await Pop.confirm(`Are you sure you want to delete the ${recipe.value.title} recipe?`)
    if (!confirmed) return
    Modal.getInstance('#recipeDetailsModal').hide()
    await recipesService.deleteRecipe(recipeId)
  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}


</script>


<template>
  <div class="modal fade" id="recipeDetailsModal" tabindex="-1" aria-labelledby="recipeDetailsModalLabel"
    aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-body">
          <div>
            <div v-if="recipe" class="container">
              <div class="row justify-content-between">
                <div class="col-md-6">
                  <div>
                    <img :src="recipe.img" :alt="'A recipe by ' + recipe.creator.name" class="recipe-box">
                  </div>
                </div>
                <div class="col-md-6 d-flex flex-column justify-space-around">
                  <div>
                    <h4 class="text-success" id="recipeDetailsModalLabel">{{ recipe.title }}</h4>
                    <div v-if="recipe?.creatorId == account?.id" class="dropdown">
                      <button class=" btn fs-4 ms-4 dropdown toggle d-flex" type="button" data-bs-toggle="dropdown"
                        aria-expanded="false"><i class="mdi mdi-dots-horizontal"></i></button>
                      <ul class="dropdown-menu">
                        <li role="button" class="dropdown-item" title="Edit recipe" @click="editMode = !editMode">Edit
                          Recipe</li>
                        <li role="button" class="dropdown-item text-danger" title="Delete recipe"
                          @click="deleteRecipe(recipe.id)">Delete
                          Recipe</li>
                      </ul>
                    </div>
                  </div>
                  <small>by: {{ recipe.creator?.name }}</small>
                  <p class="mt-2 text-capitalize"><em>{{ recipe.category }}</em></p>
                  <h5 class="mt-3 mb-3">Ingredients</h5>
                  <div class="ingreds">
                    <form @submit.prevent="createIngredients()">
                      <input v-model="editableIngredients.quantity" v-if="editMode == true" class="form-control mb-2"
                        placeholder="quantity..." type="text" name="quantity" id="quantity">
                      <input v-model="editableIngredients.name" v-if="editMode == true" type="text" name="name"
                        id="name" placeholder="ingredient..." class="form-control">
                      <div class="text-end mt-2">
                        <button type="submit" v-if="editMode == true" class="btn btn-sm btn-secondary mb-2"
                          title="Save ingredients">Save</button>
                      </div>
                    </form>
                    <ul v-for="ingredient in ingredients" :key="ingredient.id">
                      <li>{{ ingredient.quantity }} {{ ingredient.name }}</li>
                    </ul>
                  </div>
                  <div>
                    <h5>Instructions</h5>
                    <textarea v-model="editableInstructions.instructions" v-if="editMode == true" type="text"
                      class="form-control" maxlength="500"></textarea>
                    <p v-else>{{ recipe.instructions }}</p>
                    <div class="text-end mt-2">
                      <button @click="editInstructions()" v-if="editMode == true" class="btn btn-sm btn-secondary"
                        type="button" title="Save instructions">Save</button>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div>
            </div>
          </div>
        </div>
        <div class="modal-footer d-flex justify-content-between">
          <div>
            <i v-if="foundFavorite" class="mdi mdi-heart text-danger fs-4"></i>
          </div>
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>

</template>


<style lang="scss" scoped>
.recipe-box {
  height: 550px;
  width: 100%;
  object-fit: cover;
}

.ingreds {
  line-height: .4;
}

h4,
h5 {
  user-select: none;
}
</style>