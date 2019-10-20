import Vue from 'vue'
import Vuex, { Store } from 'vuex'


// Store mods
import Auth from "./Store-modules/Auth";


Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    Auth
  }

})