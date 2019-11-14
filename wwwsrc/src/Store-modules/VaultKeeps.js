import router from "../router";
import AuthService from "../AuthService";
import Axios from "axios"

import Vue from "vue";
import Auth from "./Auth";



const CONTROLLER_ROUTE = 'api/vaultKeeps'
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
    vaultkeeps: []
  },
  mutations: {
    setVaultKeeps(state, vaultkeeps) {
      state.vaultkeeps = vaultkeeps;
    }
  },
  actions: {
    async createVaultKeep({ dispatch }, vaultkeep) {
      try {
        let axiosRES = await api.post('', vaultkeep)
        let newVaultKeep = axiosRES.data
        dispatch('getVaultKeeps')
      } catch (error) {
        console.error('actions', 'createVaultKeep')
      }
    },
  }
}