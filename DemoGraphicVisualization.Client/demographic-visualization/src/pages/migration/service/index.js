import axios from "@/http-common";
const data = "/data";

class homeService {
  getMigrationDataToChart(param) {
    debugger
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
}

export default new homeService();
