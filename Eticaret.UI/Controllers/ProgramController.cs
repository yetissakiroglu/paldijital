﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Controllers
{
    public class ProgramController : Controller
    {

        
        public IActionResult Index()
        {
            return View();
        }
    }
}
