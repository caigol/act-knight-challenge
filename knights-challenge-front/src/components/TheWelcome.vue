<template>
  <div>
    <h1>Bem-vindo ao Sistema de Registro de Heróis</h1>
    <MainMenu />
  </div>
</template>

<script>
import MainMenu from '@/components/MainMenu.vue';

export default {
  components: {
    MainMenu,
  },
};
</script>

<style scoped>
/* Estilos do menu */
div {
  width: 300px;
height: 300px;
background: #fff;
}

</style>
