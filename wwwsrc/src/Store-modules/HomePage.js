import router from "../router";
import AuthService from "../AuthService";
import Axios from "axios"
import Vue from "vue";
import { async } from "q";



const CONTROLLER_ROUTE = 'api/keeps'
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
    activeKeep: {},
    keep: {}
  },
  mutations: {

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
        let endPoint = `/${keepId}`;
        await api.delete(endPoint);
        dispatch('getKeeps')
      } catch (error) {

      }
    },


    async updateViews({ commit, dispatch, state }, keepsId) {

      try {
        debugger

        let endPoint = `/${keepsId.id}`
        let axiosRes = await api.put(endPoint);
        dispatch('setKeeps', axiosRes.data)
      } catch (error) {

      }
    },
    async getKeepById({ commit, dispatch }, keepsId) {
      try {
        debugger
        let axiosRes = await api.get(keepsId)
        commit('updateViews', axiosRes.data)
      } catch (error) {

      }
    },


    async getKeeps({ commit, dispatch, state }) {
      try {
        let axiosRes = await api.get("");
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
      let axiosRes = await api.post("", keepData);
      if (axiosRes) {
        dispatch("getKeeps");
      }
    },



  }
}