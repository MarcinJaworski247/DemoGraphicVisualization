import { getField, updateField } from "vuex-map-fields";
import service from "../service";

const namespaced = true;

const state = {
  populationChart: [],
};

const getters = {
  getField,
  getPopulationChartData: (state) => state.populationChart,
};

const mutations = {
  updateField,
  setPopulationChartData(state, payload) {
    state.populationChart = payload;
  },
};

const actions = {
  setPopulationChartData: ({ commit }, year) => {
    service.getPopulationDataToChart(year).then((response) => {
      commit("setPopulationChartData", response.data);
    });
  },
  setPopulationMapData: ({ commit }, year) => {
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
};

export default { state, getters, mutations, actions, namespaced };
