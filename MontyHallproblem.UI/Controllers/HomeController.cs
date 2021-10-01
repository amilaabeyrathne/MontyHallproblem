using AutoMapper;
using Business;
using MontyHallproblem.Common;
using MontyHallproblem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MontyHallproblem.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMontyProcessorService _montyProcessorService;

        public HomeController(IMontyProcessorService montyProcessorService)
        {
            this._montyProcessorService = montyProcessorService;
        }

        /// <summary>
        /// load the index view with form to input data
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetMontyHallResult(InputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                bool isStay = false;
                if (inputModel.IsStay == "Stay")
                {
                    isStay = true;
                }

                ResultDTO resultDTO = this._montyProcessorService.Processor(inputModel.NumberOfSimulations, isStay);

                var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<ResultDTO, OutPutModel>()
                );

                var mapper = new Mapper(config);
                OutPutModel outPutModel = new OutPutModel();

                var result = mapper.Map<ResultDTO, OutPutModel>(resultDTO);
                result.StayResult = resultDTO.IsStay ? "Stay" : "Change";

                return View("Result",result); 
            }

            return View(inputModel);

        }

    }
}