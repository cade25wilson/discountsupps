

<script>
import axios from 'axios';
import SelectDropdown from '../components/SelectDropdown.vue';
import SearchForm from '../components/SearchForm.vue';
import ProductLayout from '../components/ProductLayout.vue';
import HeaderMessage from '../components/HeaderMessage.vue';
import PaginationLayout from '../components/PaginationLayout.vue';
export default {
    name: 'BrandView',
    components: {
        SelectDropdown,
        SearchForm,
        ProductLayout,
        HeaderMessage,
        PaginationLayout,
    },
    data() {
        return {
            responseData: null,
            orderBy: this.$route.query.orderby || '-discount',
            page: this.$route.query.page || 1,
            brand: this.$route.query.brand || '',
        };
    },
    mounted() {
        this.getData();
    },
    watch: {
        '$route.query': {
            handler() {
                this.orderBy = this.$route.query.orderby || '-discount';
                this.page = this.$route.query.page || 1;
                this.brand = this.$route.query.brand || '';
                this.getData();
            },
            deep: true,
        },
    },
    methods: {
        getData() {
            console.log (this.brand)
            axios
                .get('http://localhost:5081/api/Brand/', {
                    params: {
                        page: this.page,
                        url: this.brand,
                        orderby: this.orderBy,
                    },
                })
                .then((response) => {
                    this.responseData = response.data;
                })
                .catch((error) => {
                    console.log(error);
                });
        },
    },
}
</script>

<template>
    <div class="container p-4">
      <div class="row">
          <HeaderMessage />
          <SelectDropdown v-model="orderBy" :orderBy="orderBy" page="brand"/>
          <SearchForm/>
      </div>
      <div class="row d-flex align-items-stretch pb-5">
        <div class="col-xl-3 col-lg-4 col-12 mt-3 h-auto" v-for="(product, index) in responseData?.items" :key="index">
          <ProductLayout :product="product"/>
        </div>
      </div>
      <PaginationLayout :totalPages="responseData?.totalPages" url="/brand" pageType="brand"/>
    </div>
  </template>