<script setup>

</script>


<template>
  <div class="modal fade" id="addRecipeModal" tabindex="-1" aria-labelledby="addRecipeModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header bg-success">
          <h2 class="modal-title text-light" id="addRecipeModalLabel">New Recipe</h2>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form>
            <div class="d-flex">
              <div class="mb-3 me-5">
                <label for="title" class="form-label">Title</label>
                <input type="text" class="form-control" id="title" placeholder="Title..." required>
              </div>
              <div class="mb-3">
                <label for="category" class="form-label">Category</label>
                <select class="form-select" aria-label="Recipe Category" id="category" required>
                  <option selected disabled>Choose a category</option>
                  <option value="1">One</option>
                  <option value="2">Two</option>
                  <option value="3">Three</option>
                  <option value="3">Three</option>
                </select>
              </div>
            </div>
            <div class="mb-3">
              <label for="img" class="form-label">Image</label>
              <input type="url" class="form-control" id="img" placeholder="Image Url..." required>
            </div>
          </form>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn" data-bs-dismiss="modal">Cancel</button>
          <button type="button" class="btn btn-success">Submit</button>
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