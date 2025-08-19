using AdfsaLabAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing;

namespace AdfsaLabAPI.Services
{
    public class LIMSServices
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["LIMSConnection"].ConnectionString;

        public List<Species> GetSpices()
        {
            List<Species> spices = new List<Species>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetSpices", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        spices.Add(new Species
                        {
                            SpeciesId = reader["species_id"].ToString(),
                            SpeciesName = reader["species_name"].ToString()
                        });
                    }
                }
            }

            return spices;
        }

        public List<Tests> GetTest()
        {
            List<Tests> spices = new List<Tests>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetTests", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        spices.Add(new Tests
                        {
                            TestID_id = reader["TestID_id"].ToString(),
                            TestName_name = reader["TestName_name"].ToString(),
                            Test_Rate = Convert.ToDecimal(reader["Test_Rate"])
                        });
                    }
                }
            }

            return spices;
        }

        public List<Location> GetLocation()
        {
            List<Location> spices = new List<Location>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetLocation", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        spices.Add(new Location
                        {
                            LocationId = reader["LocationID"].ToString(),
                            LocationName = reader["LocationName"].ToString()

                        });
                    }
                }
            }

            return spices;
        }

        public List<Reason> GetReason()
        {
            List<Reason> spices = new List<Reason>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetReason", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        spices.Add(new Reason
                        {
                            ReasonID = reader["ReasonID"].ToString(),
                            ReasonDesc = reader["Reason"].ToString()

                        });
                    }
                }
            }

            return spices;
        }

        public List<Mediums> GetMediums()
        {
            List<Mediums> spices = new List<Mediums>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetMediums", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        spices.Add(new Mediums
                        {
                            MediumID = reader["MediumID"].ToString(),
                            MediumDesc = reader["MediumDesc"].ToString()

                        });
                    }
                }
            }

            return spices;
        }

        public List<Specimen> GetSpecimen()
        {
            List<Specimen> spices = new List<Specimen>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetSpecimen", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        spices.Add(new Specimen
                        {
                            SpecimenID = reader["SpecimenID"].ToString(),
                            SpecimenDesc = reader["Specimen"].ToString()

                        });
                    }
                }
            }

            return spices;
        }

        public List<Age> GetAge()
        {
            List<Age> spices = new List<Age>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetAge", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        spices.Add(new Age
                        {
                            AgeID = reader["AgeID"].ToString(),
                            AgeName = reader["AgeName"].ToString()

                        });
                    }
                }
            }

            return spices;
        }
    }
}