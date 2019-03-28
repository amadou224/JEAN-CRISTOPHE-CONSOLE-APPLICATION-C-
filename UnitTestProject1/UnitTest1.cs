using ConsoleApp3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
       

            public void Addition2()
            {
                Operation add = new Operation(2, "+", 3);
                float result = add.GetResultat();
                Assert.AreEqual(5, result, "L'addition de 2 +3 doit renvoyer 5");
            }

        [TestMethod]
        public void soustraction()
        {
            Operation soust = new Operation(3, "-", 5);
            float result = soust.GetResultat();
            Assert.AreEqual(-2, result, "le resultat de 3-5 vaut -2");
        }

        [TestMethod]
        public void produit()
        {
            Operation prod = new Operation(6, "*", 8);
            float result = prod.GetResultat();
            Assert.AreEqual(48, result, "Le produit de 6 et 8 vaut 48");
        }

        [TestMethod]
        public void additon3()
        {
            // etant donné
            Operation add = new Operation(2, "+", 3);
           int monResult = DataAccess.NbreCalculs();

            //Lorsque 
            DataAccess.EnregistreOperation(add.operandeGauche,add.operateur,add.operandeDroite);
            int result2 = DataAccess.NbreCalculs();

            // Alors
            Assert.IsTrue(result2 == monResult + 1, "Nbre d'operation a augmente de 1");

        }
        [TestMethod]
        public void soustr()
        {
            Operation add = new Operation(4,"-",4);
           
            DataAccess.EnregistreOperation(add.operandeGauche,add.operateur,add.operandeDroite);
            List<Operation> resu  = DataAccess.RecupListDoperationEffectuee();
            Operation derniere = resu[resu.Count - 1];
            Assert.AreEqual(add.operandeGauche, derniere.operandeGauche);
            Assert.AreEqual(add.operandeDroite, derniere.operandeDroite);
            Assert.AreEqual(add.operateur, derniere.operateur);

        }
        [TestMethod]
        public void divisionParZero()
        {
            Operation div = new Operation(4,"/",0);

            Assert.ThrowsException<Exception>(() =>
            {
                div.GetResultat();


            });

        }

        [TestMethod]
    
        public void puissance()
        {
            Operation puis = new Operation(-6,"^",-1);
            Assert.ThrowsException<Exception>(() =>
            {
                puis.GetResultat();
            });
        } 

        [TestMethod]
        public void nouvoAddition()
        {
            Operation addition = new Operation(2, "+", 3);

           bool resultat = addition.isvalide(); 
          

            Assert.IsTrue( resultat == true, "Le resultat est valide");
        }



        [TestMethod]
        public void nouvoPuissance ()
        {
            Operation puissance = new Operation(-6,"^",-1 );
            bool resultat = puissance.isvalide();
            Assert.IsFalse(resultat == true, "Le resultat est faux");
        }

       
        
        
        
        /*  public void DivisionParZero()
        {
            //Etat initial
            Operation operation = new Operation(10, "/", 0);

            try
            {
                operation.GetResultat();
                Assert.Fail("La division par zéro ne doit pas renvoyer de valeur");
            }
            catch (Exception)
            {
                //Cas attendu
            }
        }*/



    }
}

