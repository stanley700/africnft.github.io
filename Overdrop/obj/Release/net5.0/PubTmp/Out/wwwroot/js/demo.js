"use strict";

// upload preview show
(function () {
  var preview = $('.js-preview'),
      open = $('.js-preview-open'),
      close = $('.js-preview-close');
  open.on('click', function () {
    preview.addClass('visible');
  });
  close.on('click', function () {
    preview.removeClass('visible');
  });
})(); // card favorite


(function () {
  var favorite = $('.card__favorite, .options__button_favorite');
  favorite.on('click', function () {
    $(this).toggleClass('active');
  });
})(); // activity checkbox toggle


(function () {
  $('.js-activity-select').on('click', function () {
    $('.activity__group .checkbox__input').prop('checked', true).attr('checked', 'checked');
  });
  $('.js-activity-unselect').on('click', function () {
    $('.activity__group .checkbox__input').prop('checked', false).removeAttr('checked');
  });
})(); // popular add


(function () {
  var add = $('.popular__add');
  add.on('click', function () {
    $(this).toggleClass('active');
  });
})(); // connect wallet


(function () {
    /* Moralis init code */
    const serverUrl = "https://k7hima10eexg.usemoralis.com:2053/server";
    const appId = "an9bzw6zzay6R26lzSwPpm0debICNEIdQ0wAzBQI";
    Moralis.start({ serverUrl, appId });

    $('.wallet__link').on('click', function (e) {
        e.preventDefault();
        $('.wallet__link').removeClass('active');
        $(this).addClass('active');
        $('.wallet__bg').hide();
        $('.wallet__item').hide();
        metamaskLogin();
        $('.wallet__item:first-child').show();
    });

    $('.wallet__item:first-child .wallet__button, .wallet__item:first-child .wallet__code').on('click', function (e) {
        $('.wallet__item:first-child').hide();
        $('.wallet__item:nth-child(2)').show();
    });

    $('.wallet__item:nth-child(2) .wallet__button:first-child').on('click', function (e) {
        $('.wallet__link').removeClass('active');
        $('.wallet__item').hide();
        $('.wallet__bg').show();
    });

    $('.wallet__item:nth-child(2) .wallet__button:nth-child(2)').on('click', function () {
        var hash = window.location.hash;
        $(hash).addClass('registered');
    });

    $('.header__link:last-child').on('click', function (e) {
        $('.header__connect').css('display', 'flex');
        $('.header__item_notification').hide();
        $('.header__item_user').hide();
        logOut();
    });

    function showLoginHeader() {
        $('.header__connect').css('display', 'none');
        $('.header__item_notification').show();
        $('.header__item_user').show();
    }

    checkLoginStatus();
    //const user = await Moralis.authenticate({ provider: "walletconnect", chainId: 56 })
    async function metamaskLogin() {
        let user = Moralis.User.current();
        if (!user) {
            //user = await Moralis.authenticate({ type: 'erd' }).then(function (user) {
            //    console.log(user.get('erdAddress'))
            //})
            user = await Moralis.authenticate({ signingMessage: "Log in using Moralis" })
                .then(function (user) {
                    console.log("logged in user:", user);
                    console.log(user.get("ethAddress"));
                    showLoginHeader();
                    console.dir(user);
                })
                .catch(function (error) {
                    console.log(error.message);
                    //console.dir(error);
                    if (error.message.indexOf('enabled browser') >= 0) {
                        var win = window.open('https://metamask.io/download.html', '_blank');
                        if (win) {
                            win.focus();
                        } else {
                            alert('Please allow popups for this website')
                        }
                    }
                });
        } else {
            showLoginHeader()
        }

        //getStats();
    }

    async function checkLoginStatus() {
        let user = Moralis.User.current();
        if (!user) {
            $(".place_a_bid").attr("href", "#popup-connect");
        } else {
            $(".place_a_bid").attr("href", "#popup-bid");
            console.log('Log in user');
            console.log("username: " + user.getUsername());

            var address = user.get("ethAddress");
            $('.header__number').text(address);
            showLoginHeader();
            var res = await Moralis.Web3.getAllERC20();
            console.log('Tokens on ETH')
            console.log(res);

            var balance = 0;
            $.each(res, function (balance_result, dr) {
                console.log(balance_result, dr);
                console.log('Balance:' + dr.balance);
                balance += Number(dr.balance);
                $("#wallet_balance1, #wallet_balance2, #bid_wallet_balance").text(balance);
                $(".header__currency").text(dr.symbol);
            })

            var nfts = await Moralis.Web3.getNFTs();
            console.log('NFTs');
            console.log(nfts);
        }

        //const priveOptions = { address: "0xffbf315f70e458e49229654dea4ce192d26f9b25", days: "3" };
        //const NFTLowestPrice = await Moralis.Web3API.token.getNFTLowestPrice(priveOptions);
        //console.log("Lowest Price")
        //console.log(NFTLowestPrice);


        //const price1 = await Moralis.Web3API.getTokenMetadata(priveOptions);
        //console.log("Price1")
        //console.log(price1);
        //const price = await Moralis.Web3.getAllERC20(priveOptions);
        //const price = await Moralis.Web3API.token.getNFTLowestPrice(priveOptions);


        //const options = { q: "glo", filter: "name" }
        //const Nfts = await Moralis.Web3API.token.searchNFTs(options);
        //$.each(Nfts.result, function (index, item) {
        //    var tokenId = item.token_id;
        //    var tokenAddress = item.token_address;

        //    var metadata = $.parseJSON(item.metadata);
        //    console.log("metedata");
        //    console.log(metadata);
        //    console.log("Name: " + metadata.name);

        //    console.log(metadata.status.is_ready);
            
        //})
        //console.log(Nfts);
    }

    async function logOut() {
        await Moralis.User.logOut();
        console.log("logged out");
        checkLoginStatus();
    }
})();

$(document).ready(function () {
  if (window.location.hash) {
    var hash = window.location.hash;
    $('[data-id="' + hash + '"]').addClass('registered');
  }
});

(function () {
  $('.discover__link, .activity__link, .catalog__link').on('click', function (e) {
    e.preventDefault();
    $('.discover__link, .activity__link, .catalog__link').removeClass('active');
    $(this).addClass('active');
  });
})(); // upload details


$('.preview__clear').on('click', function (e) {
  e.preventDefault();
  $('.field__input').val('');
  $('.select').find('option').attr("selected", false);
  $('.select').find('option:first-child').attr("selected", true);
  $('.select').niceSelect('update');
}); // upload details

$('.catalog__reset').on('click', function (e) {
  e.preventDefault();
  $('.select').find('option').attr("selected", false);
  $('.select').find('option:first-child').attr("selected", true);
  $('.select').niceSelect('update');
  $('.js-slider')[0].noUiSlider.reset();
});
$('.js-popup-close').on("click", function () {
  $.magnificPopup.close();
});
$('.popup_purchase .popup__item .popup__button:first-child').on('click', function () {
  $(this).parents('.popup__item').hide().next().show();
});
$('.footer__note a').on('click', function (e) {
  e.preventDefault();
  $(this).hide();
}); // steps

$('.steps__button').on('click', function () {
  $(this).parents('.steps__item').next().find('.steps__button').removeClass('disabled');
  $(this).parents('.steps__item').addClass('done');
  $(this).addClass('done');
  $(this).text('Done');
});
$('.popup_price .popup__button:first-child').on('click', function () {
  var text = $(this).parents('.popup_price').find('.field__input').val();
  $('.item__currency .item__price:first-child span').text(text);
}); // $('.card__button').on('click', function(){
//     $('.popup__rate').focus();
// });