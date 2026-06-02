using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace fitness_centersApp.Models
{
    public class FitnessCenter
    {
        [DisplayName("ID")]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("Название фитнес-центра")]
        public string Name { get; set; }

        [DisplayName("Адрес")]
        public string Address { get; set; }

        [DisplayName("Телефон")]
        public string Phone { get; set; }

        [DisplayName("Количество тренажёров")]
        public int EquipmentCount { get; set; }

        [DisplayName("Время работы")]
        public string WorkingHours { get; set; }

        [DisplayName("Описание услуг")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Рейтинг")]
        public double Rating { get; set; }
    }

    public static class FitnessStorage
    {
        public static FitnessCenter[] Centers = new FitnessCenter[0];
    }
}