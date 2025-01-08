using System.Drawing.Imaging;

class NormalMapGenerator
{
	public static void GenerateNormalMap(int resolution, string filename)
	{
		double uMin = -10, uMax = 10;
		double vMin = -10, vMax = 10;

		var bitmap = new Bitmap(resolution, resolution);

		for (var y = 0; y < resolution; y++)
		{
			for (var x = 0; x < resolution; x++)
			{
				var u = uMin + (uMax - uMin) * x / (resolution - 1);
				var v = vMin + (vMax - vMin) * y / (resolution - 1);

				var z = Math.Sin(Math.Pow(u / 3.0, 2) + Math.Pow(v / 3.0, 2));

				// d / du(sin(u ^ 2 / 9 + v ^ 2 / 9)) = 2 / 9 u cos(1 / 9(u ^ 2 + v ^ 2))
				var dzdu = (2 * (u / 9.0)) * Math.Cos(Math.Pow(u / 3.0, 2) + Math.Pow(v / 3.0, 2));

				// d / dv(sin(u ^ 2 / 9 + v ^ 2 / 9)) = 2 / 9 v cos(1 / 9(u ^ 2 + v ^ 2))
				var dzdv = (2 * (v / 9.0)) * Math.Cos(Math.Pow(u / 3.0, 2) + Math.Pow(v / 3.0, 2));

				var nx = -dzdu;
				var ny = -dzdv;
				var nz = 1.0;

				var length = Math.Sqrt(nx * nx + ny * ny + nz * nz);
				nx /= length;
				ny /= length;
				nz /= length;

				var r = (int)((nx + 1.0) * 0.5 * 255);
				var g = (int)((ny + 1.0) * 0.5 * 255);
				var b = (int)((nz + 1.0) * 0.5 * 255);

				bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
			}
		}

		bitmap.Save(filename, ImageFormat.Png);
	}
}