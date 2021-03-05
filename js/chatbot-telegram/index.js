const TelegramBot  = require('node-telegram-bot-api');
const youtube      = require('./youtube');
const dialogFlow   = require('./dialogFlow')
const functions  = require('./functions')
const config       = require('./keys/telegram.json')
const vocabulario  = require('./vocabulario.json')


const bot = new TelegramBot(config.token, { polling:true });

bot.on('message', async(msg) => { 

	var cumprimentos = vocabulario['cumprimentos'];
	var despedidas   = vocabulario['despedidas'];

	try{

		const chatId =  msg.chat.id; //Specific Chat Id 
		//console.log(chatId);
		//console.log(msg);
		//console.log(msg.text);
		var text = functions.sanitizeText(msg.text);
		var flag = 0 ;

		if (cumprimentos.includes(text)) {
			bot.sendMessage(chatId,vocabulario['inicio']);
			flag = 1;
		}
		if (despedidas.includes(text)) {
			bot.sendMessage(chatId,vocabulario['fim']);
			flag = 1;
		}
		if (text=="/tel") {
			bot.sendMessage(chatId,vocabulario['tel']);
			flag = 1;
		}
		if (text=="/site") {
			bot.sendMessage(chatId,vocabulario['site']);
			flag = 1;
		}
		if (text=="/selecao") {
			bot.sendMessage(chatId,vocabulario['selecao']);
			flag = 1;
		}
		if (text=="/calendario") {
			bot.sendMessage(chatId,vocabulario['calendario']);
			flag = 1;
		}
		if (text=="/videos") {
			textResponse = await youtube.searchVideoURL("Engenharia de transportes","Engenharia de Transportes");
			bot.sendMessage(chatId, textResponse);
			flag = 1;
		}
		
		if (flag==0){
			 
				const dfResponse = await dialogFlow.sendMessage(chatId.toString(), msg.text);

				try {
				let textResponse = dfResponse.text;
				console.log(textResponse);

				 if (dfResponse.intent === 'Vídeos') {
				 	let trick = 'Engenharia de Transportes';
			        textResponse = await youtube.searchVideoURL(textResponse, trick.stringValue);
			    }
			    
			    bot.sendMessage(chatId, textResponse);
				    }
				catch(e) {
				    bot.sendMessage(chatId,"Não entendi. Repita a pergunta."); // trick if DialogFLow doesn't answer
			  	};

		}
	}catch(e) {
	    console.log(e);
	  };
	  
});

