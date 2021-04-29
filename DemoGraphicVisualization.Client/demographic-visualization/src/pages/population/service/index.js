import axios from "@/http-common";
const data = "/data";

class homeService {
  getPopulationDataToChart(year) {
    return axios.get(`${data}/getPopulationDataToChart/${year}`);
  }
  getPopulationDataToMap(year) {
    return axios.get(`${data}/getPopulationDataToMap/${year}`);
  }
  getPopulationTreeMapData(year) {
    return axios.get(`${data}/getPopulationDataToTreeMap/${year}`);
  }
  getPopulationGraphData(year) {
    return axios.get(`${data}/getPopulationDataToGraph/${year}`);
  }
}

export default new homeService();
