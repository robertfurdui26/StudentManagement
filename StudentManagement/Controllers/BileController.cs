using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BileController : ControllerBase
    {

        private const int Width = 160;
        private const int Height = 44;
        private const char BackgroundASCIICode = '.';
        private const int DistanceFromCam = 100;
        private const float IncrementSpeed = 0.6f;
        private const float K1 = 40;
        private float horizontalOffset;

        private float[] zBuffer = new float[Width * Height];
        private char[] buffer = new char[Width * Height];

        [HttpGet("balls")]
        public ActionResult<IEnumerable<Bila>> GetBile()
        {
            
                // Generare 200 de bile cu poziții aleatorii
                var random = new Random();
                var bile = Enumerable.Range(1, 200).Select(i => new Bila
                {
                    Index = i,
                    X = (float)random.NextDouble(),
                    Y = (float)random.NextDouble(),
                    Z = (float)random.NextDouble()
                });

                return Ok(bile);
            
        }


        [HttpGet("render-cube")]
        public ActionResult<IEnumerable<string>> RenderCube()
        {
            Array.Fill(buffer, BackgroundASCIICode);
            Array.Fill(zBuffer, 0);

            float cubeWidth = 20;
            float horizontalOffset = -2 * cubeWidth;

            // first cube
            for (float cubeX = -cubeWidth; cubeX < cubeWidth; cubeX += IncrementSpeed)
            {
                for (float cubeY = -cubeWidth; cubeY < cubeWidth; cubeY += IncrementSpeed)
                {
                    CalculateForSurface(cubeX, cubeY, -cubeWidth, '@');
                    CalculateForSurface(cubeWidth, cubeY, cubeX, '$');
                    CalculateForSurface(-cubeWidth, cubeY, -cubeX, '~');
                    CalculateForSurface(-cubeX, cubeY, cubeWidth, '#');
                    CalculateForSurface(cubeX, -cubeWidth, -cubeY, ';');
                    CalculateForSurface(cubeX, cubeWidth, cubeY, '+');
                }
            }

            cubeWidth = 10;
            horizontalOffset = 1 * cubeWidth;

            List<string> result = new List<string>();
            for (int k = 0; k < Width * Height; k += Width)
            {
                result.Add(new string(buffer, k, Width));
            }

            return Ok(result);
        }

        private void CalculateForSurface(float cubeX, float cubeY, float cubeZ, char ch)
        {
            float x = CalculateX(cubeX, cubeY, cubeZ);
            float y = CalculateY(cubeX, cubeY, cubeZ);
            float z = CalculateZ(cubeX, cubeY, cubeZ) + DistanceFromCam;

            float ooz = 1 / z;

            int xp = (int)(Width / 2 + horizontalOffset + K1 * ooz * x * 2);
            int yp = (int)(Height / 2 + K1 * ooz * y);

            int idx = xp + yp * Width;
            if (idx >= 0 && idx < Width * Height && ooz > zBuffer[idx])
            {
                zBuffer[idx] = ooz;
                buffer[idx] = ch;
            }
        }

        private float CalculateX(float i, float j, float k)
        {
            return j * (float)Math.Sin(A) * (float)Math.Sin(B) * (float)Math.Cos(C) -
                   k * (float)Math.Cos(A) * (float)Math.Sin(B) * (float)Math.Cos(C) +
                   j * (float)Math.Cos(A) * (float)Math.Sin(C) + k * (float)Math.Sin(A) * (float)Math.Sin(C) + i * (float)Math.Cos(B) * (float)Math.Cos(C);
        }

        private float CalculateY(float i, float j, float k)
        {
            return j * (float)Math.Cos(A) * (float)Math.Cos(C) + k * (float)Math.Sin(A) * (float)Math.Cos(C) -
                   j * (float)Math.Sin(A) * (float)Math.Sin(B) * (float)Math.Sin(C) + k * (float)Math.Cos(A) * (float)Math.Sin(B) * (float)Math.Sin(C) -
                   i * (float)Math.Cos(B) * (float)Math.Sin(C);
        }

        private float CalculateZ(float i, float j, float k)
        {
            return k * (float)Math.Cos(A) * (float)Math.Cos(B) - j * (float)Math.Sin(A) * (float)Math.Cos(B) + i * (float)Math.Sin(B);
        }

        private float A, B, C; // Aceste valori ar trebui să fie definite pe parcursul metodelor sau să fie gestionate altfel.
    }
}

