<template>
  <div>
    <div class="title">
      Population force directed graph
    </div>
    <div class="subtitle">Top 25 countries by population (year 2019)</div>
    <div>
      <Graph />
    </div>
  </div>
</template>
<script>
import Graph from "../components/PopulationGraph";

export default {
  components: {
    Graph,
  },
};
</script>
