function assignProperties(input){
    let firstPropertyName = input[0];
    let firstPropertyValue = input[1];

    let secondPropertyName = input[2];
    let secondPropertyValue = input[3];

    let thirdPropertyName = input[4];
    let thirdPropertyValue = input[5];

    var result = { [firstPropertyName]: firstPropertyValue,
                   [secondPropertyName]: secondPropertyValue,
                   [thirdPropertyName]: thirdPropertyValue};
    console.log(result);
}

assignProperties(['name', 'Pesho', 'age', '23', 'gender', 'male']);
assignProperties(['ssid', '90127461', 'status', 'admin', 'expires', '600']);