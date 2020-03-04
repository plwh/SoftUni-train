function oddOrEven (number) {
    if( number % 1 != 0) {
        console.log('invalid');
    } else if (number % 2 == 0){
        console.log('even');
    } else {
        console.log('odd');
    }
}

oddOrEven(5);
oddOrEven(8);
oddOrEven(1.5);