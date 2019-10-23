
import router from "../router";
import AuthService from "../AuthService";
import Axios from "axios"

import Vue from "vue";
import Auth from "./Auth";



const CONTROLLER_ROUTE = 'api/vaults'
// EXAMPLE: const CONTROLLER_ROUTE = 'api/cars'


let base = window.location.host.includes("localhost:8080")
  ? "https://localhost:5001/"
  : "/"

let api = Axios.create({
  baseURL: base + CONTROLLER_ROUTE,
  timeout: 3000,
  withCredentials: true
});

export default {
  state: {
    vaults: [],

  },
  mutations: {
    setVaults(state, payload) {
      state.vaults = payload
    }
  },
  actions: {
    async getVaults({ commit, dispatch, state }) {
      try {
        debugger
        let axiosRes = await api.get("");
        let vaults = axiosRes.data;
        commit("setVaults", vaults);
        // state.vaults.forEach(vault => {
        //   let vaultsId = vaults._id
        //   dispatch(vaults)
        // });
      } catch (error) {
        router.push("/");
      }
    },


    async addVaults({ commit, dispatch }, vaultData) {
      debugger
      let axiosRes = await api.post("", vaultData);
      if (axiosRes) {
        dispatch("getVaults");
      }
    },
  }
}