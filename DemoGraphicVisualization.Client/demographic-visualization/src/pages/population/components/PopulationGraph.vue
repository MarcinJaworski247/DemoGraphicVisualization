<template>
  <div>
    <div class="graph-background">
      <svg id="svg" width="1200" height="800"></svg>
    </div>
  </div>
</template>
<script>
import { mapGetters, mapActions } from "vuex";
import { mapFields } from "vuex-map-fields";

import * as d3 from "d3";

import { graphData } from "./data";

const STORE = "PopulationStore";

export default {
  data() {
    return {
      graphData,
    };
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
      let svg = d3.select("svg"),
        width = +svg.attr("width"),
        height = +svg.attr("height");

      svg.call(
        d3.zoom().on("zoom", function() {
          svg.attr("transform", d3.event.transform);
        })
      );

      let simulation = d3
        .forceSimulation()
        .force(
          "link",
          d3
            .forceLink()
            .id(function(d) {
              return d.id;
            })
            .distance(function(d) {
              return d.population / 100000;
            })
        )
        .force("charge", d3.forceManyBody())
        .force("center", d3.forceCenter(width / 2, height / 2))
        .force("y", d3.forceY(0.01))
        .force("x", d3.forceX(0.01))
        .force("collide", d3.forceCollide().radius(60).iterations(2));

      d3.json(
        "http://localhost:65301/api/data/getPopulationDataToGraph/2019",
        function(error, graph) {
          if (error) throw error;

          let link = svg
            .append("g")
            .attr("class", "links")
            .selectAll("line")
            .data(graph.links)
            .enter()
            .append("line");

          let node = svg
            .append("g")
            .attr("class", "nodes")
            .selectAll("g")
            .data(graph.nodes)
            .enter()
            .append("g");

          let circles = node
            .append("circle")
            .attr("r", 10)
            .attr("fill", function(d) {
              return getRandomColor();
            })
            .call(
              d3
                .drag()
                .on("start", dragstarted)
                .on("drag", dragged)
                .on("end", dragended)
            );

          let lables = node
            .append("text")
            .text(function(d) {
              let link = graph.links.find((el) => el.target === d.id);
              if (link != undefined)
                return d.id + " " + changeNumberPresentation(link.population);
            })
            .attr("x", 12)
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
        }
      );

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

      function getRandomColor() {
        return "#" + Math.floor(Math.random() * 16777215).toString(16);
      }

      function changeNumberPresentation(num) {
        if (num < 1000) {
          return num;
        }
        let si = [
          { v: 1e3, s: "K" },
          { v: 1e6, s: "M" },
          { v: 1e9, s: "B" },
          { v: 1e12, s: "T" },
          { v: 1e15, s: "P" },
          { v: 1e18, s: "E" },
        ];
        let i;
        for (i = si.length - 1; i > 0; i--) {
          if (num >= si[i].v) {
            break;
          }
        }
        return (
          (num / si[i].v).toFixed(2).replace(/\.0+$|(\.[0-9]*[1-9])0+$/, "$1") +
          si[i].s
        );
      }
    },
  },
  mounted() {
    this.drawGraph();
  },
};
</script>
<style>
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

.graph-background {
  margin-left: 400px !important;
  width: 1200px;
  height: 800px;
  background-color: #fff;
  opacity: 0.8;
  background-image: linear-gradient(#9da1ff 1px, transparent 1px),
    linear-gradient(to right, #9da1ff 1px, #fff 1px);
  background-size: 20px 20px;
}
</style>
