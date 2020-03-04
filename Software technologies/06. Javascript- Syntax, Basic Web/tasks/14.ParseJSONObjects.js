function parseJSONObjects(input){
    var result = new Array();

    for(let line of input){
        let str = line;
        let obj = JSON.parse(str);

        result.push(obj);
    }

    result.forEach(element => {
        console.log("Name: " + element.name);
        console.log("Age: " + element.age);
        console.log("Date: " + element.date);
    });
}