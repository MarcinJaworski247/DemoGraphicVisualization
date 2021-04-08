import axios from "@/http-common";
const data = "/data";

class homeService {
  getPopulationDataToChart() {
    return axios.get(`${data}/getPopulationDataToChart`);
  }
  getPopulationDataToMap() {
    return axios.get(`${data}/getPopulationDataToMap`);
  }
}

export default new homeService();
