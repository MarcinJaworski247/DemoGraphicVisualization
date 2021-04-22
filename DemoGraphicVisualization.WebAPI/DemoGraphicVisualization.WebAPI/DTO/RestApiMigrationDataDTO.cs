using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.DTO
{
    public class MigrationDimension
    {
        [DeserializeAs(Name = "citizen")]
        public object Citizen { get; set; }
        [DeserializeAs(Name = "agedef")]
        public object Agedef { get; set; }
        [DeserializeAs(Name = "age")]
        public object Age { get; set; }
        [DeserializeAs(Name = "unit")]
        public object Unit { get; set; }
        [DeserializeAs(Name = "sex")]
        public object Sex { get; set; }
        [DeserializeAs(Name = "geo")]
        public Geo Geo { get; set; }
        [DeserializeAs(Name = "time")]
        public Time Time { get; set; }
    }
    public class MigrationGeo
    {
        [DeserializeAs(Name = "label")]
        public string Label { get; set; }
        [DeserializeAs(Name = "category")]
        public GetCategory Category { get; set; }
    }
    public class MigrationGetCategory
    {
        [DeserializeAs(Name = "index")]
        public Dictionary<string, int> Indexes { get; set; }
        [DeserializeAs(Name = "label")]
        public Dictionary<string, string> Labels { get; set; }
    }
    public class MigrationTime
    {
        [DeserializeAs(Name = "label")]
        public string Label { get; set; }
        [DeserializeAs(Name = "category")]
        public TimeCategory TimeCategory { get; set; }
    }
    public class MigrationTimeCategory
    {
        [DeserializeAs(Name = "index")]
        public Dictionary<string, int> Indexes { get; set; }
        [DeserializeAs(Name = "label")]
        public Dictionary<string, string> Labels { get; set; }
    }
    public class RestApiMigrationDataDTO
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
        public Dictionary<string, string> Statuses { get; set; }
        [DeserializeAs(Name = "extension")]
        public object Extensions { get; set; }
        [DeserializeAs(Name = "class")]
        public string Class { get; set; }
        [DeserializeAs(Name = "value")]
        public Dictionary<string, long> Values { get; set; }
        [DeserializeAs(Name = "dimension")]
        public MigrationDimension Dimensions { get; set; }
        [DeserializeAs(Name = "id")]
        public object Id { get; set; }
        [DeserializeAs(Name = "size")]
        public object Size { get; set; }
    }

}
