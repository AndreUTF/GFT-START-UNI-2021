using System;

namespace Desafio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre o peso do transporte: ");
            string strPeso = Console.ReadLine();
            double peso = double.Parse(strPeso);

            Console.Write("Entre o valor do transporte: ");
            string strValor = Console.ReadLine();
            double valor = double.Parse(strValor);

            Console.Write("Entre a distancia do transporte: ");
            string strDistancia = Console.ReadLine();
            int distancia = Int32.Parse(strDistancia);

            Vagao vagaoTeste = new Vagao(peso, valor);
            Caminhao caminhaoTeste = new Caminhao(peso, valor);

            Console.WriteLine("Peso {0} | Valor {1} | Distancia {2}km", peso, valor, distancia);
            Console.WriteLine("Frete Vagao: ${0:0.00} e Frete Caminhao: ${1:0.00}", vagaoTeste.CalculaFrete(distancia),
                                                            caminhaoTeste.CalculaFrete(distancia));
        }

        class Carga
        {
            protected double Valor;

            protected double Peso;

            public void SetPeso (double peso)
            {
                this.Peso = peso;
            }

            public double GetPeso ()
            {
                return this.Peso;
            }

            public void SetValor(double valor)
            {
                this.Valor = valor;
            }

            public double GetValor ()
            {
                return this.Valor;
            }


        }

        abstract class Transporte
        {
            protected Carga carga = new Carga();

            public Transporte(double peso, double valor)
            {
                carga.SetPeso(peso);
                carga.SetValor(valor);
            }

            public virtual double CalculaFrete(int distancia)
            {
                return 0;
            }
        }

        class Vagao : Transporte
        {
            public Vagao(double peso, double valor) : base(peso, valor)
            {
                ;
            }
            public override double CalculaFrete(int distancia)
            {
                if (this.carga.GetPeso() < 15000)
                {
                    return 0.07 * this.carga.GetPeso() + 0.01 * this.carga.GetValor() + 0.5 * distancia + 5000;
                }
                else
                {
                    return 0.07 * this.carga.GetPeso() + 0.01 * this.carga.GetValor() + 0.5 * distancia;
                }
                
            }
        }

        class Caminhao : Transporte
        {
            public Caminhao(double peso, double valor) : base(peso, valor)
            {
                ;
            }
            public override double CalculaFrete(int distancia)
            {
                if (this.carga.GetValor() > 40000)
                {
                    return 0.75 * (0.02 * this.carga.GetPeso() + 0.03 * this.carga.GetValor() + 2 * distancia);
                }
                else
                {
                    return 0.02 * this.carga.GetPeso() + 0.03 * this.carga.GetValor() + 2 * distancia;
                }

            }
        }
    }
}
