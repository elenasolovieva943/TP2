using System.Web.Mvc;

namespace fitness_centersApp.Helpers
{
    public static class FitnessHelpers
    {
        public static MvcHtmlString DisplayRating(this HtmlHelper html, double rating)
        {
            string stars = "";
            int fullStars = (int)rating;
            bool hasHalfStar = (rating - fullStars) >= 0.5;

            for (int i = 0; i < fullStars; i++)
            {
                stars += "★";
            }

            if (hasHalfStar)
            {
                stars += "½";
            }

            for (int i = stars.Length; i < 5; i++)
            {
                stars += "☆";
            }

            return new MvcHtmlString(
                $"<span style='color: #ffc107; font-size: 18px;'>{stars}</span> " +
                $"<span style='color: #666;'>({rating})</span>");
        }
    }
}