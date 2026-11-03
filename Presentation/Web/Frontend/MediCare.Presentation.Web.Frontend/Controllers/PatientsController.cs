using global::MediCare.Application.BackEnd.Dto.Dto.Paitient;
using global::MediCare.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Controllers
{
    
 [Route("Patients")]
        public class PatientsController : Controller
        {
            private readonly HttpClient _httpClient;
            private readonly ILogger<PatientsController> _logger;

            public PatientsController(IHttpClientFactory httpClientFactory, ILogger<PatientsController> logger)
            {
                _httpClient = httpClientFactory.CreateClient("BackendApi");
                _logger = logger;
            }

            // Helper to forward authentication token if stored in cookies/session
            private void AddAuthHeader()
            {
                // If you store the JWT token in cookies or session, attach it here:
                // var token = Request.Cookies["JwtToken"];
                // if (!string.IsNullOrEmpty(token))
                // {
                //     _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                // }
            }

            // GET: /Patients
            [HttpGet("")]
            [HttpGet("Index")]
            public async Task<IActionResult> Index()
            {
                AddAuthHeader();
                try
                {
                    // Calls backend GET: api/patients (Admin/Doctor view)
                    var response = await _httpClient.GetAsync("api/patients");
                    if (response.IsSuccessStatusCode)
                    {
                        // If your backend returns ResponseDto<IEnumerable<PatientDto>>, unwrap it safely:
                        var result = await response.Content.ReadFromJsonAsync<ResponseDto<IEnumerable<PatientDto>>>();
                        return View(result?.Data ?? Enumerable.Empty<PatientDto>());
                    }

                    TempData["ErrorMessage"] = $"Backend returned status: {response.StatusCode}";
                    return View(Enumerable.Empty<PatientDto>());
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to connect to backend API for patients.");
                    TempData["ErrorMessage"] = "Cannot reach Backend API. Ensure it is running.";
                    return View(Enumerable.Empty<PatientDto>());
                }
            }

            // GET: /Patients/Me (For patient's own profile view)
            [HttpGet("Me")]
            public async Task<IActionResult> Me()
            {
                AddAuthHeader();
                try
                {
                    var response = await _httpClient.GetAsync("api/patients/me");
                    if (!response.IsSuccessStatusCode)
                    {
                        TempData["ErrorMessage"] = "Unable to load your patient profile.";
                        return RedirectToAction("Index", "Home");
                    }

                    var result = await response.Content.ReadFromJsonAsync<ResponseDto<PatientDto>>();
                    return View(result?.Data);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error fetching current patient profile.");
                    return View("Error");
                }
            }

            // GET: /Patients/Details/5
            [HttpGet("Details/{id:int}")]
            public async Task<IActionResult> Details(int id)
            {
                AddAuthHeader();
                var response = await _httpClient.GetAsync($"api/patients/{id}");
                if (!response.IsSuccessStatusCode) return NotFound();

                var result = await response.Content.ReadFromJsonAsync<ResponseDto<PatientDto>>();
                return result?.Data == null ? NotFound() : View(result.Data);
            }

            // GET: /Patients/Create
            [HttpGet("Create")]
            public IActionResult Create() => View(new CreatePatientDto());

            // POST: /Patients/Create
            [HttpPost("Create")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(CreatePatientDto dto)
            {
                if (!ModelState.IsValid) return View(dto);

                AddAuthHeader();
                var response = await _httpClient.PostAsJsonAsync("api/patients", dto);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Patient profile created successfully.";
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "Unable to create patient profile.");
                return View(dto);
            }

            // GET: /Patients/Edit/5
            [HttpGet("Edit/{id:int}")]
            public async Task<IActionResult> Edit(int id)
            {
                AddAuthHeader();
                var response = await _httpClient.GetAsync($"api/patients/{id}");
                if (!response.IsSuccessStatusCode) return NotFound();

                var result = await response.Content.ReadFromJsonAsync<ResponseDto<PatientDto>>();
                if (result?.Data == null) return NotFound();

                var patient = result.Data;
                var updateDto = new UpdatePatientDto
                {
                    PatientId = patient.PatientId,
                    // Map other necessary fields from patient to updateDto here based on your properties
                };

                return View(updateDto);
            }

            // POST: /Patients/Edit/5
            [HttpPost("Edit/{id:int}")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, UpdatePatientDto dto)
            {
                if (id != dto.PatientId) return BadRequest();
                if (!ModelState.IsValid) return View(dto);

                AddAuthHeader();
                var response = await _httpClient.PutAsJsonAsync($"api/patients/{id}", dto);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Patient profile updated successfully.";
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "Failed to update patient profile.");
                return View(dto);
            }

            // GET: /Patients/Delete/5
            [HttpGet("Delete/{id:int}")]
            public async Task<IActionResult> Delete(int id)
            {
                AddAuthHeader();
                var response = await _httpClient.GetAsync($"api/patients/{id}");
                if (!response.IsSuccessStatusCode) return NotFound();

                var result = await response.Content.ReadFromJsonAsync<ResponseDto<PatientDto>>();
                return result?.Data == null ? NotFound() : View(result.Data);
            }

            // POST: /Patients/Delete/5
            [HttpPost("Delete/{id:int}")]
            [ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                AddAuthHeader();
                var response = await _httpClient.DeleteAsync($"api/patients/{id}");
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Patient profile deleted successfully.";
                    return RedirectToAction(nameof(Index));
                }

                TempData["ErrorMessage"] = "Delete failed.";
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
    }
