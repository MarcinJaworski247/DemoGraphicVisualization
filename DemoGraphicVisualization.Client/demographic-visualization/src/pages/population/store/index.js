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
  getPopulationTreeMapData: (state) => {
    return state.populationTreeMap;
  },
  getPopulationGraphData: (state) => {
    return state.populationGraph;
  },
};

const mutations = {
  updateField,
  setPopulationChartData: (state, payload) => {
    state.populationChart = payload;
  },
  setPopulationTreeMapData: (state, payload) => {
    state.populationTreeMap = payload;
  },
  setPopulationGraphData: (state, payload) => {
    state.populationGraph = payload;
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
  setPopulationTreeMapData: ({ commit }, year) => {
    service.getPopulationTreeMapData(year).then((response) => {
      commit("setPopulationTreeMapData", response.data);
    });
  },
  setPopulationGraphData: ({ commit }, year) => {
    service.getPopulationGraphData(year).then((response) => {
      commit("setPopulationGraphData", response.data);
    });
    // return new Promise((resolve, reject) => {
    //   service.getPopulationGraphData(year).then(
    //     (response) => {
    //       resolve(response);
    //     },
    //     (error) => {
    //       reject(error);
    //     }
    //   );
    // });
  },
};

export default { state, getters, mutations, actions, namespaced };
