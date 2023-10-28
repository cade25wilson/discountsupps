<script setup>
import { RouterView } from 'vue-router'
</script>

<template>
  <header>
        <div class="text-center">
            <router-link to="/" class="text-decoration-none text-black"><h1 class="p-5">Discount Supplements</h1></router-link>
        </div>
    </header>
  <RouterView />
  <footer class="p-5">
        <div class="text-center">
            Discountsupplinks ©2023
        </div>
    </footer>
</template>
