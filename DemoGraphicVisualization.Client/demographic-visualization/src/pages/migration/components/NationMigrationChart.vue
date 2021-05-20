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
    <div class="row mt-1">
      <DxChart
        id="assaults"
        :data-source="getAssaultsChartData"
        palette="Material"
        title="Assaults per hundred people"
      >
        <DxCommonSeriesSettings type="line" argument-field="year" />
        <DxSeries value-field="assaults" name="Assaults rate" />
      </DxChart>
    </div>
    <div class="row mt-1">
      <DxChart
        id="health"
        :data-source="getHealthyLifeChartData"
        palette="Bright"
        title="Expected healthy life years"
      >
        <DxCommonSeriesSettings type="line" argument-field="year" />
        <DxSeries value-field="expectedLife" name="Expected life" />
      </DxChart>
    </div>
    <div class="row mt-1">
      <DxChart
        id="chart"
        :data-source="getNationMigrationChartData"
        palette="Ocean"
        title="Migration"
      >
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
        <DxSeries
          type="bar"
          argument-field="year"
          value-field="migration"
          name="Migration"
        />
        <DxLegend :visible="true" />

        <DxSeries
          type="line"
          value-field="average"
          name="EU Average"
          color="#008fd8"
          argument-field="year"
        />
      </DxChart>
    </div>
    <!-- <div class="row mt-4">
      <DxChart
        :data-source="getMigrationAveragesData"
        palette="Harmony Light"
        title="Average migration in EU countries"
      >
        <DxCommonSeriesSettings type="line" argument-field="year" />
        <DxSeries value-field="average" name="Average EU migration" />
      </DxChart>
    </div> -->
  </div>
</template>
<script>
import { mapGetters, mapActions } from "vuex";
import {
  DxChart,
  DxSeries,
  DxCommonSeriesSettings,
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
    DxCommonSeriesSettings,
    // DxLabel,
    // DxFormat,
    DxLegend,
    DxAnnotation,
    DxCommonAnnotationSettings,
    AnnotationTemplate,
  },
  computed: {
    ...mapGetters(STORE, [
      "getNationMigrationChartData",
      "getNationsToLookup",
      "getAssaultsChartData",
      "getHealthyLifeChartData",
      "getMigrationAveragesData",
    ]),
  },
  methods: {
    ...mapActions(STORE, [
      "setNationMigrationChartData",
      "setNationsToLookup",
      "setAssaultsChartData",
      "setHealthyLifeChartData",
      "setMigrationAveragesData",
    ]),
    nationValueChanged(data) {
      this.selectedNation = data.value;
      this.setNationMigrationChartData([
        this.selectedNation,
        this.selectedMigration,
      ]);
      this.setAssaultsChartData(this.selectedNation);
      this.setHealthyLifeChartData(this.selectedNation);
    },
    migrationValueChanged(data) {
      this.selectedMigration = data.value;
      this.setNationMigrationChartData([
        this.selectedNation,
        this.selectedMigration,
      ]);
      this.setMigrationAveragesData(this.selectedMigration);
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
    this.setAssaultsChartData(this.selectedNation);
    this.setHealthyLifeChartData(this.selectedNation);
    this.setMigrationAveragesData(this.selectedMigration);
  },
};
</script>
<style scoped>
#chart {
  height: 400px;
}
#assaults {
  height: 180px;
}
#health {
  height: 180px;
}
</style>
