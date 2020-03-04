function increment(input) {
    let targetDiv = $(input);

    let textArea = $('<textarea>')
        .addClass('counter')
        .attr('disabled', true)
        .text(0);

    let incrementButton = $('<button>')
        .addClass('btn')
        .attr('id', 'incrementBtn')
        .text('Increment')
        .on('click',increment);

    let addButton = $('<button>')
        .addClass('btn')
        .attr('id', 'addBtn')
        .text('Add')
        .on('click', add);

    let unorderedList = $('<ul>')
        .addClass('results');

    targetDiv.append(textArea);
    targetDiv.append(incrementButton);
    targetDiv.append(addButton);
    targetDiv.append(unorderedList);

    function increment () {
        let textArea = $('textarea.counter');
        textArea.val(Number(textArea.val()) + 1);
    }

    function add () {
        let textAreaValue = $('textarea.counter').val();
        $('.results').append($('<li>').text(textAreaValue));
    }
}