const CheckSlotsButton = document.getElementById('CheckSlotsButton')

CheckSlotsButton.addEventListener('click', async (e) => {

    const StartDateInput = document.getElementById('StartDateInput')
    const EndDateInput = document.getElementById('EndDateInput')
    const SlotsSection = document.getElementById('SlotsSection')
    const ParkingSlotsTitle = document.getElementById('ParkingSlotsTitle')
    const ErrorMessages = document.getElementById('ErrorMessages')
    const ParkingSlotIdInput = document.getElementById('ParkingSlotId');
    
    e.preventDefault()
    ErrorMessages.style = "display: none;"
    
    const parkingId = window.location.href.split('/').at(-1)
    
    const startDate = StartDateInput.value
    const endDate = EndDateInput.value
    
    if (!startDate || !endDate || new Date(startDate).getTime() < Date.now() || new Date(startDate).getTime() > new Date(endDate).getTime()) {
        ErrorMessages.style = "display: block;"
        ErrorMessages.innerHTML = "Select correct start and end dates. Past dates or dates without specified time are invalid."
        return
    }
    
    const response = await fetch(`/Parking/ParkingSlotsAvailability/${parkingId}`, {
        method: 'POST',
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            startDate: startDate,
            endDate: endDate
        })
    })

    ParkingSlotIdInput.value = "";
    
    for (child of SlotsSection.children) {
        child.classList.remove('inactive')
        child.classList.remove('selected')
        child.setAttribute('onclick', 'activateSlot(this)')
    }
    
    for (const [parkingSlotId, available] of Object.entries(await response.json())) {
        if (!available) {
            const unavailableSlot = document.getElementById(parkingSlotId)
            unavailableSlot.classList.add('inactive')
            unavailableSlot.setAttribute('onclick', '')
        }
    }
    
    ParkingSlotsTitle.innerHTML = `Selected availability: ${startDate} - ${endDate}`
    
})