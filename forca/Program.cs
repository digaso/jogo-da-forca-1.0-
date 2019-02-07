using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace forca
{
    class Program
    {

        
       static bool flag;
        static void Main(string[] args)
        {
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (File.Exists(@"C:..\..\..\data\palavras.txt") == false || File.Exists(@"C:..\..\..\data\logs.txt") == false || File.Exists(@"c:..\..\..\data\dados.txt") == false)
            {
                Directory.CreateDirectory(@"C:..\..\..\data");
                StreamWriter r = new StreamWriter(@"C:..\..\..\data\palavras.txt");
                StreamWriter v = new StreamWriter(@"c:..\..\..\data\logs.txt");
                StreamWriter d = new StreamWriter(@"c:..\..\..\data\dados.txt");
                d.Write("false");
                d.Close();
                r.Close();
                v.Close();

            }
            //File.ReadLines(@"C:..\..\..\data\palavras.txt").Skip(numero da linha).First;
            string[] x = File.ReadAllLines(@"c:..\..\..\data\dados.txt");
            if (x[0] == "true")
                flag = true;
            else
                flag = false;

            do
            {

                try
                {

                    Console.Clear();

                    switch (Menu())
                    {
                        case 1:
                            if (flag== true)

                                jogar();
                            else
                            {
                                Console.WriteLine("Adiciona primeiro palavras na opção 'Ficheiro' e depois 'adicionar palavras'");
                                Console.ReadKey();
                            }  
                            break;
                        case 2:
                            ficheiros();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("1º adiciona palavras caso não o tenhas feito já\n2ºescolhes a opção jogar\n\n\nDepois é só escolheres letras que achas que estão na palavra apresentada\n por cada letra errada vai-se adicionando membros\nquando tiver todos os membros\n PERDES");
                            Console.ReadKey();
                            break;
                        case 4:

                            logs();
                            break;

                        case 5:

                            Console.Clear();
                            Console.WriteLine("Créditos\n Tudo -> Diogo Alves");
                            Console.ReadKey();
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        
                        default:

                            Console.Clear();
                            Console.WriteLine("Opção errada, tente outra vez");
                            Console.Clear();
                            break;
                    }

                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    continue;

                }
            } while (true);
        }

        static void ficheiros()
        {
            int ji = 0;
            do
            {
               
                try
                {
                    Console.Clear();
                    Console.WriteLine("Ficheiros \n\n1-Limpar palavras e temas\n2-Mostrar palavras e temas\n3-Adicionar Palavras\n4-Limpar Log\n5-Voltar para o menu");
                    ji = Convert.ToInt32(Console.ReadLine());

                    switch (ji)
                    {
                        case 1:
                            FileStream f = File.Create(@"C:..\..\..\data\palavras.txt");
                            f.Close();
                            FileStream filestream = File.Open(@"c:..\..\..\data\dados.txt", FileMode.Open);
                            filestream.SetLength(0);
                            filestream.Close();
                            StreamWriter file = new StreamWriter(@"c:..\..\..\data\dados.txt");
                            file.Write("false");
                            file.Close();
                            flag = false;
                            Console.WriteLine("Limpo!!");

                            Console.ReadKey();
                            break;
                        case 2:
                            string[] aux = new string[2];
                            Console.Clear();
                            StreamReader o = new StreamReader(@"c:..\..\..\data\palavras.txt");
                            string[] linha = File.ReadAllLines(@"C:..\..\..\data\palavras.txt");
                            for (int i = 0; i < linha.Length; i++)
                            {
                                aux = linha[i].Split(',');
                                Console.Write("Palavra:{0}  ", aux[0]);
                                Console.WriteLine("Tema:{0}  ", aux[1]);
                            }
                            

                            Console.WriteLine("\nPressione qualquer tecla");
                            Console.ReadKey();
                            o.Close();
                            break;
                        case 3:
                            adicionar();
                            break;
                        case 4:
                            FileStream y = File.Create(@"C:..\..\..\data\logs.txt");
                            y.Close();
                            Console.WriteLine("Limpo!!!");
                            Console.ReadKey();
                            break;
                        case 5:

                            Console.WriteLine("Escolheste sair do menu ficheiros ...");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Opção errada");
                            Console.ReadKey();
                            break;
                    }


                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.ReadKey();

                }

            } while (ji !=5);
        }
        public static int Menu()
        {

            Console.WriteLine("JOGO DA FORCA");
            Console.WriteLine("\n\nMenu\n\n\n");
            Console.WriteLine("1-Jogar".PadRight(15) + "4-Ver Logs");
            Console.WriteLine("2-Ficheiros".PadRight(15)+"5-Créditos");
            Console.WriteLine("3-Regras".PadRight(15) + "6-Sair e guardar :(");

            return Convert.ToInt32(Console.ReadLine());
        }
        static void Forca(string nome, int t,string[] bin)
        {
            Console.Clear();
            Console.WriteLine("{0}: {1} tentativas    Tema:{2}", nome, t, bin[1]);
            Console.SetCursorPosition(0, 3);

            Console.WriteLine(" __________");
            Console.WriteLine("|	   |");
            Console.WriteLine("|          " + (t < 6 ? "o" : ""));
            Console.WriteLine("|         " + (t < 3 ? @"/|\" : (t < 4 ? "/|" : (t < 5 ? "/" : ""))));
            Console.WriteLine("|         " + (t < 2 ? @"/" : (t <1  ? @"/\" : ""))); ;
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|____________");
            Console.WriteLine("\n\n\n");
        }
        public static void jogar()
        {


            int t = 6, lvl = 0, n;
            bool band = true;
            Console.WriteLine("digite o seu nome:");
            string nome = Console.ReadLine();
            
            
                string[] bin = new string[2];
                Random r = new Random();
                n = r.Next(0, File.ReadAllLines(@"C:..\..\..\data\palavras.txt").Length);
                bin = File.ReadLines(@"C:..\..\..\data\palavras.txt").Skip(n).First().Split(',');
                char[] teste = bin[0].ToCharArray(), montra = new char[teste.Length * 2], usadas = new char[26];
                int g = 0;
                Console.WriteLine(teste.Length);

                for (int i = 0; i < montra.Length; i += 2)
                {
                    montra[i] = '_';
                }
                for (int i = 1; i < montra.Length; i += 2)
                {
                    montra[i] = ' ';
                }
                do
                {
                    if (!band)
                    {
                        t--;
                    }
                    band = true;
                    Forca(nome, t, bin);
                    for (int i = 0; i < montra.Length; i++)
                    {
                        Console.Write(montra[i]);
                        
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(17, 5);
                    Console.Write("Letra: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    try
                    {

                        Char l = Convert.ToChar(Console.ReadLine());
                        Console.SetCursorPosition(17, 5);
                       int j = 0;

                        if (teste.Contains(l))
                        {
                            for (int i = 0; i < teste.Length; i += 1)
                            {

                                if (l == teste[i])
                                {
                                    teste[i] = ' ';
                                    montra[j] = l;
                                    usadas[g] = l;
                                    

                                }
                                j += 2;
                            }
                        }else if (usadas.Contains(l)){

                        }
                        else 
                        {
                            usadas[g] = l;
                            band = false;
                            
                        }
                        g++;

                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Clear();

                        continue;
                    }
                    if(t == 0)
                     {
                         break;

                      }
                     if (!montra.Contains('_'))
                    {
                         break;
                    }




                } while (2+2 == 4);
                Console.Clear();
                if (!montra.Contains('_'))
                {
                    Console.Clear();
                    Console.WriteLine("Boa.  Ganhaste!!!!! ÉS O REIII");
                    
                    StreamWriter q = File.AppendText(@"c:..\..\..\data\logs.txt");
                    q.WriteLine("{1} ganhou um jogo ás {0} ", DateTime.Now,nome);
                    q.Close();
                    Console.ReadKey();
                }
                else if (t == 0)
                {
                    Console.Clear();
                    Console.WriteLine("pErDEsTe EheHe!");
                    Console.ReadKey();
                    StreamWriter k = File.AppendText(@"c:..\..\..\data\logs.txt");
                    k.WriteLine("{1} perdeu um jogo ás {0} ", DateTime.Now, nome);
                    k.Close();
                    
                }
            

            

        }


        public static void adicionar()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("palavra a adicionar: ");
            StreamWriter p = File.AppendText(@"C:..\..\..\data\palavras.txt");
            p.Write(Console.ReadLine());
            Console.Write("\ntema da palavra: ");
            p.WriteLine("," + Console.ReadLine());
            p.Close();
            StreamWriter n = File.AppendText(@"c:..\..\..\data\logs.txt");
            n.WriteLine("Adicionou uma palavra ás {0} ", DateTime.Now);
            n.Close();
            flag = true;
            FileStream filestream = File.Open(@"c:..\..\..\data\dados.txt", FileMode.Open);
            filestream.SetLength(0);
            filestream.Close();
            StreamWriter file = new StreamWriter(@"c:..\..\..\data\dados.txt");
            file.Write("true");
            file.Close();

            Console.WriteLine("Gravado!!!!!!!!!!");
            Console.ReadKey();
        }

        public static void logs()
        {
            Console.Clear();
            StreamReader o = new StreamReader(@"c:..\..\..\data\logs.txt");
            string[] linha = File.ReadAllLines(@"c:..\..\..\data\logs.txt");
            for (int i = 0; i < linha.Length; i++)
            {
                Console.WriteLine(linha[i]);
            }
            Console.ReadKey();
            o.Close();

        }
    }
   
}
