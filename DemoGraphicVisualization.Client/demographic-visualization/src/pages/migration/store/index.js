import { getField, updateField } from "vuex-map-fields";
import service from "../service";

const namespaced = true;

const state = {
  migrationChart: [],
  nationsLookup: [],
  nationMigrationChart: [],
  param: {
    SelectedNations: [],
    Year: "",
  },
  assaults: [],
  healthyLife: [],
  migrationAverages: [],
};

const getters = {
  getField,
  getMigrationChartData: (state) => state.migrationChart,
  getNationMigrationChartData: (state) => {
    return state.nationMigrationChart;
  },
  getNationsToLookup: (state) => {
    return state.nationsLookup;
  },
  getAssaultsChartData: (state) => state.assaults,
  getHealthyLifeChartData: (state) => state.healthyLife,
  getMigrationAveragesData: (state) => state.migrationAverages,
};

const mutations = {
  updateField,
  setMigrationChartData(state, payload) {
    state.migrationChart = payload;
  },
  setNationMigrationChartData(state, payload) {
    state.nationMigrationChart = payload;
  },
  setNationsToLookup(state, payload) {
    state.nationsLookup = payload;
  },
  setAssaultsChartData(state, payload) {
    state.assaults = payload;
  },
  setHealthyLifeChartData(state, payload) {
    state.healthyLife = payload;
  },
  setMigrationAveragesData(state, payload) {
    state.migrationAverages = payload;
  },
};

const actions = {
  setMigrationChartData: ({ commit, state }) => {
    service.getMigrationDataToChart(state.param).then((response) => {
      commit("setMigrationChartData", response.data);
    });
  },
  setMigrationDataToMap: ({ commit }, year) => {
    return new Promise((resolve, reject) => {
      service.getMigrationDataToMap(year).then(
        (response) => {
          resolve(response);
        },
        (error) => {
          reject(error);
        }
      );
    });
  },
  setNationMigrationChartData: ({ commit }, args) => {
    service.getNationMigrationDataToChart(args[0], args[1]).then((response) => {
      commit("setNationMigrationChartData", response.data);
    });
  },
  setNationsToLookup: ({ commit }) => {
    service.getNationsToLookup().then((response) => {
      commit("setNationsToLookup", response.data);
    });
  },
  setAssaultsChartData: ({ commit }, nation) => {
    service.getAssaultsDataToChart(nation).then((response) => {
      commit("setAssaultsChartData", response.data);
    });
  },
  setHealthyLifeChartData: ({ commit }, nation) => {
    service.getHealthyLifeDataToChart(nation).then((response) => {
      commit("setHealthyLifeChartData", response.data);
    });
  },
  setMigrationAveragesData: ({ commit }, migrationType) => {
    service.getMigrationAveragesData(migrationType).then((response) => {
      commit("setMigrationAveragesData", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced };
