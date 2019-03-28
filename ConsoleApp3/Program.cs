using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace ConsoleApp3
{
    class Program
    {
       // const string con = (@"Server=.\SQlExpress;Database=calculatrice;Trusted_Connection=Yes");
        static void Main(string[] args)
        {
            int valeurOperandeGauche = DemanderOperandeALUtilisateur("Veuillez entrer l'opérande de gauche :");

            string operateur = DemanderOperateurALUtilisateur();

            int valeurOperandeDroite = DemanderOperandeALUtilisateur("Veuillez entrer l'opérande de droite :");
            Operation operation = new Operation(valeurOperandeGauche, operateur, valeurOperandeDroite);

            if (valeurOperandeGauche != 0 || valeurOperandeDroite != 0)
            {
                if (operation.isvalide())
                {
                    float resultat = operation.GetResultat();
                    Console.WriteLine("Resultat" + resultat);
                }
                else
                {
                    Console.WriteLine("Operation invalide");
                }
            }
            else
            {
                Console.WriteLine("Ces valeurs ne sont pas permises");
            }
            Console.ReadKey();

            //switch (operateur)
            //{
            //    case "+":
            //        {
            //            int resultat = valeurOperandeGauche + valeurOperandeDroite;
            //            Console.WriteLine("Addition : " +  resultat);
            //        }
            //        break;
            //    case "-":
            //        {
            //            int resultat = valeurOperandeGauche - valeurOperandeDroite;
            //            Console.WriteLine("soustraction : " + resultat);
            //        }
            //        break;

            //    case "*":
            //        {
            //            int resultat = valeurOperandeGauche * valeurOperandeDroite;
            //            Console.WriteLine("Multiplication : " + resultat);
            //        }
            //        break;

            //    case "/":
            //        {
            //            if (valeurOperandeDroite != 0)
            //            {
            //                int resultat = valeurOperandeGauche / valeurOperandeDroite;
            //                Console.WriteLine("Division : " + resultat);
            //            }
            //            else
            //            {
            //                Console.WriteLine("On ne peut pas faire de division par zéro");
            //            }
            //        }
            //        break;

            //    case "^":
            //        {
            //            if (valeurOperandeDroite >= 0)
            //            {
            //                double resultatPuissance = Math.Pow(valeurOperandeGauche, valeurOperandeDroite);
            //                Console.WriteLine("Puissance : " + resultatPuissance);
            //            }
            //            else
            //            {
            //                Console.WriteLine("On ne souhaite pas calculer des puissances inférieures à 0");
            //            }
            //        }
            //        break;
            //    default:
            //        {
            //            Console.WriteLine("Cet opérateur n'est pas connu");
            //        }
            //        break;
            // }

            DataAccess.EnregistreOperation(valeurOperandeGauche, operateur, valeurOperandeDroite);   // premiere requete sql 


            Console.ReadKey();

            int Nbre = DataAccess.NbreCalculs();                                                    // deuxieme requete sql
            Console.WriteLine("Vous avez " + Nbre + "operations");

            Console.ReadKey();

            List<Operation> operationRecupDepuisBDD = DataAccess.RecupListDoperationEffectuee();          // troisieme requete sql 

            foreach (var op in operationRecupDepuisBDD)
            {
                Console.WriteLine($"Vous avez effecutué les operations :{ op.operandeGauche} { op.operateur} { op.operandeDroite}");
            }

            Console.ReadKey();
        }



        static int DemanderOperandeALUtilisateur(string message)
        {
            string saisieUtilisateur = DemanderSaisieUtilisateur(message);
            int valeurParsee = int.Parse(saisieUtilisateur);
            return valeurParsee;
        }

        static string DemanderOperateurALUtilisateur()
        {
            string operateur = DemanderSaisieUtilisateur("Veuillez saisir l'opérateur");
            return operateur;
        }

        static string DemanderSaisieUtilisateur(string message)
        {
            Console.WriteLine(message);
            string saisieUtilisateur = Console.ReadLine();
            return saisieUtilisateur;
        }

        /* public static void EnregistreOperation(double OperandeGauche, string Operateur, double OperandeDroite)
         {
             SqlConnection connection = new SqlConnection(con);
             connection.Open();
             SqlCommand myrequete = new SqlCommand("Insert into Operation(OperandeGauche,Operateur,OperandeDroite) Values(@ope1,@operat,@ope2)", connection);
             var operParameter = new SqlParameter("@ope1", OperandeGauche);
             var operandeParameter = new SqlParameter("@operat", Operateur);
             var operatdParameter = new SqlParameter("@ope2", OperandeDroite);
             myrequete.Parameters.Add(operParameter);
             myrequete.Parameters.Add(operandeParameter);
             myrequete.Parameters.Add(operatdParameter);
             myrequete.ExecuteNonQuery();

             connection.Close();
         }
         */

        //  requete sql qui compte le nbre calcul dans la base de donnees 
        /*  public static int NbreCalculs()
          {
              SqlConnection connection = new SqlConnection(con);
              connection.Open();
              SqlCommand newRequete = new SqlCommand(("Select COUNT(*) FROM Operation"), connection);
              int calcul = (int)newRequete.ExecuteScalar();     // lorsqu'il recupere juste un nombre  executescalar 
              connection.Close();
              return calcul;

          }*/
        // Ecrivez les calculs qui ont été faites  , ecrivez les resultats qui ont été calculer  => appelez objet   



        /*
    public static List<Operation> RecupListDoperationEffectuee()
    {
        List<Operation> nouvoList = new List<Operation>();
        using (SqlConnection connection = new SqlConnection(con))
        {
            connection.Open();
            SqlCommand nouveauRequete = new SqlCommand(("Select OperandeGauche,Operateur,OperandeDroite FROM Operation"), connection);
            SqlDataReader reader = nouveauRequete.ExecuteReader();
            while (reader.Read())
            {
                float OperandeGauche = (float)reader["OperandeGauche"];
                float OperandeDroite = (float)reader["OperandeDroite"];
                string Operateur = (string)reader["Operateur"];

                Operation operationCourante = new Operation(OperandeGauche, Operateur, OperandeDroite);
                nouvoList.Add(operationCourante);
            }
            connection.Close();
            return nouvoList;

        }

*/


    }

}


