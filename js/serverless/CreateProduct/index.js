const createMongoClient = require('../shared/mongoClient');

module.exports = async function (context, req) {
    const product = req.body || {};

	console.log(req.body);
	if (product) context.res = {status: 400,body: 'Product is required'};

    const {client:MongoClient, closeConnectionFn} =  await createMongoClient();//connection
    const Products = MongoClient.collection('products');

    try {
		const res = await Products.insert(product);
		closeConnectionFn(); //close connection
		context.res = {status: 201, body:res};
	}catch(error){
		context.res = {status: 500, body:'Error inserting the product'};
	}
};