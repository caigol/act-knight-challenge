import KnightsList from '../src/components/KnightsList.vue';
import AddKnight from '../src/components/AddKnight.vue';
import KnightDetails from '../src/components/KnightDetails.vue';
import DeleteKnight from '../src/components/DeleteKnight.vue';

const routes = [
  { path: '/knights', component: KnightsList },
  { path: '/add-knight', component: AddKnight },
  { path: '/knight-details', component: KnightDetails },
  { path: '/delete-knight', component: DeleteKnight },
];

export default routes;