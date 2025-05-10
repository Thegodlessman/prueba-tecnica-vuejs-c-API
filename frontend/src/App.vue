<template>
  <div id="app">
    <UsersTable />
    </div>
</template>

<script>
import UsersTable from './components/usersTable.vue';

export default {
  name: 'App',
  components: {
    UsersTable
  }
};
</script>

<style>
/* Estilos globales */
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>