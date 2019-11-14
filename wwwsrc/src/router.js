import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Vaults from './views/Vaults.vue'


Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/vaults',
      name: 'Vaults',
      component: Vaults
    },
    // {  
    //   path: '/viewkeep',
    //   name: 'viewkeep',
    //   component: ViewKeep
    // },
    {
      path: '/keeps/:keepId',
      name: 'keepId',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: function () {
        // @ts-ignore
        return import(/* webpackChunkName: "keep" */ './Store-modules/HomePage.js')
      }

    }

  ]
})
