using System;
using System.Collections.Generic;

namespace mahric_operation_polonaise
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string> list = Saisie();
            
            Affichage(Resolution(list));
           

        }



        private static List<String> Saisie()
        {
            String saisie;
            List<String> list;


            Console.WriteLine("Entrée votre équation en séparant les membre par un espace");
           
            
            saisie= Console.ReadLine();

            list = String_to_List(saisie, ' ');
            if ( list == null || list.Count<3 )
            {
                Console.WriteLine("Saisie incorrecte. A pour relancer et une autre pour terminer");
                saisie = Console.ReadLine();

                if (saisie == "A")
                {
                    return Saisie();
                }
                else
                {
                    return null;
                }
            }
            
            return list; 
        }

        
      

        public static List<String> String_to_List(string str, char separator)
        {
            List<string> result = new List<string>();
            String val;
            int startIndex = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == separator)
                {
                    val=str.Substring(startIndex, i - startIndex);
                    if (Not_Unaire(val))
                    {
                        result.Add(val);
                    }
                    else
                    {
                        return null;
                    }


                    startIndex = i + 1;
                }
            }
            result.Add(str.Substring(startIndex));
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool Not_Unaire(string str)
        {
            if (str.Length == 1 && Is_Operatore(str[0]))
            {
                return true;
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    
                    if (Is_Operatore(str[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool Is_Operatore(char str)
        {
            if (str == '+' || str == '-' || str == '*' || str == '/')
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        private static int Resolution(List<String> list)
        {
            int index_first_operator;


            while (list.Count > 1)
            {
                index_first_operator = Find_Index_First_Operator(list);
                if (index_first_operator <2 || index_first_operator>=list.Count)
                {
                    throw new Exception("Expression non solvable"); 
                }
                else
                {
                    
                    if ((list = Calcul(list, index_first_operator)) == null)
                    {
                        throw new Exception("Expression non solvable");
                        
                    }
                }
            }
            return int.Parse(list[0]);
        }


        private static List<String> Calcul(List<String> list, int index_first_operator)
        {
            double result = 0;
            try
            {
                switch (list[index_first_operator])
                {
                    case "+":
                        result = double.Parse(list[index_first_operator - 2]) + double.Parse(list[index_first_operator - 1]);
                        break;
                    case "-":
                        result = double.Parse(list[index_first_operator - 2]) - double.Parse(list[index_first_operator - 1]);
                        break;
                    case "*":
                        result = double.Parse(list[index_first_operator - 2]) * double.Parse(list[index_first_operator - 1]);
                        break;
                    case "/":
                        result = double.Parse(list[index_first_operator - 2]) / double.Parse(list[index_first_operator - 1]);
                        break;
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
            list[index_first_operator - 2] = result.ToString();
            list.RemoveAt(index_first_operator - 1);
            list.RemoveAt(index_first_operator - 1);
            return list;
        }
        





    private static int Find_Index_First_Operator(List<String> list)
        {
            int index = 0;
            while ( list.Count > index && list[index] != "+" && list[index] != "-" && list[index] != "*" && list[index] != "/" )
            {
                index++;
                
            }
            return index;
        }


        private static void Affichage(int result)
        {
            
           
                Console.WriteLine("le résultat est : " + result);
            
        }

    }
}
