import axios from "@/http-common";
const data = "/data";

class homeService {
  getMigrationDataToChart(param) {
    return axios.post(`${data}/getMigrationDataToChart`, param);
  }
  getMigrationDataToMap(year) {
    return axios.get(`${data}/getMigrationDataToMap/${year}`);
  }
  getNationMigrationDataToChart(nation, migrationType) {
    return axios.get(
      `${data}/getNationMigrationDataToChart/${nation}/${migrationType}`
    );
  }
  getNationsToLookup() {
    return axios.get(`${data}/getNationsToLookup`);
  }
  getAssaultsDataToChart(nation) {
    return axios.get(`${data}/getAssaultsDataToChart/${nation}`);
  }
  getHealthyLifeDataToChart(nation) {
    return axios.get(`${data}/getHealthyLifeDataToChart/${nation}`);
  }
  getMigrationAveragesData(migratioNnType) {
    return axios.get(`${data}/getMigrationAverage/${migratioNnType}`);
  }
}

export default new homeService();
