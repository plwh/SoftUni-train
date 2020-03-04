function createBook(selector, titleName, authorName, isbn) {
    let bookGenerator = (function () {
        let id = 1;
        return function (selector, titleName, authorName, isbn) {
            let selectedDiv = $(selector);
            let bookDiv = $('<div>')
                .attr('id', `book${id}`)
                .css('border', 'none');

            bookDiv.append($('<p>')
                .addClass('title')
                .text(titleName))
                .append($('<p>')
                    .addClass('author')
                    .text(authorName))
                .append($('<p>')
                    .addClass('isbn')
                    .text(isbn))
                .append($('<button>')
                    .text('Select')
                    .on('click',() => {
                        bookDiv.css('border','2px solid blue')
                    }))
                .append($('<button>')
                    .text('Deselect')
                    .on('click',() => {
                        bookDiv.css('border','none')
                    }));

            selectedDiv.append(bookDiv);
            id++;
        }
    }());

    let btn = $('#addBtn');

    btn.on('click', () => {bookGenerator(selector, titleName, authorName, isbn)});
}