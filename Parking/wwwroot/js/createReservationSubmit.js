const CreateReservationButton = document.getElementById('CreateReservationButton')

CreateReservationButton.addEventListener('click', (e) => {
    const StartDateInput = document.getElementById('StartDateInput')
    const EndDateInput = document.getElementById('EndDateInput')
    const ErrorMessages = document.getElementById('ErrorMessages')
    const ParkingSlotIdInput = document.getElementById('ParkingSlotId');
    const startDate = StartDateInput.value
    const endDate = EndDateInput.value

    ErrorMessages.style = "display: none;"

    if (!startDate || !endDate || new Date(startDate).getTime() < Date.now() || new Date(startDate).getTime() > new Date(endDate).getTime()) {
        e.preventDefault()
        ErrorMessages.style = "display: block;"
        ErrorMessages.innerHTML = "Select correct start and end dates. Past dates or dates without specified time are invalid."
    }
    else if (ParkingSlotIdInput.value === "") {
        e.preventDefault()
        ErrorMessages.style = "display: block;"
        ErrorMessages.innerHTML = "Select available parking slot"
    }

    
})