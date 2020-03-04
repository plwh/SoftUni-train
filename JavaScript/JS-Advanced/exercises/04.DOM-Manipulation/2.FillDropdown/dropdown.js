function addItem() {

    let inputText = document.getElementById('newItemText');
    let inputValue = document.getElementById('newItemValue');

    let option = document.createElement('option');
    option.value = inputValue.value;
    option.textContent = inputText.value;

    document.getElementById('menu').appendChild(option);

    inputText.value = '';
    inputValue.value = '';
}