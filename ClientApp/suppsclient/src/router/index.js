import { createRouter, createWebHistory } from 'vue-router'
import IndexView from '../views/IndexView.vue'
import SearchView from '../views/SearchView.vue'
import BrandView from '../views/BrandView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: IndexView
    },
    {
      path: '/search',
      name: 'search',
      component: SearchView
    },
    {
      path: '/brand/',
      name: 'brand',
      component: BrandView
    }
  ]
})

export default router
