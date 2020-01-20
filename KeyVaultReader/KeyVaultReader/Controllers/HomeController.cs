using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KeyVaultReader.Models;
using Microsoft.Extensions.Configuration;

namespace KeyVaultReader.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {            
            return View(new SecretsViewModel() { KeyVaultName = _config.GetValue<string>("KeyVaultName") });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(SecretsViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.SecretName))
                return View(viewModel);
            
            string secret = _config.GetValue<string>(viewModel.SecretName);
            viewModel.Secret = secret == null ? "not found" : secret;
            viewModel.KeyVaultName = _config.GetValue<string>("KeyVaultName");
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
