<template>
  <div class="vault" v-if="vaultkeeps">
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
    name: 'vault',
    props: ["propvault"],
    data() {
      return {}
    },
    computed: {},
    methods: {
      viewVault() {
        debugger
        this.$router.push({
          name: "Vault",
          params: { id: this.propvault.id }
        });
      },
      activeVault() {
        return this.$store.Vaults.activeVault;
      },
      vaultKeeps(keeps) {
        return this.$store.Vaults.vaultKeeps;
      },
    },
    async mounted() {
      await this.$store.dispatch("getVaultById", this.$route.params.id);
      this.$store.dispatch("getKeepsByVaultId", this.$route.params.id);
    },
    components: {}
  }
</script>


<style scoped>

</style>