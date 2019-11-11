<template>
  <div id="app">
      <nav-header></nav-header>
    <div class="container-fluid">
      <div class="row">
        <div class="col" role="main">
          <router-view />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import NavHeader from "./components/NavHeader";

export default {
  name: 'App',
  components: {
    "nav-header": NavHeader
  }
}
</script>
