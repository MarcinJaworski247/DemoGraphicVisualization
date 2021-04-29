<template>
  <div>
    <div class="title">
      Population force directed graph
    </div>
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
