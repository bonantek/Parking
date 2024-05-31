
const activateSlot = (selectedSlot) => {
    const grid = document.getElementById('SlotsSection')
    for (slot of grid.children) {
        slot.classList.remove('selected')
    }
    selectedSlot.classList.add('selected')
    
    const parkingSlotIdInput = document.getElementById('ParkingSlotId')
    parkingSlotIdInput.value = selectedSlot.id;
}