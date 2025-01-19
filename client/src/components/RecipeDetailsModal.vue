<script setup>
import { AppState } from "@/AppState";
import { computed } from "vue";


const recipe = computed(() => AppState.activeRecipe)
const account = computed(() => AppState.account)



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
                        <li class="dropdown-item">Edit Recipe</li>
                        <li class="dropdown-item text-danger">Delete Recipe</li>
                      </ul>
                    </div>
                  </div>
                  <small>by: {{ recipe.creator.name }}</small>
                  <p class="mt-2 text-capitalize">{{ recipe.category }}</p>
                  <h5 class="mt-3 mb-3">Ingredients</h5>
                  <div class="ingreds">
                    <p>baclonkfjdl</p>
                  </div>
                  <div>
                    <h5>Instructions</h5>
                    <p>{{ recipe.instructions }}</p>
                  </div>
                </div>
              </div>
            </div>
            <div>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button v-if="recipe?.creatorId == account?.id" class="btn btn-success">Save Changes</button>
          <button type="button" class="btn btn-success" data-bs-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>

</template>


<style lang="scss" scoped>
.recipe-box {
  height: 500px;
  width: 450px;
  background-size: cover;
  background-position: center;
  // border-radius: 5px;
}

.ingreds {
  line-height: .4;
}
</style>