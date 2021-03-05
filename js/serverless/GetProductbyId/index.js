const { ObjectID } = require('mongodb');
const createMongoClient = require('../shared/mongoClient');

module.exports = async function (context, req) {
  const {id} = req.params;
  const { client: MongoClient, closeConnectionFn } = await createMongoClient();//connection
  const Products = MongoClient.collection('products');
  const body = await Products.findOne({ _id: ObjectID(id) });
  closeConnectionFn(); //close connection
  context.res = { status: 200, body };
};