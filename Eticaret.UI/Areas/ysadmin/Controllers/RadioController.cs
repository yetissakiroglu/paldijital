using Eticaret.Core.Extensions;
using Eticaret.Core.Entities.ComplexTypes;
using Eticaret.Core.Utilities.Messages;
using Eticaret.UI.Areas.ysadmin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Eticaret.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Mapster;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using Eticaret.Business.Abstract.Admin;

namespace Eticaret.UI.Areas.ysadmin.Controllers
{
    [Area("ysadmin")]

    public class RadioController : Controller
    {
        IRadioService _radioService;
        IRadioCategoryService _radioCategoryService;

        public RadioController(IRadioService radioService, IRadioCategoryService radioCategoryService)
        {
            _radioService = radioService;
            _radioCategoryService = radioCategoryService;
        }

        public IActionResult Index(int limit, string metin, int page = 1)
        {
            if (limit == 0)
            {
                limit = 10;
            }

            //const int pageSize = 20;

            var radioslist = _radioService.ListRadioWithRadioCategoryAndAramaPaging(metin, page, limit);
            if (radioslist.Success)
            {
                var modeller = new RadioListViewModel()
                {
                    Radios = radioslist.Data,
                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = limit,
                        TotalItems = _radioService.CountRadios().Data,
                    }
                };

                List<RadioStreamStatus> streamstatus = new List<RadioStreamStatus>();
                foreach (var items in modeller.Radios)
                {
                    try
                    {
                        XDocument xDoc = XDocument.Load($"{items.streamUrl}/statistics");
                        XElement rootElement = xDoc.Root;
                        foreach (XElement streamserver in rootElement.Elements())
                        //Foreach ile okudumuz root tagları arasındaki Rehber Elementi içinde dönüyoruz ver verileri okumaya başlıyoruz.
                        {
                            if ((streamserver.Name == "STREAMSTATS"))
                            {

                                if ((streamserver.Element("STREAM").Name == "STREAM") || (streamserver.Element("STREAM").Attribute("id").Value == items.streamId.ToString()))
                                {

                                    streamstatus.Add(new RadioStreamStatus() { RadioId = items.radioId, StreamStatus = streamserver.Element("STREAM").Element("STREAMSTATUS").Value.ToString() });

                                }
                            }

                        }
                    }
                    catch
                    { }
                }

                modeller.streamStatus = streamstatus;
                return View(modeller);
            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = ProsesMessages.MessageError,
                    Css = ProsesMessages.CssError,
                });
                return View();
            }
        }


        [HttpGet]
        public IActionResult Create()
        {
            RadioListViewModel model = new RadioListViewModel()
            {
                title = "YENİ RADYO OLUŞTUR",
                Categories = new SelectList(_radioCategoryService.ListRadioCategory().Data, "categoryId", "title"),
                Radio = new Radio()
            };


            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> Create(RadioListViewModel model, IFormFile imgPath)
        {
            Radio entity = model.Radio.Adapt<Radio>();
            var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "radio", model.Radio.title);
            entity.imgPath = ImgFile;

            var result = _radioService.Create(entity);
            if (result.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleSuccess,
                    Message = ProsesMessages.MessageCreate,
                    Css = ProsesMessages.CssSuccess,
                });

                return RedirectToAction("Index");
            }
            else
            {
                return View("Index", result);
            }
        }
        [HttpPost]
        public IActionResult RadioPreview(int? Id)
        {
            var radio = _radioService.GetRadioByradioId((int)Id);

            STREAMSTATSViewRadio streanstatses = new STREAMSTATSViewRadio();


            if (radio.Success)
            {

                XDocument xDoc = XDocument.Load($"{radio.Data.streamUrl}/statistics");
                XElement rootElement = xDoc.Root;
                foreach (XElement streamserver in rootElement.Elements())
                //Foreach ile okudumuz root tagları arasındaki Rehber Elementi içinde dönüyoruz ver verileri okumaya başlıyoruz.
                {
                    if ((streamserver.Name == "STREAMSTATS"))
                    {

                        streanstatses.TOTALSTREAMS = streamserver.Element("TOTALSTREAMS").Value;
                        streanstatses.ACTIVESTREAMS = streamserver.Element("ACTIVESTREAMS").Value;
                        streanstatses.CURRENTLISTENERS = streamserver.Element("CURRENTLISTENERS").Value;
                        streanstatses.PEAKLISTENERS = streamserver.Element("PEAKLISTENERS").Value;
                        streanstatses.MAXLISTENERS = streamserver.Element("MAXLISTENERS").Value;
                        streanstatses.UNIQUELISTENERS = streamserver.Element("UNIQUELISTENERS").Value;
                        streanstatses.AVERAGETIME = streamserver.Element("AVERAGETIME").Value;
                        streanstatses.VERSION = streamserver.Element("VERSION").Value;



                        if ((streamserver.Element("STREAM").Name == "STREAM") || (streamserver.Element("STREAM").Attribute("id").Value == "1"))
                        {

                            var streamModel = new STREAMViewRadio()
                            {


                                CURRENTLISTENERS = streamserver.Element("STREAM").Element("CURRENTLISTENERS").Value,
                                PEAKLISTENERS = streamserver.Element("STREAM").Element("PEAKLISTENERS").Value,
                                MAXLISTENERS = streamserver.Element("STREAM").Element("MAXLISTENERS").Value,
                                UNIQUELISTENERS = streamserver.Element("STREAM").Element("UNIQUELISTENERS").Value,
                                AVERAGETIME = streamserver.Element("STREAM").Element("AVERAGETIME").Value,
                                SERVERGENRE = streamserver.Element("STREAM").Element("SERVERGENRE").Value,

                                SERVERURL = streamserver.Element("STREAM").Element("SERVERURL").Value,
                                SERVERTITLE = streamserver.Element("STREAM").Element("SERVERTITLE").Value,
                                SONGTITLE = streamserver.Element("STREAM").Element("SONGTITLE").Value,
                                DJ = streamserver.Element("STREAM").Element("DJ").Value,
                                STREAMHITS = streamserver.Element("STREAM").Element("STREAMHITS").Value,
                                STREAMSTATUS = streamserver.Element("STREAM").Element("STREAMSTATUS").Value,

                                BACKUPSTATUS = streamserver.Element("STREAM").Element("BACKUPSTATUS").Value,
                                STREAMLISTED = streamserver.Element("STREAM").Element("STREAMLISTED").Value,
                                STREAMLISTEDERROR = streamserver.Element("STREAM").Element("STREAMLISTEDERROR").Value,
                                STREAMUPTIME = streamserver.Element("STREAM").Element("STREAMUPTIME").Value,
                                BITRATE = streamserver.Element("STREAM").Element("BITRATE").Value,

                                SAMPLERATE = streamserver.Element("STREAM").Element("SAMPLERATE").Value,
                                CONTENT = streamserver.Element("STREAM").Element("CONTENT").Value,
                            };


                            streanstatses.streams = streamModel;


                        }
                    }

                }


                RadioListViewModel _radioDetail = radio.Data.Adapt<RadioListViewModel>();

                _radioDetail.streamState = streanstatses;
                _radioDetail.Radio = radio.Data;

                return PartialView("RadioPreview", _radioDetail);
            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = radio.Message,
                    Css = ProsesMessages.CssError
                });
                RadioListViewModel _radioDetail = radio.Adapt<RadioListViewModel>();
                return PartialView("RadioPreview", _radioDetail);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var radio = _radioService.GetRadioByradioId((int)id);
            if (radio.Success)
            {
                Radio entity = radio.Data.Adapt<Radio>();
                var radiodelete = _radioService.Delete(entity);
                if (radiodelete.Success)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesMessages.TitleSuccess,
                        Message = ProsesMessages.MessageDelete,
                        Css = ProsesMessages.CssWarning,
                    });
                }
                else
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesMessages.TitleError,
                        Message = ProsesMessages.MessageError,
                        Css = ProsesMessages.CssError,
                    });

                }

            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = ProsesMessages.MessageError,
                    Css = ProsesMessages.CssError,
                });
            }

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var radio = _radioService.GetRadioByradioId((int)id);
            if (radio.Data == null)
            {
                return NotFound();
            }

            if (radio.Success)
            {

                RadioListViewModel model = new RadioListViewModel()
                {
                    title = radio.Data.title,
                    Categories = new SelectList(_radioCategoryService.ListRadioCategory().Data, "categoryId", "title"),
                    Radio = radio.Data.Adapt<Radio>(),

                };

                return View(model);
            }
            else
            {
                return NotFound();
            }



        }
        [HttpPost]
        public async Task<IActionResult> Edit(RadioListViewModel model, IFormFile imgPath)
        {
            var radio = _radioService.GetRadioByradioId(model.Radio.radioId);
            if (radio.Success)
            {
                Radio entity = model.Radio.Adapt<Radio>();

                if (imgPath != null)
                {
                    var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "radio", model.Radio.title);
                    entity.imgPath = ImgFile;
                }
                else
                {
                    entity.imgPath = model.Radio.imgPath;
                }
                var radioUpdate = _radioService.Update(entity);

                if (radioUpdate.Success)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesMessages.TitleSuccess,
                        Message = radioUpdate.Message,
                        Css = ProsesMessages.CssSuccess,
                    });

                }
                else
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesMessages.TitleError,
                        Message = radioUpdate.Message,
                        Css = ProsesMessages.CssError,
                    });


                    model.Categories = new SelectList(_radioCategoryService.ListRadioCategory().Data, "categoryId", "title");
                    return View(model);

                }

                return RedirectToAction("Index");

            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = ProsesMessages.MessageNoData,
                    Css = ProsesMessages.CssError,
                });

                return RedirectToAction("Index");
            }

        }
        public IActionResult RadioCategoryCreate()
        {
            RadioCategoryListViewModel model = new RadioCategoryListViewModel()
            {
                RadioCategory = new RadioCategory()
            };


            var row = _radioCategoryService.ListRadioCategory().Data.ToList().Count();
            if (row > 0)
            {
                model.RadioCategory.row = row + 1;
            }

            return PartialView("RadioCategoryCreate", model);
        }
        [HttpPost]
        public IActionResult RadioCategoryCreate(RadioCategoryListViewModel model)
        {
            var entity = new RadioCategory()
            {
                title = model.RadioCategory.title,
                keywords = model.RadioCategory.title,
                description = model.RadioCategory.title,
                url = Replace.UrlAndTitleReplace(model.RadioCategory.title),
                status = true,
                row = model.RadioCategory.row
            };
            var result = _radioCategoryService.Create(entity);

            if (result.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleSuccess,
                    Message = model.RadioCategory.title + " " + ProsesMessages.MessageCreate,
                    Css = ProsesMessages.CssSuccess,

                });
            }
            return RedirectToAction("Create", "Radio", model);
        }

        [HttpPost]
        public IActionResult RadioWebActive(bool active, int id)
        {
            var radio = _radioService.GetRadioByradioId((int)id);

            RadioListViewModel model = new RadioListViewModel()
            {
                Radio = radio.Data
            };


            if (active == true)
            {
                model.Radio.webstatus = false;
            }
            if (active == false)
            {
                model.Radio.webstatus = true;
            }

            var resultUpdate = _radioService.Update(model.Radio);
            if (resultUpdate.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleSuccess,
                    Message = $"" + ProsesMessages.MessageEdit,
                    Css = ProsesMessages.CssSuccess
                });
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RadioMobilActive(bool active, int id)
        {
            var radio = _radioService.GetRadioByradioId((int)id);

            RadioListViewModel model = new RadioListViewModel()
            {
                Radio = radio.Data
            };


            if (active == true)
            {
                model.Radio.mobilstatus = false;
            }
            if (active == false)
            {
                model.Radio.mobilstatus = true;
            }

            var resultUpdate = _radioService.Update(model.Radio);
            if (resultUpdate.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleSuccess,
                    Message = $"" + ProsesMessages.MessageEdit,
                    Css = ProsesMessages.CssSuccess
                });
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult IndexRadioCategory(int page = 1)
        {
            const int pageSize = 10;
            var radiocategoryslist = _radioCategoryService.ListRadioCategoryWithRadiosPaging(page, pageSize);
            if (radiocategoryslist.Success)
            {
                var modeller = new RadioCategoryListViewModel()
                {
                    RadioCategorys = radiocategoryslist.Data,
                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = _radioCategoryService.CountRadioCategories().Data,
                    }
                };

                return View(modeller);
            }

            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = ProsesMessages.MessageError,
                    Css = ProsesMessages.CssError,
                });

                return View();
            }

        }

        public IActionResult CreateCategory()
        {
            RadioCategoryListViewModel model = new RadioCategoryListViewModel()
            {
                RadioCategory = new RadioCategory()
            };


            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(RadioCategoryListViewModel model, IFormFile imgPath)
        {

            RadioCategory entity = model.RadioCategory.Adapt<RadioCategory>();


            var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "radio", model.RadioCategory.title);
            entity.imgPath = ImgFile;

            entity.url = Replace.UrlAndTitleReplace(model.RadioCategory.url == null ? model.RadioCategory.title : model.RadioCategory.url);


            var result = _radioCategoryService.Create(entity);
            if (result.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleSuccess,
                    Message = ProsesMessages.MessageCreate,
                    Css = ProsesMessages.CssSuccess,
                });

                return RedirectToAction("IndexRadioCategory");
            }
            else
            {
                return View("IndexRadioCategory", result);
            }
        }
        [HttpPost]
        public IActionResult RadioCategoryPreview(int? Id)
        {
            var radio = _radioCategoryService.GetRadioCategoryBycategoryId((int)Id);
            if (radio.Success)
            {
                RadioCategoryListViewModel _radioCategoryDetail = radio.Data.Adapt<RadioCategoryListViewModel>();
                _radioCategoryDetail.RadioCategory = radio.Data;
                return PartialView("RadioCategoryPreview", _radioCategoryDetail);
            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = radio.Message,
                    Css = ProsesMessages.CssError
                });
                RadioCategoryListViewModel _Detail = radio.Adapt<RadioCategoryListViewModel>();
                return PartialView("RadioCategoryPreview", _Detail);
            }
        }
        [HttpGet]
        public IActionResult DeleteCategory(int? id)
        {
            var radio = _radioCategoryService.GetRadioCategoryBycategoryId((int)id);
            if (radio.Success)
            {
                RadioCategory entity = radio.Data.Adapt<RadioCategory>();
                var radiodelete = _radioCategoryService.DeleteFromRadioCategoryandRadios(entity);
                if (radiodelete.Success)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesMessages.TitleSuccess,
                        Message = ProsesMessages.MessageDelete,
                        Css = ProsesMessages.CssWarning,
                    });
                }
                else
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesMessages.TitleError,
                        Message = ProsesMessages.MessageError,
                        Css = ProsesMessages.CssError,
                    });

                }

            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = ProsesMessages.MessageError,
                    Css = ProsesMessages.CssError,
                });
            }

            return RedirectToAction("IndexRadioCategory");

        }
        [HttpGet]
        public IActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var radio = _radioCategoryService.GetRadioCategoryBycategoryId((int)id);
            if (radio.Data == null)
            {
                return NotFound();
            }

            if (radio.Success)
            {

                RadioCategoryListViewModel model = new RadioCategoryListViewModel()
                {
                    RadioCategory = radio.Data.Adapt<RadioCategory>(),
                };

                return View(model);
            }
            else
            {
                return NotFound();
            }



        }
        [HttpPost]
        public async Task<IActionResult> EditCategory(RadioCategoryListViewModel model, IFormFile imgPath)
        {
            var radio = _radioCategoryService.GetRadioCategoryBycategoryId(model.RadioCategory.categoryId);
            if (radio.Success)
            {
                RadioCategory entity = model.RadioCategory.Adapt<RadioCategory>();

                if (imgPath != null)
                {
                    var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "radio", model.RadioCategory.title);
                    entity.imgPath = ImgFile;
                }
                else
                {
                    entity.imgPath = model.RadioCategory.imgPath;
                }
                var radioUpdate = _radioCategoryService.Update(entity);

                if (radioUpdate.Success)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesMessages.TitleSuccess,
                        Message = radioUpdate.Message,
                        Css = ProsesMessages.CssSuccess,
                    });

                }
                else
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesMessages.TitleError,
                        Message = radioUpdate.Message,
                        Css = ProsesMessages.CssError,
                    });


                    return View(model);

                }

                return RedirectToAction("IndexRadioCategory");

            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = ProsesMessages.MessageNoData,
                    Css = ProsesMessages.CssError,
                });

                return RedirectToAction("IndexRadioCategory");
            }

        }
        [HttpPost]
        public IActionResult RadioCategoryWebActive(bool active, int id)
        {
            var radio = _radioCategoryService.GetRadioCategoryBycategoryId((int)id);

            RadioCategoryListViewModel model = new RadioCategoryListViewModel()
            {
                RadioCategory = radio.Data
            };


            if (active == true)
            {
                model.RadioCategory.status = false;
            }
            if (active == false)
            {
                model.RadioCategory.status = true;
            }

            var resultUpdate = _radioCategoryService.Update(model.RadioCategory);
            if (resultUpdate.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleSuccess,
                    Message = $"" + ProsesMessages.MessageEdit,
                    Css = ProsesMessages.CssSuccess
                });
            }
            return RedirectToAction("IndexRadioCategory");
        }






    }
}
