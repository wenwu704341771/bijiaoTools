using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwarerAchitecture.Modules.MainInterface
{
    public class DailyPricesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string currencyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long amountCNY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double exCurrencyRate { get; set; }
    }

    public class TotalPriceWithTax
    {
        /// <summary>
        /// 
        /// </summary>
        public string currencyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long amountCNY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double exCurrencyRate { get; set; }
    }

    public class TaxPrice
    {
        /// <summary>
        /// 
        /// </summary>
        public string currencyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long amountCNY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double exCurrencyRate { get; set; }
    }

    public class AvgPriceWithOutTax
    {
        /// <summary>
        /// 
        /// </summary>
        public string currencyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long amountCNY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double exCurrencyRate { get; set; }
    }

    public class AvgPriceWithTax
    {
        /// <summary>
        /// 
        /// </summary>
        public string currencyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long amountCNY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double exCurrencyRate { get; set; }
    }

    public class SellerRoomPricesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public long sellerRoomTypeId { get; set; }
        /// <summary>
        /// 精致小单间
        /// </summary>
        public string sellerRoomTypeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isB2bVip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long hid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long adultNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long childerNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> ages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isOuterRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vendor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long isHotelPackage { get; set; }
        /// <summary>
        /// 大促销-免费接送机,免费洗漱用品,矿泉水一瓶,信用住免押金入住,快速确认 单早
        /// </summary>
        public string sellerRatePlan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> gifts { get; set; }
        /// <summary>
        /// 实时预订价商品
        /// </summary>
        public string itemType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long maxReserveAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long nod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long nop { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long maxDays { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hasReceipt { get; set; }
        /// <summary>
        /// 单早
        /// </summary>
        public string breakfirst { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> breakfirstCalList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> refundPolicy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string price { get; set; }
        /// <summary>
        /// 根据酒店所在地当地法规，您可能还需在酒店支付额外税费。
        /// </summary>
        public string bookingNoticeText1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DailyPricesItem> dailyPrices { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TotalPriceWithTax totalPriceWithTax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TaxPrice taxPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AvgPriceWithOutTax avgPriceWithOutTax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AvgPriceWithTax avgPriceWithTax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string copyWriter { get; set; }
        /// <summary>
        /// 美元
        /// </summary>
        public string foreignCurrencyDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long virtualCardSubtractPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long backCash { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long backTicketAmount { get; set; }
        /// <summary>
        /// 退订政策
        /// </summary>
        public string refundDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long minusPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isJu { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string discountPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string discountDescs { get; set; }
        /// <summary>
        /// 信用住
        /// </summary>
        public string paymentType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long paymentTypeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long salesCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isSJYF { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long itemId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> othersDiscounts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long rpId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string quickBuy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string enable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isNewRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long rateId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long quota { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long isMemberPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isFirstStay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> dailyPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string oldBuyUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string newBuyUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string oldItemUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string newItemUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long gid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string autoShip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isDualEleven { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isGuarantee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long immediatelySubtract { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long subtractPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string newYearSpeOffer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long agreement { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long occupancy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> promotionDescArr { get; set; }
        /// <summary>
        /// 年度盛典
        /// </summary>
        public string double12Desc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long totalSubtractAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long totalBackCashAmount { get; set; }
    }

    public class ItemsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string isShowRobot { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long sellerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sellerIcon { get; set; }
        /// <summary>
        /// 遨游国际酒店广州专营店
        /// </summary>
        public string sellerName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long salesCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isB { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isLianMeng { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isTbtrip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SellerRoomPricesItem> sellerRoomPrices { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double sellerScore { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long sellerScoreThanAvg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long orderShipTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string showShipTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long shipTimeThanAvg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long orderSucessRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long successRateThanAvg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isGuojiSeller { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string showNewPeopleCash { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isDualEleven { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string quaGuoji { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isB2bVip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isShowVendorLogoUrl { get; set; }
    }

    public class SellersRoomTypes
    {
        /// <summary>
        /// 
        /// </summary>
        public long total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long totalPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long isOverseas { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long isGangAoTai { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ItemsItem> items { get; set; }
    }

    public class SroomTypesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public long srtId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string b2bVip { get; set; }
        /// <summary>
        /// 精致小单间
        /// </summary>
        public string srtName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long quota { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string englishSrtName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> bedType { get; set; }
        /// <summary>
        /// 有窗
        /// </summary>
        public string windowType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> picUrls { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> facility { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string floor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string recommendPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isHotSale { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string showNewPeopleCash { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isDualEleven { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isLaterPay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long subtractPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long immediatelySubtract { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string newYearSpeOffer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isFirstStay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isMemberPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SellersRoomTypes sellersRoomTypes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long backCash { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string virtualCardSubtractDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> promotionDescArr { get; set; }
        /// <summary>
        /// 年度盛典
        /// </summary>
        public string double12Desc { get; set; }
    }

    public class HotelPriceWithoutTax
    {
        /// <summary>
        /// 
        /// </summary>
        public string currencyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long amountCNY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double exCurrencyRate { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public long subtractPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hotelPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SroomTypesItem> sroomTypes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long isOverseas { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public HotelPriceWithoutTax hotelPriceWithoutTax { get; set; }
    }

    public class RootTBH
    {
        /// <summary>
        /// 
        /// </summary>
        public long code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }
}
