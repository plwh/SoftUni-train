function composeHTMLtag (input){

    let source = input[0];
    let alternateText = input[1];

    console.log(`<img src="${source}" alt="${alternateText}">`);
}

composeHTMLtag(['smiley.gif', 'Smiley Face']);