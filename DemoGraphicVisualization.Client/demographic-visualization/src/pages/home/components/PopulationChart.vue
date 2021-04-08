<template>
  <div></div>
</template>
<script>
import { mapGetters, mapActions } from "vuex";

const STORE = "HomeStore";

export default {
  computed: {
    ...mapGetters(SOTRE, ["getPopulationChartData"]),
  },
  methods: {
    ...mapActions(STORE, ["setPopulationChartData"]),
  },
  mounted() {
    this.setPopulationChartData();
  },
};
</script>
