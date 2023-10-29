<template>
    <div class="row">
      <div class="col-12">
        <div class="d-flex justify-content-center">
            <router-link :to="{ path: url, query: { page: previouspage, brand: brand, orderby: orderby } }" class="btn btn-outline-primary mx-2 bottom-btn" v-if="page > 1" @click="scrolltop">Previous</router-link>
            <router-link :to="{ path: url, query: { page: nextpage, brand: brand, orderby: orderby } }" class="btn btn-outline-primary mx-2 bottom-btn" v-if="page < totalPages" @click="scrolltop">Next</router-link>
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
    computed: {
        nextpage() {
            //make this.page a number
            const page = parseInt(this.page);
            return page + 1;
        },
        previouspage() {
            //make this.page a number
            const page = parseInt(this.page);
            return page - 1;
        },
    },
    // watch for url changes and update page number accordingly
    watch: {
        //watch for url changes
        $route(to) {
            //update page number
            this.page = to.query.page || 1;
            this.brand = to.query.brand || '';
            this.orderby = to.query.orderby || '-discount';
        }
    },
    methods: {
        scrolltop() {
            window.scrollTo(0, 0);
        }
    }
}
</script>