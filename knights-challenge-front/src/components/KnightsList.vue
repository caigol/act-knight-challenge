<template>
    <div>
      <h2>Lista de Cavaleiros</h2>
      <ul>
        <li v-for="knight in knights" :key="knight.id">{{ knight.name }}</li>
      </ul>
    </div>
  </template>
  
  <script>
  import api from '@/api.js';
  import axios from 'axios';

  export default {
    data() {
      return {
        knights: [],
      };
    },
    mounted() {
      this.fetchKnights();
    },
    methods: {
      async fetchKnights() {
        try {
          const response =  await axios
      .get('https://localhost:44345/Knights')
      .then(response => (this.info = response))
          this.knights = response.data;
        } catch (error) {
          console.error('Erro ao buscar cavaleiros:', error);
        }
      },
    },
  };
  </script>
  