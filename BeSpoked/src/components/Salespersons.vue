<template>
  <div>
    <h1>Salespersons</h1>
    <hr />
    <data-table v-bind:fields="fields" v-bind:items="items" v-bind:detailRoute="detailRoute"></data-table>
  </div>
</template>

<script>
import axios from "axios";
import dataTable from "./DataTable";

export default {
  name: "Salespersons",
  components: {
    "data-table": dataTable
  },
  data() {
    return {
      detailRoute: "SalespersonDetail",
      fields: [
        "firstName",
        "lastName",
        "address",
        "phone",
        "startDate",
        "terminationDate"
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
        .get("./static/salespersons.json")
        .then(response => {
          vm.items = response.data;
        })
        .catch(e => {});
    }
  }
};
</script>
