<template>
  <div class="keeps container-fluid">
    <button type="button" v-on:click.once="getVaultsOption(vaults, keepProp)"> your vaults </button>
    <div>
      <!-- value is being passed and a array of objects to saveKeep in methods -->
      <select v-on:change="saveKeep($event.target.value, keepProp)">
        <option v-for="vault in vaults" :value="vault" :vaults="vault" :key="vault._id">{{vault.name}}</option>
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
        value: {},
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
      saveKeep(value, keepProp) {
        debugger
        let vaultId = value
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
  .far {
    color: blue;
  }
</style>