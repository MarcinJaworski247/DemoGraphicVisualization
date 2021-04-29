<template>
  <div>
    <div class="ml-4">
      <svg id="svg" width="1200" height="800"></svg>
    </div>
  </div>
</template>
<script>
import { mapGetters, mapActions } from "vuex";
import { mapFields } from "vuex-map-fields";
//import { DxSelectBox } from "devextreme-vue";

import * as d3 from "d3";

import { graphData } from "./data";
import miserables from "./miserables";

const STORE = "PopulationStore";

export default {
  data() {
    return {
      years: [
        { id: 0, name: "2009" },
        { id: 1, name: "2010" },
        { id: 2, name: "2011" },
        { id: 3, name: "2012" },
        { id: 4, name: "2013" },
        { id: 5, name: "2014" },
        { id: 6, name: "2015" },
        { id: 7, name: "2016" },
        { id: 8, name: "2017" },
        { id: 9, name: "2018" },
        { id: 10, name: "2019" },
        { id: 11, name: "2020" },
      ],
      graphData,
      miserables,
    };
  },
  components: {
    //DxSelectBox,
  },
  computed: {
    ...mapGetters(STORE, ["getPopulationGraphData"]),
    ...mapFields(STORE, ["populationGraph"]),
  },
  methods: {
    ...mapActions(STORE, ["setPopulationGraphData"]),
    valueChanged(data) {
      this.setPopulationGraphData(this.years[data.value].name);
    },
    drawGraph() {
      var svg = d3.select("svg"),
        width = +svg.attr("width"),
        height = +svg.attr("height");

      var color = d3.scaleOrdinal(d3.schemeCategory20);

      var simulation = d3
        .forceSimulation()
        .force(
          "link",
          d3.forceLink().id(function(d) {
            return d.id;
          })
        )
        .force("charge", d3.forceManyBody())
        .force("center", d3.forceCenter(width / 2, height / 2));

      d3.json("http://localhost:65301/api/data/getPopulationDataToGraph/2019", function(error, graph) {
        if (error) throw error;

        var link = svg
          .append("g")
          .attr("class", "links")
          .selectAll("line")
          .data(graph.links)
          .enter()
          .append("line")
          .attr("stroke-width", function(d) {
            return Math.sqrt(d.value);
          });

        var node = svg
          .append("g")
          .attr("class", "nodes")
          .selectAll("g")
          .data(graph.nodes)
          .enter()
          .append("g");

        var circles = node
          .append("circle")
          .attr("r", 10)
          .attr("fill", function(d) {
            return color(d.group);
          })
        .call(
          d3
            .drag()
            .on("start", dragstarted)
            .on("drag", dragged)
            .on("end", dragended)
        );

        var lables = node
          .append("text")
          .text(function(d) {
            return d.id;
          })
          .attr("x", 6)
          .attr("y", 3);

        node.append("title").text(function(d) {
          return d.id;
        });

        simulation.nodes(graph.nodes).on("tick", ticked);

        simulation.force("link").links(graph.links);

        function ticked() {
          link
            .attr("x1", function(d) {
              return d.source.x;
            })
            .attr("y1", function(d) {
              return d.source.y;
            })
            .attr("x2", function(d) {
              return d.target.x;
            })
            .attr("y2", function(d) {
              return d.target.y;
            });

          node.attr("transform", function(d) {
            return "translate(" + d.x + "," + d.y + ")";
          });
        }
      });

      function dragstarted(d) {
        if (!d3.event.active) simulation.alphaTarget(0.3).restart();
        d.fx = d.x;
        d.fy = d.y;
      }

      function dragged(d) {
        d.fx = d3.event.x;
        d.fy = d3.event.y;
      }

      function dragended(d) {
        if (!d3.event.active) simulation.alphaTarget(0);
        d.fx = null;
        d.fy = null;
      }
    },
  },
  mounted() {
    //this.setPopulationGraphData(this.years[11].name).then((response) => {
      //this.drawGraph(response.data);
    //});
    this.drawGraph();
  },
};
</script>
<style >
.links line {
  stroke: #999;
  stroke-opacity: 0.6;
}

.nodes circle {
  stroke: #fff;
  stroke-width: 1.5px;
}

text {
  font-family: sans-serif;
  font-size: 10px;
}
</style>
