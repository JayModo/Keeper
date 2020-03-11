<template>
  <div class="vaultsview">

    <h1 v-model="activevault">{{activeVault.name}}</h1>
    <nav class="navbar shadow rounded navbar-light bg-light">
      <a class="navbar-brand" href="#">
        <router-link to="/">keeps</router-link>
        <button v-if="user.id" @click="logout">logout</button>
        <router-link v-else :to="{name: 'login'}">Login</router-link>
      </a>
    </nav>
    <div v-for="vaultKeep in vaultKeeps" :vaultKeeps="vaultKeep" :key="vaultKeeps.id">
      <div>
        <h3>{{vaultKeep.name}}</h3>
        {{vaultKeep.id}}
        <img class="vaultKeep-img" :src="vaultKeep.img" alt />
        <h4>{{vaultKeep.description}}</h4>

        <button type="button" class="text-white m-1 btn btn-outline-light btn-sm"
          @click="deleteVk(vaultKeep, activeVault)">delete</button>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'vaultsview',
    props: ["propvault"],
    data() {
      return {
        activevault: {},
        vaultkeeps: [],
        vaultkeep: {}
      }
    },
    computed: {
      vaultKeep() {
        return this.$store.state.VaultKeeps.vaultkeep
      },

      activeVault() {
        return this.$store.state.Vaults.activevault;
      },
      vaultKeeps() {
        return this.$store.state.VaultKeeps.vaultkeeps;
      },
      user() {
        return this.$store.state.Auth.user;
      },
    },
    methods: {
      deleteVk(vaultKeep, activeVault) {

        this.vaultKeep
        let vkId = this.$store.state.VaultKeeps.vaultkeep.id
        let keepId = vaultKeep.id,
          vaultId = this.activeVault.id
        let vkData = {

          keepId,
          vaultId,
        };
        this.$store.dispatch("deleteVaultKeep", vkData)
      },
      viewVault() {

        this.$router.push({
          name: "Vault",
          params: { id: this.propvault.id }
        });
      },
      logout() {
        this.$store.dispatch("logout");
      }
    },
    async mounted(activeVault) {

      await this.$store.dispatch("getVaultById", this.$route.params.id);
      this.$store.dispatch("getVaultKeeps", this.$route.params.id);
    },
    components: {}
  }
</script>


<style scoped>

</style>