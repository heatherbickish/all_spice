<script setup>
import { AppState } from "@/AppState";
import { recipesService } from "@/services/RecipesService";
import { logger } from "@/utils/Logger";
import Pop from "@/utils/Pop";
import { computed, ref } from "vue";


const recipe = computed(() => AppState.activeRecipe)
const account = computed(() => AppState.account)
const ingredients = computed(() => AppState.ingredients)

const editMode = ref(false)

const editableInstructions = ref({ instructions: '' })

async function saveChanges() {
  try {
    const recipeId = recipe.value.id
    const updatedInstructions = await recipesService.saveChanges(editableInstructions.value, recipeId)
    editableInstructions.value = { instructions: '' }
    editMode.value = false
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
            <div v-if="recipe">
              <div class="d-flex">
                <img :src="recipe.img" alt="" class="recipe-box">
                <div class="ms-4">
                  <div class="d-flex align-items-center">
                    <h4 class="text-success">{{ recipe.title }}</h4>
                    <div v-if="recipe?.creatorId == account?.id" class="dropdown">
                      <button class=" btn fs-4 ms-4 dropdown toggle" type="button" data-bs-toggle="dropdown"
                        aria-expanded="false"><i class="mdi mdi-dots-horizontal"></i></button>
                      <ul class="dropdown-menu">
                        <li class="dropdown-item" @click="editMode = !editMode">Edit Recipe</li>
                        <li class="dropdown-item text-danger">Delete Recipe</li>
                      </ul>
                    </div>
                  </div>
                  <small>by: {{ recipe.creator?.name }}</small>
                  <p class="mt-2 text-capitalize">{{ recipe.category }}</p>
                  <h5 class="mt-3 mb-3">Ingredients</h5>
                  <!-- <button class="btn"><i class="mdi mdi-plus-circle-outline text-success fs-4"></i></button> -->
                  <div class="ingreds">
                    <input v-if="editMode == true" type="text" name="" id="">
                    <ul v-for="ingredient in ingredients" :key="ingredient.id">
                      <li>{{ ingredient.quantity }} {{ ingredient.name }}</li>
                    </ul>
                  </div>
                  <div>
                    <h5>Instructions</h5>
                    <!-- <p v-if="editMode == true" contenteditable="true">{{ recipe.instructions }}</p> -->
                    <textarea v-model="editableInstructions.instructions" v-if="editMode == true" type="text"
                      class="form-floating" maxlength="500"></textarea>
                    <p v-else>{{ recipe.instructions }}</p>
                    <div class="text-end">
                      <button @click="saveChanges()" v-if="editMode == true"
                        class="btn btn-sm btn-success">Save</button>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <!-- <button v-if="recipe?.creatorId == account?.id" class="btn btn-success">Save Changes</button> -->
          <button type="button" class="btn btn-success" data-bs-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>

</template>


<style lang="scss" scoped>
.recipe-box {
  height: 500px;
  width: 400px;
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