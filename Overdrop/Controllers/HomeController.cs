using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Overdrop.Code.Data.Api.Moralis;
using Overdrop.Code.Services.Interfaces;
using Overdrop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Overdrop.Controllers
{
    public class HomeController : Controller
    {
        private IMoralisService _moralisService;

        private readonly ILogger<HomeController> _logger;
        public HomeController(IMoralisService moralisService, ILogger<HomeController> logger)
        {
            _moralisService = moralisService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _moralisService.SearchNfts(new MoralisNftSearchRequest
            {
                Chain = "eth",
                Filter = "description",
                Limit = 50,
                Para = "art"
            });

            var model = new DefaultSearchResultModel();
            if(result != null)
            {
                model.HeaderSliderData = result?.result?.Result?.Where(x => !string.IsNullOrEmpty(x.DeserializedMetadata?.image_url) && x.DeserializedMetadata?.auction != null && x.DeserializedMetadata.auction.seller?.nickname != null).Select(x => new HeaderSliderData
                {
                    TokenId = x.Token_Id,
                    TokenAddress = x.Token_Address,
                    CreatorImage = x.DeserializedMetadata?.owner?.image ?? string.Empty,
                    CreatorName = x.DeserializedMetadata?.owner?.nickname ?? string.Empty,
                    CurrentPrice = FormatAmount(x.DeserializedMetadata?.auction?.current_price) ?? "0.0",
                    InstantPrice = FormatAmount(x.DeserializedMetadata?.auction?.end_price) ?? "0.0",
                    MainPrice = FormatAmount(x.DeserializedMetadata?.auction?.start_price) ?? "0.0",
                    Name = x.DeserializedMetadata.name,
                    MainSliderImage = x.DeserializedMetadata.image_url_cdn ?? x.DeserializedMetadata.image_url,
                    SellerName = x.DeserializedMetadata.auction?.seller?.nickname ?? "Unknown seller",
                    ReceiverAddress = x.DeserializedMetadata?.owner?.address ?? "No owner address",
                    ContractAddress = x.Token_Address
                }).Take(5).ToList();
            }

            return View(model);
        }

        private static string FormatAmount(string price)
        {
            if(string.IsNullOrWhiteSpace(price))
            {
                return null;
            }

            if (price.Contains('.'))
            {
                var splitString = price.Split('.');
                price = splitString[0] + (splitString[1])[0];
            }
            else
            {
                price = price.Length > 5 ? price.Substring(0, 4) : price;
            }
            return price;
        }

        public IActionResult Profile()
        {
            return View();
        }

        [Route("faq")]
        public IActionResult Faq()
        {
            return View();
        }

        [Route("upload-variants")]
        public IActionResult UploadVariants()
        {
            return View();
        }

        [Route("search/{keyword}")]
        public IActionResult Search(string keyword = "")
        {
            return View();
        }

        [Route("search")]
        public IActionResult Search()
        {
            return View();
        }

        [Route("connect-wallet")]
        public IActionResult ConnectWallet()
        {
            return View();
        }

        [Route("items/{id}")]
        public async Task<IActionResult> Item(string id)
        {
            return View();
        }

        [Route("upload-details")]
        public IActionResult UploadDetails()
        {
            return View();
        }

        [Route("upload-details-multiple")]
        public IActionResult UploadDetailsMultiple()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
