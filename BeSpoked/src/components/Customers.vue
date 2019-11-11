<template>
  <div>
    <h1>Customers</h1>
    <hr />
    <data-table v-bind:fields="fields" v-bind:items="items"></data-table>
  </div>
</template>

<script>
import axios from "axios";
import dataTable from "./DataTable";

export default {
  name: "Customers",
  components: {
    "data-table": dataTable
  },
  data() {
    return {
      fields: ["firstName", "lastName", "address", "phone", "startDate"],
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
        .get("./static/customers.json")
        .then(response => {
          vm.items = response.data;
        })
        .catch(e => {});
    }
  }
};
</script>
