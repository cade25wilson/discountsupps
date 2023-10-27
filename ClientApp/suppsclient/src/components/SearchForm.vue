<script>

export default {
  name: 'SearchForm',
};

</script>

<template>
    <div class="input-group mb-3">
        <input type="text" class="form-control" placeholder="Search" name="search" value="">
        <router-link :to="{ path: '/search', query: { search: search } }" class="btn btn-primary" id="button-addon2">Search</router-link>
    </div>
</template>