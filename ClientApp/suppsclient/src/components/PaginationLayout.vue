<!-- <template>
    <div class="row">
      <div class="col-12">
        <div class="d-flex justify-content-center">
            <router-link :to="{ path: url, query: { page: previouspage, orderby: orderby } }" class="btn btn-outline-primary mx-2 bottom-btn" v-if="page > 1" @click="scrolltop">Previous</router-link>
            <router-link :to="{ path: url, query: { page: nextpage, orderby: orderby } }" class="btn btn-outline-primary mx-2 bottom-btn" v-if="page < totalPages" @click="scrolltop">Next</router-link>
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
            orderby: this.$route.query.orderby || '-discount',
        };
    },
    computed: {
        nextpage() {
            const page = parseInt(this.page);
            return page + 1;
        },
        previouspage() {
            const page = parseInt(this.page);
            return page - 1;
        },
    },
    watch: {
        $route(to) {
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
</script> -->

<template>
    <div class="row">
        <div class="col-12">
            <div class="d-flex justify-content-center">
                <router-link
                    :to="{ path: url, query: { page: previouspage, orderby: orderby, [pageType]: searchTerm } }"
                    class="btn btn-outline-primary mx-2 bottom-btn"
                    v-if="page > 1"
                    @click="scrolltop"
                >
                    Previous
                </router-link>
                <router-link
                    :to="{ path: url, query: { page: nextpage, orderby: orderby, [pageType]: searchTerm } }"
                    class="btn btn-outline-primary mx-2 bottom-btn"
                    v-if="page < totalPages"
                    @click="scrolltop"
                >
                    Next
                </router-link>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "PaginationLayout",
    props: {
        url: {
            type: String,
            required: true,
        },
        totalPages: {
            type: Number,
            required: true,
        },
        pageType: {
            type: String,
            required: false,
            default: "",
        },
    },
    data() {
        return {
            page: this.$route.query.page || 1,
            orderby: this.$route.query.orderby || "-discount",
            searchTerm: this.$route.query[this.pageType] || "",
        };
    },
    computed: {
        nextpage() {
            const page = parseInt(this.page);
            return page + 1;
        },
        previouspage() {
            const page = parseInt(this.page);
            return page - 1;
        },
    },
    watch: {
        $route(to) {
            this.page = to.query.page || 1;
            this.orderby = to.query.orderby || "-discount";
            this.searchTerm = to.query[this.pageType] || "";
        },
    },
    methods: {
        scrolltop() {
            window.scrollTo(0, 0);
        },
    },
};
</script>