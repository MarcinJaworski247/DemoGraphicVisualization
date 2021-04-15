<template>
  <div>
    <div class="title">
      Population
    </div>
    <div>
      <Map />
    </div>
  </div>
</template>
<script>
import Map from "../components/Map";

export default {
  components: {
    Map,
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
