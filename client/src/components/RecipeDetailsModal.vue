<script setup>
import { AppState } from "@/AppState";
import { computed } from "vue";


const recipe = computed(() => AppState.activeRecipe)




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
                  <h4 class="text-success">{{ recipe.title }}</h4>
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
          <button type="button" class="btn btn-success" data-bs-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>

</template>


<style lang="scss" scoped>
.recipe-box {
  height: 500px;
  width: auto;
  background-size: cover;
  background-position: center;
  // border-radius: 5px;
}

.ingreds {
  line-height: .4;
}
</style>