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
    vaultkeeps: [],
    vaultkeep: {}
  },
  mutations: {
    setVaultKeeps(state, vaultKeeps) {
      debugger
      state.vaultkeeps = vaultKeeps;
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
    async getVaultKeeps({ commit, dispatch, rootState }) {
      try {
        debugger
        // let endpoint = `${rootState.VaultKeeps.vaultKeeps}`;
        let axiosRES = await api.get("")
        let vk = axiosRES.data
        commit('setVaultKeeps', vk);

        dispatch(vk)

      } catch (error) {
        console.error('actions', 'getVaultKeeps')
      }
    },
    async saveKeep({ commit, dispatch }, keepData) {
      try {
        debugger
        let vKeeps = {
          keepId: keepData.keepId.id,
          vaultId: keepData.vaultId.id,
        }
        let axiosRES = await api.post('', vKeeps);
        if (axiosRES) {
          commit("setVaultKeeps", vKeeps)
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