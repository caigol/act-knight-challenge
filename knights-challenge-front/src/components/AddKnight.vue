<template>
    <div>
      <h2>Adicionar Cavaleiro</h2>
      <form @submit.prevent="addKnight">
        <label for="name">Nome:</label>
        <input type="text" id="name" v-model="newKnight.name" required>
        <label for="nickname">Apelido:</label>
        <input type="text" id="nickname" v-model="newKnight.nickname" required>
        <label for="birthday">Aniversário:</label>
        <input type="date" id="birthday" v-model="newKnight.birthday" required>
        <button type="submit">Adicionar Cavaleiro</button>
      </form>
    </div>
  </template>
  
  <script>
  import api from '@/api.js';
  
  export default {
    data() {
      return {
        newKnight: {
          name: '',
          nickname: '',
          birthday: '',
        },
      };
    },
    methods: {
      async addKnight() {
        try {
          await api.post('/knights', this.newKnight);
          alert('Cavaleiro adicionado com sucesso!');
          this.$router.push('/knights');
        } catch (error) {
          console.error('Erro ao adicionar cavaleiro:', error);
          alert('Erro ao adicionar cavaleiro. Verifique o console para mais detalhes.');
        }
      },
    },
  };
  </script>
  