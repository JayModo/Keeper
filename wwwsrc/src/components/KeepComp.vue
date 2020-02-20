<template>
  <div class="keeps container-fluid">
    <button v-on:click.once="getVaultsOption(vaults)">your Vaults</button>

    <div v-for="vault in vaults" :vaults="vault" :key="vault._id">
      <select v-on:click="saveKeep(vault)">
        <option>
          <ul v-on:click="saveKeep(vault)">{{vault.name}}</ul>
        </option>
      </select>
    </div>
  </div>
</template>


<script>
  export default {
    name: "keepComp",
    mounted() {

    },
    props: {
      // vaults: [],
      keep: {
        type: Object,
      }
    },
    data() {
      return {
        vaultProp: {},
        value: [],
        newVaultId: "",
        // newKeep: {
        //   description: ""
        // }
      };
    },
    computed: {
      // vault() {
      //   return this.$store.state.Vaults.activeVaults;
      // },
      user() {
        return this.$store.state.user;
      },
      vaults() {
        // this.$store.state.Vaults.vaults = this.vaults
        return this.$store.state.Vaults.vaults;
      },
      keeps() {
        return this.$store.state.HomePage.keeps;
      }
    },
    methods: {
      addToVault(vault) {
        debugger

      },

      getVaultsOption(vaults) {
        debugger
        this.$store.dispatch("getVaults", vaults);
        this.$store.state.Vaults.vaults = this.vaultProp
        // this.$emit('getVaultsOption', this.$store.state.Vaults.vaults)
        // vaults = this.vaultProp
        // this.$emit('getVaultsOption', this.vaultProp)
        this.vaultProp = []




      },
      // trying to get activeKeep and activeVault for vaultkeep
      saveKeep(vault) {
        debugger
        let vaultId = vault.id
        let keepData = {

          keepId: this.$store.dispatch("getKeepById", this.$route.params.keepId),
          vaultId,
          userId: { type: Number }
        };
        // this.$emit('saveKeep', keepData)
        this.$store.dispatch("saveKeep", keepData);
      },
      deleteKeep(keep) {
        this.$store.dispatch("deleteKeep", keep);
      }
    }
  };
</script>


<style scoped>

</style>