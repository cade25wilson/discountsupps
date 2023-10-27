<script>
import axios from 'axios'
import SelectDropdown from '../components/SelectDropdown.vue';
import SearchForm from '../components/SearchForm.vue';
import ProductLayout from '../components/ProductLayout.vue';
import HeaderMessage from '../components/HeaderMessage.vue';

export default {
  name: 'IndexView',
  components: {
    SelectDropdown,
    SearchForm,
    ProductLayout,
    HeaderMessage
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
    orderBy: function (newOrderBy) {
      this.$router.push({ query: { orderby: newOrderBy } });
      this.getData();
    }
  },
  methods: {
    //make a method called getdata() and call it in mounted() and watch orderBy
    getData() {
      axios.get('http://localhost:5081/api/supplement', {
        params: {
          page: this.$route.params.page,
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
        <HeaderMessage />
        <SelectDropdown v-model="orderBy" />
        <SearchForm />
    </div>
    <div class="row d-flex align-items-stretch pb-5">
      <div class="col-xl-3 col-lg-4 col-12 mt-3 h-auto" v-for="(product, index) in responseData" :key="index">
        <ProductLayout :product="product"/>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <div class="d-flex justify-content-center">

        </div>
      </div>
    </div>
  </div>
</template>
