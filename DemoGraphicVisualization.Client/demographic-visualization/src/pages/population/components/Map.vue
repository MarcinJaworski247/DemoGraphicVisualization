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
      <DxVectorMap id="vector-map" :bounds="bounds">
        <DxLayer
          :data-source="europeMap"
          :color-groups="colorGroups"
          :customize="customizeLayer"
          palette="Violet"
          name="areas"
          color-grouping-field="population"
        />

        <DxTooltip :enabled="true" :customize-tooltip="customizeTooltip">
          <DxBorder :visible="true" />
          <DxFont color="#000" />
        </DxTooltip>

        <DxLegend :customize-text="customizeText">
          <DxSource layer="areas" grouping="color" />
        </DxLegend>
      </DxVectorMap>
    </div>
  </div>
</template>
<script>
import { mapActions } from "vuex";
const STORE = "PopulationStore";
import * as mapsData from "devextreme/dist/js/vectormap-data/europe.js";
import { populations } from "./data.js";
import {
  DxVectorMap,
  DxLayer,
  DxLegend,
  DxSource,
  DxTooltip,
  DxBorder,
  DxFont,
} from "devextreme-vue/vector-map";
import { DxSelectBox } from "devextreme-vue";
export default {
  components: {
    DxVectorMap,
    DxLayer,
    DxLegend,
    DxSource,
    DxSelectBox,
    DxTooltip,
    DxBorder,
    DxFont,
  },
  data() {
    return {
      europeMap: mapsData.europe,
      bounds: [20, 85, 35, 15],
      colorGroups: [
        0,
        1000000,
        5000000,
        10000000,
        30000000,
        50000000,
        100000000,
      ],
      countries: null,
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
    };
  },
  methods: {
    ...mapActions(STORE, ["setPopulationMapData"]),
    customizeTooltip(info) {
      const name = info.attribute("name");
      const population = populations[name];
      if (population) {
        return {
          text: `${name} <br/>Population: ${population}`,
        };
      }
    },
    customizeLayer(elements) {
      elements.forEach((element) => {
        const country = populations[element.attribute("name")];
        element.attribute("population", populations[element.attribute("name")]);
        // if (country) {
        //   element.applySettings({
        //     color: "#e0e000",
        //     hoveredColor: "navy",
        //     selectedColor: "#008f00",
        //     text: `${country.name}`
        //   });
        // }
      });
    },
    customizeText(itemInfo) {
      let text;
      if (itemInfo.index === 0) {
        text = "< 1 000 000";
      } else if (itemInfo.index === 5) {
        text = "> 100 000 000";
      } else {
        text = `${itemInfo.start} to ${itemInfo.end}`;
      }
      return text;
    },
    valueChanged(data) {
      this.setPopulationMapData(this.years[data.value].name);
    },
  },
  mounted() {
    this.setPopulationMapData(this.years[11].name).then((response) => {
      this.countries = response.data;
    });
  },
};
</script>
<style scoped>
#vector-map {
  height: 600px;
  width: 50%;
  margin: auto;
}
</style>
