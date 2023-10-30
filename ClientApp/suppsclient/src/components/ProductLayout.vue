<script>
import ProductImage from '../components/ProductImage.vue';

export default{
    name: 'ProductLayout',
    components: {
        ProductImage
    },
    props: {
        product: {
            type: Object,
            required: true,
        },
    },
}
</script>

<template>
    
    <div class="border rounded p-3 h-100">
      <!-- {{ product }} -->
          <ProductImage :image="product.supplement.image" :url="product.url"/>
          <div class="product-name h-auto">
            <h5>{{product.supplement.name}}</h5>
            <div class="row h-auto">
              <div class="col-3">
                <div class="product-price">
                  <p> 
                    <span class="text-danger"><del>${{ product.supplement.originalPrice }}</del></span>
                    ${{ product.supplement.discountPrice }}
                  </p>
                </div>
              </div>
              <div class="col-9">
                <div class="product-brand text-end" v-if="product.brand">
                  <router-link :to="`/brand/`+product.brand.brandUrl" class="text-black">
                    <p class="mb-0" >{{ product.brand.brandName }}</p>
                  </router-link>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-3">
                <p>${{product.supplement.discount}}🔻</p>
              </div>
              <div class="col-9 text-end" v-if="product.advertiser">
                <a href="/" class="text-black">
                  <p>{{ product.supplement.advertiser }}</p>
                </a>
              </div>
            </div>
            <div class="row">
              <div class="text-center">
                <a :href="product.supplement.url" class="btn btn-primary w-75" target="_blank">View Product</a>
              </div>
            </div>
          </div>
        </div>

</template>