<template>
  <div>
    <div class="row">
      <div class="ml-4">
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
      <DxChart
        id="chart"
        :data-source="getPopulationChartData"
        :legend-visible="false"
        palette="Soft"
      >
        <DxCommonSeriesSettings
          argument-field="nation"
          value-field="population"
          :ignore-empty-points="true"
          type="bar"
        />
        <DxSeriesTemplate name-field="nation" />
        <DxTitle text="Population in European countries" class="mb-4" />
        <DxTooltip
          :enabled="true"
          :customize-tooltip="customizeTooltip"
          format="millions"
        />
        <DxLegend :visible="false" />
      </DxChart>
    </div>
  </div>
</template>
<script>
import { mapGetters, mapActions } from "vuex";
import {
  DxChart,
  DxSeriesTemplate,
  DxCommonSeriesSettings,
  DxTitle,
  DxTooltip,
  DxLegend,
} from "devextreme-vue/chart";
import { DxSelectBox } from "devextreme-vue";

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
    };
  },
  components: {
    DxChart,
    DxSeriesTemplate,
    DxCommonSeriesSettings,
    DxTitle,
    DxTooltip,
    DxSelectBox,
    DxLegend,
  },
  computed: {
    ...mapGetters(STORE, ["getPopulationChartData"]),
  },
  methods: {
    ...mapActions(STORE, ["setPopulationChartData"]),
    customizeTooltip(pointInfo) {
      return {
        text: `${pointInfo.argumentText}<br/>Population:  ${pointInfo.valueText}`,
      };
    },
    valueChanged(data) {
      this.setPopulationChartData(this.years[data.value].name);
    },
  },
  mounted() {
    this.setPopulationChartData(this.years[11].name);
  },
};
</script>
<style scoped>
.title {
  font-size: 32px;
  border-bottom: 1px solid black;
  margin: 32px;
}
#chart {
  height: 600px;
}
</style>
