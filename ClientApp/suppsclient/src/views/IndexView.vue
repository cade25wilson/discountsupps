<script>
import axios from 'axios'
import SelectDropdown from '../components/SelectDropdown.vue';
import SearchForm from '../components/SearchForm.vue';
import ProductImage from '../components/ProductImage.vue';

export default {
  name: 'IndexView',
  components: {
    SelectDropdown,
    SearchForm,
    ProductImage,
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
      <div class="col col-lg-6 col-4">
        <p class="mb-0">Total results</p>
      </div>
      <div class="col-4 col-lg-2">
        <SelectDropdown v-model="orderBy" />
      </div>
      <div class="col-4 col-lg-4 text-right">
        <SearchForm />
      </div>
    </div>
    <div class="row d-flex align-items-stretch pb-5">
      <div class="col-xl-3 col-lg-4 col-12 mt-3 h-auto" v-for="(product, index) in responseData" :key="index">
        <div class="border rounded p-3 h-100">
          <ProductImage :image="product.image" />
          <div class="product-name h-auto">
            <h5>{{product.name}}</h5>
            <div class="row h-auto">
              <div class="col-3">
                <div class="product-price">
                  <p>
                    Add discount here 
                      <span class="text-danger"><del>${{ product.originalPrice }}</del></span>
                    ${{ product.discountPrice }}
                  </p>
                </div>
              </div>
              <div class="col-9">
                <div class="product-brand text-end">
                  <a href="/" class="text-black">
                    <p class="mb-0" v-if="product.brand">{{ product.brand }}</p>
                  </a>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-3">
                <p>${{product.discount}}🔻</p>
              </div>
              <div class="col-9 text-end" v-if="product.advertiser">
                <a href="/" class="text-black">
                  <p>{{ product.advertiser }}</p>
                </a>
              </div>
            </div>
            <div class="row">
              <div class="text-center">
                <a :href="product.url" class="btn btn-primary w-75">View Product</a>
              </div>
            </div>
          </div>
        </div>
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
