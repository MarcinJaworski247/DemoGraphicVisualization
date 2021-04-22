import Vue from "vue";
import Vuex from "vuex";

import PopulationStore from "./pages/population/store";
import MigrationStore from "./pages/migration/store";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    PopulationStore,
    MigrationStore,
  },
});
