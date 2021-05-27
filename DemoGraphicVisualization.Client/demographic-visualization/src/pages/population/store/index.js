import { getField, updateField } from "vuex-map-fields";
import service from "../service";

const namespaced = true;

const state = {
  populationChart: [],
  populationTreeMap: [],
  populationGraph: null,
};

const getters = {
  getField,
  getPopulationChartData: (state) => state.populationChart,
  getPopulationTreeMapData: (state) => state.populationTreeMap,
  getPopulationGraphData: (state) => state.populationGraph,
};

const mutations = {
  updateField,
  SET_POPULATION_CHART_DATA: (state, payload) => {
    state.populationChart = payload;
  },
  SET_POPULATION_TREEMAP_DATA: (state, payload) => {
    state.populationTreeMap = payload;
  },
  SET_POPULATION_GRAPH_DATA: (state, payload) => {
    state.populationGraph = payload;
  },
};

const actions = {
  setPopulationChartData: async ({ commit }, year) => {
    await service.getPopulationDataToChart(year).then((response) => {
      commit("SET_POPULATION_CHART_DATA", response.data);
    });
  },
  setPopulationMapData: async ({ commit }, year) => {
    return new Promise((resolve, reject) => {
      service.getPopulationDataToMap(year).then(
        (response) => {
          resolve(response);
        },
        (error) => {
          reject(error);
        }
      );
    });
  },
  setPopulationTreeMapData: async ({ commit }, year) => {
    await service.getPopulationTreeMapData(year).then((response) => {
      commit("SET_POPULATION_TREEMAP_DATA", response.data);
    });
  },
  setPopulationGraphData: async ({ commit }, year) => {
    await service.getPopulationGraphData(year).then((response) => {
      commit("SET_POPULATION_GRAPH_DATA", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced };
