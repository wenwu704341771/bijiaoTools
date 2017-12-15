using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwarerAchitecture.Modules.MainInterface
{
    public class SWProductsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Info { get; set; }
    }

    public class IncreaseProductsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyId { get; set; }
        /// <summary>
        /// 商务经济座服务
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PriceOfAirportCounter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CanBuyNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Must { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SeatId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Discount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IncreaseProductOrderDetailId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PaymentStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Segment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SWProductsItem> SWProducts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProdDetailID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Lat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Lng { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DepartureTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PassengersNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ClientMessages { get; set; }
    }

    public class AircraftCabinInfosItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TotalLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Remain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Discount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Integral { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Baggage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AirportConstructionFees { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FuelSurcharge { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OtherFees { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<IncreaseProductsItem> IncreaseProducts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsActivity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ActivityCheck { get; set; }
    }

    public class AircraftCabinsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int CabinLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<AircraftCabinInfosItem> AircraftCabinInfos { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> Guest { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsActivity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ActivityCheck { get; set; }
    }

    public class RouteItemItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string IsDiscount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SegmentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int LyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Transport { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Bus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RouteType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RouteArea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MinCabinPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MinCabinLevel { get; set; }
        /// <summary>
        /// 2 小时 25 分钟
        /// </summary>
        public string FlightsTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RouteSegType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ActId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> Stopovers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<AircraftCabinsItem> AircraftCabins { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RouteTotalTax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// 上海
        /// </summary>
        public string Departure { get; set; }
        /// <summary>
        /// 上海浦东T2航站楼
        /// </summary>
        public string DepartureStation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TicketAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DepartureStationRemark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DepartureCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DepartureAirportCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DepartureTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DepartureTimeBJ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ArrivalTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ArrivalTimeBJ { get; set; }
        /// <summary>
        /// 大阪
        /// </summary>
        public string Arrival { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ArrivalStationRemark { get; set; }
        /// <summary>
        /// 大阪关西国际机场T2航站楼
        /// </summary>
        public string ArrivalStation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ArrivalCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ArrivalAirportCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FlightDateBJ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FlightDateLocal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OriTerm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DesTerm { get; set; }
        /// <summary>
        /// 2小时25分
        /// </summary>
        public string FlightTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DepartureWeekday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SegType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SegTypeName { get; set; }
    }

    public class Root9C
    {
        /// <summary>
        /// 
        /// </summary>
        public List<List<RouteItemItem>> Route { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MaxDiscount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IfExistLC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsBg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsEmployee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MinPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ANumLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CNumLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int INumLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsInternational { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsShowTaxprice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }
    }
}
