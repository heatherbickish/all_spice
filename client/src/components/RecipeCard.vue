<script setup>

</script>


<template>
  <div class="col-md-4 mt-4">
    <div class="mb-5 shadow recipe-box">
      <div class="d-flex align-items-center justify-content-between">
        <h5 class="text-light ms-4 mt-2 rounded-pill glass-box px-3">Lunch</h5>
        <button class="btn selectable"><i class="mdi mdi-heart text-danger fs-3"></i></button>
      </div>
      <div class="ms-3">
        <h5 class="text-light position-absolute bottom-0 glass-box px-2 py-2">Pumpkin Bisque</h5>
      </div>
      <!-- <img src="" alt="" class=""> -->
    </div>
  </div>
</template>


<style lang="scss" scoped>
.recipe-box {
  background-image: url(https://images.unsplash.com/photo-1690983322070-22861e13ce47?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  height: 300px;
  width: auto;
  background-size: cover;
  background-position: center;
  border-radius: 5px;
  position: relative;
}

.glass-box {
  border-radius: 5px;
  background-color: rgba(0, 0, 0, 0.01);
  backdrop-filter: blur(10px);
}
</style>