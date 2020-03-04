function printNumsInReverse(lines){
    let result = "";
    for(let i in lines){
        result += lines[lines.length-i - 1] + "\n";
    }
    
    return result;
}