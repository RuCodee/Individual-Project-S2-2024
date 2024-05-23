using BusinessLogic;
using DataAccessLayer.UnitTestInterfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApp.Pages
{
    [Authorize(Roles = "Patient")]
    public class PrescriptionMRecordWebModel : PageModel
    {
        private readonly MedicalRecordManager _medicalRecordManager;
        private readonly ILogger<PrescriptionMRecordWebModel> _logger;

        public List<PrescriptionMedicalRecord> MedicalRecords { get; set; }

        [BindProperty(SupportsGet = true)]
        public int UserId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string VisitDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string VisitType { get; set; }

        [BindProperty(SupportsGet = true)]
        public string DoctorName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Symptoms { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Diagnosis { get; set; }

        public PrescriptionMRecordWebModel(MedicalRecordManager medicalRecordManager, ILogger<PrescriptionMRecordWebModel> logger)
        {
            _medicalRecordManager = medicalRecordManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                if (UserId <= 0)
                {
                    return NotFound("Invalid user ID.");
                }

                _logger.LogInformation("Fetching medical records for user ID: {UserId}", UserId);
                _logger.LogInformation("Filters - VisitDate: {VisitDate}, VisitType: {VisitType}, DoctorName: {DoctorName}, Symptoms: {Symptoms}, Diagnosis: {Diagnosis}", VisitDate, VisitType, DoctorName, Symptoms, Diagnosis);

                MedicalRecords = await _medicalRecordManager.GetFilteredPrescriptionRecords(UserId, VisitDate, VisitType, DoctorName, Symptoms, Diagnosis);
                if (MedicalRecords == null || MedicalRecords.Count == 0)
                {
                    _logger.LogWarning($"No medical records found for user ID: {UserId}");
                    return NotFound("No medical records found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching medical records for user ID: {UserId}");
                return StatusCode(500, "An error occurred while fetching medical records.");
            }

            return Page();
        }
    }
}