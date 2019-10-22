<template>
  <div class="keepComp col-4 border rounded" @click="viewKeep()">
    <h5>{{keep.name}}</h5>
    <h5>{{keep.description}}</h5>
    <h5>{{keep.img}}</h5>
    <h5>{{keep.views}}</h5>
    <h5>{{keep.keep}}</h5>

  </div>
</template>


<script>
  export default {
    name: 'KeepComp',
    props: ["keep"],
    data() {
      return {}
    },
    props: {
    },
    computed: {},
    methods: {
      viewKeep() {

        this.$router.push({ name: "keepComp", params: { keepId: this.keepProp._id } })
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>