function printFormattedData(input) {
    let body = "";

    for (let i=0; i < input.length; i++)
    {
        if(i % 2 == 0) {
            body +=
            ` <question>
            ${input[i]}
         </question>`;
        } else {
            body +=
            `        <answer>
            ${input[i]}
         </answer>`;
        }

        if( i != input.length - 1){
            body += "\n";
        }
    }

    let result = `
    <?xml version="1.0" encoding="UTF-8"?>
    <quiz>
        ${body}
    </quiz>
    `;

    console.log(result);
}

printFormattedData(["Dry ice is a frozen form of which gas?",
    "Carbon Dioxide",
    "What is the brightest star in the night sky?",
    "Sirius"]);