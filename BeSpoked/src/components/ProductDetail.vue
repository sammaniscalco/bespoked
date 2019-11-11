 <template>
  <div>
    <h1>Product Details</h1>
    <hr />
    <div v-if="alertVisible" class="alert" :class="alertType" role="alert">{{alertMessage}}</div>
    <form class="p-1 mb-5">
      <div class="form-group row">
        <label for="name" class="col-sm-3 col-form-label col-form-label-sm">Name</label>
        <div class="col-sm-9">
          <input type="text" class="form-control form-control-sm" id="name" v-model="item.name" />
        </div>
      </div>
      <div class="form-group row">
        <label for="manufacturer" class="col-sm-3 col-form-label col-form-label-sm">Manufacturer</label>
        <div class="col-sm-9">
          <input
            type="text"
            class="form-control form-control-sm"
            id="manufacturer"
            v-model="item.manufacturer"
          />
        </div>
      </div>
      <div class="form-group row">
        <label for="style" class="col-sm-3 col-form-label col-form-label-sm">Style</label>
        <div class="col-sm-9">
          <input type="text" class="form-control form-control-sm" id="style" v-model="item.style" />
        </div>
      </div>
      <div class="form-group row">
        <label for="purchasePrice" class="col-sm-3 col-form-label col-form-label-sm">Purchase Price</label>
        <div class="col-sm-9">
          <input
            type="number"
            class="form-control form-control-sm"
            id="purchasePrice"
            v-model="item.purchasePrice"
          />
        </div>
      </div>
      <div class="form-group row">
        <label for="salePrice" class="col-sm-3 col-form-label col-form-label-sm">Sale Price</label>
        <div class="col-sm-9">
          <input
            type="number"
            class="form-control form-control-sm"
            id="salePrice"
            v-model="item.salePrice"
          />
        </div>
      </div>
      <div class="form-group row">
        <label
          for="quantityOnHand"
          class="col-sm-3 col-form-label col-form-label-sm"
        >Quantity On Hand</label>
        <div class="col-sm-9">
          <input
            type="number"
            class="form-control form-control-sm"
            id="quantityOnHand"
            :value="item.quantityOnHand"
          />
        </div>
      </div>
      <div class="form-group row">
        <label
          for="commissionPercentage"
          class="col-sm-3 col-form-label col-form-label-sm"
        >Commission Percentage</label>
        <div class="col-sm-9">
          <input
            type="number"
            class="form-control form-control-sm"
            id="commissionPercentage"
            :value="item.commissionPercentage"
          />
        </div>
      </div>
      <button v-on:click="submitForm" class="btn btn-primary">Update Product</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "ProductDetail",
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
        .put("/products/" + this.id, this.item)
        .then(response => {
          this.alertVisible = true;
          this.alertType = "alert-success";
          this.alertMessage = "Product Successfully Updated";
        })
        .catch(e => {
          this.alertVisible = true;
          this.alertType = "alert-danger";
          this.alertMessage = "Error Updating Product";
        });
    },
    fetchData() {
      const vm = this;
      axios
        .get("./static/products.json")
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