using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult GetAll()
        {
            ML.Empresa empresa = new ML.Empresa();

            var result = BL.Empresa.GetAll();

            if (result.Item1)
            {
                empresa = result.Item3;

                return View(empresa);
            }
            else
            {
                return View();
            }
        }
        public ActionResult Form(int? IdEmpresa)
        {
            ML.Empresa empresa = new ML.Empresa();

            //Update
            if (IdEmpresa != null)
            {
                
                var result = BL.Empresa.GetById(IdEmpresa.Value);
                if (result.Item1)
                {
                    return View(empresa);
                }
                else
                {
                    ViewBag.Text = "Ocurrio un problema" + result.Item2;
                    return PartialView("Modal");
                }

            }

            else
            //Agregar
            {
                var result = BL.Empresa.Add(empresa);
                if (result.Item1)
                {
                    return View(empresa);
                }
                else
                {
                    ViewBag.Text = "Ocurrió un error" + result.Item2;
                    return PartialView("Modal");
                }
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Empresa empresa)
        {

            if (empresa.IdEmpresa != 0)
            {
                var update = BL.Empresa.Update(empresa);
                if (update.Item1)
                {
                    ViewBag.Text = "El Registro se ha Actualizado Exitosamente";
                    return PartialView("Modal");

                }
                else
                {
                    ViewBag.Text = "Ocurrio un Error: El Registro No se Guardo Exitosamente";
                    return PartialView("Modal");
                }
            }

            else
            {
                var result = BL.Empresa.Add(empresa);
                if (result.Item1)
                {
                    ViewBag.Text = "Se Agrego Exitosamente";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Text = "No Se Agrego Exitosamente";
                    return PartialView("Modal");
                }


            }
        }

        [HttpPost]
        public ActionResult Delete(int IdEmpresa)
        {
            if (IdEmpresa != 0)
            {

                var result = BL.Empresa.Delete(IdEmpresa);


                ViewBag.Text = "Se Elimino Exitosamente";
                return PartialView("Modal");

                return RedirectToAction("GetAll");
            }
            else
            {
                ViewBag.Text = "No se Elimino Exitosamente";
                return PartialView("Modal");

                return RedirectToAction("GetAll");
            }
        }
    }
}