using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwarerAchitecture.Modules.MainInterface
{
    public class RootZH
    {
        [JsonProperty("flightSearchResult")]
        public FlightSearchResult FlightSearchResult { get; set; }

    }
    public class FlightSearchResult
    {

        [JsonProperty("airportDuty")]
        public object AirportDuty { get; set; }

        [JsonProperty("classTypes")]
        public string[] ClassTypes { get; set; }

        [JsonProperty("departureTime")]
        public string DepartureTime { get; set; }

        [JsonProperty("departureTime2")]
        public object DepartureTime2 { get; set; }

        [JsonProperty("discountChild")]
        public string DiscountChild { get; set; }

        [JsonProperty("dstCity")]
        public string DstCity { get; set; }

        [JsonProperty("flightInfoList")]
        public FlightInfoList[] FlightInfoList { get; set; }

        [JsonProperty("flightInfoList2")]
        public object[] FlightInfoList2 { get; set; }

        [JsonProperty("flightInfoWFEasyFlyList")]
        public object FlightInfoWFEasyFlyList { get; set; }

        [JsonProperty("flightWFSearchResult")]
        public object FlightWFSearchResult { get; set; }

        [JsonProperty("hasEasyWF")]
        public bool HasEasyWF { get; set; }

        [JsonProperty("hasGroupWF")]
        public bool HasGroupWF { get; set; }

        [JsonProperty("hasStorage")]
        public bool HasStorage { get; set; }

        [JsonProperty("hcType")]
        public string HcType { get; set; }

        [JsonProperty("oilTaxAdult")]
        public object OilTaxAdult { get; set; }

        [JsonProperty("oilTaxChild")]
        public object OilTaxChild { get; set; }

        [JsonProperty("orgCity")]
        public string OrgCity { get; set; }

        [JsonProperty("selectWFType")]
        public string SelectWFType { get; set; }

        [JsonProperty("selectedFlight")]
        public object SelectedFlight { get; set; }

        [JsonProperty("selectedFlight2")]
        public object SelectedFlight2 { get; set; }
    }
    public class FlightInfoList
    {

        [JsonProperty("acType")]
        public string AcType { get; set; }

        [JsonProperty("airportPrice")]
        public string AirportPrice { get; set; }

        [JsonProperty("basePrice")]
        public string BasePrice { get; set; }

        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("carrierFlightNo")]
        public string CarrierFlightNo { get; set; }

        [JsonProperty("classInfoList")]
        public ClassInfoList[] ClassInfoList { get; set; }

        [JsonProperty("classStorageF")]
        public object ClassStorageF { get; set; }

        [JsonProperty("classStorageY")]
        public object ClassStorageY { get; set; }

        [JsonProperty("dstAirport")]
        public string DstAirport { get; set; }

        [JsonProperty("dstCity")]
        public string DstCity { get; set; }

        [JsonProperty("dstCityCH")]
        public string DstCityCH { get; set; }

        [JsonProperty("dstDate")]
        public string DstDate { get; set; }

        [JsonProperty("dstTime")]
        public string DstTime { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("f_classInfo")]
        public object FClassInfo { get; set; }

        [JsonProperty("flightNo")]
        public string FlightNo { get; set; }

        [JsonProperty("hasStorage")]
        public bool HasStorage { get; set; }

        [JsonProperty("isCodeShare")]
        public string IsCodeShare { get; set; }

        [JsonProperty("maxRefundRate")]
        public object MaxRefundRate { get; set; }

        [JsonProperty("maxRescheduleRate")]
        public object MaxRescheduleRate { get; set; }

        [JsonProperty("meal")]
        public string Meal { get; set; }

        [JsonProperty("minRefundRate")]
        public object MinRefundRate { get; set; }

        [JsonProperty("minRescheduleRate")]
        public object MinRescheduleRate { get; set; }

        [JsonProperty("oilPriceAdult")]
        public string OilPriceAdult { get; set; }

        [JsonProperty("oilPriceChild")]
        public string OilPriceChild { get; set; }

        [JsonProperty("oilPriceInfant")]
        public string OilPriceInfant { get; set; }

        [JsonProperty("orgAirport")]
        public string OrgAirport { get; set; }

        [JsonProperty("orgCity")]
        public string OrgCity { get; set; }

        [JsonProperty("orgCityCH")]
        public string OrgCityCH { get; set; }

        [JsonProperty("orgDate")]
        public string OrgDate { get; set; }

        [JsonProperty("orgTime")]
        public string OrgTime { get; set; }

        [JsonProperty("pageClassInfoMap")]
        public object PageClassInfoMap { get; set; }

        [JsonProperty("publicClassPriceF")]
        public string PublicClassPriceF { get; set; }

        [JsonProperty("publicClassPriceY")]
        public string PublicClassPriceY { get; set; }

        [JsonProperty("segmentId")]
        public string SegmentId { get; set; }

        [JsonProperty("selectedClassInfo")]
        public object SelectedClassInfo { get; set; }

        [JsonProperty("stopCity")]
        public object StopCity { get; set; }

        [JsonProperty("stopCityAirport")]
        public object StopCityAirport { get; set; }

        [JsonProperty("stopCityCH")]
        public object StopCityCH { get; set; }

        [JsonProperty("stopDeptDate")]
        public object StopDeptDate { get; set; }

        [JsonProperty("stopDstDate")]
        public object StopDstDate { get; set; }

        [JsonProperty("wfClassInfo")]
        public object WfClassInfo { get; set; }

        [JsonProperty("y_classInfo")]
        public object YClassInfo { get; set; }
    }

    public class ClassInfoList
    {

        [JsonProperty("accMileage")]
        public string AccMileage { get; set; }

        [JsonProperty("baseprice")]
        public int Baseprice { get; set; }

        [JsonProperty("boundPermitted")]
        public string BoundPermitted { get; set; }

        [JsonProperty("changeRefund")]
        public string ChangeRefund { get; set; }

        [JsonProperty("classCode")]
        public string ClassCode { get; set; }

        [JsonProperty("classLinkageFlag")]
        public bool ClassLinkageFlag { get; set; }

        [JsonProperty("classPrice")]
        public string ClassPrice { get; set; }

        [JsonProperty("classType")]
        public string ClassType { get; set; }

        [JsonProperty("comfortableEconomyClassFlag")]
        public bool ComfortableEconomyClassFlag { get; set; }

        [JsonProperty("discount")]
        public string Discount { get; set; }

        [JsonProperty("ei")]
        public string Ei { get; set; }

        [JsonProperty("fareBase")]
        public string FareBase { get; set; }

        [JsonProperty("hasMemberPrice")]
        public bool HasMemberPrice { get; set; }

        [JsonProperty("maxRefundRate")]
        public string MaxRefundRate { get; set; }

        [JsonProperty("maxRescheduleRate")]
        public string MaxRescheduleRate { get; set; }

        [JsonProperty("memberCoupon")]
        public string MemberCoupon { get; set; }

        [JsonProperty("memberDiscount")]
        public string MemberDiscount { get; set; }

        [JsonProperty("memberPrice")]
        public string MemberPrice { get; set; }

        [JsonProperty("minRefundRate")]
        public string MinRefundRate { get; set; }

        [JsonProperty("minRescheduleRate")]
        public string MinRescheduleRate { get; set; }

        [JsonProperty("productMap")]
        public object ProductMap { get; set; }

        [JsonProperty("publicClassPrice")]
        public string PublicClassPrice { get; set; }

        [JsonProperty("referDiscount")]
        public string ReferDiscount { get; set; }

        [JsonProperty("saveMoney")]
        public string SaveMoney { get; set; }

        [JsonProperty("spolCode")]
        public string SpolCode { get; set; }

        [JsonProperty("storage")]
        public string Storage { get; set; }

        [JsonProperty("tc")]
        public object Tc { get; set; }

        [JsonProperty("ticketPrice")]
        public int TicketPrice { get; set; }
    }

}
