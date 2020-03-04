function printTriangle(n) {
    let lineToPrint = '';
    for (let i=1; i<=n; i++){
        console.log(lineToPrint+='$');
    }
}

printTriangle(4);