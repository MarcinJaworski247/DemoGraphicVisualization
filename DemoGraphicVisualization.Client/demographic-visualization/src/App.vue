<template>
  <div id="app">
    <nav id="navigator" class="navbar" :class="{ navbaropen: opened }">
      <span class="open-slide">
        <a href="#" @click="opened = !opened">
          <div>
            <div class="bar" :class="{ topopen: opened }"></div>
            <div class="bar" :class="{ midopen: opened }"></div>
            <div class="bar" :class="{ botopen: opened }"></div>
          </div>
        </a>
      </span>
      <div>
        <div class="title">
          DemoGraphicVisualization<i class="ml-4 fas fa-globe-europe"></i>
        </div>
      </div>
    </nav>
    <div id="side-menu" class="side-nav" :class="{ sidenavopen: opened }">
      <router-link :to="{ name: `population.chart.index` }">
        <div>Population chart</div>
      </router-link>
      <router-link :to="{ name: `population.map.index` }">
        <div>Population map</div>
      </router-link>
      <router-link :to="{ name: `population.treemap.index` }">
        <div>Population tree map</div>
      </router-link>
      <router-link :to="{ name: `population.graph.index` }">
        <div>Population graph</div>
      </router-link>
      <router-link :to="{ name: `migration.chart.index` }">
        <div>Migration chart</div>
      </router-link>
      <router-link :to="{ name: `migration.nationChart.index` }">
        <div>Migration chart by nation</div>
      </router-link>
      <!-- <router-link :to="{ name: `migration.map.index` }">
        <div>Migration map</div>
      </router-link> -->
    </div>
    <div id="main" :class="{ mainopen: opened }">
      <router-view />
    </div>
  </div>
</template>

<script>
export default {
  name: "App",
  data() {
    return {
      opened: false,
      times: "fas fa-times",
      bars: "fas fa-bars",
    };
  },
  methods: {
    handleSidebar() {
      this.opened = !this.opened;
    },
  },
  components: {},
};
</script>

<style scoped>
body {
  background-color: #f5f5f5;
  overflow-x: hidden;
}
.title {
  font-size: 24px;
}
.navbar {
  background-color: #7897da;
  overflow: hidden;
  height: 80px;
}

.navbaropen {
  background-color: #7897da;
  overflow: hidden;
  height: 80px;
  margin-left: 200px;
}

.navbar a {
  float: left;
  display: block;
  color: #f2f2f2;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
}

.navbar ul {
  margin: 8px 0 0 0;
  list-style: none;
}

/* .navbar a:hover {
  background-color: #ddd;
  color: #000;
} */

.side-nav {
  height: 100%;
  width: 0;
  position: fixed;
  z-index: 1;
  top: 0;
  left: 0;
  background-color: #111;
  opacity: 0.9;
  overflow-x: hidden;
  padding-top: 60px;
  transition: 0.3s;
}

.sidenavopen {
  height: 100%;
  width: 200px;
  position: fixed;
  z-index: 1;
  top: 0;
  left: 0;
  background-color: #111;
  opacity: 0.9;
  overflow-x: hidden;
  padding-top: 60px;
  transition: 0.3s;
}

.side-nav a {
  padding: 10px 10px 40px 30px;
  text-decoration: none;
  font-size: 18px;
  color: #ccc;
  display: block;
  transition: 0.3s;
}

.side-nav a:hover {
  color: #fff;
}

.side-nav .btn-close {
  position: absolute;
  top: 0;
  right: 22px;
  font-size: 36px;
  margin-left: 50px;
}

#main {
  transition: margin-left 0.3s;
  padding: 20px;
  overflow: hidden;
  width: 100%;
}

.mainopen {
  transition: margin-left 0.3s;
  padding: 20px;
  overflow: hidden;
  width: (100% - 250px);
  margin-left: 200px;
}

nav {
  transition: margin-left 0.3s;
}

.bar {
  display: block;
  height: 5px;
  width: 35px;
  background: #000;
  margin: 5px auto;
}

.midopen {
  width: 0;
}
.bar {
  transition: all 0.7s ease;
}
.topopen {
  transform: translateY(10px) rotateZ(45deg);
}
.botopen {
  transform: translateY(-10px) rotateZ(-45deg);
}
</style>
