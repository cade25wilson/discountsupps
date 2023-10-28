<script>
export default{
    name: 'HeaderMessage',
    props: {
        totalProducts: {
            type: Number,
            required: false,
        },
    }
}
</script>
<template>
    <div class="col col-lg-6 col-4">
        <h2 v-if="$route.query.brand" class="mb-2">Showing results for {{ $route.query.brand }}</h2>
        <h2 v-if="$route.query.search" class="mb-2">Search results for {{ $route.query.search }}</h2>
        <p v-if="!$route.query.brand && !$route.query.search" class="mb-0">{{ totalProducts }} total results</p>
    </div>  
</template>