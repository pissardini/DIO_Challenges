const YouTube = require('youtube-node');
const config  = require('./keys/youtube.json')

const youtube = new YouTube();
youtube.setKey(config.key);

function searchVideoURL(message,queryText){
	//console.log(queryText.toString());
	return new Promise ((resolve,reject) => {
		youtube.search(queryText.toString(),2, function(error,result){
				if(!error) {
					const videoIds = result.items.map((item) => item.id.videoId).filter(item => item);
					const youtubeLinks = videoIds.map(videoId => `https://www.youtube.com/watch?v=${videoId}`).join(', ');
					resolve(`${message} ${youtubeLinks}`);
				}else{
					resolve('Não foi possível encontrar um vídeo. Por favor tente mais tarde.');
				};
			});	
	});
	
}

module.exports.searchVideoURL = searchVideoURL;