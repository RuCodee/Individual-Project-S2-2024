using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccessLayer;
using Microsoft.Extensions.Logging;

namespace BusinessLogic
{
    public class PatientManager
    {
        private readonly UserManager _userManager;
        private readonly ILogger<PatientManager> _logger;

        public PatientManager(UserManager userManager, ILogger<PatientManager> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<bool> AddPatient(User user)
        {
            try
            {
                // Register the user and let the database trigger handle inserting a patient record
                int userId = await _userManager.RegisterUserAsync(user);
                if (userId > 0)
                {

                    _logger.LogInformation($"Patient registration successful for UserId: {userId}");
                    return true;
                }
                else
                {
                    _logger.LogError("User registration failed, unable to create patient.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occurred during patient registration.");
                return false;
            }
        }

        public MedicalRecord? ViewMedicalRecord(int patientId)
        {
            return null;
        }

        public void BookAppointment(Appointment appointment)
        {
            // logic
        }

        public void AddAllergy(int patientId, Allergy allergy)
        {
            // logic
        }

        public void RemoveAllergy(int patientId, Allergy allergy)
        {
            // logic
        }
    }
}
