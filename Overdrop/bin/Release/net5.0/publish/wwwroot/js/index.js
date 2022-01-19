"use strict";

(function () {
    getNfts();
    async function getNfts() {
        const options = { q: "africa", filter: "name,description", limit: "5" }
        const Nfts = await Moralis.Web3API.token.searchNFTs(options);

        console.log(Nfts);

        //getNftWithBids(Nfts.result);

        //$.each(Nfts.result, function (index, item) {
        //    var tokenId = item.token_id;
        //    var tokenAddress = item.token_address;

        //    var metadata = $.parseJSON(item.metadata);
        //    console.log("metedata");
        //    console.log(metadata);
        //    console.log("Name: " + metadata.name);

        //    if ('status' in metadata) {
        //        console.log(metadata.status.is_ready);
        //    }

        //})
    }

    async function getNftWithBids(nfts) {
        //User Underscore to filter

        const withBids = _.where(nfts, function (item) {
            var hasBids = false;
            if (item.hasOwnProperty('metadata')) {
                var metadata = $.parseJSON(item.metadata);
                hasBids = metadata.hasOwnProperty('auction') && !$.isEmptyObject(metadata.auction) && metadata.auction.hasOwnProperty('nickname') && metadata.hasOwnProperty('is_ready')
            }
            return hasBids;
        });

        //$.each(withBids, function (index, data) {
        //    if (index < 1) {
        //        var item = $.parseJSON(data.metadata);
        //        //console.log('nft');
        //        console.log(item);
        //        $("#main_slider_token_name" + index).text(item.name);
        //        $("#main_slider_image" + index).attr('src', item.image_url_cdn);
        //        $("#main_slider_image" + index).attr('srcSet', item.image_url_cdn);
        //        $("#main_slider_owner_image" + index).attr('src', item.image_url);
        //        $("#main_slider_owner_name" + index).text(item.owner.nickname);
        //        $("#main_slider_owner_name" + index).attr('style', 'text-overflow: ellipsis;width: 14em;white-space: nowrap;');
        //        $("#main_slider_instant_price" + index).text(item.auction.end_price);
        //        $("#main_slider_current_price" + index).text(item.auction.current_price);
        //        $("#main_slider_main_price" + index).text(item.auction.start_price);
        //    }
        //});
        //console.log('With bids');
        //console.log(withBids)

        //var scriptHtml = $("#hidden-nft-with-details").html();
        //console.log(scriptHtml);

        //var template = Handlebars.compile(scriptHtml);
        //var contextObj = template({ nft : withBids });

        //console.log(contextObj);
        ////top_main_bids_section
        //$("#top_main_bids_section").html(contextObj);
    }

    $('#place_bid_cancel_btn').click(function () {
        $('#bid_nft_name').text('');
        $('#bid_nft_seller').text('');
    })

    $("#bid_input_amount").keyup(function () {
        var input_amount = $(this).val();

        var total_bid_amount = parseFloat($("#bid_service_fee").text()) + parseFloat(input_amount);
        $("#bid_total_amount").text(total_bid_amount);
    })

    $('#send_transaction_wallet').click(function () {
        //Transaction amount
        var transaction_amount = parseFloat($("#bid_total_amount").text());
        console.log("total amount: " + transaction_amount);
    })

    $('#bid_popup_place_bid').click(async function () {
        await Moralis.enableWeb3();
        let user = Moralis.User.current();
        if (!user) {
            $(".place_a_bid").attr("href", "#popup-connect");
        } else {
            var receiverAddress = $('#bid_nft_reciever_address').text();
            var contractAddress = $('#bid_token_contract_address').text();
            var tokenId = $('#bid_token_id').text();
            const options = {
                type: "erc721",
                receiver: receiverAddress,
                contractAddress: contractAddress,
                tokenId: tokenId
            }

            console.log('Buy NFT initiated......');
            console.log(options);
            let transaction = await Moralis.transfer(options);

            console.log("response------");
            console.log(transaction);
        }
    })
})();


function setbidModelContent(obj) {
    console.log('Place a bid button clicked')
    var token_id = $(obj).attr('token_id');
    var nft_name = $(obj).attr('nft_name');
    var nft_seller = $(obj).attr('nft_seller');
    var receiver_address = $(obj).attr('nft_reciever_address');
    var nftContractAddress = $(obj).attr('nft_contract_address');

    console.log('Token Id: ' + token_id + '; NFT Name: ' + nft_name);

    $('#bid_nft_name').text(nft_name);
    $('#bid_nft_seller').text(nft_seller);
    $('#bid_nft_reciever_address').text(receiver_address);
    $('#bid_token_contract_address').text(nftContractAddress);
    $('#bid_token_id').text(token_id);

    $('#bid_popup_place_bid').attr('token_id', token_id)
}