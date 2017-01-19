using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace myWebApplication.Api.Products
{
	public class ProductModel
	{
		[Description("ShopYourWay product ID.")]
		[JsonProperty(PropertyName = "Id")]
		public long Id { get; set; }

		[Description("Product name.")]
		[JsonProperty(PropertyName = "Name")]
		public string Name { get; set; }

		[Description("Product description.")]
		[JsonProperty(PropertyName = "Description")]
		public string Description { get; set; }

		[Description("This is the sale price of the product main buying option. This price is always smaller or equal to the regular price.")]
		[JsonProperty(PropertyName = "Price")]
		public decimal? Price { get; set; }

//		[Description("Product rating (1-5 stars). If not rated, no rating is returned.")]
//		[JsonProperty(PropertyName = "Rating")]
//		public int? Rating { get; set; }

		[Description("URL containing the product image.")]
		[JsonProperty(PropertyName = "ImageUrl")]
		public string ImageUrl { get; set; }

		[Description("URL of the product page in ShopYourWay. This URL is subject to changes in the product name.")]
		[JsonProperty(PropertyName = "ProductUrl")]
		public string ProductUrl { get; set; }

		[Description("ID of the category tag with which the product is associated..")]
		[JsonProperty(PropertyName = "TagId")]
		public long? TagId { get; set; }

		[Description("Category under which the product is listed.")]
		[JsonProperty(PropertyName = "CategoryName")]
		public string CategoryName { get; set; }

		[Description("Product source.")]
		[JsonProperty(PropertyName = "Source")]
		public string Source { get; set; }

		[Description("Sears Inventory Number.")]
		[JsonProperty(PropertyName = "Sin")]
		public string Sin { get; set; }

		[Description("Product ID at the source. For example, if the source is Sears.com, this is the product ID at Sears.com. This field is also known as external product ID.")]
		[JsonProperty(PropertyName = "SourceProductId")]
		public string SourceProductId { get; set; }

		[Description("Number of buying options.")]
		[JsonProperty(PropertyName = "NumberOfBuyingOptions")]
		public int NumberOfBuyingOptions { get; set; }

		[Description("The exact product ID. This ID incorporates the source (like Sears.com or Kmart.com), as well as the product's exact variant (like shirt, red, V-neck, size L).")]
		[JsonProperty(PropertyName = "ItemId")]
		public string ItemId { get; set; }

		[Description("Product availability status, updated once a day.")]
		[JsonProperty(PropertyName = "Availability")]
		public string Availability { get; set; }

		[Description("Number of users who owns the product.")]
		[JsonProperty(PropertyName = "Owns")]
		public int Owns { get; set; }

		[Description("Number of users who wants the product.")]
		[JsonProperty(PropertyName = "Wants")]
		public int Wants { get; set; }

		[Description("Number of users who likes the product.")]
		[JsonProperty(PropertyName = "Likes")]
		public int Likes { get; set; }

		[Description("This is the full retail price of the product.")]
		[JsonProperty(PropertyName = "RegularPrice")]
		public decimal? RegularPrice { get; set; }

		[Description("Shows if the product is exclusive only for ShopYourWay.com")]
		[JsonProperty(PropertyName = "IsExclusive")]
		public bool IsExclusive { get; set; }

		[Description("Shows if the product is ma")]
		[JsonProperty(PropertyName = "IsMapViolated")]
		public bool IsMapViolated { get; set; }
	}
}