import axios from "@/http-common";
const data = "/data";

class homeService {
  getTestData() {
    return axios.get(`${data}/getTestData`);
  }
}

export default new homeService();
