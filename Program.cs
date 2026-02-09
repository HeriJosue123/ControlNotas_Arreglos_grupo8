using System;

namespace Tarea_Asincrona
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int totalEstudiantes = 5;
            const int totalNotas = 3;

            string[] nombres = new string[totalEstudiantes];
            int[,] notas = new int[totalEstudiantes, totalNotas];
            double[] promedios = new double[totalEstudiantes];

            // Ingreso de datos
            for (int i = 0; i < totalEstudiantes; i++)
            {
                bool nombreValido = false;

                while (!nombreValido)
                {
                    Console.Write("Ingrese el nombre del estudiante " + (i + 1) + ": ");
                    string nombre = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(nombre) && nombre.Trim().Length >= 3)
                    {
                        nombre = nombre.Trim();
                        bool tieneNumero = false;

                        for (int k = 0; k < nombre.Length; k++)
                        {
                            if (char.IsDigit(nombre[k]))
                            {
                                tieneNumero = true;
                                break;
                            }
                        }

                        if (!tieneNumero)
                        {
                            nombres[i] = nombre;
                            nombreValido = true;
                        }
                        else
                        {
                            Console.WriteLine("Error: el nombre no debe contener números.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: el nombre debe tener al menos 3 caracteres.");
                    }
                }

                int suma = 0;

                for (int j = 0; j < totalNotas; j++)
                {
                    bool notaValida = false;

                    while (!notaValida)
                    {
                        Console.Write("Ingrese la nota " + (j + 1) + " (0 a 10): ");
                        string entrada = Console.ReadLine();

                        if (int.TryParse(entrada, out int nota))
                        {
                            if (nota >= 0 && nota <= 10)
                            {
                                notas[i, j] = nota;
                                suma += nota;
                                notaValida = true;
                            }
                            else
                            {
                                Console.WriteLine("Error: la nota debe estar entre 0 y 10.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: solo se permiten números enteros.");
                        }
                    }
                }

                promedios[i] = (double)suma / totalNotas;
                Console.WriteLine();
            }

            // Mostrar resultados
            Console.WriteLine("RESULTADOS\n");

            for (int i = 0; i < totalEstudiantes; i++)
            {
                Console.WriteLine("Estudiante: " + nombres[i]);

                for (int j = 0; j < totalNotas; j++)
                {
                    Console.WriteLine("Nota " + (j + 1) + ": " + notas[i, j]);
                }

                Console.WriteLine("Promedio: " + promedios[i]);
                Console.WriteLine("------------------------");
            }

            Console.WriteLine("Presione cualquier tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
