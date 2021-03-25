﻿using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.DTO
{
    public class Dimension
    {
        [DeserializeAs(Name = "indic_de")]
        public object Indic_de { get; set; }
        [DeserializeAs(Name = "geo")]
        public Geo Geo { get; set; }
    }
    public class Geo
    {
        [DeserializeAs(Name = "label")]
        public string Label { get; set; }
        [DeserializeAs(Name = "category")]
        public GetCategory Category { get; set; }
    }
    public class GetCategory
    {
        [DeserializeAs(Name = "index")]
        public List<Dictionary<string, int>> Indexes { get; set; }
        [DeserializeAs(Name = "label")]
        public List<Dictionary<string, string>> Labels { get; set; }
    }
    public class Time
    {
        [DeserializeAs(Name = "label")]
        public string Label { get; set; }
        [DeserializeAs(Name = "category")]
        public TimeCategory TimeCategory { get; set; }
    }
    public class TimeCategory
    {
        [DeserializeAs(Name = "index")]
        public List<Dictionary<string, int>> Indexes { get; set; }
        [DeserializeAs(Name = "label")]
        public List<Dictionary<string, string>> Labels { get; set; }
    }
    public class PopulationDataDTO
    {
        [DeserializeAs(Name = "version")]
        public string Version { get; set; }
        [DeserializeAs(Name = "label")]
        public string Label { get; set; }
        [DeserializeAs(Name = "href")]
        public string Href { get; set; }
        [DeserializeAs(Name = "source")]
        public string Source { get; set; }
        [DeserializeAs(Name = "updated")]
        public string Updated { get; set; }
        [DeserializeAs(Name = "status")]
        public List<Dictionary<string, string>> Statuses { get; set; }
        [DeserializeAs(Name = "extension")]
        public object Extensions { get; set; }
        [DeserializeAs(Name = "class")]
        public string Class { get; set; }
        [DeserializeAs(Name = "value")]
        public List<Dictionary<string, int>> Values { get; set; }
        [DeserializeAs(Name = "dimension")]
        public List<Dimension> Dimensions { get; set; }
        [DeserializeAs(Name = "id")]
        public object Id { get; set; }
        [DeserializeAs(Name = "size")]
        public object Size { get; set; }
    }
}
