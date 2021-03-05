const dialogflow = require('dialogflow');
const configs = require('./keys/ptr-bot.json');

//create session

const sessionClient = new dialogflow.SessionsClient({
	projectId: configs.project_id,
	credentials: {private_key: configs.private_key,client_email: configs.client_email}
});


async function sendMessage(chatId, message){
	//const sessionClient = new dialogflow.SessionsClient();
	//console.log(chatId);
	//console.log(message);
	try{
		const sessionPath = sessionClient.sessionPath(configs.project_id, chatId);
		const request = {
			session: sessionPath,
			queryInput:{}
		};

	    const textQueryInput = { text: { text: message, languageCode: 'pt-BR' } };
	    const eventQueryInput = { event: { name: 'start', languageCode: 'pt-BR' }};
		request.queryInput = message === '/start' ?  eventQueryInput : textQueryInput;
		
		//console.log(request);
		//send and receive
		const responses = await sessionClient.detectIntent(request);
		//console.log(responses);
		const result = responses[0].queryResult;
		//console.log(JSON.stringify(result,null,2));
		 //console.log(result.fulfillmentText);
		 return { text: result.fulfillmentText, intent: result.intent.displayName, fields: result.parameters.fields };
		 //return { text: result.fulfillmentText};
	}catch(e) {
	    console.log(e); 
	  };
};

//export functions

module.exports.sendMessage = sendMessage;

