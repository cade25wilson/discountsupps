<template>
  <div class="col-4 col-lg-2">
    <select name="orderby" class="form-select" v-model="selectedValue">
      <option value="-discount">Discount</option>
      <option value="discount_price">Lowest Price</option>
      <option value="-discount_price">Highest Price</option>
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
    },
  computed: {
    selectedValue: {
      get() {
        return this.orderBy;
      },
      set(newValue) {
        this.$emit("input", newValue);
      },
    },
  },
};
</script>
  