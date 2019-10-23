<template>
  <div class="home">
    <link href="//netdna.bootstrapcdn.com/font-awesome/3.2.1/css/font-awesome.css" rel="stylesheet">
    <h1>Peep the Keeps {{user.username}}</h1>
    <nav class="navbar shadow rounded navbar-light bg-light">
      <a class="navbar-brand" href="#">

        <button class="btn btn-danger" v-if="user.id" @click="logout">logout</button>
        <router-link v-else :to="{name: 'login'}">Login</router-link>
        <router-link to="/vaults">Vault</router-link>
        <!-- <vaults v-for="vault in vaults" :key="vaults._id" :vaults="vaults" /> -->

      </a>
    </nav>
    <form @submit.prevent="addKeeps">
      <input type="text" placeholder="title" v-model="newKeep.name" required>
      <input type="text" placeholder="description" v-model="newKeep.description">
      <input type="url" placeholder="img" v-model="newKeep.img">
      <button class="btn btn-primary" type="submit">Create</button>
    </form>
    <div v-for="keep in keeps" :keeps="keep" :key="keeps.id">

      <!-- <keepComp v-for="keep in keeps" :keepProp="keep" :key="keep._id" /> -->
      <div class="card" style="width: 16rem;">
        <h4 v-on:click="keep.views += 1">Views {{keep.views}}</h4>
        <h4>Keep </h4>
        <h5 class="card-title">{{keep.name}}</h5>
        <p class="card-text">{{keep.description}}</p>
        <button></i>Keep It</button>
        <img data-toggle="modal" :src="keep.img" />

      </div>
    </div>







  </div>
</template>

<script>
  // import keepComp from "../components/KeepComp";
  export default {
    name: "home",
    mounted() {
      this.$store.dispatch("getKeeps");
      this.$store.state.HomePage.keeps.forEach(keeps => {
        let keepsId = keeps.id
        this.$store.dispatch(keepsId)
      });
    },
    data() {
      return {
        newKeep: {
          name: "",
          description: "",
          img: "",
          views: Number,
          keep: Boolean,
        }
      }
    },
    components: {
    },
    computed: {
      views() {
        return this.$store.state.HomePage.keeps;
      },
      keeps() {
        return this.$store.state.HomePage.keeps;
      },
      user() {
        return this.$store.state.Auth.user;
      }
    },
    methods: {
      viewKeeps() {
        this.$store.dispatch("keepView");
      },
      deleteKeeps() {

      },
      takeKeep() {
        this.$store.dispatch("takeKeep")
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