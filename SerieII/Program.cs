using System;
using TreeBInDisk.Tree;

namespace SerieII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SERIE II\n");

            //Selección de grado para el árbol
            bool bGrado = false;
            int iGrado = 0;
            //Validación de valor para Grado
            while (bGrado == false)
            {
                Console.Write("Ingrese el grado del árbol: ");
                string sTryGrado = Console.ReadLine();
                if (int.TryParse(sTryGrado, out iGrado) == true)
                {
                    //Si el valor es apropiado, se ingresa
                    iGrado = int.Parse(sTryGrado);
                    bGrado = true;
                }
                else
                {
                    bGrado = false;
                    Console.WriteLine("**Ingrese un entero** \n");
                }
            }

            //Creación del árbol
            //MTree<int, int> Arbolito = new MTree<int, int>(iGrado);
            Tree<int> Arbolito = new Tree<int>();

            //Menú
            bool bMenuStay = true;
            while (bMenuStay == true)
            {
                Console.WriteLine("\nMENÚ");
                Console.WriteLine("1.Insertar valor");
                Console.WriteLine("2.Mostrar valores");
                Console.WriteLine("3.Buscar valor");
                Console.WriteLine("4.Salir \n");

                int iSeleccion = 0;
                bool bSeleccion = false;
                //Validación de valor para el Menú
                do
                {
                    Console.Write("Selección: ");
                    string sTrySeleccion = Console.ReadLine();
                    if (int.TryParse(sTrySeleccion, out iSeleccion) == true)
                    {
                        iSeleccion = int.Parse(sTrySeleccion);
                        bSeleccion = true;
                    }
                    else
                    {
                        bSeleccion = false;
                        Console.WriteLine("**Ingrese un entero** \n");
                    }
                } while (bSeleccion == false);

                switch (iSeleccion)
                {
                    //Insertar valor
                    case 1:
                        {
                            bool bInsertStay = true;
                            //Validación del valor a ingresar
                            while (bInsertStay == true)
                            {
                                int iInsert = 0;
                                bool bEntero = false;
                                while (bEntero == false)
                                {
                                    Console.Write("\nValor a insertar: ");
                                    string sTryInsert = Console.ReadLine();

                                    if (int.TryParse(sTryInsert, out iInsert) == true)
                                    {
                                        //Si el valor es apropiado, se ingresa
                                        iInsert = int.Parse(sTryInsert);
                                        bEntero = true;
                                    }
                                    else
                                    {
                                        bEntero = false;
                                        Console.WriteLine("**Ingrese un entero**");
                                    }
                                }
                                //Se hace la inserción al árbol como tal
                                Arbolito.Insert(iInsert, iInsert);

                                //Se pregunta si desea ingresar otro valor
                                ConsoleKey response;
                                do
                                {
                                    Console.WriteLine("\n¿Ingresar otro valor? [Y/N]");
                                    response = Console.ReadKey().Key;
                                    Console.WriteLine("");

                                } while (response != ConsoleKey.Y && response != ConsoleKey.N);

                                //Si la respuesta es No, se regresa al Menú
                                if (response == ConsoleKey.N)
                                {
                                    bInsertStay = false;
                                }
                            }
                            break;
                        }
                    //Mostrar valores
                    case 2:
                        {
                            Console.WriteLine("\nMostrando valores...\n++++++++++");
                            List<int> mostrar = new List<int>();
                            Arbolito.InOrden(ref mostrar);
                            foreach (var item in mostrar)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("++++++++++");
                            Console.Write("\nPress key for Menu\n");
                            Console.ReadKey();
                            break;
                        }
                    //Buscar valor
                    case 3:
                        {
                            //Validación del valor a buscar
                            int iBuscar = 0;
                            bool bEnteroBuscar = false;
                            while (bEnteroBuscar == false)
                            {
                                Console.Write("\nValor a buscar: ");
                                string sTryBuscar = Console.ReadLine();

                                if (int.TryParse(sTryBuscar, out iBuscar) == true)
                                {
                                    //Si el valor es apropiado, se ingresa
                                    iBuscar = int.Parse(sTryBuscar);
                                    bEnteroBuscar = true;
                                }
                                else
                                {
                                    bEnteroBuscar = false;
                                    Console.WriteLine("**Ingrese un entero**");
                                }
                            }
                            Console.WriteLine(Arbolito.IsElementInTree(iBuscar));
                            Console.Write("\nPress key for Menu\n");
                            Console.ReadKey();
                            break;
                        }
                    //Salir
                    case 4:
                        {
                            Console.WriteLine("\nAdiós...");
                            bMenuStay = false;
                            break;
                        }
                    default:
                        Console.WriteLine("**Seleccione una opción válida**");
                        break;
                }
            }


            Console.Write("\nPress key to end");
            Console.ReadKey();
        }
    }
}
