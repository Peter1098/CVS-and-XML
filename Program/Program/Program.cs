using System;
//using System.STAThread;
namespace Program
{
    internal static class Program
    {
        [System.STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
           
            // Define la cadena de conexión (modifica según tu configuración)
        }
            }
        }
   