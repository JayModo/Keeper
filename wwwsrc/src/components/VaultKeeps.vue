<template>
  <div class="vault-keeps" id="vKeeps">
    <select v-model="selected" v-if="user.id!=null">
      <option value="vaults.name" v-for="vault in vaults" :key="vaults" :vaults="vaults" @click="addToVault(keep)">
        {{vaults}}
      </option>
    </select>
    <span>Selected: {{selected}}</span>
    <div class="row">{{vaultkeeps.name}}</div>

  </div>
</template>


<script>
  export default {
    name: 'vaultkeeps',
    props: {
      vaultkeep: {
        type: Object,
      }
    },

    data() {
      return {
        selected: ''
      }
    },
    computed: {
      vaults() {
        return this.$store.state.Vaults.vaults;
      },
      keeps() {
        return this.$store.state.HomePage.keeps;
      },
      userVaults() {
        return this.$store.Vaults.state.userVaults
      }
    },
    methods: {

    },
    components: {

    }
  }
</script>


<style scoped>

</style>