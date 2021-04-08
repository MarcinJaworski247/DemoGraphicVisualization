<template>
  <div></div>
</template>
<script>
import { mapGetters, mapActions } from "vuex";

const STORE = "HomeStore";

export default {
  computed: {
    ...mapGetters(SOTRE, ["getPopulationMapData"]),
  },
  methods: {
    ...mapActions(STORE, ["setPopulationMapData"]),
  },
  mounted() {
    this.setPopulationMapData();
  },
};
</script>
