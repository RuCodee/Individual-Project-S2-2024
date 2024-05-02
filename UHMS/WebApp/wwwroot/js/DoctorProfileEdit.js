document.addEventListener("DOMContentLoaded", function () {
    initProfileEdit();
    initPasswordChange();
    initClinicInfoEdit();
});

function initProfileEdit() {
    const editBtn = document.getElementById('editProfileBtn');
    editBtn.addEventListener('click', function (event) {
        event.preventDefault();
        toggleEditState(editBtn);
    });
}

function toggleEditState(button) {
    const isEditing = button.textContent.includes("Edit Profile");
    button.textContent = isEditing ? "Update Profile" : "Edit Profile";
    const fieldsToEdit = ['TelephoneNumber', 'EmailAddress', 'HomeAddress'];

    fieldsToEdit.forEach(field => {
        const detailValue = document.querySelector(`.detail .value[data-field="${field}"]`);
        if (detailValue) {
            if (isEditing) {
                const inputValue = detailValue.textContent.trim();
                detailValue.innerHTML = `<input type="text" value="${inputValue}" class="edit-input" data-type="${field}" />`;
            } else {
                const inputElement = detailValue.querySelector('input');
                detailValue.textContent = inputElement ? inputElement.value : detailValue.textContent;
                if (!isEditing) updateProfileDetails(); // Save changes when toggling off edit mode
            }
        }
    });

    if (isEditing) {
        addMessageBelowHomeAddress();
    } else {
        removeMessageBelowHomeAddress();
    }
}

function addMessageBelowHomeAddress() {
    const homeAddressDiv = document.querySelector('.detail .value[data-field="HomeAddress"]');
    if (homeAddressDiv && !document.querySelector('.home-address-message')) {
        const messageDiv = document.createElement('div');
        messageDiv.style.color = 'red';
        messageDiv.textContent = "Want to change First Name, Last Name, Date Of Birth, Gender or SSN? Please contact it@rumed.com";
        messageDiv.classList.add('home-address-message');
        homeAddressDiv.parentElement.appendChild(messageDiv);
    }
}

function removeMessageBelowHomeAddress() {
    const messageDiv = document.querySelector('.home-address-message');
    if (messageDiv) {
        messageDiv.remove();
    }
}

function updateProfileDetails() {
    console.log('Profile details updated');
}

function initPasswordChange() {
    const changePasswordBtn = document.querySelector('.change-password-btn');
    const closeButton = document.querySelector('.password-modal .close');
    const modal = document.getElementById('passwordModal');

    changePasswordBtn.addEventListener('click', function () {
        modal.style.display = 'block';
    });

    closeButton.addEventListener('click', function () {
        modal.style.display = 'none';
    });

    window.addEventListener('click', function (event) {
        if (event.target === modal) {
            modal.style.display = 'none';
        }
    });

    document.getElementById('passwordForm').addEventListener('submit', function (event) {
        event.preventDefault();
        submitNewPassword();
    });
}

function submitNewPassword() {
    const currentPassword = document.getElementById('currentPassword').value;
    const newPassword = document.getElementById('newPassword').value;
    const confirmNewPassword = document.getElementById('confirmNewPassword').value;

    if (newPassword !== confirmNewPassword) {
        alert('New passwords do not match.');
        return;
    }

    console.log('Submitting new password...');
}

function initClinicInfoEdit() {
    const editBtn = document.querySelector('.edit-contact-btn');
    editBtn.addEventListener('click', function (event) {
        event.preventDefault();
        const isEditing = editBtn.textContent === "Edit";
        editBtn.textContent = isEditing ? "Save" : "Edit";
        toggleClinicFields(isEditing);
    });
}

function toggleClinicFields(editing) {
    const fields = document.querySelectorAll('.contact-details .value');
    const editBtn = document.querySelector('.edit-contact-btn');
    console.log('Editing state:', editing);

    if (editing) {
        // Switch to input fields for editing
        fields.forEach(field => {
            let fieldValue = field.textContent;
            field.innerHTML = `<input type="text" value="${fieldValue}" class="edit-input" />`;
        });
        editBtn.textContent = 'Save';
    } else {
        // Check if all fields are filled before sending data to server
        const allFieldsFilled = Array.from(fields).every(field => {
            const inputElement = field.querySelector('input');
            if (inputElement && !inputElement.value.trim()) {
                alert("All fields must be filled out.");
                return false;
            }
            return true;
        });

        if (!allFieldsFilled) return;

        function updateClinicDetails(callback) {
            const updatedInfo = {
                clinicAddress: document.querySelector('[data-field="ClinicAddress"] input').value,
                clinicCity: document.querySelector('[data-field="ClinicCity"] input').value,
                clinicPCode: document.querySelector('[data-field="ClinicPCode"] input').value,
                clinicPhone: document.querySelector('[data-field="ClinicPhone"] input').value,
                clinicEmail: document.querySelector('[data-field="ClinicEmail"] input').value
            };

            fetch('/api/updateClinicInfo', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(updatedInfo)
            })
                .then(response => {
                    if (!response.ok) throw new Error('Network response was not ok.');
                    return response.json();
                })
                .then(data => {
                    console.log('Success:', data);
                    alert('Clinic information updated successfully!');
                    callback(); // Update UI
                })
                .catch(error => {
                    console.error('Error:', error);
                    alert('Failed to update clinic information.');
                });
        }
    }
}