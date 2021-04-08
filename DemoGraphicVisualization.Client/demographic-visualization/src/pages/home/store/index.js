import { getField, updateField } from "vuex-map-fields";
import service from "../service";

const namespaced = true;

const state = {
  populationChart: [],
  populationMap: [],
};

const getters = {
  getField,
  getPopulationChartData: (state) => state.populationChart,
  getPopulationMapData: (state) => state.populationMap,
};

const mutations = {
  updateField,
  setPopulationChartData(state, payload) {
    state.populationChart = payload;
  },
  setPopulationMapData(state, payload) {
    state.populationMap = payload;
  },
};

const actions = {
  setPopulationChartData: ({ commit }) => {
    service.getPopulationDataToChart().then((response) => {
      commit("setPopulationChartData", response.data);
    });
  },
  setPopulationMapData: ({ commit }) => {
    service.getPopulationDataToMap().then((response) => {
      commit("setPopulationMapData", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced };
