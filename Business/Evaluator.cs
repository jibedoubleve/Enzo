using CodingSeb.ExpressionEvaluator;

namespace enzo.Business
{
    public static class Evaluator
    {
        #region Fields

        private static readonly ExpressionEvaluator _evaluator = new ExpressionEvaluator();

        #endregion Fields

        #region Methods

        public static bool Evaluate(string expression, string solution)
        {
            var t1 = (int)_evaluator.Evaluate(expression);
            int.TryParse(solution, out int r1);

            return t1 == r1;
        }

        #endregion Methods
    }
}