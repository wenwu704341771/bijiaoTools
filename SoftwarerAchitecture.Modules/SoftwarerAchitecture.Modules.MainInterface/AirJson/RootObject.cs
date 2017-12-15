using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwarerAchitecture.Modules.MainInterface
{
    public class CabinInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string cabinCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string baseCabinCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cabinStatusCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cabinQuantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string baseCabin4Whole { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> cabinInfoDetail { get; set; }
    }

    public class RuleInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string ruleVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string changeRuleJsonStr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nonendRuleJsonStr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string refundRuleJsonStr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string saleCheckRuleJsonStr { get; set; }
    }

    public class Fare
    {
        /// <summary>
        /// 
        /// </summary>
        public string baseClassFullPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string salePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fdPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fareContainsTax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fareDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string memberLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string referenceTax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currencyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string promotionPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string discount { get; set; }
    }

    public class FareInfoViewItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string paxType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string flightNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tourCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fareBasisCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ei { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string eiComment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string minStay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string maxStay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string weighting { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string baggageAllowance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string validityPeriod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string giftId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RuleInfo ruleInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Fare fare { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> gifts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string productInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fareSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int productIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string flightSearchCacheKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sessionUnitKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string inter { get; set; }
    }

    public class ProductInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string productCode { get; set; }
        /// <summary>
        /// 会员价-经济舱
        /// </summary>
        public string productName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string purpose { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string usage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string discount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ticketDesignatorCode { get; set; }
        /// <summary>
        /// 该促销产品暂只支持会员登录购票。
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> insureTips { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string salingRule { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mileage { get; set; }
    }

    public class DepartureAirport
    {
        /// <summary>
        /// 
        /// </summary>
        public string cityCode { get; set; }
        /// <summary>
        /// 上海
        /// </summary>
        public string cityContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 浦东机场
        /// </summary>
        public string codeContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string terminal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string arriveTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string departTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string distance { get; set; }
    }

    public class ArrivalAirport
    {
        /// <summary>
        /// 
        /// </summary>
        public string cityCode { get; set; }
        /// <summary>
        /// 北京
        /// </summary>
        public string cityContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 首都机场
        /// </summary>
        public string codeContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string terminal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string arriveTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string departTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string distance { get; set; }
    }

    public class MarketingAirline
    {
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 东方航空
        /// </summary>
        public string codeContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string countryCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string flightNumber { get; set; }
    }

    public class OperatingAirline
    {
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 东方航空
        /// </summary>
        public string codeContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string countryCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string flightNumber { get; set; }
    }

    public class Equipment
    {
        /// <summary>
        /// 
        /// </summary>
        public string airEquipType { get; set; }
    }

    public class BookingClassAvail
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> meal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cabinCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cabinStatusCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cabinQuantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string baseCabinCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isAsr { get; set; }
    }

    public class FlightsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DepartureAirport departureAirport { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ArrivalAirport arrivalAirport { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string stopLocationMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string departureDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string arrivalDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int stopQuantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string flightNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string flownMileageQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string stopoverInd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string distance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dateChangeNbr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string specialFlightCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isCodeShareAirline { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isSpecialSeg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string specialSegType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string specialSegNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MarketingAirline marketingAirline { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public OperatingAirline operatingAirline { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Equipment equipment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public BookingClassAvail bookingClassAvail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<BookingClassAvail> bookingClassAvails { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string duration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string stayTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string disneyFlight { get; set; }
    }

    public class OriDestOptionItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int odNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isDirectionInd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string flightNumberGroup { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<FlightsItem> flights { get; set; }
    }

    public class ProductUnitsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int priceItineraryTypeIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string flightNoGroup { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currencyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fareRank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fareSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CabinInfo cabinInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<FareInfoViewItem> fareInfoView { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ProductInfo productInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<OriDestOptionItem> oriDestOption { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string loadFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string priceIcon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string snk { get; set; }
    }

    //public class DepartureAirport
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string cityCode { get; set; }
    //    /// <summary>
    //    /// 上海
    //    /// </summary>
    //    public string cityContext { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string code { get; set; }
    //    /// <summary>
    //    /// 虹桥机场
    //    /// </summary>
    //    public string codeContext { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string terminal { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string gate { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string region { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string arriveTime { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string departTime { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string distance { get; set; }
    //}

    //public class ArrivalAirport
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string cityCode { get; set; }
    //    /// <summary>
    //    /// 北京
    //    /// </summary>
    //    public string cityContext { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string code { get; set; }
    //    /// <summary>
    //    /// 首都机场
    //    /// </summary>
    //    public string codeContext { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string terminal { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string gate { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string region { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string arriveTime { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string departTime { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string distance { get; set; }
    //}

    //public class MarketingAirline
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string code { get; set; }
    //    /// <summary>
    //    /// 东方航空
    //    /// </summary>
    //    public string codeContext { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string countryCode { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string flightNumber { get; set; }
    //}

    //public class OperatingAirline
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string code { get; set; }
    //    /// <summary>
    //    /// 东方航空
    //    /// </summary>
    //    public string codeContext { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string countryCode { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string flightNumber { get; set; }
    //}

    //public class Equipment
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string airEquipType { get; set; }
    //}

    public class BookingClassAvailsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> meal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cabinCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cabinStatusCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cabinQuantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string baseCabinCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isAsr { get; set; }
    }

    //public class FlightsItem
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public int index { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public DepartureAirport departureAirport { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public ArrivalAirport arrivalAirport { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string stopLocationMessage { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string departureDateTime { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string arrivalDateTime { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public int stopQuantity { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string flightNumber { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string flownMileageQty { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string stopoverInd { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string distance { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string dateChangeNbr { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string specialFlightCode { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string isCodeShareAirline { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string isSpecialSeg { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string specialSegType { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string specialSegNumber { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public MarketingAirline marketingAirline { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public OperatingAirline operatingAirline { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public Equipment equipment { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string bookingClassAvail { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public List<BookingClassAvailsItem> bookingClassAvails { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string duration { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string stayTime { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string disneyFlight { get; set; }
    //}

    public class NoPriceOptionsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int odNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isDirectionInd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string flightNumberGroup { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<FlightsItem> flights { get; set; }
    }

    public class ProductAssembleRule
    {
        /// <summary>
        /// 
        /// </summary>
        public string OD_DISCOUNT_I { get; set; }
        /// <summary>
        /// 
        /// </summary>    
        public string INTER_OD { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SCW_OD_MU_FF { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VIRTUAL_J { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMMON_F { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMMON_J { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HYJ_EC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VIRTUAL_J1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMMON_J1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMMON_Y { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SHARE_CZ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMMON_P { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMMON_U { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string COMMON_Y1 { get; set; }
    }

    public class ProductUnitAssemble
    {
    }

    public class ProductTagsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string snk { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string link { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string className { get; set; }
    }

    //public class BookingClassAvailsItem
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public List<string> meal { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string cabinCode { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string cabinStatusCode { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string cabinQuantity { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string baseCabinCode { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public string isAsr { get; set; }
    //}

    public class FlightsAllItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string flightNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<BookingClassAvailsItem> bookingClassAvails { get; set; }
    }

    public class AirResultDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string tripType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ProductUnitsItem> productUnits { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<NoPriceOptionsItem> noPriceOptions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> productCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ProductAssembleRule productAssembleRule { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ProductUnitAssemble productUnitAssemble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string taxCurrency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string packageSaleFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fscKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string odN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ProductTagsItem> productTags { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<FlightsAllItem> flightsAll { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string imageView { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string resultType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string inter { get; set; }
    }

    public class CabinNames
    {
        /// <summary>
        /// 头等舱
        /// </summary>
        public string first { get; set; }
        /// <summary>
        /// 公务舱
        /// </summary>
        public string business { get; set; }
        /// <summary>
        /// 经济舱
        /// </summary>
        public string economy { get; set; }
        /// <summary>
        /// 最低价
        /// </summary>
        public string lowest { get; set; }
        /// <summary>
        /// 更多优惠
        /// </summary>
        public string more { get; set; }
        /// <summary>
        /// 高端舱
        /// </summary>
        public string luxury { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public string sessionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adtNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string chdNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string infNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timeStamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string shopLandFlightResultNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pageNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string travelType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fareType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string resultType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string resultCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string resultMsg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AirResultDto airResultDto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int blockPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string itemType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string intervalTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string taxCurrency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CabinNames cabinNames { get; set; }
    }
}
