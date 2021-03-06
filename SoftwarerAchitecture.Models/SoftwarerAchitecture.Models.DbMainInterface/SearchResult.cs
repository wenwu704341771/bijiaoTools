//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoftwarerAchitecture.Models.DbMainInterface
{
    using System;
    using System.Collections.Generic;
    
    public partial class SearchResult
    {
        public int ID { get; set; }
        public string AirLineName { get; set; }
        public string AirLine { get; set; }
        public string OrgCity { get; set; }
        public string DepartureCity { get; set; }
        public string DepartureCityCode { get; set; }
        public string DstCity { get; set; }
        public string ArrivalCity { get; set; }
        public string ArrivalCityCode { get; set; }
        public string IsInter { get; set; }
        public string DepDateTime { get; set; }
        public Nullable<System.DateTime> DepartureTime { get; set; }
        public Nullable<System.DateTime> ArrivalTime { get; set; }
        public Nullable<double> TicketPrice { get; set; }
        public string AirportPrice { get; set; }
        public string FuelPrice { get; set; }
        public string FlightNo { get; set; }
        public string ClassCode { get; set; }
        public string BookUrl { get; set; }
        public string Storage { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<double> UpdateBatch { get; set; }
    }
}
