import Vue from "vue";
import App from "./App.vue";

import store from "./store";
import router from "./router";

//Bootstrap
import { BootstrapVue } from "bootstrap-vue";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
Vue.use(BootstrapVue);

//FontAwesome
import "@fortawesome/fontawesome-free/css/all.css";
import "@fortawesome/fontawesome-free/js/all.js";

//DevExtreme
import "devextreme/dist/css/dx.common.css";
import "devextreme/dist/css/dx.light.css";


// styles
import "@/styles/main.css"

Vue.config.productionTip = false;

new Vue({
  store,
  router,
  render: (h) => h(App),
}).$mount("#app");
