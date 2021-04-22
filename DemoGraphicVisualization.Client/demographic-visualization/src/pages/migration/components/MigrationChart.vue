<template>
  <div>
    <div class="row">
      <div class="ml-4 mb-4" style="display: flex">
        <DxSelectBox
          :data-source="years"
          value-expr="id"
          display-expr="name"
          :value="years[11].id"
          class="ml-4"
          @value-changed="valueChanged"
        />
        <div class="dx-field-value">
          <DxTagBox
            :data-source="getNationsToLookup"
            display-expr="value"
            value-expr="key"
            :hide-selected-items="true"
            class="ml-4 tag-box-width"
            placeholder="Choose nations"
            @value-changed="nationsChanged"
          />
        </div>
      </div>
    </div>
    <div>
      <DxChart id="chart" :data-source="getMigrationChartData" palette="Ocean">
        <DxCommonSeriesSettings argument-field="nation" type="bar">
          <DxLabel :visible="true">
            <DxFormat :precision="0" type="fixedPoint" />
          </DxLabel>
        </DxCommonSeriesSettings>
        <DxSeries value-field="immigration" name="Immigration" />
        <DxSeries value-field="emigration" name="Emigration" />
        <DxLegend vertical-alignment="bottom" horizontal-alignment="center" />
      </DxChart>
    </div>
  </div>
</template>
<script>
import { mapGetters, mapActions } from "vuex";
import { mapFields } from "vuex-map-fields";
import {
  DxChart,
  DxSeries,
  DxCommonSeriesSettings,
  DxLabel,
  DxFormat,
  DxLegend,
} from "devextreme-vue/chart";
import { DxSelectBox } from "devextreme-vue";
import DxTagBox from "devextreme-vue/tag-box";

const STORE = "MigrationStore";

export default {
  data() {
    return {
      years: [
        { id: 0, name: "2008" },
        { id: 1, name: "2009" },
        { id: 2, name: "2010" },
        { id: 3, name: "2011" },
        { id: 4, name: "2012" },
        { id: 5, name: "2013" },
        { id: 6, name: "2014" },
        { id: 7, name: "2015" },
        { id: 8, name: "2016" },
        { id: 9, name: "2017" },
        { id: 10, name: "2018" },
        { id: 11, name: "2019" },
      ],
    };
  },
  components: {
    DxSelectBox,
    DxChart,
    DxSeries,
    DxCommonSeriesSettings,
    DxLabel,
    DxFormat,
    DxLegend,
    DxTagBox,
  },
  computed: {
    ...mapGetters(STORE, ["getMigrationChartData", "getNationsToLookup"]),
    ...mapFields(STORE, ["param.SelectedNations", "param.Year"]),
  },
  methods: {
    ...mapActions(STORE, ["setMigrationChartData", "setNationsToLookup"]),
    valueChanged(data) {
      this.Year = data.value;
      this.setMigrationChartData();
    },
    nationsChanged(data) {
      debugger
      this.SelectedNations = data.value;
      this.setMigrationChartData();
    },
  },
  mounted() {
    this.Year = this.years[0].name;
    this.setMigrationChartData();
    this.setNationsToLookup();
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
.tag-box-width {
  width: 400px;
}
</style>
