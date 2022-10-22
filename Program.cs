using System;
using System.Diagnostics;
using System.Threading;

namespace TP_Threads
{

    class Program
    {
        static void Main(string[] args)
        {
            #region PUNTO 1

            ////MONOHILO
            //Stopwatch timeMeasure = new Stopwatch();
            //timeMeasure.Start();

            //new Program().AsignarPrimero();
            //new Program().AsignarSegundo();
            //new Program().AsignarTercero();
            //new Program().AsignarCuarto();

            //Console.WriteLine("Vector Secuencial cargado");

            //timeMeasure.Stop();
            //Console.WriteLine($"Tiempo: {timeMeasure.ElapsedMilliseconds} ms \n\n\n");

            ////MULTIHILOS
            //timeMeasure = new Stopwatch();
            //timeMeasure.Start();

            //Thread hilo0 = new Thread(new Program().AsignarPrimero);
            //Thread hilo1 = new Thread(new Program().AsignarSegundo);
            //Thread hilo2 = new Thread(new Program().AsignarTercero);
            //Thread hilo3 = new Thread(new Program().AsignarCuarto);

            //hilo0.Start();
            //hilo1.Start();
            //hilo2.Start();
            //hilo3.Start();

            //hilo0.Join();
            //hilo1.Join();
            //hilo2.Join();
            //hilo3.Join();
            //Console.WriteLine("Vector MultiHilos cargado");

            //timeMeasure.Stop();
            //Console.WriteLine($"Tiempo: {timeMeasure.ElapsedMilliseconds} ms");

            #endregion

            #region PUNTO 2-3
            ////MONOHILO
            //Stopwatch timeMeasure = new Stopwatch();
            //timeMeasure.Start();

            //Program obj = new Program();
            //obj.Incrementar();
            //obj.Decrementar();
            //Console.WriteLine("El valor del indice es: " + obj.j);

            //timeMeasure.Stop();
            //Console.WriteLine($"Tiempo: {timeMeasure.ElapsedMilliseconds} ms");

            ////MULTIHILO
            //timeMeasure = new Stopwatch();
            //timeMeasure.Start();

            //obj = new Program();

            //Thread hilo0 = new Thread(obj.IncrementarMitad);
            //Thread hilo1 = new Thread(obj.IncrementarMitad);
            //Thread hilo2 = new Thread(obj.DecrementarMitad);
            //Thread hilo3 = new Thread(obj.DecrementarMitad);

            //hilo0.Start();
            //hilo1.Start();
            //hilo2.Start();
            //hilo3.Start();

            //hilo0.Join();
            //hilo1.Join();
            //hilo2.Join();
            //hilo3.Join();

            //Console.WriteLine("El valor del indice es: " + obj.j);

            //timeMeasure.Stop();
            //Console.WriteLine($"Tiempo: {timeMeasure.ElapsedMilliseconds} ms");
            #endregion
        }

        #region PUNTO 1
        double[] vector = new double[10000000];

        private void AsignarPrimero()
        {
            int i = 0;
            while (i < 2500000)
            {
                vector[i] = i;
                i++;
            }

            Console.WriteLine("1/4 Cargando...");
        }

        private void AsignarSegundo()
        {
            int i = 0;
            while (i < 2500000)
            {
                vector[i + 2500000] = i + 2500000;
                i++;
            }

            Console.WriteLine("2/4 Cargando...");
        }

        private void AsignarTercero()
        {
            int i = 0;
            while (i < 2500000)
            {
                vector[i + 5000000] = i + 5000000;
                i++;
            }

            Console.WriteLine("3/4 Cargando...");
        }

        private void AsignarCuarto()
        {
            int i = 0;
            while (i < 2500000)
            {
                vector[i + 7500000] = i + 7500000;
                i++;
            }

            Console.WriteLine("4/4 Cargando...");
        }

        #endregion

        #region PUNTO 2-3
        //VARIABLE GLOBAL
        public int j = 0;
        object objeto = new object();

        private void Incrementar()
        {
            for (int i = 0; i < 100000000; i++)
            {
                j++;
            }
        }

        private void IncrementarMitad()
        {
            Monitor.Enter(objeto);
            for (int i = 0; i < 50000000; i++)
            {
                j++;
            }
            Monitor.Exit(objeto);
        }

        private void DecrementarMitad()
        {
            Monitor.Enter(objeto);
            for (int i = 0; i < 50000000; i++)
            {
                j--;
            }
            Monitor.Exit(objeto);
        }

        private void Decrementar()
        {
            for (int i = 0; i < 100000000; i++)
            {
                j--;
            }
        }
        #endregion
    }
}
