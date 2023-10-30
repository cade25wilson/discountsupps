<template>
  <div class="col-4 col-lg-2">
    <select name="orderby" class="form-select" v-model="selectedValue" @change="updateRoute">
      <option value="-discount">Discount</option>
      <option value="-discount_price">Lowest Price</option>
      <option value="discount_price">Highest Price</option>
    </select>
  </div>
</template>

<script>
export default {
  name: "SelectDropdown",
  props: {
    orderBy: {
      type: String,
      required: true,
    },
    page: {
      type: String,
      required: true,
    },
  },
  data() {
    return {
      selectedValue: this.orderBy,
    };
  },
  methods: {
    updateRoute() {
      const queryParams = {};
      queryParams.orderby = this.selectedValue;
      if (this.page == 'search') {
        const search = this.$route.query.search;
        queryParams.search = search;
      }
      if (this.page == 'brand') {
        const brand = this.$route.query.brand;
        queryParams.brand = brand;
      }
      this.$router.push({ query: queryParams });
      console.log(queryParams);
    },
  },
};
</script>
