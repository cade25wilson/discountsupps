<script>
import axios from 'axios'
import SelectDropdown from '../components/SelectDropdown.vue';
import SearchForm from '../components/SearchForm.vue';
import ProductLayout from '../components/ProductLayout.vue';
import HeaderMessage from '../components/HeaderMessage.vue';
import PaginationLayout from '../components/PaginationLayout.vue';

export default {
  name: 'IndexView',
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
    };
  }, 
  mounted() {
    this.getData();
  }, 
  watch: {
    '$route.query.orderby': function() {
      this.orderBy = this.$route.query.orderby;
      this.getData();
    },
    $route(to) {
      this.orderBy = to.query.orderby || '-discount';
      this.getData();
    }
  },
  methods: {
    getData() {
      axios.get('http://localhost:5081/api/supplement', {
        params: {
          page: this.$route.query.page,
          orderby: this.orderBy,
        }
      })
      .then(response => {
        this.responseData = response.data;
      })
      .catch(error => {
        console.log(error);
      });
    }
  }
};
</script>

<template>
  <div class="container p-4">
    <div class="row">
        <HeaderMessage :totalProducts="responseData?.totalItems"/>
        <SelectDropdown v-model="orderBy" :orderBy="orderBy"/>
        <SearchForm :orderBy="orderBy"/>
    </div>
    <div class="row d-flex align-items-stretch pb-5">
      <div class="col-xl-3 col-lg-4 col-12 mt-3 h-auto" v-for="(product, index) in responseData?.items" :key="index">
        <ProductLayout :product="product"/>
      </div>
    </div>
        <PaginationLayout url="/" :total-pages="responseData?.totalPages"/>
  </div>
</template>
