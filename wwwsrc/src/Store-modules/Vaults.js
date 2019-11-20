
import router from "../router";
import AuthService from "../AuthService";
import Axios from "axios"

import Vue from "vue";
import Auth from "./Auth";



const CONTROLLER_ROUTE = 'api/'
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
    activevault: {},
    vaults: [],
    vaultKeeps: [],
  },
  mutations: {
    setactiveVault(state, activevault) {
      debugger
      state.activevault = activevault
    },
    setKeepsByVaultId(state, vaultkeeps) {
      state.vaultkeeps = vaultkeeps;
    },
    setVaults(state, payload) {
      state.vaults = payload
    },
    setVaultKeeps(state, payload) {
      state.vaultKeeps = payload
    },
    setUserKeeps(state, payload) {
      state.userVaults = payload
    }
  },
  actions: {
    async getVaultById({ commit, dispatch }, payload) {
      try {
        debugger
        let endpoint = `vaults/${payload}`;
        let axiosRES = await api.get(endpoint)
        commit('setactiveVault', axiosRES.data)
      }
      catch (error) {
        console.error(error)
      }
    },
    async getKeepsByVaultId({ commit }, vaultId) {
      try {
        let endpoint = `vaults/${vaultId}`;
        let axiosRES = await api.get(endpoint);
        commit('setKeepsByVaultId', axiosRES.data);
      } catch (error) {
        console.error(error)

      }
    },
    async deleteVaults({ dispatch, state }, vaultsId) {
      try {
        debugger
        let vaultId = vaultsId.id
        let endPoint = `vaults/${vaultId}`;
        await api.delete(endPoint);
        dispatch('getVaults')
      } catch (error) {

      }
    },



    // async addVkeeps({ commit, dispatch }, keepsId) {
    //   try {
    //     debugger
    //     let axiosRes = await api.post(`/vaultkeeps`, keepsId)
    //     commit("setVaultKeeps", axiosRes.data)
    //   } catch (error) {
    //     console.error("vault store addkeeps() for vaults")
    //   }
    // },
    async getVkeeps({ commit, dispatch }, vaultId) {
      try {
        let endpoint = `${vaultId}/keeps`;
        let axiosRES = await api.get(endpoint);
        commit('setKeepsByVaultId', axiosRES.data);
      } catch (error) {
        console.error(error)

      }
    },

    async getVaults({ commit, dispatch, state }) {
      try {
        let axiosRes = await api.get("vaults");
        let vaults = axiosRes.data;
        commit("setVaults", vaults);
        state.vaults.forEach(vault => {
          let vaultsId = vaults._id
          dispatch(vaultsId)
        });
      } catch (error) {
        router.push("/vaults");
      }
    },
    async getUserVaults({ commit, dispatch }) {
      try {
        let axiosRes = await api.get(`/vaults`)
        commit('setVaults', axiosRes.data)
      } catch (error) {

      }
    },


    async addVaults({ commit, dispatch }, vaultData) {
      let axiosRes = await api.post("vaults", vaultData);
      if (axiosRes) {
        dispatch("getVaults");
      }
    },
  }
}