<template>
  <table class="table table-sm table-striped table-bordered table-rwd">
    <thead>
      <tr>
        <th v-if="detailRoute" class="th-min"></th>
        <th v-for="key in fields" :key="key">{{key}}</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in items" :key="item.id">
        <td v-if="detailRoute">
          <router-link
            :to="{ name: detailRoute, params: {id: item.id} }"
            class="btn btn-primary"
          >Update</router-link>
        </td>
        <td v-for="key in fields" :key="key">{{item[key]}}</td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  name: "DataTable",
  props: {
    fields: Array,
    items: Array,
    detailRoute: {
      type: String,
      default: null
    }
  }
};
</script>