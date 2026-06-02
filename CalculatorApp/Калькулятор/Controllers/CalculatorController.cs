using System.Web.Mvc;
using CalculatorApp.Models;

namespace CalculatorApp.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public ActionResult Index(CalculatorModel model, string action)
        {
            if (action == "clear")
            {
                ModelState.Clear();
                return View(new CalculatorModel());
            }

            ViewBag.ExpectedResult = 42.0;
            ViewBag.Calculated = false;

            if (ModelState.IsValid)
            {
                if (!sbyte.TryParse(model.Operand2, out sbyte op2))
                {
                    ModelState.AddModelError("Operand2", "Введите целое число от -128 до 127");
                }
                else
                {
                    double op1 = model.Operand1;

                    switch (model.Operation)
                    {
                        case "+":
                            model.Result = op1 + op2;
                            ViewBag.Calculated = true;
                            break;
                        case "-":
                            model.Result = op1 - op2;
                            ViewBag.Calculated = true;
                            break;
                        case "*":
                            model.Result = op1 * op2;
                            ViewBag.Calculated = true;
                            break;
                        case "/":
                            if (op2 != 0)
                            {
                                model.Result = op1 / op2;
                                ViewBag.Calculated = true;
                            }
                            else
                            {
                                ModelState.AddModelError("", "Деление на ноль!");
                            }
                            break;
                        default:
                            ModelState.AddModelError("", "Выберите операцию");
                            break;
                    }
                }
            }

            return View(model);
        }

        public ActionResult OperationDetails()
        {
            string op1 = Request.QueryString["op1"];
            string op2 = Request.QueryString["op2"];
            string operation = Request.QueryString["operation"];
            string result = Request.QueryString["result"];

            string operationString = $"{op1} {operation} {op2} = {result}";

            char[] operators = { '+', '-', '*', '/' };
            int eqIndex = operationString.IndexOf('=');

            if (eqIndex > 0)
            {
                string leftPart = operationString.Substring(0, eqIndex);
                int opIndex = leftPart.LastIndexOfAny(operators);

                if (opIndex >= 0)
                {
                    string oldOp = operationString[opIndex].ToString();
                    string newOp = "";

                    switch (oldOp)
                    {
                        case "+": newOp = " плюс "; break;
                        case "-": newOp = " минус "; break;
                        case "*": newOp = " умножить на "; break;
                        case "/": newOp = " разделить на "; break;
                    }

                    operationString = operationString.Remove(opIndex, 1);
                    operationString = operationString.Insert(opIndex, newOp);
                }
            }

            ViewBag.OperationString = operationString;
            return View();
        }
    }
}