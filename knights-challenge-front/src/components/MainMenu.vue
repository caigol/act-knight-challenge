<template>
    <div>
      <nav>
        <ul>
          <a href="/knights"><router-link to="/knights">Lista de Cavaleiros</router-link></a>
          <a href="/add-knight"><router-link to="/add-knight">Adicionar Cavaleiro</router-link></a>
          <a href="/knight-details"><router-link to="/knight-details">Detalhes do Cavaleiro</router-link></a>
          <a href="/delete-knight"><router-link to="/delete-knight">Deletar Cavaleiro</router-link></a>
        </ul>
      </nav>
    </div>
  </template>
  
  <script>
  export default {
    // Se necessário, adicione lógica específica do menu aqui
  };
  </script>
  
  <style scoped>
  /* Estilos do menu */
  nav ul {
    list-style-type: none;
    padding: 0;
  }
  
  nav ul li {
    display: inline;
    margin-right: 10px;
  }
  
  nav ul li a {
    text-decoration: none;
    color: blue;
    cursor: pointer; /* Garante que o cursor mude ao passar sobre os links */
  }
  </style>
  