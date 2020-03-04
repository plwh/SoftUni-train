function findOccurence(stringToSearch, letter){
    let count = 0;

    for (let i=0; i< stringToSearch.length; i++){
        if(stringToSearch[i] == letter) {
            count++;
        }
    }

    console.log(count);
}

findOccurence('hello', 'l');
findOccurence('panther', 'n');