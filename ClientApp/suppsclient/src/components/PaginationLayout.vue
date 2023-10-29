<template>
    <div class="row">
      <div class="col-12">
        {{ totalPages }}
        <div class="d-flex justify-content-center">
            <router-link :to="{ path: url, query: { page: page - 1, brand: brand, orderby: orderby } }" class="btn btn-outline-primary mx-2 bottom-btn" v-if="page > 1">Previous</router-link>
            <router-link :to="{ path: url, query: { page: page + 1, brand: brand, orderby: orderby } }" class="btn btn-outline-primary mx-2 bottom-btn" v-if="page < totalPages">Next</router-link>
        </div>
      </div>
    </div>
</template>

<script>
export default {
    name: 'PaginationLayout',
    props:
    {
        url: {
            type: String,
            required: true,
        },
        totalPages: {
            type: Number,
            required: true,
        },
    },
    data() {
        return {
            page: this.$route.query.page || 1,
            brand: this.$route.query.brand || '',
            orderby: this.$route.query.orderby || '-discount',

        };
    },
}
</script>