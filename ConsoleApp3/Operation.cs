using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class Operation
    {
        public float operandeGauche { get; private set; }
        public string operateur { get; private set; }
        public float operandeDroite { get; private set; } 

        public Operation (float premierNbre,string ope ,float deuxiemeNbre)
        {
            this.operandeGauche = premierNbre;                                                  // constructeur de la classe operation 
            this.operateur = ope;
            this.operandeDroite = deuxiemeNbre;
        }

        public float GetResultat()
        {
            switch (operateur)
            {
                case "+":
                    return operandeGauche + operandeDroite;
                case "-":
                    return operandeGauche - operandeDroite;
                case "*":
                    return operandeGauche * operandeDroite;
                case "/":
                    if (operandeDroite == 0)

                    {
                        throw new Exception("Division par zero");
                    }
                   
                    return operandeGauche / operandeDroite;

                case "^":
                    if(operandeDroite<0 && operandeGauche <0)
                    {
                        throw new Exception("Operande inferieur a 0");
                    }
                    return (float)Math.Pow(operandeGauche, operandeDroite);
            }
            throw new Exception("operateur non reconnu");   // exception 
        }


        public bool isvalide()
        {
            switch (operateur)
            {
                case "/":
                    return operandeDroite != 0.0f;
                case "^":
                    return operandeDroite >= 0.0f;
                default:
                return true;
            }
        }

    }

}
