import axios from "axios";

export default axios.create({
  baseURL: "http://localhost:65301/api",
  headers: {
    "Content-type": "application/json",
  },
});
