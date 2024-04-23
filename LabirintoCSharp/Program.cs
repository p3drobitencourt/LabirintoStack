using System;
using System.Collections.Generic;

namespace LabirintoCSharp
{
    public class Posicao
    {
        private int i;
        private int j;

        public Posicao(int i, int j)
        {
            this.i = i;
            this.j = j;
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
                if (meuLab[i, j + 1] == '.')
                {
                    j++;
                    Posicao novaPosicao = new Posicao(i,j);
                    minhaPilha.Push(novaPosicao);
                    // empilhar posicao atual
                    // minhaPilha.Push();// i e j
                    
                }
                else if (meuLab[i + 1, j] == '.')
                {
                    i++;
                    Posicao novaPosicao = new Posicao(i, j);
                    minhaPilha.Push(novaPosicao);
                    
                }
                else if (meuLab[i,j-1] == '.')
                {
                    j++;
                    Posicao novaPosicao = new Posicao(i, j);
                    minhaPilha.Push(novaPosicao);

                }
                else if (meuLab[i-1, j] == '.')
                {
                    i++;
                    Posicao novaPosicao = new Posicao(i, j);
                    minhaPilha.Push(novaPosicao);

                }
                if()
                //else if baixo i+1
                // else if esquerda j-1
                // else if cima i-1
                // if nao tiver vazio minhaPilha.Count()>0
                // i, j = pop
                // se tiver vazio
                // return false


                System.Threading.Thread.Sleep(200);
                Console.Clear();
                mostrarLabirinto(meuLab, limit, limit);
            } while (meuLab[i, j] != 'Q');
            // encontrou
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
