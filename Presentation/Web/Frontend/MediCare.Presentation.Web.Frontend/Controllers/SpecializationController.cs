using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediCare.Application.BackEnd.Dto.Dto.Specialization;

namespace MediCare.Presentation.Web.Frontend.Controllers
{
    public class SpecializationController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SpecializationController> _logger;

        public SpecializationController(IHttpClientFactory httpClientFactory, ILogger<SpecializationController> logger)
        {
            _httpClient = httpClientFactory.CreateClient("BackendApi");
            _logger = logger;
        }

        private void SetLanguageHeader()
        {
            var culture = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            _httpClient.DefaultRequestHeaders.AcceptLanguage.Clear();
            _httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue(culture));
        }

        // GET: /Specialization
        public async Task<IActionResult> Index()
        {
            SetLanguageHeader();
            try
            {
                var response = await _httpClient.GetAsync("api/specializations");
                if (response.IsSuccessStatusCode)
                {
                    var items = await response.Content.ReadFromJsonAsync<IEnumerable<SpecializationDto>>();
                    return View(items ?? Enumerable.Empty<SpecializationDto>());
                }

                _logger.LogWarning("API returned status code {StatusCode} for GET api/specializations", response.StatusCode);
                TempData["ErrorMessage"] = $"Backend returned status: {response.StatusCode}";
                return View(Enumerable.Empty<SpecializationDto>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to connect to backend API at {BaseAddress}", _httpClient.BaseAddress);
                TempData["ErrorMessage"] = $"Cannot reach Backend API at {_httpClient.BaseAddress}. Ensure the API project is running.";
                return View(Enumerable.Empty<SpecializationDto>());
            }
        }

        // GET: /Specialization/Details/5
        public async Task<IActionResult> Details(int id)
        {
            SetLanguageHeader();
            try
            {
                var response = await _httpClient.GetAsync($"api/specializations/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    return NotFound();
                }

                var item = await response.Content.ReadFromJsonAsync<SpecializationDto>();
                if (item == null) return NotFound();

                return View(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve specialization with ID {Id}", id);
                return NotFound();
            }
        }

        // GET: /Specialization/Create
        public IActionResult Create()
        {
            return View(new CreateSpecializationDto());
        }

        // POST: /Specialization/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSpecializationDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/specializations", dto);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Specialization created successfully.";
                    return RedirectToAction(nameof(Index));
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogWarning("Create failed: {StatusCode} - {Error}", response.StatusCode, errorContent);
                ModelState.AddModelError(string.Empty, $"Unable to create specialization. Server returned {response.StatusCode}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while posting to api/specializations");
                ModelState.AddModelError(string.Empty, "Cannot reach the backend server to create specialization.");
            }

            return View(dto);
        }

        // GET: /Specialization/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            SetLanguageHeader();
            try
            {
                var response = await _httpClient.GetAsync($"api/specializations/{id}");
                if (!response.IsSuccessStatusCode) return NotFound();

                var item = await response.Content.ReadFromJsonAsync<SpecializationDto>();
                if (item == null) return NotFound();

                var updateDto = new UpdateSpecializationDto
                {
                    SpecializationId = item.SpecializationId,
                    EnName = item.EnName,
                    ArName = item.ArName,
                    EnDescription = item.EnDescription,
                    ArDescription = item.ArDescription
                };

                return View(updateDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching specialization {Id} for edit", id);
                return NotFound();
            }
        }

        // POST: /Specialization/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateSpecializationDto dto)
        {
            if (id != dto.SpecializationId) return BadRequest();
            if (!ModelState.IsValid) return View(dto);

            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/specializations/{id}", dto);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Specialization updated successfully.";
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, $"Failed to update. Status: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating specialization {Id}", id);
                ModelState.AddModelError(string.Empty, "Failed to connect to backend server.");
            }

            return View(dto);
        }

        // GET: /Specialization/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            SetLanguageHeader();
            try
            {
                var response = await _httpClient.GetAsync($"api/specializations/{id}");
                if (!response.IsSuccessStatusCode) return NotFound();

                var item = await response.Content.ReadFromJsonAsync<SpecializationDto>();
                if (item == null) return NotFound();

                return View(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching specialization {Id} for delete", id);
                return NotFound();
            }
        }

        // POST: /Specialization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/specializations/{id}");
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Specialization deleted successfully.";
                    return RedirectToAction(nameof(Index));
                }

                TempData["ErrorMessage"] = $"Delete failed. Server returned {response.StatusCode}.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting specialization {Id}", id);
                TempData["ErrorMessage"] = "Could not reach the backend to perform deletion.";
            }

            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}