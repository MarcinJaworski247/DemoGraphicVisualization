<template>
  <div>
    <div class="title">
      Population tree map
    </div>
    <div>
      <TreeMap />
    </div>
  </div>
</template>
<script>
import TreeMap from "../components/PopulationTreeMap";

export default {
  components: {
    TreeMap,
  },
};
</script>
