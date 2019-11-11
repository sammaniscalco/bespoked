<template>
  <div>
    <h1>Salesperson Details</h1>
    <hr />
    <div v-if="alertVisible" class="alert" :class="alertType" role="alert">{{alertMessage}}</div>
    <form class="p-1 mb-5">
      <div class="form-group row">
        <label for="firstName" class="col-sm-3 col-form-label col-form-label-sm">First Name</label>
        <div class="col-sm-9">
          <input
            type="text"
            class="form-control form-control-sm"
            id="firstName"
            v-model="item.firstName"
          />
        </div>
      </div>
      <div class="form-group row">
        <label for="lastName" class="col-sm-3 col-form-label col-form-label-sm">Last Name</label>
        <div class="col-sm-9">
          <input
            type="text"
            class="form-control form-control-sm"
            id="lastName"
            v-model="item.lastName"
          />
        </div>
      </div>
      <div class="form-group row">
        <label for="address" class="col-sm-3 col-form-label col-form-label-sm">Address</label>
        <div class="col-sm-9">
          <input
            type="text"
            class="form-control form-control-sm"
            id="address"
            v-model="item.address"
          />
        </div>
      </div>
      <div class="form-group row">
        <label for="phone" class="col-sm-3 col-form-label col-form-label-sm">Phone</label>
        <div class="col-sm-9">
          <input type="tel" class="form-control form-control-sm" id="phone" v-model="item.phone" />
        </div>
      </div>
      <div class="form-group row">
        <label for="startDate" class="col-sm-3 col-form-label col-form-label-sm">Start Date</label>
        <div class="col-sm-9">
          <input
            type="date"
            class="form-control form-control-sm"
            id="startDate"
            v-model="item.startDate"
          />
        </div>
      </div>
      <div class="form-group row">
        <label
          for="terminationDate"
          class="col-sm-3 col-form-label col-form-label-sm"
        >Termination Date</label>
        <div class="col-sm-9">
          <input
            type="date"
            class="form-control form-control-sm"
            id="terminationDate"
            v-model="item.terminationDate"
          />
        </div>
      </div>
      <button v-on:click="submitForm" class="btn btn-primary">Update Salesperson</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "SalespersonDetail",
  props: {
    id: {
      type: Number,
      default: null
    }
  },
  data() {
    return {
      item: {},
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
        .put("/salespersons/" + this.id, this.item)
        .then(response => {
          this.alertVisible = true;
          this.alertType = "alert-success";
          this.alertMessage = "Salesperson Successfully Updated";
        })
        .catch(e => {
          this.alertVisible = true;
          this.alertType = "alert-danger";
          this.alertMessage = "Error Updating Salesperson";
        });
    },
    fetchData() {
      const vm = this;
      axios
        .get("./static/salespersons.json")
        .then(response => {
          vm.item = response.data.filter(item => {
            return item.id == this.id;
          })[0];
        })
        .catch(e => {});
    }
  }
};
</script>