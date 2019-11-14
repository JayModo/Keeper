import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import AuthService from "./AuthService"
import VModal from 'vue-js-modal'

Vue.use(VModal, { dynamic: true, dynamicDefaults: { clickToClose: false } })
//Vue.config.productionTip = false



async function init() {
  let user = await AuthService.Authenticate()
  if (user) { store.commit("setUser", user) }
  new Vue({
    router,
    store,
    render: h => h(App)
  }).$mount('#app')
}
init()

