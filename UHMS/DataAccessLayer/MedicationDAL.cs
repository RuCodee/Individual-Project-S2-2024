using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class MedicationDAL
    {
        public async Task CreateMedication(Medication medication)
        {
            using (var connection = DBHelper.OpenConnection())
            {
                var query = @"
                INSERT INTO Medications (Name, CompanyName, PossibleSideEffects, Contraindications, DosageForm, Dosage, UsedFor)
                VALUES (@Name, @CompanyName, @PossibleSideEffects, @Contraindications, @DosageForm, @Dosage, @UsedFor);";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", medication.Name);
                    command.Parameters.AddWithValue("@CompanyName", medication.CompanyName);
                    command.Parameters.AddWithValue("@PossibleSideEffects", medication.PossibleSideEffects ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Contraindications", medication.Contraindications ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DosageForm", medication.DosageForm ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Dosage", medication.Dosage ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@UsedFor", medication.UsedFor ?? (object)DBNull.Value);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public Medication GetMedicationById(int medicationId)
        {
            // retrieve a medication by its ID
            return null;
        }

        public void UpdateMedication(Medication medication)
        {
        }

        public void DeleteMedication(int medicationId)
        {
        }

        public async Task<List<Medication>> GetAllMedications()
        {
            List<Medication> medications = new List<Medication>();
            using (var connection = DBHelper.OpenConnection())
            {
                var query = "SELECT * FROM Medications";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No data found.");
                            return medications;
                        }

                        while (reader.Read())
                        {
                            medications.Add(new Medication
                            {
                                MedicationId = reader.GetInt32(reader.GetOrdinal("MedicationId")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                CompanyName = reader.IsDBNull(reader.GetOrdinal("CompanyName")) ? null : reader.GetString(reader.GetOrdinal("CompanyName")),
                                PossibleSideEffects = reader.IsDBNull(reader.GetOrdinal("PossibleSideEffects")) ? null : reader.GetString(reader.GetOrdinal("PossibleSideEffects")),
                                Contraindications = reader.IsDBNull(reader.GetOrdinal("Contraindications")) ? null : reader.GetString(reader.GetOrdinal("Contraindications")),
                                DosageForm = reader.IsDBNull(reader.GetOrdinal("DosageForm")) ? null : reader.GetString(reader.GetOrdinal("DosageForm")),
                                Dosage = reader.IsDBNull(reader.GetOrdinal("Dosage")) ? null : reader.GetString(reader.GetOrdinal("Dosage")),
                                UsedFor = reader.IsDBNull(reader.GetOrdinal("UsedFor")) ? null : reader.GetString(reader.GetOrdinal("UsedFor"))
                            });
                        }
                    }
                }
            }
            return medications;
        }
    }
}
