function attachEventsListeners() {
    let buttons = document.querySelectorAll('input[type=\'button\']');

    for (let button of buttons) {
        if(button.id === 'daysBtn') {
            button.addEventListener('click', convertFromDays);
        } else if(button.id == 'hoursBtn') {
            button.addEventListener('click', convertFromHours);
        } else if(button.id == 'minutesBtn') {
            button.addEventListener('click', convertFromMinutes);
        } else if(button.id == 'secondsBtn') {
            button.addEventListener('click', convertFromSeconds);
        }
    }

    function convertFromDays(event) {
        let value = Number(event.target.parentElement.children[1].value);

        document.getElementById('hours').value = value * 24;
        document.getElementById('minutes').value = value * 24 * 60;
        document.getElementById('seconds').value = value * 24 * 60 * 60;
    }

    function convertFromHours(event) {
        let value = Number(event.target.parentElement.children[1].value);

        document.getElementById('days').value = value / 24;
        document.getElementById('minutes').value = value * 60;
        document.getElementById('seconds').value = value * 60 * 60;
    }

    function convertFromMinutes(event) {
        let value = Number(event.target.parentElement.children[1].value);

        document.getElementById('days').value = value / 60 / 24;
        document.getElementById('hours').value = value / 60;
        document.getElementById('seconds').value = value * 60;
    }

    function convertFromSeconds(event) {
        let value = Number(event.target .parentElement.children[1].value);

        document.getElementById('days').value = value / 60 / 60 / 24;
        document.getElementById('hours').value = value / 60 / 60;
        document.getElementById('minutes').value = value / 60;
    }
}