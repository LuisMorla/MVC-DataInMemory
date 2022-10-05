using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace MVC_Proyect1.Controllers
{
    public class MVCappController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Zodiaco sz)
        {
            string resultado = "";

            //Application.ViewModel.ViewZodiac viewZodiac = new();

            // Acuario ----------------------------------------------------------------------------

            if (sz.Dia >= 21 && sz.Mes == "1")
            {
                resultado = "Acuario♒";
            }
            else if (sz.Dia <= 18 && sz.Mes == "2")
            {
                resultado = "Acuario♒";
            }

            // Piscis ----------------------------------------------------------------------------
            else if (sz.Dia >= 19 && sz.Mes == "2")
            {
                resultado = "Piscis♓";
            }
            else if (sz.Dia <= 20 && sz.Mes == "3")
            {
                resultado = "Piscis♓";
            }
        
            // Aries ----------------------------------------------------------------------------
            else if (sz.Dia >= 21 && sz.Mes == "3")
            {
                resultado = "Aries♈";
            }
            else if (sz.Dia <= 20 && sz.Mes == "4")
            {
                resultado = "Aries♈";
            }

            // Tauro ----------------------------------------------------------------------------
            else if (sz.Dia >= 21 && sz.Mes == "4")
            {
                resultado = "Tauro♉";
            }
            else if (sz.Dia <= 21 && sz.Mes == "5")
            {
                resultado = "Tauro♉";
            }

            // Geminis ----------------------------------------------------------------------------
            else if (sz.Dia >= 22 && sz.Mes == "5")
            {
                resultado = "Geminis♊";
            }
            else if (sz.Dia <= 21 && sz.Mes == "6")
            {
                resultado = "Geminis♊";
            }

            // Cancer ----------------------------------------------------------------------------
            else if (sz.Dia >= 22 && sz.Mes == "6")
            {
                resultado = "Cancer♋";
            }
            else if (sz.Dia <= 22 && sz.Mes == "7")
            {
                resultado = "Cancer♋";
            }

            // Leo ----------------------------------------------------------------------------
            else if(sz.Dia >= 23 && sz.Mes == "7")
            {
                resultado = "Leo♌";
            }
            else if(sz.Dia <= 23 && sz.Mes == "8")
            {
                resultado = "Leo♌";
            }

            // Virgo ----------------------------------------------------------------------------
            else if(sz.Dia >= 24 && sz.Mes == "8")
            {
                resultado = "Virgo♍";
            }
            else if(sz.Dia <= 23 && sz.Mes == "9")
            {
                resultado = "Virgo♍";
            }

            // Libra ----------------------------------------------------------------------------
            else if(sz.Dia >= 24 && sz.Mes == "9")
            {
                resultado = "Libra♎";
            }
            else if(sz.Dia <= 23 && sz.Mes == "10")
            {
                resultado = "Libra♎";
            }

            // Escorpio ----------------------------------------------------------------------------
            else if(sz.Dia >= 24 && sz.Mes == "10")
            {
                resultado = "Escorpio♏";
            }
            else if(sz.Dia <= 22 && sz.Mes == "11")
            {
                resultado = "Escorpio♏";
            }

            // Sagitario ----------------------------------------------------------------------------
            else if(sz.Dia >= 23 && sz.Mes == "11")
            {
                resultado = "Sagitario♐";
            }
            else if(sz.Dia <= 21 && sz.Mes == "12")
            {
                resultado = "Sagitario♐";
            }

            // Capricornio ----------------------------------------------------------------------------
            else if(sz.Dia >= 22 && sz.Mes == "12")
            {
                resultado = "Capricornio♑";
            }
            else if(sz.Dia <= 21 && sz.Mes == "1")
            {
                resultado = "Capricornio♑";
            }

            else
            {
                return BadRequest();
            }
            return RedirectToAction("ZodiacoVista", new { resultado = resultado });
        }

        public IActionResult ZodiacoVista(string resultado) 
        {
            ViewBag.RESULTADO = resultado;
            return View();
        }

        public IActionResult Convertidor()
        {
            return View();
        }

       [HttpPost]
        public IActionResult Convertidor(ConversionVM cs) 
        {
            double Conversion = 0;
        
            if (cs.Tipomoneda == "1")
            {
                Conversion = cs.Entrada / 53.26;
            }

            else if (cs.Tipomoneda == "2")
            {
                Conversion = (cs.Entrada) * 53.26;
            }

            else if (cs.Tipomoneda == "3")
            {
                Conversion = (cs.Entrada) * 0.999624;
            }

            else if (cs.Tipomoneda == "4")
            {
                Conversion = (cs.Entrada) / 0.999624;
            }

            else if (cs.Tipomoneda == "5")
            {
                Conversion = (cs.Entrada) / 53.62;
            }

            else if (cs.Tipomoneda == "6")
            {
                Conversion = (cs.Entrada) * 53.62;
            }
            else 
            {
                return BadRequest();
            }

            return RedirectToAction("ConvertidorVista", new { conversion = Conversion });
        }

        public IActionResult ConvertidorVista(string conversion) 
        {
            ViewBag.CONVERSION = conversion;
            return View();
        }

        public IActionResult Prestamos() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Prestamos(PrestamosVM pm/*double TasaInteres, double TipoPrestamo, double Monto, int Meses*/) 
        {
            double calculado = 0;
            double MontoNeto=0;
            double Intereses = 0;
            switch (pm.TipoPrestamo) 
            {
                case "1": Intereses = pm.TasaInteres / 100;
                    MontoNeto = pm.Monto + (pm.Monto * Intereses);
                    calculado = MontoNeto / pm.Meses;
                    calculado = Math.Round(calculado, 2);
                    break;

                case "2":
                    Intereses = pm.TasaInteres / 100;
                    MontoNeto = pm.Monto + (pm.Monto * Intereses);
                    calculado = MontoNeto / pm.Meses;
                    calculado = Math.Round(calculado, 2);
                    break;

                case "3":
                    Intereses = pm.TasaInteres / 100;
                    MontoNeto = pm.Monto + (pm.Monto * Intereses);
                    calculado = MontoNeto / pm.Meses;
                    calculado = Math.Round(calculado, 2);
                    break;
            }
            return RedirectToAction("PrestamosVista", new { calculado = calculado });
        }

       public IActionResult PrestamosVista(double calculado) 
        {
            ViewBag.CALCULADO = calculado;
            return View();
       } 
    }
}
