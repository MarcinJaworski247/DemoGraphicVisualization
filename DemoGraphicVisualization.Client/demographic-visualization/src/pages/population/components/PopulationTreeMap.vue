<template>
  <div>
    <div class="row">
      <div class="ml-4 mb-4">
        <DxSelectBox
          :data-source="years"
          value-expr="id"
          display-expr="name"
          :value="years[11].id"
          class="ml-4"
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
  </div>
</template>
<script>
import { mapGetters, mapActions } from "vuex";
import { DxSelectBox } from "devextreme-vue";
import DxTreeMap, { DxTooltip } from "devextreme-vue/tree-map";
import { treeMapPopulations } from "./data.js";

const STORE = "PopulationStore";

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
    };
  },
  components: {
    DxSelectBox,
    DxTreeMap,
    DxTooltip,
  },
  computed: {
    ...mapGetters(STORE, ["getPopulationTreeMapData"]),
  },
  methods: {
    ...mapActions(STORE, ["setPopulationTreeMapData"]),
    valueChanged(data) {
      this.setPopulationTreeMapData(this.years[data.value].name);
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
    this.setPopulationTreeMapData(this.years[11].name);
  },
};
</script>
<style scoped>
#treemap {
  height: 500px;
}
.country {
  font-weight: 500;
}
</style>
