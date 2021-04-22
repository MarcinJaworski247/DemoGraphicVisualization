<template>
  <!-- <div class="annotation">
        <span :class="() => data.Change >= 0 ? green : red">
            {{ data.change.toPrecision(3) }}%
        </span>
    </div>  -->
  <svg class="annotation">
    <text
      x="70"
      y="25"
      class="state"
      :fill="(data.change >= 0) ? 'green' : 'red'"
    >
      {{ data.change.toPrecision(3) }}%
    </text>
    <text x="70" y="50" class="state">{{ data.migration }}</text>
  </svg>
</template>
<script>
export default {
  props: {
    annotation: {
      type: Object,
      default: () => ({}),
    },
  },
  data() {
    return {
      data: this.annotation.data,
    };
  },
  mounted() {
    debugger;
  },
};
</script>
<style scoped>
.annotation {
  font-size: 12px;
}
.border {
  width: 60px;
  height: 40px;
  stroke: rgba(191, 191, 191, 0.25);
  stroke-width: 1px;
  fill: transparent;
}
.state {
  font-weight: 500;
  font-size: 14px;
}
.caption {
  font-weight: 500;
}
.sup {
  font-size: 0.8em;
}
.green {
  color: green;
}
.red {
  color: red;
}
</style>
