using AdfsaLabAPI.Filters;
using AdfsaLabAPI.Models;
using AdfsaLabAPI.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;

namespace AdfsaLabAPI.Controllers
{
    [ApiKeyAuthorize]
    public class LIMSController : ApiController
    {
        private LIMSServices _LIMSService = new LIMSServices();

        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["LIMSConnection"].ConnectionString;

        [HttpGet]
        [Route("api/LIMS/GetSpices")]
        public IHttpActionResult GetSpices()
        {
            try
            {
                var spices = _LIMSService.GetSpices();

                if (spices.Count == 0)
                {
                    return Content(System.Net.HttpStatusCode.BadRequest, new
                    {
                        resourceType = "OperationOutcome",
                        issue = new[]
                        {
                            new {
                                severity = "error",
                                code = "value-missing",
                                details = new { text = "data not available" },
                                expression = new string[]{""}
                            }
                        }
                    });
                }

                return Content(System.Net.HttpStatusCode.Accepted, new
                {
                    Status = "SUCCESS",
                    Data = new
                    {
                        species = spices
                    },
                    Error = new object[] { } // empty if no errors
                });
            }
            catch (System.Exception ex)
            {
                return Content(System.Net.HttpStatusCode.Accepted, new
                {
                    Status = "ERROR",
                    Data = new object() { },
                    Error = new[]
                    {
                        new {
                            Code = "EXCEPTION",
                            message = ex.Message,
                            severity = "Fatal"
                        }
                    }
                });
            }
        }


        [HttpGet]
        [Route("api/LIMS/GetTests")]
        public IHttpActionResult GetTests()
        {
            try
            {
                var tests = _LIMSService.GetTest();

                if (tests.Count == 0)
                {
                    return Content(System.Net.HttpStatusCode.BadRequest, new
                    {
                        resourceType = "OperationOutcome",
                        issue = new[]
                        {
                            new {
                                severity = "error",
                                code = "value-missing",
                                details = new { text = "data not available" },
                                expression = new string[]{""}
                            }
                        }
                    });
                }

                return Content(System.Net.HttpStatusCode.Accepted, new
                {
                    Status = "SUCCESS",
                    Data = new
                    {
                        Tests = tests
                    },
                    Error = new object[] { } // empty if no errors
                });
            }
            catch (System.Exception ex)
            {
                return Content(System.Net.HttpStatusCode.Accepted, new
                {
                    Status = "ERROR",
                    Data = new object() { },
                    Error = new[]
                    {
                        new {
                            Code = "EXCEPTION",
                            message = ex.Message,
                            severity = "Fatal"
                        }
                    }
                });
            }
        }


        [HttpGet]
        [Route("api/LIMS/GetLocation")]
        public IHttpActionResult GetLocation()
        {
            try
            {
                var sLocation = _LIMSService.GetLocation();

                if (sLocation.Count == 0)
                {
                    return Content(System.Net.HttpStatusCode.BadRequest, new
                    {
                        resourceType = "OperationOutcome",
                        issue = new[]
                        {
                            new {
                                severity = "error",
                                code = "value-missing",
                                details = new { text = "data not available" },
                                expression = new string[]{""}
                            }
                        }
                    });
                }

                return Content(System.Net.HttpStatusCode.Accepted, new
                {
                    Status = "SUCCESS",
                    Data = new
                    {
                        Locations = sLocation
                    },
                    Error = new object[] { } // empty if no errors
                });
            }
            catch (System.Exception ex)
            {
                return Content(System.Net.HttpStatusCode.Accepted, new
                {
                    Status = "ERROR",
                    Data = new object() { },
                    Error = new[]
                    {
                        new {
                            Code = "EXCEPTION",
                            message = ex.Message,
                            severity = "Fatal"
                        }
                    }
                });
            }
        }

        [HttpGet]
        [Route("api/LIMS/GetReason")]
        public IHttpActionResult GetReason()
        {
            try
            {
                var sReason = _LIMSService.GetReason();

                if (sReason.Count == 0)
                {
                    return Content(System.Net.HttpStatusCode.BadRequest, new
                    {
                        resourceType = "OperationOutcome",
                        issue = new[]
                        {
                            new {
                                severity = "error",
                                code = "value-missing",
                                details = new { text = "data not available" },
                                expression = new string[]{""}
                            }
                        }
                    });
                }

                return Content(System.Net.HttpStatusCode.Accepted, new
                {
                    Status = "SUCCESS",
                    Data = new
                    {
                        Reasons = sReason
                    },
                    Error = new object[] { } // empty if no errors
                });
            }
            catch (System.Exception ex)
            {
                return Content(System.Net.HttpStatusCode.Accepted, new
                {
                    Status = "ERROR",
                    Data = new object() { },
                    Error = new[]
                    {
                        new {
                            Code = "EXCEPTION",
                            message = ex.Message,
                            severity = "Fatal"
                        }
                    }
                });
            }
        }

        [HttpGet]
        [Route("api/LIMS/GetMediums")]
        public IHttpActionResult GetMediums()
        {
            try
            {
                var sMediums = _LIMSService.GetMediums();

                if (sMediums.Count == 0)
                {
                    return Content(System.Net.HttpStatusCode.BadRequest, new
                    {
                        resourceType = "OperationOutcome",
                        issue = new[]
                        {
                            new {
                                severity = "error",
                                code = "value-missing",
                                details = new { text = "data not available" },
                                expression = new string[]{""}
                            }
                        }
                    });
                }

                return Content(System.Net.HttpStatusCode.Accepted, new
                {
                    Status = "SUCCESS",
                    Data = new
                    {
                        Mediums = sMediums
                    },
                    Error = new object[] { } // empty if no errors
                });
            }
            catch (System.Exception ex)
            {
                return Content(System.Net.HttpStatusCode.Accepted, new
                {
                    Status = "ERROR",
                    Data = new object() { },
                    Error = new[]
                    {
                        new {
                            Code = "EXCEPTION",
                            message = ex.Message,
                            severity = "Fatal"
                        }
                    }
                });
            }
        }

        [HttpGet]
        [Route("api/LIMS/GetTestGroups")]
        public IHttpActionResult GetSpecimen()
        {
            try
            {
                var sSpecimen = _LIMSService.GetSpecimen();

                if (sSpecimen.Count == 0)
                {
                    return Content(System.Net.HttpStatusCode.BadRequest, new
                    {
                        resourceType = "OperationOutcome",
                        issue = new[]
                        {
                            new {
                                severity = "error",
                                code = "value-missing",
                                details = new { text = "data not available" },
                                expression = new string[]{""}
                            }
                        }
                    });
                }

                return Content(System.Net.HttpStatusCode.Accepted, new
                {
                    Status = "SUCCESS",
                    Data = new
                    {
                        Specimens = sSpecimen
                    },
                    Error = new object[] { } // empty if no errors
                });
            }
            catch (System.Exception ex)
            {
                return Content(System.Net.HttpStatusCode.Accepted, new
                {
                    Status = "ERROR",
                    Data = new object() { },
                    Error = new[]
                    {
                        new {
                            Code = "EXCEPTION",
                            message = ex.Message,
                            severity = "Fatal"
                        }
                    }
                });
            }
        }

        [HttpGet]
        [Route("api/LIMS/GetAge")]
        public IHttpActionResult GetAge()
        {
            try
            {
                var sAge = _LIMSService.GetAge();

                if (sAge.Count == 0)
                {
                    return Content(System.Net.HttpStatusCode.BadRequest, new
                    {
                        resourceType = "OperationOutcome",
                        issue = new[]
                        {
                            new {
                                severity = "error",
                                code = "value-missing",
                                details = new { text = "data not available" },
                                expression = new string[]{""}
                            }
                        }
                    });
                }

                return Content(System.Net.HttpStatusCode.Accepted, new
                {
                    Status = "SUCCESS",
                    Data = new
                    {
                        Age = sAge
                    },
                    Error = new object[] { } // empty if no errors
                });
            }
            catch (System.Exception ex)
            {
                return Content(System.Net.HttpStatusCode.Accepted, new
                {
                    Status = "ERROR",
                    Data = new object() { },
                    Error = new[]
                    {
                        new {
                            Code = "EXCEPTION",
                            message = ex.Message,
                            severity = "Fatal"
                        }
                    }
                });
            }
        }


        [HttpPost]
        [Route("api/LIMS/labtestrequest")]
        public IHttpActionResult InsertLabTestRequest([FromBody] LabTestRequest request)
        {
            if (request == null || request.Animal == null)
                return Ok(new { status = "ERROR", order_id = (string)null, message = "Invalid request payload" });

            int labCaseCode = 0;
            string orderId = request.Animal.Animals?.FirstOrDefault()?.Animal_Id ?? request.Animal.Species; // fallback for example

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // 1️⃣ Insert into Lab_Submissions
                using (SqlCommand cmd = new SqlCommand("sp_InsertLabTestRequest", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LabCaseID", request.LabCaseID ?? ""); 
                    cmd.Parameters.AddWithValue("@Specie", request.Animal.Animals?.FirstOrDefault()?.Name ?? "");
                    cmd.Parameters.AddWithValue("@Age", request.Animal.Animals?.FirstOrDefault()?.Age ?? "");
                    cmd.Parameters.AddWithValue("@Gender", request.Animal.Animals?.FirstOrDefault()?.Gender ?? "");
                    cmd.Parameters.AddWithValue("@Location", request.Animal.Emirate_Or_Location ?? "");
                    cmd.Parameters.AddWithValue("@Reason", DBNull.Value);
                    cmd.Parameters.AddWithValue("@OwnerId", request.Animal.Owner_Id ?? "");
                    cmd.Parameters.AddWithValue("@OwnerEmiratesId", request.Animal.Owner_Emirates_Id ?? "");
                    cmd.Parameters.AddWithValue("@OwnerEmail", request.Animal.Owner_Email ?? "");
                    cmd.Parameters.AddWithValue("@OwnerPhone", request.Animal.Owner_Phone_Number ?? "");
                    cmd.Parameters.AddWithValue("@BatchCategory", request.Animal.Batch_Category ?? "");
                    cmd.Parameters.AddWithValue("@Region", request.Animal.Region ?? "");
                    cmd.Parameters.AddWithValue("@Area", request.Animal.Area ?? "");
                    cmd.Parameters.AddWithValue("@CreatedBy", "SYSTEM");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            labCaseCode = Convert.ToInt32(reader["LabCaseCode"]);
                    }
                }

                // 2️⃣ Insert tests into Lab_Samples
                if (request.Animal.Tests != null && request.Animal.Tests.Any())
                {
                    foreach (var test in request.Animal.Tests)
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_InsertLabSample", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@LabCaseCode", labCaseCode);
                            cmd.Parameters.AddWithValue("@GroupNumber", test.Group_Code ?? "");
                            cmd.Parameters.AddWithValue("@Specimen", test.Sample_Type ?? "");
                            cmd.Parameters.AddWithValue("@Medium", DBNull.Value);
                            cmd.Parameters.AddWithValue("@UniqueID", test.Test_Code ?? "");
                            cmd.Parameters.AddWithValue("@IsActive", 1);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            return Ok(new
            {
                status = "SUCCESS",
                order_id = request.LabCaseID,  
                lab_case_code = labCaseCode,
                message = "Lab test request inserted successfully"
            });
        }



    }
}

