using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwarerAchitecture.Modules.MainInterface
{
    public class RootMF
    {
        [JsonProperty("resultCode")]
        public string ResultCode { get; set; }

        [JsonProperty("title")]
        public object Title { get; set; }

        [JsonProperty("note")]
        public object Note { get; set; }

        [JsonProperty("nextJsonToken")]
        public string NextJsonToken { get; set; }

        [JsonProperty("orgCity")]
        public string OrgCity { get; set; }

        [JsonProperty("orgAirport")]
        public string OrgAirport { get; set; }

        [JsonProperty("dstCity")]
        public string DstCity { get; set; }

        [JsonProperty("dstAirport")]
        public string DstAirport { get; set; }

        [JsonProperty("takeoffDate")]
        public string TakeoffDate { get; set; }

        [JsonProperty("returnDate")]
        public object ReturnDate { get; set; }

        [JsonProperty("tripType")]
        public int TripType { get; set; }

        [JsonProperty("lowPrice1")]
        public string LowPrice1 { get; set; }

        [JsonProperty("lowPrice2")]
        public object LowPrice2 { get; set; }

        [JsonProperty("flightInfos1")]
        public FlightInfos1[] FlightInfos1 { get; set; }

        [JsonProperty("flightInfos2")]
        public object FlightInfos2 { get; set; }

        [JsonProperty("segRecomends")]
        public object SegRecomends { get; set; }

        [JsonProperty("cabinComList")]
        public object CabinComList { get; set; }

        [JsonProperty("noFlight")]
        public bool NoFlight { get; set; }
    }
    public class FlightInfos1
    {

        [JsonProperty("airline")]
        public string Airline { get; set; }

        [JsonProperty("carrier")]
        public object Carrier { get; set; }

        [JsonProperty("fltNo")]
        public string FltNo { get; set; }

        [JsonProperty("org")]
        public string Org { get; set; }

        [JsonProperty("dst")]
        public string Dst { get; set; }

        [JsonProperty("takeoffTime")]
        public string TakeoffTime { get; set; }

        [JsonProperty("arrivalTime")]
        public string ArrivalTime { get; set; }

        [JsonProperty("equipment")]
        public string Equipment { get; set; }

        [JsonProperty("meal")]
        public int Meal { get; set; }

        [JsonProperty("eTicket")]
        public bool ETicket { get; set; }

        [JsonProperty("codeShare")]
        public bool CodeShare { get; set; }

        [JsonProperty("stop")]
        public int Stop { get; set; }

        [JsonProperty("cBrand")]
        public CBrand CBrand { get; set; }

        [JsonProperty("fBrand")]
        public object FBrand { get; set; }

        [JsonProperty("iBrand")]
        public object IBrand { get; set; }

        [JsonProperty("yBrand")]
        public YBrand YBrand { get; set; }

        [JsonProperty("airportTax")]
        public double[] AirportTax { get; set; }

        [JsonProperty("fuelTax")]
        public double[] FuelTax { get; set; }

        [JsonProperty("term")]
        public string Term { get; set; }

        [JsonProperty("arrTerm")]
        public string ArrTerm { get; set; }

        [JsonProperty("mutiSegPromotion")]
        public MutiSegPromotion MutiSegPromotion { get; set; }

        [JsonProperty("state")]
        public int State { get; set; }

        [JsonProperty("termLst")]
        public TermLst[] TermLst { get; set; }

        [JsonProperty("classes")]
        public Class[] Classes { get; set; }

        [JsonProperty("codeShareList")]
        public object CodeShareList { get; set; }

        [JsonProperty("arriveAd")]
        public object ArriveAd { get; set; }

        [JsonProperty("skPrice")]
        public object SkPrice { get; set; }

        [JsonProperty("dsCount")]
        public object DsCount { get; set; }

        [JsonProperty("dsSelfCount")]
        public object DsSelfCount { get; set; }

        [JsonProperty("dsManyPeopleCount")]
        public object DsManyPeopleCount { get; set; }

        [JsonProperty("asr")]
        public bool Asr { get; set; }
    }
    public class CBrand
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("brandName")]
        public string BrandName { get; set; }

        [JsonProperty("fltNO")]
        public string FltNO { get; set; }

        [JsonProperty("cabin")]
        public string Cabin { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("childPrice")]
        public string ChildPrice { get; set; }

        [JsonProperty("seats")]
        public string Seats { get; set; }

        [JsonProperty("csId")]
        public object CsId { get; set; }

        [JsonProperty("mCard")]
        public int MCard { get; set; }

        [JsonProperty("coupon")]
        public int Coupon { get; set; }

        [JsonProperty("rcRemark")]
        public object RcRemark { get; set; }

        [JsonProperty("candidateId")]
        public object CandidateId { get; set; }

        [JsonProperty("isSaleCabin")]
        public int IsSaleCabin { get; set; }

        [JsonProperty("hideCabin")]
        public bool HideCabin { get; set; }

        [JsonProperty("dsName")]
        public object DsName { get; set; }

        [JsonProperty("dsCount")]
        public object DsCount { get; set; }

        [JsonProperty("dsSelfCount")]
        public object DsSelfCount { get; set; }

        [JsonProperty("dsManyPeopleCount")]
        public object DsManyPeopleCount { get; set; }

        [JsonProperty("psgrNumMin")]
        public int PsgrNumMin { get; set; }

        [JsonProperty("candidate")]
        public bool Candidate { get; set; }

        [JsonProperty("highEndOrder")]
        public bool HighEndOrder { get; set; }

        [JsonProperty("codeShareFlight")]
        public bool CodeShareFlight { get; set; }

        [JsonProperty("firstClass")]
        public bool FirstClass { get; set; }
    }
    public class YBrand
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("brandName")]
        public string BrandName { get; set; }

        [JsonProperty("fltNO")]
        public string FltNO { get; set; }

        [JsonProperty("cabin")]
        public string Cabin { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("childPrice")]
        public string ChildPrice { get; set; }

        [JsonProperty("seats")]
        public string Seats { get; set; }

        [JsonProperty("csId")]
        public object CsId { get; set; }

        [JsonProperty("mCard")]
        public int MCard { get; set; }

        [JsonProperty("coupon")]
        public int Coupon { get; set; }

        [JsonProperty("rcRemark")]
        public object RcRemark { get; set; }

        [JsonProperty("candidateId")]
        public object CandidateId { get; set; }

        [JsonProperty("isSaleCabin")]
        public int IsSaleCabin { get; set; }

        [JsonProperty("hideCabin")]
        public bool HideCabin { get; set; }

        [JsonProperty("dsName")]
        public object DsName { get; set; }

        [JsonProperty("dsCount")]
        public object DsCount { get; set; }

        [JsonProperty("dsSelfCount")]
        public object DsSelfCount { get; set; }

        [JsonProperty("dsManyPeopleCount")]
        public object DsManyPeopleCount { get; set; }

        [JsonProperty("psgrNumMin")]
        public int PsgrNumMin { get; set; }

        [JsonProperty("candidate")]
        public bool Candidate { get; set; }

        [JsonProperty("highEndOrder")]
        public bool HighEndOrder { get; set; }

        [JsonProperty("codeShareFlight")]
        public bool CodeShareFlight { get; set; }

        [JsonProperty("firstClass")]
        public bool FirstClass { get; set; }
    }
    public class MutiSegPromotion
    {

    }

    public class TermLst
    {
        [JsonProperty("dep")]
        public string Dep { get; set; }

        [JsonProperty("arr")]
        public object Arr { get; set; }
    }
    public class Class
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("av")]
        public string Av { get; set; }

        [JsonProperty("subClass")]
        public object[] SubClass { get; set; }
    }


    public class RootMfInfo
    {

        public string ResultCode { get; set; }


        public string Title { get; set; }


        public string Note { get; set; }


        public string OrgCity { get; set; }


        public string DstCity { get; set; }

        public BrandList[] BrandList { get; set; }
    }

    public class BrandList
    {

        public string Id { get; set; }

        public string BrandName { get; set; }

        public string FltNO { get; set; }


        public string Cabin { get; set; }


        public string Price { get; set; }


        public string ChildPrice { get; set; }


        public string Seats { get; set; }


        public string CsId { get; set; }


        public string MCard { get; set; }


        public string Coupon { get; set; }


        public string RcRemark { get; set; }


        public string CandidateId { get; set; }


        public string IsSaleCabin { get; set; }


        public string HideCabin { get; set; }


        public string DsName { get; set; }


        public string DsCount { get; set; }


        public string DsSelfCount { get; set; }


        public string DsManyPeopleCount { get; set; }

        public string PsgrNumMin { get; set; }


        public string Candidate { get; set; }


        public string HighEndOrder { get; set; }


        public string CodeShareFlight { get; set; }


        public string FirstClass { get; set; }
    }


    public class R
    {
        public string org { get; set; }
        public string dst { get; set; }
        public string takeoffDate { get; set; }
        public object returnDate { get; set; }
        public string takeoffTime { get; set; }
        public string arrivalTime { get; set; }
        public int tripType { get; set; }
        public int stop { get; set; }
        public string equipment { get; set; }
        public string fltNo { get; set; }
        public string airline { get; set; }
        public object arriveAd { get; set; }
        public Class[] classes { get; set; }

        public object codeShareList { get; set; }
        public int curTrip { get; set; }
        public int channelId { get; set; }
        public string bottomCabin { get; set; }
    }
}
