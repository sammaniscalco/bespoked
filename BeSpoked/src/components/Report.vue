<template>
  <div>
    <h1>Commission Report</h1>
    <hr />
    <data-table v-bind:fields="fields" v-bind:items="items"></data-table>
  </div>
</template>

<script>
import axios from "axios";
import dataTable from "./DataTable";

export default {
  name: "Report",
  components: {
    "data-table": dataTable
  },
  data() {
    return {
      fields: ["salesPerson", "quarter", "commission"],
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
        .get("./static/report.json")
        .then(response => {
          vm.items = response.data.filter(item => {
            return item.id == this.id;
          });
        })
        .catch(e => {});
    }
  }
};
</script>
