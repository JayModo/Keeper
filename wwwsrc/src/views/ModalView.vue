<template>
  <div class="modal-view" v-show="value">
    <div class="container">
      <div class="modal-content">
        <slot>

        </slot>
      </div>
    </div>
    <button @click.prevent="cancel" class="mt-3 border-b border-teal font-semibold">Close</button>
  </div>
</template>


<script>
  import Home from '../views/Home'
  export default {
    props: {

      value: {},
    },
    name: 'modal-view',
    data() {
      return {
        openModal: true
      }
    },


    components: {
    },
    computed: {},
    methods: {


      cancel() {
        this.$emit("input", !this.value)
        // this.closeCallBack()
      }
    },
    mounted() {
      this.isVisible = this.showModal
    }
  }
</script>


<style scoped>
  .modal {
    display: flex;
    justify-content: center;
    align-content: center;
    align-items: center;
    position: fixed;
    width: 100vw;
    height: 100vh;
    left: 0px;
    top: 0px;
    background-color: rgba(0, 0, 0, 0.356);
  }

  .modal-body {
    z-index: 100;
    padding: 23px;
    border-radius: 15px;
    background-color: rgb(230, 230, 230);
    box-shadow: 4px 4px 23px rgb(51, 51, 51);
  }
</style>