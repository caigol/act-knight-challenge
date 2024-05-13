<template>
    <div>
      <h2>Deletar Cavaleiro</h2>
      <button @click="deleteKnight">Deletar Cavaleiro</button>
    </div>
  </template>
  
  <script>
  import api from '@/api.js';
  
  export default {
    methods: {
      async deleteKnight() {
        const knightId = this.$route.params.id;
        if (confirm('Tem certeza de que deseja deletar este cavaleiro?')) {
          try {
            await api.delete(`/knights/${knightId}`);
            alert('Cavaleiro deletado com sucesso!');
            this.$router.push('/knights');
          } catch (error) {
            console.error('Erro ao deletar cavaleiro:', error);
            alert('Erro ao deletar cavaleiro. Verifique o console para mais detalhes.');
          }
        }
      },
    },
  };
  </script>
  