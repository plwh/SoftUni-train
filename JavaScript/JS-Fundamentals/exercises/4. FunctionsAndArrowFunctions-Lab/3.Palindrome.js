function isPalindrome(input) {
    let result = true;

    for (let i=0, j=input.length-1; i < input.length / 2; i++, j--) {
        if(input[i] != input[j]){
            result = false;
        }
    }

    console.log(result);
}

isPalindrome("haha");
isPalindrome("racecar");
isPalindrome("unitinu");

