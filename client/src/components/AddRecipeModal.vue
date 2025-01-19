<script setup>
import { recipesService } from "@/services/RecipesService";
import { logger } from "@/utils/Logger";
import Pop from "@/utils/Pop";
import { ref } from "vue";
import { Modal } from "bootstrap";


const categories = ['breakfast', 'lunch', 'dinner', 'snack', 'dessert']

const editableRecipeData = ref({
  title: '',
  category: '',
  img: ''
})

async function createRecipe() {
  try {
    const createdRecipe = await recipesService.createRecipe(editableRecipeData.value)
    editableRecipeData.value = {
      title: '',
      category: '',
      img: ''
    }
    Modal.getInstance('#addRecipeModal').hide()

  }
  catch (error) {
    Pop.meow(error);
    logger.error(error)
  }
}

</script>


<template>
  <div class="modal fade" id="addRecipeModal" tabindex="-1" aria-labelledby="addRecipeModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header bg-secondary">
          <h2 class="modal-title text-light" id="addRecipeModalLabel">New Recipe</h2>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createRecipe()">
            <div class="d-flex">
              <div class="mb-3 me-5">
                <label for="title" class="form-label">Title</label>
                <input v-model="editableRecipeData.title" type="text" class="form-control" maxlength="30" id="title"
                  placeholder="Title..." required>
              </div>
              <div class="mb-3">
                <label for="category" class="form-label">Category</label>
                <select v-model="editableRecipeData.category" class="form-select" aria-label="Recipe Category"
                  id="category" required>
                  <option selected value="" disabled>Choose a category</option>
                  <option v-for="category in categories" :key="'option-' + category" :value="category"
                    class="text-capitalize">{{ category }}
                  </option>
                </select>
              </div>
            </div>
            <div class="mb-3">
              <label for="img" class="form-label">Image</label>
              <input v-model="editableRecipeData.img" type="url" class="form-control" maxlength="3000" id="img"
                placeholder="Image Url..." required>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn" data-bs-dismiss="modal">Cancel</button>
              <button type="submit" class="btn btn-success">Submit</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
@import url('https://fonts.googleapis.com/css2?family=Oranienbaum&display=swap');

h2 {
  font-family: "Oranienbaum", serif;
}
</style>