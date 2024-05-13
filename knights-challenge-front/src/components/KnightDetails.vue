<template>
    <div>
      <h2>Detalhes do Cavaleiro</h2>
      <div v-if="knight">
        <p><strong>Nome:</strong> {{ knight.name }}</p>
        <p><strong>Apelido:</strong> {{ knight.nickname }}</p>
        <p><strong>Aniversário:</strong> {{ knight.birthday }}</p>
      </div>
      <div v-else>
        <p>Cavaleiro não encontrado.</p>
      </div>
    </div>
  </template>
  
  <script>
  import api from '@/api.js';
  
  export default {
    data() {
      return {
        knight: null,
      };
    },
    async mounted() {
      const knightId = this.$route.params.id;
      try {
        const response = await api.get(`/knights/${knightId}`);
        this.knight = response.data;
      } catch (error) {
        console.error('Erro ao buscar detalhes do cavaleiro:', error);
      }
    },
  };
  </script>
  