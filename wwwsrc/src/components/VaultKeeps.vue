<template>
  <div class="vaultkeeps">
    <div class="row">{{vaultkeeps.name}}
    </div>

  </div>
</template>


<script>
  export default {
    name: 'vaultkeeps',
    props: {
      vaulrkeep: {
        type: Object,
        required: true
      }
    },

    data() {
      return {

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
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>