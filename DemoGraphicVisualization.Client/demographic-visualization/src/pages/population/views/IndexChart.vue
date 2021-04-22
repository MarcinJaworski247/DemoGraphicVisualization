<template>
  <div>
    <div class="title">
      Population
    </div>
    <div>
      <Chart />
    </div>
  </div>
</template>
<script>
import Chart from "../components/PopulationChart";

export default {
  components: {
    Chart,
  },
};
</script>
<style scoped>
.title {
  font-size: 32px;
  border-bottom: 1px solid black;
  margin: 32px;
}
</style>
