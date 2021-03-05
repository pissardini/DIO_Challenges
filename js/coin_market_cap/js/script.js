let apikey = {
	key: INSERT_YOUR_API_KEY_HERE
}


function pretty_data(data){
	return data.split("T")[0];
}


fetch('https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?CMC_PRO_API_KEY='+
	apikey.key).
	then ((response) =>{
		//200
		if (!response.ok) throw new Error ('Error executing the request, status' + response.status);
		return response.json();

	}).
	then((api)=> {
		var text = "";

		for(let i=0;i<10;i++){

			text = text + '<div class="media"><img src="img/coin.jpg" class="align-self-center mr-3" alt="coin" width="100" height="60"><div class="media-body">'+
				  '<h5 class="mt-2">'+ api.data[i].name + '</h5>' +
				  '<p>'+api.data[i].symbol+'- First Historical Data : ' + pretty_data(api.data[i].date_added)+'</p>'+
				  '<p> Quote (US$): '+ Number(api.data[i].quote.USD.price).toFixed(2)+'</p></div></div>';
			document.getElementById("coins").innerHTML=texto;
		}

		console.log(api.data);
	}).
	catch((error)=> { 
		console.error(error.message);
	});