<template>
  <div>
    <div class="jumbotron jumbotron-fluid">
      <div class="container">
        <h1 class="display-4">BeSpoked</h1>
        <p class="lead">THE high-end bicycle shop near you</p>
      </div>
    </div>
    <div class="card-columns mt-5">
      <div class="card-wrapper">
        <router-link :to="{ name: 'Products' }">
          <div class="card">
            <div class="card-body">
              <h5 class="card-title">Products</h5>
              <p class="card-text">View and Update Products</p>
            </div>
          </div>
        </router-link>
      </div>
      <div class="card-wrapper">
        <router-link :to="{ name: 'Salespersons' }">
          <div class="card">
            <div class="card-body">
              <h5 class="card-title">Salespersons</h5>
              <p class="card-text">View and Update Salespersons</p>
            </div>
          </div>
        </router-link>
      </div>
      <div class="card-wrapper">
        <router-link :to="{ name: 'Customers' }">
          <div class="card">
            <div class="card-body">
              <h5 class="card-title">Customers</h5>
              <p class="card-text">View Customers</p>
            </div>
          </div>
        </router-link>
      </div>
      <div class="card-wrapper">
        <router-link :to="{ name: 'Sales' }">
          <div class="card">
            <div class="card-body">
              <h5 class="card-title">Sales</h5>
              <p class="card-text">View and Enter Sales</p>
            </div>
          </div>
        </router-link>
      </div>
      <div class="card-wrapper">
        <router-link :to="{ name: 'Report' }">
          <div class="card">
            <div class="card-body">
              <h5 class="card-title">Commission Report</h5>
              <p class="card-text">View Quarterly Salesperson Commission Report</p>
            </div>
          </div>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Home"
};
</script>
