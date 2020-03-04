import router from "../router";
import AuthService from "../AuthService";
import Axios from "axios"
import Vue from "vue";
import { async } from "q";



const CONTROLLER_ROUTE = 'api/'
// EXAMPLE: const CONTROLLER_ROUTE = 'api/cars'


let base = window.location.host.includes("localhost:8080")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: base + CONTROLLER_ROUTE,
  timeout: 3000,
  withCredentials: true
});

export default {
  state: {
    keeps: [],
    vaults: [],
    activeKeep: {},
    keep: {}
  },
  mutations: {
    setVaults(state, payload) {
      state.vaults = payload
    },
    setActiveKeep(state, payload) {
      state.activeKeep = payload
    },
    setKeeps(state, payload) {
      state.keeps = payload
    },
    setKeep(state, payload) {
      debugger
      state.keep = payload
    }
  },
  actions: {
    async deleteKeeps({ dispatch, state }, keepsId) {
      try {
        debugger
        let keepId = keepsId.id
        let endPoint = `keeps/${keepId}`;
        await api.delete(endPoint);
        dispatch('getKeeps')
      } catch (error) {

      }
    },


    async updateViews({ commit, dispatch, state }, keepsId) {

      try {
        debugger

        let endPoint = `keeps/${keepsId.id}`
        let axiosRes = await api.put(endPoint);
        dispatch('setKeeps', axiosRes.data)
      } catch (error) {

      }
    },
    async getKeepById({ commit, dispatch }, keepId) {
      try {
        debugger
        let keep = keepId.id
        let endPoint = `keeps/${keep}`;
        let axiosRes = await api.get(endPoint)
        commit('updateViews', axiosRes.data)
      } catch (error) {

      }
    },


    async getKeeps({ commit, dispatch, state }) {
      try {
        let axiosRes = await api.get("keeps");
        let keeps = axiosRes.data;
        commit("setKeeps", keeps);
        state.keeps.forEach(keep => {
          let keepId = keep._id
          dispatch(keepId)
        })
      } catch (error) {
        router.push("/");
      }
    },


    async addKeeps({ commit, dispatch }, keepData) {
      let axiosRes = await api.post("keeps", keepData);
      if (axiosRes) {
        dispatch("getKeeps");
      }
    },



  }
}