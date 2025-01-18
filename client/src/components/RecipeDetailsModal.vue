<script setup>




</script>


<template>
  <div class="modal fade" id="recipeDetailsModal" tabindex="-1" aria-labelledby="recipeDetailsModalLabel"
    aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-body">
          <div>
            <div>
              <div class="d-flex">
                <img
                  src="https://images.unsplash.com/photo-1578020190125-f4f7c18bc9cb?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                  alt="" class="recipe-box">
                <div class="ms-4">
                  <h4 class="text-success">Pumpkin Bisque</h4>
                  <small>by: Millie Sheppard</small>
                  <p class="mt-2">Lunch</p>
                  <h5 class="mt-3 mb-3">Ingredients</h5>
                  <div class="ingreds">
                    <p>baclonkfjdl</p>
                  </div>
                  <div>
                    <h5>Instructions</h5>
                    <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Nobis deserunt atque nostrum minus ex
                      asperiores modi cupiditate</p>
                  </div>
                </div>
              </div>
            </div>
            <div>

            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
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