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

    getStats();
  }
  
  async function logOut() {
    await Moralis.User.logOut();
    console.log("logged out");
  }
  function getStats() {
    const user = Moralis.User.current();
    if (user) {
      getUserTransactions(user);
    }
  }
  
  async function getUserTransactions(user) {
    // create query
    const query = new Moralis.Query("EthTransactions");
    query.equalTo("from_address", user.get("ethAddress"));
  
    // run query
    const results = await query.find();
    console.log("user transactions:", results);
  }
  
  async function getUserTransactions(user) {
    // create query
    const query = new Moralis.Query("EthTransactions");
    query.equalTo("from_address", user.get("ethAddress"));
  
    // subscribe to query updates ** add this**
    const subscription = await query.subscribe();
    handleNewTransaction(subscription);
  
    // run query
    const results = await query.find();
    console.log("user transactions:", results);
  }
  
  async function handleNewTransaction(subscription) {
    // log each new transaction
    subscription.on("create", function(data) {
      console.log("new transaction: ", data);
    });
  }

  // REAL-TIME TRANSACTIONS
  async function handleNewTransaction(subscription) {
    // log each new transaction
    subscription.on("create", function (data) {
      console.log("new transaction: ", data);
    });
  }

  // CLOUD FUNCTION
  async function getAverageGasPrices() {
    const results = await Moralis.Cloud.run("getAvgGas");
    console.log("average user gas prices:", results);
    renderGasStats(results);
  }

  function renderGasStats(data) {
    const container = document.getElementById("gas-stats");
    container.innerHTML = data
      .map(function (row, rank) {
        return `<li>#${rank + 1}: ${Math.round(row.avgGas)} gwei</li>`;
      })
      .join("");
  }

  // get stats on page load
  getStats();


//document.getElementById("metamaskAnchor").onclick = login;
//document.getElementById("btn-logout").onclick = logOut;
//document.getElementById("btn-get-stats").onclick = getStats;
