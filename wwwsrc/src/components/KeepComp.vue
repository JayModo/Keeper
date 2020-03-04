<template>
  <div class="keeps container-fluid">
    <button v-on:click.once="getVaultsOption(vaults, keepProp)">your Vaults</button>

    <div v-for="vault in vaults" :vaults="vault" :key="vault._id">
      <select v-on:click="saveKeep(vault, keepProp)">
        <option>
          <ul v-on:click="saveKeep(vault)">{{vault.name}}</ul>
        </option>
      </select>
    </div>
  </div>
</template>


<script>
  import Home from '../views/Home.vue'
  export default {
    name: "keepComp",
    mounted() {

    },
    props: {
      keepProp: {},
      // keeps: {
      //   id: Number,
      //   type: Object,
      // }
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
      user() {
        return this.$store.state.Auth.user;
      },
      vaults() {
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
        this.$store.dispatch("getVaults", vaults);
        this.$store.state.Vaults.vaults = this.vaultProp
        this.vaultProp = []
      },
      // trying to get activeKeep and activeVault for vaultkeep
      saveKeep(vault, keepProp) {
        debugger
        let vaultId = vault
        let keepData = {
          keepId: this.keepProp,
          vaultId,
          // userId: this.user.id
        };
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