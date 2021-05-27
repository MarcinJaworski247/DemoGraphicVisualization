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
  getNationMigrationChartData: (state) => state.nationMigrationChart,
  getNationsToLookup: (state) => state.nationsLookup,
  getAssaultsChartData: (state) => state.assaults,
  getHealthyLifeChartData: (state) => state.healthyLife,
  getMigrationAveragesData: (state) => state.migrationAverages,
};

const mutations = {
  updateField,
  SET_MIGRATION_CHART_DATA(state, payload) {
    state.migrationChart = payload;
  },
  SET_NATION_MIGRATION_CHART_DATA(state, payload) {
    state.nationMigrationChart = payload;
  },
  SET_NATIONS_TO_LOOKUP(state, payload) {
    state.nationsLookup = payload;
  },
  SET_ASSAULTS_CHART_DATA(state, payload) {
    state.assaults = payload;
  },
  SET_HEALTHY_LIFE_CHART_DATA(state, payload) {
    state.healthyLife = payload;
  },
  SET_MIGRAITON_AVERAGES_DATA(state, payload) {
    state.migrationAverages = payload;
  },
};

const actions = {
  setMigrationChartData: ({ commit, state }) => {
    service.getMigrationDataToChart(state.param).then((response) => {
      commit("SET_MIGRATION_CHART_DATA", response.data);
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
  setNationMigrationChartData: async ({ commit }, args) => {
    await service.getNationMigrationDataToChart(args[0], args[1]).then((response) => {
      commit("SET_NATION_MIGRATION_CHART_DATA", response.data);
    });
  },
  setNationsToLookup: async ({ commit }) => {
    await service.getNationsToLookup().then((response) => {
      commit("SET_NATIONS_TO_LOOKUP", response.data);
    });
  },
  setAssaultsChartData: async ({ commit }, nation) => {
    await service.getAssaultsDataToChart(nation).then((response) => {
      commit("SET_ASSAULTS_CHART_DATA", response.data);
    });
  },
  setHealthyLifeChartData: async ({ commit }, nation) => {
    await service.getHealthyLifeDataToChart(nation).then((response) => {
      commit("SET_HEALTHY_LIFE_CHART_DATA", response.data);
    });
  },
  setMigrationAveragesData: async ({ commit }, migrationType) => {
    await service.getMigrationAveragesData(migrationType).then((response) => {
      commit("SET_MIGRAITON_AVERAGES_DATA", response.data);
    });
  },
};

export default { state, getters, mutations, actions, namespaced };
