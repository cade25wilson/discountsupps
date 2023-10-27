<script>

export default {
  name: 'ProductImage',
  props: {
    image: {
      type: String,
      required: true,
    },
    url: {
      type: String,
      required: true,
    },
    computed: {
      isFromCdn() {
        return this.image.startsWith('http');
      },
    },
  },
};
</script>

<template>
    <div class="mb-2 text-center">
        <a :href="url" target="_blank">
            <template v-if="isFromCdn">
                <img :src="image" alt="image" class="img-thumbnail border-0">
            </template>
            <template v-else>
                <img :src="`./assets/images/${image}`" alt="image" class="img-thumbnail border-0">
            </template>
        </a>
    </div>
</template>