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
    setVaultKeeps(state, payload) {
      state.vaultkeeps = payload;
    }
  },
  actions: {
    async createVaultKeep({ dispatch }, vaultkeep) {
      try {
        let axiosRES = await api.post('', vaultkeep)
        let newVaultKeep = axiosRES.data
        dispatch('setVaultKeeps')
      } catch (error) {
        console.error('actions', 'createVaultKeep')
      }
    },
    async getVaultKeeps({ commit, rootState }) {
      try {
        let endpoint = `${rootState.Vaults.activevault.id}`;
        let axiosRES = await api.get(endpoint)
        let vaultkeeps = axiosRES.data
        commit('setVaultKeeps', vaultkeeps)
      } catch (error) {
        console.error('actions', 'getVaultKeeps')
      }
    },
    async saveKeep({ commit, dispatch }, keepData) {
      try {
        debugger
        // let endpoint = `${vaultkeep}`;
        let axiosRES = await api.post('', keepData);
        if (axiosRES) {
          dispatch("getVaultKeeps")
        }

        // endpoint = "";
        // await api.post(endpoint, vaultkeep);
        // await dispatch('getVaultKeeps')

      } catch (error) {
        alert('store-module vaultkeep.js actions saveKeep()')
      }
    },
    async deleteVaultKeep({ commit, dispatch }, vaultkeep) {
      try {
        let vaultkeepId = vaultkeep
        let endPoint = `${vaultkeepId}`;
        await api.delete(endPoint);
        dispatch('getVaultKeeps')
      } catch (error) {
        alert('store-module vaultkeep.js actions deleteKeep()')
      }
    }
  }
}