import Vue from 'vue'
import Vuex, { Store } from 'vuex'


// Store mods
import Auth from "./Store-modules/Auth";
import HomePage from "./Store-modules/HomePage";
import Vaults from "./Store-modules/Vaults"
Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    Auth,
    HomePage,
    Vaults
  }

})