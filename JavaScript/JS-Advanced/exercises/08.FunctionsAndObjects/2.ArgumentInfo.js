function result () {

    let summary = {};

    for (let i = 0; i < arguments.length; i++) {
        let obj = arguments[i];
        let type = typeof obj;
        console.log(type + ': ' + obj);

        if(!summary[type]) {
            summary[type] = 1;
        } else {
            summary[type]++;
        }
    }

    let sortedKeys  = Object.keys(summary).sort(function(a,b){
        return summary[b] - summary[a];
    });

    for (let key of sortedKeys) {
        console.log(`${key} = ${summary[key]}`);
    }

}

result('cat', 42, 45, 46, function () { console.log('Hello world!'); });