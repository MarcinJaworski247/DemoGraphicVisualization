import Vue from "vue";
import Router from "vue-router";
import PopulationChart from "./pages/population/views/IndexChart.vue";
import PopulationMap from "./pages/population/views/IndexMap.vue";

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
  }
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
