<template>
  <div class="vaults">
    <h1>{{user.username}}'s vault is secure</h1>
    <nav class="navbar shadow rounded navbar-light bg-light">
      <a class="navbar-brand" href="#">
        <router-link to="/">keeps</router-link>
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
        <button type="button" class="text-white m-1 btn btn-outline-light btn-sm"
          @click="deleteVaults(vault)">delete</button>
        <h5 class="card-title" @click="addVKeeps(vault.id)">{{vault.name}}</h5>
        <p class="card-text">{{vault.description}}</p>
        <button type="button" @click="viewVault(vault)" class="btn btn-secondary">View Vault</button>

      </div>

    </div>

  </div>
</template>


<script>
  import vaultKeeps from '../components/VaultKeeps.vue'
  export default {
    name: 'vaults',
    props: ['vaultprop'],
    mounted() {
      this.$store.dispatch("getVaults");
      // this.$store.dispatch("getKeepsByVaultId", this.$route.params.id);
      this.$store.state.Vaults.vaults.forEach(vaults => {
        let vaultsId = vaults.id
        this.$store.dispatch(vaultsId)
      });
    },
    data() {
      return {
        newVault: {
          name: "",
          description: "",
          vaultKeeps: []
        }
      }
    },
    computed: {
      // activeVault() {
      //   debugger
      //   return this.$store.state.Vaults.activevault;
      // },
      vaultKeeps() {
        return this.$store.state.Vaults.activevault;
      },
      keeps(keepProp) {
        return this.$store.state.HomePage.keeps;
      },

      user() {
        return this.$store.state.Auth.user;
      },
      vaults(vaultsId) {
        debugger
        if (vaultsId.userId != this.user.id) {

        }
        return this.$store.state.Vaults.vaults;
      },

    },
    methods: {
      viewVault(vault) {
        debugger
        this.$router.push({
          name: "VaultsView",
          params: { id: vault.id }
        });
      },
      deleteVaults(vaultsId) {
        debugger
        if (vaultsId.userId != this.user.id) {
          // return alert("this is not yours to delete")
        }
        this.$store.dispatch("deleteVaults", vaultsId);
      },

      addVKeeps(vaultsId) {
        debugger
        this.$store.dispatch("addVKeeps", vaultsId)
      },

      addVaults() {
        this.$store.dispatch("addVaults", this.newVault);
        this.newVault = { name: "", description: "" }
      },
      logout() {
        this.$store.dispatch("logout");
      }

    },
    components: {
      // VaultKeeps
    }
  }
</script>


<style scoped>

</style>