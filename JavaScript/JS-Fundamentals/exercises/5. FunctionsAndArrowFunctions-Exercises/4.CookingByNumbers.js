function cook(input){
    let num = input[0];

    for (let i=1; i<input.length; i++){
        switch(input[i]){
            case "chop":
                num /= 2;
                break;
            case "dice":
                num = Math.sqrt(num);
                break;
            case "spice":
                num++;
                break;
            case "bake":
                num *= 3;
                break;
            case "fillet":
                num -= num * 0.20;
                break;
        }
        console.log(num);
    }
}

cook([32, "chop", "chop", "chop", "chop", "chop"]);
