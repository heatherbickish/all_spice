<script setup>
import { Recipe } from "@/models/Recipe";

defineProps({
  recipe: { type: Recipe, required: true }
})
</script>


<template>
  <div class="mb-5 shadow recipe-box" :style="{ backgroundImage: `url(${recipe.img})` }">
    <div class="d-flex align-items-center justify-content-between">
      <h5 class="text-light ms-4 mt-2 rounded-pill glass-box px-3">{{ recipe.category }}</h5>
      <button class="btn selectable"><i class="mdi mdi-heart text-danger fs-3"></i></button>
    </div>
    <div class="ms-3">
      <h6 class="text-light position-absolute bottom-0 glass-box px-2 py-2">{{ recipe.title }}</h6>
    </div>
    <!-- <img src="" alt="" class=""> -->
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
  background-color: rgba(0, 0, 0, 0.0750);
  backdrop-filter: blur(10px);
}
</style>