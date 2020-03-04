function solve(input) {
    let words = input.split(" ");
    let result = new Array();
    let regex = /_[a-zA-Z$0-9]+/g;

    for (let i of words) {
        let match = regex.exec(i);
        while(match){
            if(i.replace(match[0],'').length == 0) {
                result.push(match[0].substring(1));
            }

            match = regex.exec(i);
        }
    }
    console.log(result.join(','));
}

solve("The _id and _age variables are both integers.");
solve("Calculate the _area of the _perfectRectangle object.");
solve("__invalidVariable _evenMoreInvalidVariable_ _validVariable");