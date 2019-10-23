<template>
  <div class="vaults">
    <h1>{{user.username}}'s vault is secure</h1>
    <nav class="navbar shadow rounded navbar-light bg-light">
      <a class="navbar-brand" href="#">

        <button v-if="user.id" @click="logout">logout</button>
        <router-link v-else :to="{name: 'login'}">Login</router-link>
      </a>
    </nav>
    <form @submit.prevent="addVaults">
      <input type="text" placeholder="title" v-model="newVault.name" required>
      <input type="text" placeholder="description" v-model="newVault.description">
      <button class="btn btn-primary" type="submit">Create</button>
    </form>
    <div v-for="vault in vaults" :vaults="vault" :key="vaults.id">
      <div class="card" style="width: 16rem;">
        <h5 class="card-title">{{vault.name}}</h5>
        <p class="card-text">{{vault.description}}</p>

      </div>

    </div>

  </div>
</template>


<script>
  export default {
    name: 'vaults',
    mounted() {
      this.$store.dispatch("getVaults");
      this.$store.state.Vaults.vaults.forEach(vaults => {
        let VaultsId = vaults.id
        this.$store.dispatch(VaultsId)
      });
    },
    data() {
      return {
        newVault: {
          name: "",
          description: "",
        }
      }
    },
    computed: {
      user() {
        return this.$store.state.Auth.user;
      },
      vaults() {
        return this.$store.state.Vaults.vaults;
      },

    },
    methods: {
      addVaults() {
        this.$store.dispatch("addVaults", this.newVault);
        this.newVault = { name: "", description: "" }
      },
      logout() {
        this.$store.dispatch("logout");
      }

    },
    components: {

    }
  }
</script>


<style scoped>

</style>