<template>
  <div class="home">


    <link href="//netdna.bootstrapcdn.com/font-awesome/3.2.1/css/font-awesome.css" rel="stylesheet">
    <h1>Peep the Keeps {{user.username}}</h1>
    <nav class="navbar shadow rounded navbar-light bg-light">
      <a class="navbar-brand" href="#">

        <button class="btn btn-danger" v-if="user.id" @click="logout">logout</button>
        <router-link v-else :to="{name: 'login'}">Login</router-link>
        <router-link v-if="user.id!=null" to="/vaults">Vault</router-link>
      </a>
    </nav>


    <form v-if="user.id!=null" @submit.prevent="addKeeps">
      <input type="text" placeholder="title" v-model="newKeep.name" required>
      <input type="text" placeholder="description" v-model="newKeep.description">
      <input type="url" placeholder="img" v-model="newKeep.img">
      <button class="btn btn-primary" type="submit">Create</button>
    </form>



    <div class="col">


      <div v-for="keep in keeps" :keeps="keep" :key="keeps.id">

        <div class="card" style="width: 16rem;">
          <h5 class="card-title">{{keep.name}}</h5>
          <h3>views: {{keep.views}}</h3>
          <p class="card-text">{{keep.description}}</p>
          <button v-if="user.id!=null" type="button" class=" m-1 btn btn-outline-light btn-sm"
            @click="deleteKeeps(keep)">delete</button>




          <keepComp v-on:getVaultsOption="showVaults(value)" v-bind:keepProp="keep" />

          <img class="btn" @click="openModal(keep)" :src="keep.img">
        </div>
        <modal-view v-if="modalOpen" v-model="modalOpen" onclick.prevent="modalKeep">
          <img :src="keep.description" alt="">
          <h4 v-on:click="">Views {{keep.views}}</h4>
          <h5 class="card-title">{{keep.name}}</h5>
          <p>{{keep.description}}</p>

        </modal-view>
      </div>

    </div>


  </div>
  </div>
</template>

<script>
  import KeepComp from '../components/KeepComp'
  import vaultKeeps from '../components/VaultKeeps.vue'
  import Vaults from './Vaults.vue'
  import ModalView from './ModalView.vue'
  export default {
    name: "home",

    props: {
      keep: { type: Object },

    },
    mounted() {
      this.$store.dispatch("getKeeps");
      this.$store.state.HomePage.keeps.forEach(keep => {
        let keepsId = keep.id
        this.$store.dispatch(keepsId)

      });
    },

    data() {
      return {
        vault: [{}],
        selected: '',
        modalKeep: {
          Keep: { type: Object },
        },
        modalOpen: false,
        newKeep: {
          name: "",
          description: "",
          img: "",
          views: Number,
          isPrivate: Boolean,
          keep: Boolean,
        },
        keepProp: [this.keeps],
      }
    },
    components: {
      Vaults,
      ModalView,
      vaultKeeps,
      KeepComp

    },
    computed: {
      vaults() {
        return this.$store.state.Vaults.vaults;

      },

      isPrivate() {
        if (user.keeps.isPrivate != true) {
          return this.$store.state.HomePage.keeps
        }
      },

      views() {
        return this.$store.state.HomePage.keep;
      },

      keeps() {
        return this.$store.state.HomePage.keeps;
      },
      user() {
        return this.$store.state.Auth.user;
      }
    },
    methods: {
      showVaults(vault) {
        this.vault.push(vault)
      },


      getVaultsOption(vaults) {
        this.vaults == vaults
        this.$store.state.Vaults.vaults == vaults
        return vaults
      },
      AddToVault(keepsId) {
        this.$store.Vaults.dispatch(keepsId)
      },
      handleViews(views) {

      },
      openModal(keepsId) {
        this.modalOpen = !this.modalOpen;
        keepsId.views += 1
        this.$store.dispatch("updateViews", keepsId)

      },

      viewKeeps() {
        this.$store.dispatch("updateViews", keepsId)
      },
      deleteKeeps(keepsId) {
        if (keepsId.userId != this.user.id) {
          return alert("this is not yours to delete")
        }
        this.$store.dispatch("deleteKeeps", keepsId);
      },
      addKeeps() {
        this.$store.dispatch("addKeeps", this.newKeep);
        this.newKeep = { name: "", description: "", img: "" }
      },

      logout() {
        this.$store.dispatch("logout");

      },
    }
  };
</script>
<style>

</style>