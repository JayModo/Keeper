<template>
  <div class="keeps container-fluid">
    <!-- <div class="row"> -->
    <!-- <div class="col-4">
        <button v-if="keep.userId == user.id" @click="deleteKeep(keep)" type="button" class="btn btn-danger">Delete
          Keep</button>
        <img class="keep-img" :src="keep.img" />
        <br />
        {{keep.name}}
        <br />
        {{keep.description}}
        <br /> -->
    <!-- <button type="button" class="btn btn-primary">View Keep</button> -->
    <!-- <select @change="saveKeep()" v-model="newVaultId">
      <option v-for="vault in vaults" :value="vault.id" :key="vault.id">{{vault.name}}</option>
    </select> -->

    <select v-on:click.once="getVaultsOption(vaults)" @change="saveKeep(vaults)">
      <option v-for="vault in vaults" :key="vault.id">

        <ul @click="saveKeep(vault)">{{vault.name}}</ul>
      </option>
    </select>

    <!-- </div>
  </div>
  <br /> -->
  </div>
</template>


<script>
  export default {
    name: "keepComp",
    // mounted() {
    //   this.$store.dispatch("getVaults");
    // },
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
      vault() {
        return this.$store.state.Vaults.activeVaults;
      },
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
      //  this.$store.dispatch("getVaults");
      // // this.$store.dispatch("getKeepsByVaultId", this.$route.params.id);
      // this.$store.state.Vaults.vaults.forEach(vaults => {
      //   let vaultsId = vaults.id
      //   this.$store.dispatch(vaultsId)
      getVaultsOption(vaults) {
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
        // let vaultId = this.vault.id

        let keepData = {

          keepId: this.$store.state.HomePage.keeps.id,
          vaultId: this.vaults.id,
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