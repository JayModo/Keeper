<template>
  <div class="home">
    <h1>Welcome Home {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>
    <form @submit.prevent="addKeeps">
      <input type="text" placeholder="title" v-model="newKeep.name" required>
      <input type="text" placeholder="description" v-model="newKeep.description">
      <input type="url" placeholder="img" v-model="newKeep.img">
      <button class="btn btn-primary" type="submit">Create</button>
    </form>

    <div v-for="keep in keeps" :keeps="keeps" :key="keeps.id">
      <h4>{{keep.Name}}</h4>
    </div>







  </div>
</template>

<script>
  export default {
    name: "home",
    mounted() {
      this.$store.dispatch("getKeeps");
      this.$store.state.HomePage.keeps.forEach(keep => {
        let keepsId = keeps.id
        this.$store.dispatch(keepId)
      });
    },
    data() {
      return {
        newKeep: {
          name: "",
          description: "",
          img: ""
        }
      }
    },
    computed: {
      keeps() {
        return this.$store.state.HomePage.keeps;
      },
      user() {
        return this.$store.state.Auth.user;
      }
    },
    methods: {
      addKeeps() {
        this.$store.dispatch("addKeeps", this.newKeep);
        this.newKeep = { name: "", description: "", img: "" }
      },

      logout() {
        this.$store.dispatch("logout");
      }
    }
  };
</script>