
    let currentNumber = 0;

    function increaseNumber() {
        currentNumber++;
    document.getElementById('number').innerHTML = currentNumber;
                                                            }

    function decreaseNumber() {
                                                                if (currentNumber > 0) {
        currentNumber--;
    document.getElementById('number').innerHTML = currentNumber;
                                                                }

                                                            }
