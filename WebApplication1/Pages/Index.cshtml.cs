using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using org.mariuszgromada.math.mxparser;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        public int arrayLength, lineWidth;
        public float scale;
        public bool dot;
        public double[] X, Y;
        public string[] fields;
        string[] fieldNames = new string[] { "expression", "step", "min", "max", "width", "scale", "dot" };
        string[] defaultFields = new string[] { "", "0.2", "-20", "20", "2", "30", "0" };

        public void OnGet()
        {
            dot = false;
            fields = new string[fieldNames.Length];
            for (int i = 0; i < fieldNames.Length; i++)
            {
                fields[i] = defaultFields[i];
            }
        }

        public void OnPost(string expression, float step, int min, int max, int width, float scale, int dot)
        {
            lineWidth = width;
            this.scale = scale;
            this.dot = dot == 1;
            arrayLength = (int)((Math.Abs(min) + Math.Abs(max)) / step);
            X = new double[arrayLength];
            Y = new double[arrayLength];
            for (float x = min; x < max; x += step)
            {
                int currentIndex = (int)((x + Math.Abs(min)) / step);
                X[currentIndex] = x;
                Argument xArgument = new Argument($"x = {x}");
                Expression e = new Expression(expression, xArgument);
                Y[currentIndex] = e.calculate(); // Function to plot
            }

            // Get fields data
            fields = new string[fieldNames.Length];
            for (int i = 0; i < fieldNames.Length; i++)
            {
                fields[i] = Request.Form[fieldNames[i]].ToString();
            }
        }
    }
}