using System.ComponentModel.DataAnnotations;

namespace CalculatorApp.Models
{
    public class CalculatorModel
    {
        [Required(ErrorMessage = "Пожалуйста, введите первый операнд")]
        [Display(Name = "Первый операнд")]
        public sbyte Operand1 { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите второй операнд")]
        [StringLength(4, MinimumLength = 1,
            ErrorMessage = "Длина значения второго операнда должна быть от 1 до 4 символов")]
        [Display(Name = "Второй операнд")]
        public string Operand2 { get; set; }

        [Required(ErrorMessage = "Пожалуйста, выберите операцию")]
        [Display(Name = "Операция")]
        public string Operation { get; set; }

        [Display(Name = "Результат")]
        public double Result { get; set; }
    }
}