document.addEventListener("DOMContentLoaded", function () {
    initProfileEdit();
    initPasswordChange();
    initEmergencyContactEdit();
    initParentContactEdit();
});

function initProfileEdit() {
    const editBtn = document.getElementById('editProfileBtn');
    editBtn.addEventListener('click', function (event) {
        event.preventDefault();
        if (editBtn.textContent === "Edit Profile") {
            editBtn.textContent = "Update Profile";
            makeProfileFieldsEditable();
        } else {
            if (validateProfileFields()) {
                revertProfileFields();
                editBtn.textContent = "Edit Profile";
            }
        }
    });

    function makeProfileFieldsEditable() {
        const fieldsToEdit = ['TelephoneNumber', 'EmailAddress', 'HomeAddress'];
        fieldsToEdit.forEach(field => {
            const valueSpan = document.querySelector(`.detail .value[data-field="${field}"]`);
            if (valueSpan) {
                const inputValue = valueSpan.textContent;
                valueSpan.innerHTML = `<input type="text" value="${inputValue}" class="edit-input" data-type="${field}" />`;
            }
        });
        addMessageBelowHomeAddress();
    }

    function revertProfileFields() {
        document.querySelectorAll('.edit-input').forEach(input => {
            const fieldSpan = input.closest('.value');
            fieldSpan.textContent = input.value;
        });
        const messageDiv = document.querySelector('.home-address-message');
        if (messageDiv) {
            messageDiv.remove();
        }
    }

    function validateProfileFields() {
        let isValid = true;
        const phoneNumberInput = document.querySelector('.edit-input[data-type="TelephoneNumber"]');
        const emailInput = document.querySelector('.edit-input[data-type="EmailAddress"]');
        if (phoneNumberInput && !phoneNumberInput.value.match(/^\+\d{12}$/)) {
            alert("Phone number must be in the format + followed by 12 digits.");
            isValid = false;
        }
        if (emailInput && !emailInput.value.match(/^\S+@\S+\.\S+$/)) {
            alert("Please enter a valid email address.");
            isValid = false;
        }
        return isValid;
    }

    function addMessageBelowHomeAddress() {
        const homeAddressDiv = document.querySelector('.detail .value[data-field="HomeAddress"]');
        if (homeAddressDiv) {
            const messageDiv = document.createElement('div');
            messageDiv.style.color = 'red';
            messageDiv.textContent = "Want to change First Name, Last Name, Date Of Birth, Gender or SSN? Please contact it@rumed.com";
            messageDiv.classList.add('home-address-message');
            homeAddressDiv.parentElement.appendChild(messageDiv);
        }
    }
}

function initPasswordChange() {
    const changePasswordBtn = document.querySelector('.change-password-btn');
    const modal = document.getElementById('passwordModal');
    const closeButton = document.querySelector('.close-button');
    const form = document.getElementById('passwordForm');
    const passwordError = document.getElementById('passwordError');

    changePasswordBtn.addEventListener('click', function () {
        modal.style.display = 'block';
    });

    closeButton.addEventListener('click', function () {
        modal.style.display = 'none';
    });

    window.onclick = function (event) {
        if (event.target === modal) {
            modal.style.display = 'none';
        }
    };

    form.onsubmit = function (event) {
        event.preventDefault();
        validateNewPassword();
    };

    function validateNewPassword() {
        const newPassword = document.getElementById('newPassword').value;
        const passwordRegex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*])(?=.{8,})/;
        if (!passwordRegex.test(newPassword)) {
            passwordError.textContent = "Password must have at least 8 characters with lowercase, uppercase, numbers, and special characters.";
            passwordError.style.display = 'block';
        } else {
            passwordError.style.display = 'none';
            console.log('Password is valid, submit the form here.');
        }
    }
}

function initEmergencyContactEdit() {
    const editContactBtn = document.querySelector('.edit-contact-btn');
    const contactDetails = document.querySelector('.contact-section .contact-details');

    editContactBtn.addEventListener('click', function (event) {
        event.preventDefault();
        if (editContactBtn.textContent === "Edit") {
            makeContactFieldsEditable();
            editContactBtn.textContent = "Update";
        } else {
            revertContactFields();
            editContactBtn.textContent = "Edit";
        }
    });

    function makeContactFieldsEditable() {
        const detailSpans = contactDetails.querySelectorAll('.detail .value');
        detailSpans.forEach(span => {
            const input = document.createElement('input');
            input.type = 'text';
            input.value = span.textContent.trim();
            input.classList.add('editable-input');
            span.textContent = '';
            span.appendChild(input);
        });
    }

    function revertContactFields() {
        const detailInputs = contactDetails.querySelectorAll('.detail input');
        detailInputs.forEach(input => {
            const span = input.parentElement;
            span.textContent = input.value;
        });
    }
}

function initParentContactEdit() {
    const editParentContactBtn = document.querySelector('.edit-parent-contact-btn');
    const parentContactDetails = document.querySelector('.contact-section .parent-contact-label + .contact-details');

    editParentContactBtn.addEventListener('click', function (event) {
        event.preventDefault();
        if (editParentContactBtn.textContent === "Edit") {
            makeParentContactFieldsEditable();
            editParentContactBtn.textContent = "Update";
        } else {
            revertParentContactFields();
            editParentContactBtn.textContent = "Edit";
        }
    });

    function makeParentContactFieldsEditable() {
        const detailSpans = parentContactDetails.querySelectorAll('.detail .value');
        detailSpans.forEach(span => {
            const input = document.createElement('input');
            input.type = 'text';
            input.value = span.textContent.trim();
            input.classList.add('editable-input');
            span.textContent = '';
            span.appendChild(input);
        });
    }

    function revertParentContactFields() {
        const detailInputs = parentContactDetails.querySelectorAll('.detail input');
        detailInputs.forEach(input => {
            const span = input.parentElement;
            span.textContent = input.value;
        });
    }
}
