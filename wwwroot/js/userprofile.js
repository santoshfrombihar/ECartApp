
    document.addEventListener('DOMContentLoaded', function () {
        const editButtons = document.querySelectorAll('.edit-address-btn');
        
        editButtons.forEach(button => {
        button.addEventListener('click', function () {
            // Get data from attributes
            const id = this.getAttribute('data-id');
            const type = this.getAttribute('data-type');
            const address = this.getAttribute('data-address');
            const city = this.getAttribute('data-city');
            const district = this.getAttribute('data-district');
            const state = this.getAttribute('data-state');
            const pincode = this.getAttribute('data-pincode');
            const contact = this.getAttribute('data-contact');

            // Set values in modal
            document.getElementById('edit-id').value = id;
            document.getElementById('edit-type').value = type;
            document.getElementById('edit-address').value = address;
            document.getElementById('edit-city').value = city;
            document.getElementById('edit-district').value = district;
            document.getElementById('edit-state').value = state;
            document.getElementById('edit-pincode').value = pincode;
            document.getElementById('edit-contact').value = contact;
        });
        });
    });


document.getElementById('photoInput').onchange = function () {
    // Optional: You can add a loading spinner here
    document.getElementById('photoForm').submit();
};

