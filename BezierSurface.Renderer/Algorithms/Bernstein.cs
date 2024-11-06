namespace BezierSurface.Renderer.Algorithms;

public static class Bernstein
{
    public static float Coefficient(int i, int n, float t)
    {
        return Binomial.Coefficient(n, i) * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i);
    }
    private static class Binomial
    {
        private static int[][] _coefficients = [[1], [1, 1], [1, 2, 1], [1, 3, 3, 1]];

        public static int Coefficient(int n, int k)
        {
            return _coefficients[n][k];
        }
    }
}