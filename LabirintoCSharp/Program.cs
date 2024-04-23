using System;
using System.Collections.Generic;

namespace LabirintoCSharp
{
    public class Posicao
    {
        private int _i;
        private int _j;

        public Posicao(int i, int j)
        {
            this._i = i;
            this._j = j;
        }

        public int i
        {
            get => _i;
            set => _i = value;
        }

        public int j
        {
            get => _j;
            set => _j = value;
        }

    }

    internal class Program
    {
        private const int limit = 15;


        static void mostrarLabirinto(char[,] array, int l, int c)
        {
            for (int i = 0; i < l; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < c; j++)
                {
                    Console.Write($" {array[i, j]} ");
                }
            }
            Console.WriteLine();
        }


        static void criaLabirinto(char[,] meuLab)
        {
            Random random = new Random();
            for (int i = 0; i < limit; i++)
            {
                for (int j = 0; j < limit; j++)
                {
                    meuLab[i, j] = random.Next(4) == 1 ? '|' : '.';
                }
            }


            for (int i = 0; i < limit; i++)
            {
                meuLab[0, i] = '*';
                meuLab[limit - 1, i] = '*';
                meuLab[i, 0] = '*';
                meuLab[i, limit - 1] = '*';
            }


            int x = random.Next(limit);
            int y = random.Next(limit);
            meuLab[x, y] = 'Q';
        }


    static void buscarQueijo(char[,] meuLab, int i, int j)
        {
            Stack<Posicao> minhaPilha = new Stack<Posicao>();


            do
            {
                meuLab[i, j] = 'M';
                if (meuLab[i, j + 1] == '.' || meuLab[i, j + 1] == 'Q')
                {
                    j++;
                    Posicao novaPosicao = new Posicao(i,j);
                    minhaPilha.Push(novaPosicao);

                }
                else if (meuLab[i + 1, j] == '.' || meuLab[i+1, j ] == 'Q')
                {
                    i++;
                    Posicao novaPosicao = new Posicao(i, j);
                    minhaPilha.Push(novaPosicao);
                    
                }
                else if (meuLab[i,j-1] == '.' || meuLab[i,j-1] == 'Q')
                {
                    j--;
                    Posicao novaPosicao = new Posicao(i, j);
                    minhaPilha.Push(novaPosicao);

                }
                else if (meuLab[i-1, j] == '.' || meuLab[i-1, j] == 'Q')
                {
                    i--;
                    Posicao novaPosicao = new Posicao(i, j);
                    minhaPilha.Push(novaPosicao);

                }
                else
                {
                    if (minhaPilha.Count > 0)
                    {
                        Posicao posicao = minhaPilha.Pop();
                        i = posicao.i;
                        j = posicao.j;
                    }
                    else
                    {
                        Console.WriteLine("Não é possivel chegar ao queijo!");
                    }
                }                    

                System.Threading.Thread.Sleep(200);
                Console.Clear();
                mostrarLabirinto(meuLab, limit, limit);
            } while (meuLab[i, j] != 'Q');

            Console.WriteLine($"Queijo encontrado na posição: {i},{j}");

        }


        static void Main(string[] args)
        {
            char[,] labirinto = new char[limit, limit];
            criaLabirinto(labirinto);
            mostrarLabirinto(labirinto, limit, limit);
            buscarQueijo(labirinto, 1, 1);
            Console.ReadKey();

        }
    }
}
