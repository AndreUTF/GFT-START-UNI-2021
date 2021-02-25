using System;

namespace Desafio1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Multiplicando: ");
            string strMultiplicando = Console.ReadLine();
            int multiplicando = Int32.Parse(strMultiplicando);

            Console.Write("Início do Intervalo: ");
            string strInicio= Console.ReadLine();
            int inicio = Int32.Parse(strInicio);

            Console.Write("Fim do Intevalo: ");
            string strFim = Console.ReadLine();
            int fim = Int32.Parse(strFim);

            if (multiplicando < 0 || multiplicando > 3000)
            {
                Console.WriteLine("Multiplicando deve ser maior que 0 e menor ou igual a 3000");
            }
            else if ((fim < 0 || inicio < 0 ) || (fim > 3000 || inicio > 3000))
            {
                Console.WriteLine("Fim e início devem ser maiores que 0 e menores ou iguais a 3000"); ;
            }
            else if((fim - inicio) > 10)
            {
                Console.WriteLine("A diferença entre fim e inicio nao pode ser maior que 10");
            }
            else if ( inicio > fim )
            {
                Console.WriteLine("Incio tem que ser menor que o fim do intervalo");
            }
            else
            {
                for (int i = inicio; i <= fim; i++)
                {
                    Console.WriteLine("{0} x {1} = {2}", multiplicando, i, multiplicando * i);
                }
            }
        }
    }
}
