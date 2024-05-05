using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLogic;
using Domain;
using DataAccessLayer;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly UserManager _userManager;
        private readonly PatientManager _patientManager;
        private readonly DoctorManager _doctorManager;
        private readonly AdministratorManager _administratorManager;
        private readonly ILogger<RegistrationModel> _logger;

        public RegistrationModel(UserManager userManager, PatientManager patientManager, DoctorManager doctorManager, AdministratorManager administratorManager, ILogger<RegistrationModel> logger)
        {
            _userManager = userManager;
            _patientManager = patientManager;
            _doctorManager = doctorManager;
            _administratorManager = administratorManager;
            _logger = logger; // Store the injected logger
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel(); // Initializes InputModel

        public void OnGet()
        {
        }

        public class InputModel
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            [Required(ErrorMessage = "Date of birth is required.")]
            public DateTime DateOfBirth { get; set; }
            public Gender Gender { get; set; }
            [Required(ErrorMessage = "Telephone number is required.")]
            [RegularExpression(@"^\+[0-9]{11,14}$", ErrorMessage = "Telephone number must start with + followed by 11 to 14 digits.")]
            public string? TelephoneNumber { get; set; }
            [Required(ErrorMessage = "SSN is required.")]
            [RegularExpression(@"^\d{9}$", ErrorMessage = "SSN must be exactly 9 digits.")]
            public string? SSN { get; set; }
            public string? EmailAddress { get; set; }
            public string? HomeAddress { get; set; }
            public string? Password { get; set; }
            public Role Role { get; set; }
            public string? DoctorJobId { get; set; }
            public Specialization? Specialization { get; set; }
            public string? AdministratorJobId { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("Starting user registration process.");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid. User data: {Email}", Input.EmailAddress); // Log email for tracing without sensitive data
                return Page();
            }

            // Prepare user object for registration
            var user = new User
            {
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                DateOfBirth = Input.DateOfBirth,
                Gender = Input.Gender,
                TelephoneNumber = Input.TelephoneNumber,
                SSN = Input.SSN,
                EmailAddress = Input.EmailAddress,
                HomeAddress = Input.HomeAddress,
                Password = Input.Password,
                Role = Input.Role
            };

            try
            {
                int userId = await _userManager.RegisterUserAsync(user);
                _logger.LogInformation($"User registered with ID: {userId}, Role: {Input.Role}");

                if (userId <= 0)
                {
                    _logger.LogWarning("Registration failed, no user ID returned.");
                    throw new Exception("Registration failed, no user ID returned.");
                }

                // Handle specific roles
                switch (Input.Role)
                {
                    case Role.Patient:
                        await _patientManager.AddPatient(new Patient { Id = userId});
                        _logger.LogInformation("Patient record and medical record created successfully for User ID: {UserId}", userId);
                        break;

                    case Role.Doctor:
                        await _doctorManager.AddDoctor(new Doctor { Id = userId, DoctorJobId = Input.DoctorJobId, Specialization = Input.Specialization.GetValueOrDefault() });
                        _logger.LogInformation("Doctor record created successfully for User ID: {UserId}", userId);
                        break;

                    case Role.Administrator:
                        await _administratorManager.AddAdministrator(new Administrator { Id = userId, AdministratorJobId = Input.AdministratorJobId });
                        _logger.LogInformation("Administrator record created successfully for User ID: {UserId}", userId);
                        break;
                }

                return RedirectToPage("/Login");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registration process failed for User: {Email}", Input.EmailAddress);
                ModelState.AddModelError("", "Registration failed: " + ex.Message);
                return Page();
            }
        }
    }
}