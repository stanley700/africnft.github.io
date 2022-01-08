/* Moralis init code */
const serverUrl = "https://k7hima10eexg.usemoralis.com:2053/server";
const appId = "an9bzw6zzay6R26lzSwPpm0debICNEIdQ0wAzBQI";
Moralis.start({ serverUrl, appId });

/* TODO: Add Moralis Authentication code */
async function login() {
    let user = Moralis.User.current();
    if (!user) {
      user = await Moralis.authenticate({ signingMessage: "Log in using Moralis" })
        .then(function (user) {
          console.log("logged in user:", user);
          console.log(user.get("ethAddress"));
        })
        .catch(function (error) {
          console.log(error);
        });
    }
  }
  
  async function logOut() {
    await Moralis.User.logOut();
    console.log("logged out");
  }
  
  document.getElementById("btn-login").onclick = login;
  document.getElementById("btn-logout").onclick = logOut;