<template>
  <nav class="navbar navbar-expand-md navbar-dark bg-dark">
    <a class="navbar-brand" href="/">BeSpoked</a>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navItems"
      aria-controls="navbarSupportedContent"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="navItems">
      <ul class="navbar-nav mr-auto">
        <li class="nav-item" v-for="item in items" :key="item.name">
          <router-link :to="'/'+item.name" class="nav-link">{{item.name}}</router-link>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script>
export default {
  name: "NavHeader",
  data() {
    return {
      items: [
        { name: "Products" },
        { name: "Salespersons" },
        { name: "Customers" },
        { name: "Sales" },
        { name: "Report" }
      ]
    };
  }
};
</script>