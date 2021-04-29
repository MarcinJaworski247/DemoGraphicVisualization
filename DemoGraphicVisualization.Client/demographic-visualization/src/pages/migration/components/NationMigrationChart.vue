<template>
  <div>
    <div class="row">
      <div class="ml-4 mb-4" style="display: flex">
        <DxSelectBox
          :data-source="getNationsToLookup"
          value-expr="key"
          display-expr="value"
          :value="getNationsToLookup[0].key"
          class="ml-4"
          @value-changed="nationValueChanged"
        />
        <DxSelectBox
          :data-source="migrationTypes"
          value-expr="id"
          display-expr="name"
          :value="migrationTypes[0].id"
          class="ml-4"
          @value-changed="migrationValueChanged"
        />
      </div>
    </div>
    <div>
      <DxChart
        id="chart"
        :data-source="getNationMigrationChartData"
        palette="Ocean"
      >
        <!-- <DxCommonSeriesSettings argument-field="year" type="bar">
          <DxLabel :visible="true">
            <DxFormat :precision="0" type="fixedPoint" />
          </DxLabel>
        </DxCommonSeriesSettings> -->
        <DxCommonAnnotationSettings
          :allow-dragging="false"
          type="custom"
          series="Migration"
          template="annotationTemplate"
        />
        <DxAnnotation
          v-for="data in getNationMigrationChartData"
          :key="data.year"
          :argument="data.year"
          :data="data"
        />
        
        <template #annotationTemplate="{ data }">
          <AnnotationTemplate :annotation="data" />
        </template>
        <DxSeries type="bar" argument-field="year" value-field="migration" name="Migration" />
        <DxLegend :visible="false" />
      </DxChart>
    </div>
  </div>
</template>
<script>
import { mapGetters, mapActions } from "vuex";
import {
  DxChart,
  DxSeries,
  //DxCommonSeriesSettings,
  // DxLabel,
  // DxFormat,
  DxLegend,
  DxAnnotation,
  DxCommonAnnotationSettings,
} from "devextreme-vue/chart";
import { DxSelectBox } from "devextreme-vue";

import AnnotationTemplate from "./Annotation";

const STORE = "MigrationStore";

export default {
  data() {
    return {
      migrationTypes: [
        {
          id: 0,
          name: "Immigration",
        },
        {
          id: 1,
          name: "Emigration",
        },
      ],
      selectedNation: null,
      selectedMigration: null,
    };
  },
  components: {
    DxSelectBox,
    DxChart,
    DxSeries,
    //DxCommonSeriesSettings,
    // DxLabel,
    // DxFormat,
    DxLegend,
    DxAnnotation,
    DxCommonAnnotationSettings,
    AnnotationTemplate,
  },
  computed: {
    ...mapGetters(STORE, ["getNationMigrationChartData", "getNationsToLookup"]),
  },
  methods: {
    ...mapActions(STORE, ["setNationMigrationChartData", "setNationsToLookup"]),
    nationValueChanged(data) {
      this.selectedNation = data.value;
      this.setNationMigrationChartData([
        this.selectedNation,
        this.selectedMigration,
      ]);
    },
    migrationValueChanged(data) {
      this.selectedMigration = data.value;
      this.setNationMigrationChartData([
        this.selectedNation,
        this.selectedMigration,
      ]);
    },
  },
  mounted() {
    this.selectedNation = "Austria";
    this.selectedMigration = this.migrationTypes[0].id;
    this.setNationMigrationChartData([
      this.selectedNation,
      this.selectedMigration,
    ]);
    this.setNationsToLookup();
  },
};
</script>
<style scoped>
#chart {
  height: 600px;
}
</style>
