import Vue from "vue";
import Router from "vue-router";
// population
import PopulationChart from "./pages/population/views/IndexChart.vue";
import PopulationMap from "./pages/population/views/IndexMap.vue";

// migration
import MigrationChart from "./pages/migration/views/IndexChart.vue";
import MigrationMap from "./pages/migration/views/IndexMap.vue";
import NationMigrationChart from "./pages/migration/views/IndexNationChart";

Vue.use(Router);

const allRoutes = [
  {
    path: "/population/chart",
    name: "population.chart.index",
    component: PopulationChart,
  },
  {
    path: "/population/map",
    name: "population.map.index",
    component: PopulationMap,
  },
  {
    path: "/migration/chart",
    name: "migration.chart.index",
    component: MigrationChart,
  },
  {
    path: "/migration/map",
    name: "migration.map.index",
    component: MigrationMap,
  },
  {
    path: "/migration/nationChart",
    name: "migration.nationChart.index",
    component: NationMigrationChart,
  },
];

// const redirectToHome = [
//   {
//     path: "/",
//     redirect: { name: "home.index" },
//   },
// ];

export default new Router({
  mode: "history",
  routes: allRoutes,
});
