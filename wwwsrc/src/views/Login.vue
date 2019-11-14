<template>
    <div class="login">
        <router-link :to="{name: 'home'}">preview our site</router-link>
        <form v-if="loginForm" @submit.prevent="loginUser">
            <input type="email" v-model="creds.email" placeholder="email">
            <input type="password" v-model="creds.password" placeholder="password">
            <button type="submit">Login</button>
        </form>
        <form v-else @submit.prevent="register">
            <input type="text" v-model="newUser.username" placeholder="name">
            <input type="email" v-model="newUser.email" placeholder="email">
            <input type="password" v-model="newUser.password" placeholder="password">
            <button type="submit">Create Account</button>
        </form>
        <div @click="loginForm = !loginForm">
            <p v-if="loginForm">No account Click to Register</p>
            <p v-else>Already have an account click to Login</p>
        </div>
        <!-- <div class="card" style="width: 16rem;">
            <h5 class="card-title">{{keep.name}}</h5>
            <h3>views: {{keep.views}}</h3>
            <p class="card-text">{{keep.description}}</p>
        </div> -->
    </div>
</template>

<script>
    export default {
        name: "login",
        mounted() {
            // this.$store.dispatch("getKeeps");
            // this.$store.state.HomePage.keeps.forEach(keep => {
            //     let keepsId = keep.id
            //     this.$store.dispatch(keepsId)
            // })
        },
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };

        },
        computed: {
            keeps() {
                return this.$store.state.HomePage.keeps;
            }
        },
        components: {
        },
        beforeCreate() {
            if (this.$store.state.Auth.user._id) {
                // this.$router.push({ name: "home" })
            }
        },
        methods: {
            getKeeps() {


            },
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            }
        }
    };
</script>
<style>
    .Login {
        background-color: aquamarine;
    }
</style>