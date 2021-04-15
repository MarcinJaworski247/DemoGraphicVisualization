import axios from "@/http-common";
const data = "/data";

class homeService {
  getPopulationDataToChart(year) {
    return axios.get(`${data}/getPopulationDataToChart/${year}`);
  }
  getPopulationDataToMap(year) {
    return axios.get(`${data}/getPopulationDataToMap/${year}`);
  }
}

export default new homeService();
