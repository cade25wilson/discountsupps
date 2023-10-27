<template>
    <select name="orderby" class="form-select" v-model="selectedValue">
      <option value="-discount">Discount</option>
      <option value="discount_price">Lowest Price</option>
      <option value="-discount_price">Highest Price</option>
    </select>
  </template>
  
  <script>
  export default {
    name: "SelectDropdown",
    
    computed: {
      selectedValue: {
        get() {
          return this.value; // Set the initial value of selectedValue
        },
        set(newValue) {
          this.$emit("input", newValue);
        },
      },
    },
  };
  </script>
  