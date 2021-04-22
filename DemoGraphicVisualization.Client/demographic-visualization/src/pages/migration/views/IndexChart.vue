<template>
  <div>
    <div class="title">
      Migration
    </div>
    <div>
      <Chart />
    </div>
  </div>
</template>
<script>
import Chart from "../components/MigrationChart";

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
