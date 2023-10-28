<!-- <script>
import axios from 'axios'
import SelectDropdown from '../components/SelectDropdown.vue';
import SearchForm from '../components/SearchForm.vue';
import ProductLayout from '../components/ProductLayout.vue';
import HeaderMessage from '../components/HeaderMessage.vue';

export default {
    name: 'SearchView',
    components: {
        SelectDropdown,
        SearchForm,
        ProductLayout,
        HeaderMessage
    },
    data() {
        return {
            search: this.$route.query.search || '',
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
        },
        search: function (newSearch) {
            this.$router.push({ query: { search: newSearch } });
        },
    },
    methods: {
        getData() {
            axios.get('http://localhost:5081/api/Search', {
                params: {
                    page: this.$route.params.page,
                    orderby: this.orderBy,
                    searchterm: this.$route.query.search
                }
            })
                .then(response => {
                    this.responseData = response.data;
                })
                .catch(error => {
                    console.log(error);
                    //log the url
                    console.log(this.$route.query.search);
                });
        }
    },
};

</script> -->

<script>
import axios from 'axios';
import SelectDropdown from '../components/SelectDropdown.vue';
import SearchForm from '../components/SearchForm.vue';
import ProductLayout from '../components/ProductLayout.vue';
import HeaderMessage from '../components/HeaderMessage.vue';

export default {
  name: 'SearchView',
  components: {
    SelectDropdown,
    SearchForm,
    ProductLayout,
    HeaderMessage,
  },
  data() {
    return {
      search: this.$route.query.search || '',
      responseData: null,
      orderBy: this.$route.query.orderby || '-discount',
    };
  },
  mounted() {
    this.getData();
  },
  watch: {
    $route(to) {
      this.search = to.query.search || '';
      this.orderBy = to.query.orderby || '-discount';
      this.getData();
    },
  },
  methods: {
    getData() {
      axios
        .get('http://localhost:5081/api/Search', {
          params: {
            page: this.$route.params.page,
            orderby: this.orderBy,
            searchterm: this.search,
          },
        })
        .then((response) => {
          this.responseData = response.data;
        })
        .catch((error) => {
          console.log(error);
          // Log the URL
          console.log(this.search);
        });
    },
  },
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