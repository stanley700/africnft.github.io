"use strict";

(function () {

    $('#place_bid_cancel_btn').click(function () {
        $('#bid_nft_name').text('');
        $('#bid_nft_seller').text('');
    })
})();

function setbidModelContent(obj) {
    console.log('Place a bid button clicked')
    var token_id = $(obj).attr('token_id');
    var nft_name = $(obj).attr('nft_name');
    var nft_seller = $(obj).attr('nft_seller');

    console.log('Token Id: ' + token_id + '; NFT Name: ' + nft_name);

    $('#bid_nft_name').text(nft_name);
    $('#bid_nft_seller').text(nft_seller);

    $('#bid_popup_place_bid').attr('token_id', token_id)
}
