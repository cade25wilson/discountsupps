<script>
import axios from 'axios';
import SelectDropdown from '../components/SelectDropdown.vue';
import SearchForm from '../components/SearchForm.vue';
import ProductLayout from '../components/ProductLayout.vue';
import HeaderMessage from '../components/HeaderMessage.vue';
import PaginationLayout from '../components/PaginationLayout.vue';

export default {
  name: 'SearchView',
  components: {
    SelectDropdown,
    SearchForm,
    ProductLayout,
    HeaderMessage,
    PaginationLayout,
  },
  data() {
    return {
      search: this.$route.query.search || '',
      responseData: null,
      orderBy: this.$route.query.orderby || '-discount',
      page: this.$route.query.page || 1,
    };
  },
  mounted() {
    this.getData();
  },
  watch: {
    $route(to) {
      this.search = to.query.search || '';
      this.orderBy = to.query.orderby || '-discount';
      this.page = to.query.page || 1;
      this.getData();
    },
  },
  methods: {
    getData() {
      axios
        .get('http://localhost:5081/api/Search', {
          params: {
            page: this.page,
            orderby: this.orderBy,
            searchterm: this.search,
          },
        })
        .then((response) => {
          console.log('http://localhost:5081/api/Search?searchterm=' + this.search + '&page=' + this.page + '&orderby=' + this.orderBy)
          this.responseData = response.data;
        })
        .catch((error) => {
          console.log('http://localhost:5081/api/Search?searchterm=' + this.search + '&page=' + this.page + '&orderby=' + this.orderBy)
          console.log(error);
        });
    },
  },
};
</script>


<template>
    <div class="container p-4">
      <div class="row">
          <HeaderMessage />
          <SelectDropdown v-model="orderBy" :orderBy="orderBy" page="search"/>
          <SearchForm/>
      </div>
      <div class="row d-flex align-items-stretch pb-5">
        <div class="col-xl-3 col-lg-4 col-12 mt-3 h-auto" v-for="(product, index) in responseData?.items" :key="index">
          <ProductLayout :product="product"/>
        </div>
      </div>
      <PaginationLayout :totalPages="responseData?.totalPages" url="/search" pageType="search"/>
    </div>
  </template>