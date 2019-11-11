<template>
  <div>
    <h1>Sale Details</h1>
    <hr />
    <div v-if="alertVisible" class="alert" :class="alertType" role="alert">{{alertMessage}}</div>
    <form class="p-1 mb-5">
      <div class="form-group row">
        <label for="product" class="col-sm-3 col-form-label col-form-label-sm">Product</label>
        <div class="col-sm-9">
          <select class="form-control form-control-sm" v-model="item.product" id="product">
            <option v-for="opt in products" :key="opt.id" value="opt.id">{{ opt.name }}</option>
          </select>
        </div>
      </div>
      <div class="form-group row">
        <label for="salesperson" class="col-sm-3 col-form-label col-form-label-sm">Salesperson</label>
        <div class="col-sm-9">
          <select class="form-control form-control-sm" v-model="item.salesperson" id="salesperson">
            <option
              v-for="opt in salespersons"
              :key="opt.id"
              :value="opt.id"
            >{{ opt.firstName +' '+opt.lastName }}</option>
          </select>
        </div>
      </div>
      <div class="form-group row">
        <label for="customer" class="col-sm-3 col-form-label col-form-label-sm">Customer</label>
        <div class="col-sm-9">
          <select class="form-control form-control-sm" v-model="item.customer" id="customer">
            <option
              v-for="opt in customers"
              :key="opt.id"
              :value="opt.id"
            >{{ opt.firstName +' '+opt.lastName }}</option>
          </select>
        </div>
      </div>
      <div class="form-group row">
        <label for="saleDate" class="col-sm-3 col-form-label col-form-label-sm">Sales Date</label>
        <div class="col-sm-9">
          <input type="date" class="form-control form-control-sm" v-model="item.saleDate" />
        </div>
      </div>
      <button v-on:click="submitForm" class="btn btn-primary">Submit New Sale</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "SaleDetail",
  props: {
    id: {
      type: Number,
      default: null
    }
  },
  data() {
    return {
      item: {},
      products: [],
      salespersons: [],
      customers: [],
      alertVisible: false,
      alertType: "alert-success",
      alertMessage: ""
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
    submitForm(event) {
      axios
        .post("/sales/" + this.id, this.item)
        .then(response => {
          this.alertVisible = true;
          this.alertType = "alert-success";
          this.alertMessage = "Sale Successfully Submitting";
        })
        .catch(e => {
          this.alertVisible = true;
          this.alertType = "alert-danger";
          this.alertMessage = "Error Submitting Sale";
        });
    },
    fetchData() {
      const vm = this;
      axios
        .get("./static/products.json")
        .then(response => {
          vm.products = response.data;
        })
        .catch(e => {});
      axios
        .get("./static/salespersons.json")
        .then(response => {
          vm.salespersons = response.data;
        })
        .catch(e => {});
      axios
        .get("./static/customers.json")
        .then(response => {
          vm.customers = response.data;
        })
        .catch(e => {});
    }
  }
};
</script>