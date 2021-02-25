using System;
using System.Collections;
using System.Collections.Generic;

namespace Desafio3
{
    class Program
    {
        static void Main(string[] args)
        {
            SimulacaoCustoFrete sim1 = new SimulacaoCustoFrete();
            sim1.Add(18550, 27500, 200);
            sim1.Add(8100, 35410, 554);
            sim1.Add(27500, 3650, 112);
            sim1.Add(9541, 5799, 1580);
            sim1.Add(27540, 45000, 321);
            sim1.Add(5000, 90570, 627);
            sim1.Add(8900, 41000, 876);

            sim1.ComparaFretes();


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

        class SimulacaoCustoFrete
        {
            public List<Carga> listaCarga = new List<Carga>();
            protected List<int> listaDistancia = new List<int>();

            public void Add(double peso, double valor, int distancia)
            {
                Carga c1 = new Carga();
                c1.SetPeso(peso);
                c1.SetValor(valor);
                listaCarga.Add(c1);
                listaDistancia.Add(distancia);
            }


            public void ComparaFretes()
            {
                double freteCaminhao = 0.0, freteVagao = 0.0;
                int numCaminhoes = 0;
                for(int i = 0; i < 7; i++)
                {
                    Caminhao c1 = new Caminhao(listaCarga[i].GetPeso(), listaCarga[i].GetValor());
                    Vagao v1 = new Vagao(listaCarga[i].GetPeso(), listaCarga[i].GetValor());
                    freteCaminhao += c1.CalculaFrete(listaDistancia[i]);
                    freteVagao += v1.CalculaFrete(listaDistancia[i]);
                    numCaminhoes++;
                }
                Console.WriteLine("Custo por caminhoes será de: {0} e por vagao de : {1}", freteCaminhao, freteVagao);
                Console.WriteLine("Serao necessários {0} caminhoes e {1} vagoes", numCaminhoes, 7);

                if (freteCaminhao == freteVagao)
                {
                    Console.WriteLine("Frete por caminhao compensa mais");
                }
                else if (freteCaminhao > freteVagao)
                {
                    Console.WriteLine("Frete por vagao compensa mais");
                }
                else
                {
                    Console.WriteLine("Frete por caminhao compensa mais");
                }
            }
        }
    }
}
