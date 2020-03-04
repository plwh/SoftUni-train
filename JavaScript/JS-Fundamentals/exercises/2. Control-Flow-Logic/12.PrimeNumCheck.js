function checkPrime (num) {
    let isPrime = true;
    for (let i=2; i<= Math.sqrt(num); i++){
        if(num % i == 0){
            isPrime = false;
            break;
        }
    }

    console.log(isPrime);
}

checkPrime(7);
checkPrime(8);
checkPrime(81);