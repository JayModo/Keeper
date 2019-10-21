import router from "../router";
import AuthService from "../AuthService";
import Axios from "axios"
import Vue from "vue";



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
    keeps: []
  },
  mutations: {
    setKeeps(state, payload) {
      state.keep = payload
    }
  },
  actions: {
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


    async generic({ commit }, value) {
      try {
        let endPoint = `${value}`
        let axiosResponse = await api.get(endPoint)
        let data = axiosResponse.data

        commit('generic', data)
      } catch (error) {
        console.error('template.js actions: generic()')
      }
    }
  }
}