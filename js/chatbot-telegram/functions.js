function sanitizeText(object){
    return object.toString().toLowerCase().normalize("NFD").replace(/[\u0300-\u036f]/g);
}

module.exports.sanitizeText=sanitizeText;