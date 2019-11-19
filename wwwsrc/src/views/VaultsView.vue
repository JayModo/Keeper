<template>
  <div class="vaultsview" v-if="vaultkeeps">
    <h1>{{activevault.name}}</h1>
    <nav class="navbar shadow rounded navbar-light bg-light">
      <a class="navbar-brand" href="#">
        <router-link to="/">keeps</router-link>
        <button v-if="user.id" @click="logout">logout</button>
        <router-link v-else :to="{name: 'login'}">Login</router-link>
      </a>
    </nav>
    <h1>{{activevault.name}}</h1>
    <div v-for="keep in vaultkeeps" :key="'vault-keep-'+keep.id">
      <h3>{{keep.name}}</h3>
      <img class="keep-img" :src="keep.img" alt />
      <h4>{{keep.description}}</h4>
      <div>keep count: {{keep.keeps}}</div>
      <div>keep views: {{keep.views}}</div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'activevault',
    props: ["propvault"],
    data() {
      return {
        activevault: {},
        vaultkeeps: []
      }
    },
    computed: {
      activeVault() {
        debugger
        return this.$store.state.Vaults.activevault;
      },
      vaultKeeps() {
        return this.$store.vaultKeeps.vaultkeeps;
      },
      user() {
        return this.$store.state.Auth.user;
      },
    },
    methods: {
      viewVault() {
        debugger
        this.$router.push({
          name: "Vault",
          params: { id: this.propvault.id }
        });
      },
      logout() {
        this.$store.dispatch("logout");
      }
    },
    async mounted() {
      debugger
      await this.$store.dispatch("getVaultById", this.$route.params.id);
      this.$store.dispatch("getKeepsByVaultId", this.$route.params.id);
    },
    components: {}
  }
</script>


<style scoped>

</style>