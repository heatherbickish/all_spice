<script setup>
import Login from "@/components/Login.vue";
import RecipeCard from "@/components/RecipeCard.vue";


</script>

<template>
  <section class="container">
    <div class="row hero justify-content-end mt-4 shadow">
      <div class="col-md-4">
        <div class="mt-2 d-flex align-items-center">
          <input type="text" class="form-control" placeholder="Search...">
          <button class="btn text-light fs-4"><i class="mdi mdi-magnify me-3"></i></button>
          <Login />
          <div class="mt-2">
          </div>
        </div>
      </div>
      <div class="row justify-content-center">
        <div class="col-md-3">
          <div class="text-light text-center text">
            <h1>All-Spice</h1>
            <h5>Cherish Your Family And Their Cooking</h5>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- SECTION  menu buttons -->
  <section class="container">
    <div class="row justify-content-center">
      <div class="col-md-4 text-center menu-box">
        <div class="bg-light rounded py-2 shadow">
          <button class="btn text-success fs-5 selectable">Home</button>
          <button class="btn text-success fs-5 selectable">My Recipes</button>
          <button class="btn text-success fs-5 selectable">Favorites</button>
        </div>
      </div>
    </div>
  </section>

  <!-- SECTION recipe cards -->
  <section class="container">
    <div class="row">
      <RecipeCard />
    </div>
  </section>
</template>

<style scoped lang="scss">
.hero {
  background-image: url(https://images.unsplash.com/photo-1690983322070-22861e13ce47?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  height: 500px;
  width: auto;
  background-size: cover;
  background-position: center;
  border-radius: 5px;
}

.text {
  text-shadow: 1px 1px black;
}


@media screen and (min-width: 768px) {
  .menu-box {
    position: relative;
    bottom: 2em;
  }
}
</style>
