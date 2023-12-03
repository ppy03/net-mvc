const targetDates = new Date().getTime() + 1000 * 3600 * 24 * 3;
function updateCountdown() {
    const currentDate = new Date().getTime();
    const timeRemaining = targetDates - currentDate;

    if (timeRemaining <= 0) {
        clearInterval(timer);
        document.getElementById("countdown").innerHTML = "Countdown expired!";
        return;
    }

    const days = Math.floor(timeRemaining / (1000 * 60 * 60 * 24));
    const hours = Math.floor((timeRemaining % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    const minutes = Math.floor((timeRemaining % (1000 * 60 * 60)) / (1000 * 60));
    const seconds = Math.floor((timeRemaining % (1000 * 60)) / 1000);

    document.getElementById("days").textContent = days;
    document.getElementById("hours").textContent = hours;
    document.getElementById("minutes").textContent = minutes;
    document.getElementById("seconds").textContent = seconds;
}

const timers = setInterval(updateCountdown, 1000);
updateCountdown();

                    