<template>
  <div>
    <h1>Sales</h1>
    <hr />
    <router-link class="btn btn-primary" :to="{ name: 'SaleDetail' }">Enter A New Sale</router-link>
    <br />
    <br />
    <div class="row">
      <div class="form-group col-md-6 row">
        <label for="saleDate" class="col-sm-3 col-form-label col-form-label-sm">Start Date</label>
        <div class="col-sm-9">
          <input
            type="date"
            class="form-control form-control-sm"
            @input="fetchData"
            v-model="startDate"
          />
        </div>
      </div>
      <div class="form-group col-md-6 row">
        <label for="saleDate" class="col-sm-3 col-form-label col-form-label-sm">End Date</label>
        <div class="col-sm-9">
          <input
            type="date"
            class="form-control form-control-sm"
            @input="fetchData"
            v-model="endDate"
          />
        </div>
      </div>
    </div>
    <data-table v-bind:fields="fields" v-bind:items="items"></data-table>
  </div>
</template>

<script>
import axios from "axios";
import dataTable from "./DataTable";

export default {
  name: "Sales",
  components: {
    "data-table": dataTable
  },
  data() {
    return {
      fields: [
        "product",
        "customer",
        "salesDate",
        "price",
        "salesperson",
        "commission"
      ],
      items: [],
      startDate: null,
      endDate: null
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
        .get(
          "./static/sales.json?startDate=" +
            this.startDate +
            "&endDate=" +
            this.endDate
        )
        .then(response => {
          vm.items = response.data.filter(item => {
            return (
              (this.startDate == null && this.endDate == null) ||
              (this.startDate != null &&
                this.endDate == null &&
                new Date(item.salesDate) >= new Date(this.startDate)) ||
              (this.startDate == null &&
                this.endDate != null &&
                new Date(item.salesDate) <= new Date(this.endDate)) ||
              (this.startDate != null &&
                this.endDate != null &&
                new Date(item.salesDate) <= new Date(this.endDate) &&
                new Date(item.salesDate) >= new Date(this.startDate))
            );
          });
        })
        .catch(e => {});
    }
  }
};
</script>
