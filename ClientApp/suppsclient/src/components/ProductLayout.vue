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
          <ProductImage :image="product.image" :url="product.url"/>
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
                <a :href="product.url" class="btn btn-primary w-75" target="_blank">View Product</a>
              </div>
            </div>
          </div>
        </div>

</template>