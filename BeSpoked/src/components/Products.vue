<template>
  <div>
    <h1>Products</h1>
    <hr />
    <data-table v-bind:fields="fields" v-bind:items="items" v-bind:detailRoute="detailRoute"></data-table>
  </div>
</template>

<script>
import axios from "axios";
import dataTable from "./DataTable";

export default {
  name: "Products",
  components: {
    "data-table": dataTable
  },
  data() {
    return {
      detailRoute: "ProductDetail",
      fields: [
        "name",
        "manufacturer",
        "style",
        "purchasePrice",
        "salePrice",
        "quantityOnHand",
        "commissionPercentage"
      ],
      items: []
    };
  },
  mounted() {
    this.fetchData();
  },
  watch: {
    // call again the method if the route changes
    $route: "fetchData"
  },
  methods: {
    fetchData() {
      const vm = this;
      axios
        .get("./static/products.json")
        .then(response => {
          vm.items = response.data;
        })
        .catch(e => {});
    }
  }
};
</script>
