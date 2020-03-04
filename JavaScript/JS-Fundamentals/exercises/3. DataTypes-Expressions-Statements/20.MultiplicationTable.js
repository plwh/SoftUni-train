function printMultiplicationTable(n){
    let result = "<table border='1'>\n";

    // print first row
    for (let i=0; i<=n; i++){
        if(i == 0){
            result+= "<tr>";
            result+= "<th>x</th>";
        } else if(i == n) {
            result+= `<th>${i}</th>`;
            result+= "</tr>\n";
        } else {
            result+= `<th>${i}</th>`;
        }
    }

    // print next rows

    for (let row = 1; row <= n; row++ ){
        result += `<tr><th>${row}</th>`;
        for(let col = 1; col <= n; col++){
            result += `<td>${row*col}</td>`;
        }
        result+="</tr>\n";
    }

    result += "</table>";
    return result;
}

printMultiplicationTable(5);
