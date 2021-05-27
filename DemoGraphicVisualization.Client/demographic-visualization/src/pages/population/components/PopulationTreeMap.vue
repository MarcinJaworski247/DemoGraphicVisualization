<template>
  <div>
    <div class="row">
      <div class="ml-4 mb-4">
        <DxSelectBox
          :data-source="years"
          value-expr="id"
          display-expr="name"
          :value="years[11].id"
          class="ml-2 select-box"
          @value-changed="valueChanged"
        />
      </div>
    </div>
    <div>
      <DxTreeMap
        id="treemap"
        :data-source="getPopulationTreeMapData"
      >
        <DxTooltip
          :enabled="true"
          :customize-tooltip="customizeTooltip"
          format="millions"
        />
      </DxTreeMap>
    </div>
    <LoadSpinner v-if="loading" />
  </div>
</template>
<script>
// DevExtreme
import { mapGetters, mapActions } from "vuex";
import { DxSelectBox } from "devextreme-vue";
import DxTreeMap, { DxTooltip } from "devextreme-vue/tree-map";

// data
import { treeMapPopulations } from "./data.js";

// store
const STORE = "PopulationStore";

// components
import LoadSpinner from "@/components/LoadSpinner";

export default {
  data() {
    return {
      years: [
        { id: 0, name: "2009" },
        { id: 1, name: "2010" },
        { id: 2, name: "2011" },
        { id: 3, name: "2012" },
        { id: 4, name: "2013" },
        { id: 5, name: "2014" },
        { id: 6, name: "2015" },
        { id: 7, name: "2016" },
        { id: 8, name: "2017" },
        { id: 9, name: "2018" },
        { id: 10, name: "2019" },
        { id: 11, name: "2020" },
      ],
      treeMapPopulations,
      loading: false,
    };
  },
  components: {
    DxSelectBox,
    DxTreeMap,
    DxTooltip,
    LoadSpinner,
  },
  computed: {
    ...mapGetters(STORE, ["getPopulationTreeMapData"]),
  },
  methods: {
    ...mapActions(STORE, ["setPopulationTreeMapData"]),
    async valueChanged(data) {
      this.loading = true;
      this.setPopulationTreeMapData(this.years[data.value].name);
      this.loading = false;
    },
    customizeTooltip(arg) {
      const data = arg.node.data;
      return {
        text: arg.node.isLeaf()
          ? `<span class="country">${data.name}</span><br/>Population: ${arg.valueText}`
          : null,
      };
    },
  },
  mounted() {
    this.loading = true;
    this.setPopulationTreeMapData(this.years[11].name);
    this.loading = false;
  },
};
</script>
<style scoped>
#treemap {
  height: 500px;
}
#selectbox {
  width: 200px;
}
.country {
  font-weight: 500;
}
</style>
