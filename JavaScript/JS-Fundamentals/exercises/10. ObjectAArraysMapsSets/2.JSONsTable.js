function solve(input) {
    let html = "&lt;table&gt;\n";
    for (let i = 0; i < input.length; i++) {
        let obj = JSON.parse(input[i]);
        html += '   &lt;tr&gt;\n'+
                    `     &lt;td&gt;${obj['name']}&lt;/td&gt;\n` +
                    `     &lt;td&gt;${obj['position']}&lt;/td&gt;\n` +
                    `     &lt;td&gt;${obj['salary']}&lt;/td&gt;\n` +
                '   &lt;/tr&gt;\n';
    }

    html += "&lt;/table&gt;";
    console.log(html);
}

solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}']);