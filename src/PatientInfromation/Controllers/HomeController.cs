using Company.Infrastructure.HttpService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PatientInformation.Application.Services;
using PatientInfrastructure.Application.Dto;
using PatientInfromation.Models;
using System.Diagnostics;

namespace PatientInfromation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAllergy _allergyService;
        private readonly IPatient _patientService;
        private readonly IDisease _diseaseService;
        private readonly INCD _ncdService;
        public HomeController(ILogger<HomeController> logger, IAllergy allergyService, IPatient patientService, IDisease diseaseService, INCD ncdService)
        {
            _logger = logger;
            _ncdService = ncdService;
            _patientService = patientService;
            _allergyService = allergyService;
            _diseaseService = diseaseService;
        }

        public async Task<IActionResult> Index()
        {
            var patientList = await _patientService.GetAll();
            return View(patientList);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var diseases = await _diseaseService.GetAll();
            var ncds = await _ncdService.GetAll();
            var allergies = await _allergyService.GetAll();
            ViewBag.Diseases = new SelectList(diseases, "Id", "Name");
            ViewBag.NCD = new SelectList(ncds, "Id", "Name");
            ViewBag.Allergy = new SelectList(allergies, "Id", "Name");

            ViewBag.Epilepsy = new SelectList(Enum.GetValues(typeof(Epilepsy)).Cast<Epilepsy>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList(), "Value", "Text");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PatientInformationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await _patientService.Add(request);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}