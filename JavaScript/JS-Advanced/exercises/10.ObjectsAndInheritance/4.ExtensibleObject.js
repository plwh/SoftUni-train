function extensibleObject () {
    let result = {
        extend: function (template) {
            for(let parentProp of Object.keys(template)) {
                if(typeof(template[parentProp] == 'function')){
                    Object.getPrototypeOf(result)[parentProp] = template[parentProp];
                } else {
                    result[parentProp] = template[parentProp];
                }
            }
        }
    };

    return result;
}


