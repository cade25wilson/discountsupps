<template>
    <div class="col-4 col-lg-4 text-right">
        <div class="input-group mb-3">
            <input type="text" class="form-control" placeholder="Search" name="search" v-model="search">
            <router-link :to="'/search?search=' + search" class="btn btn-primary" id="button-addon2">Search</router-link>
        </div>
    </div>
</template>

<script>
export default {
    name: 'SearchForm',
    data() {
        return {
            search: '',
        };
    },
};
</script>