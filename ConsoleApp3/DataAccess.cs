using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp3
{
    public class DataAccess
    {

        const string con = (@"Server=.\SQlExpress;Database=calculatrice;Trusted_Connection=Yes");

        public static void EnregistreOperation(double OperandeGauche, string Operateur, double OperandeDroite)
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


        public static int NbreCalculs()
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand newRequete = new SqlCommand(("Select COUNT(*) FROM Operation"), connection);
            int calcul = (int)newRequete.ExecuteScalar();     // lorsqu'il recupere juste un nombre  executescalar 
            connection.Close();
            return calcul;

        }


        // Troisieme requete sql 

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




        }
    }
}
