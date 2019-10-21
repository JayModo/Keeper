import Vue from 'vue'
import Vuex, { Store } from 'vuex'


// Store mods
import Auth from "./Store-modules/Auth";
import HomePage from "./Store-modules/HomePage";

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    Auth,
    HomePage
  }

})