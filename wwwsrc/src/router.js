import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Vaults from './views/Vaults.vue'
// @ts-ignore
import VaultsView from './views/VaultsView.vue'
// @ts-ignore
import ModalView from './views/ModalView.vue'
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
      name: 'vaults',
      component: Vaults
    },
    {
      path: '/vaults/:id',
      name: 'VaultsView',
      component: VaultsView
    },
    // {  
    //   path: '/viewkeep',
    //   name: 'viewkeep',
    //   component: ViewKeep
    // },
    {
      path: '/keeps/:id',
      name: 'keepId',
      component: ModalView

    }

  ]
})
