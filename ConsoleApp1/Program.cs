using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Morpion
    {
        public Case[,] Cases;
        public Symbol SymboleDuJoueurQuiDoitJouer;

        public static void JouerUneCase(Morpion morpion, Tour tourAJouer)
        {
            //1ère étape : récupère dans la grille de morpion la cellule qui correspond au tour à jouer
            Case laCaseJouee = morpion.Cases[tourAJouer.IndexLigneJouee, tourAJouer.IndexColonneJouee];

            //2ème étape : sur cette case, je lui positionne le symbole du joueur courant
            Symbol symbolAPositionnerDansCaseJouee = morpion.SymboleDuJoueurQuiDoitJouer;
            Case.PositionnerSymbol(laCaseJouee, symbolAPositionnerDansCaseJouee);

            //3ème étape : j'inverse le joueur courant
            Symbol leProchainSymbolQuiDoitJouer =
                morpion.SymboleDuJoueurQuiDoitJouer == Symbol.Croix ? Symbol.Rond : Symbol.Croix;
            morpion.SymboleDuJoueurQuiDoitJouer = leProchainSymbolQuiDoitJouer;
        }

        public static Symbol? DeterminerSymbolGagnant(Morpion morpion)
        {
            //Pour chaques lignes
            //  si toutes les cases de cette ligne ont le même symboles 
            //  et que ce symbole n'est pas "vide"
            //      alors le symbol gagnant est le symbol de la 1ère case de la ligne
            //      je retourne le symbole gagnant
            for (int indexLigne = 0; indexLigne < 3; indexLigne++)
            {
                if(morpion.Cases[indexLigne, 0].SymbolCourant != null &&
                    morpion.Cases[indexLigne, 0].SymbolCourant == morpion.Cases[indexLigne, 1].SymbolCourant
                    && morpion.Cases[indexLigne, 0].SymbolCourant == morpion.Cases[indexLigne, 2].SymbolCourant)
                {
                    return morpion.Cases[indexLigne, 0].SymbolCourant;
                }
            }

            //Pour chaques colonnes
            //  si toutes les cases de cette colonne ont le même symboles
            //  et que ce symbole n'est pas "vide"
            //      alors le symbole gagnant est le symbole de la 1ère case de la colonne
            //      je retourne le symbole gagnant

            for (int indexColonne = 0; indexColonne < 3; indexColonne++)
            {
                if (morpion.Cases[0, indexColonne].SymbolCourant != null &&
                    morpion.Cases[0, indexColonne].SymbolCourant == morpion.Cases[1, indexColonne].SymbolCourant
                    && morpion.Cases[0, indexColonne].SymbolCourant == morpion.Cases[2, indexColonne].SymbolCourant)
                {
                    return morpion.Cases[0, indexColonne].SymbolCourant;
                }
            }

            //Pour les 2 diagonales
            //  si toutes les cases de cette diagonale ont le même symboles
            //  et que ce symbole n'est pas "vide"
            //      alors le symbole gagnant est le symbole de la 1ère case de la diagonale
            //      je retourne le symbole gagnant

            if(morpion.Cases[0,0].SymbolCourant != null
                && morpion.Cases[0, 0].SymbolCourant == morpion.Cases[1, 1].SymbolCourant
                && morpion.Cases[0, 0].SymbolCourant == morpion.Cases[2, 2].SymbolCourant)
            {
                return morpion.Cases[0, 0].SymbolCourant;
            }


            if (morpion.Cases[2, 0].SymbolCourant != null
                && morpion.Cases[2, 0].SymbolCourant == morpion.Cases[1, 1].SymbolCourant
                && morpion.Cases[2, 0].SymbolCourant == morpion.Cases[0, 2].SymbolCourant)
            {
                return morpion.Cases[0, 0].SymbolCourant;
            }

            //Sinon
            //  Il n'y a aucun gagnant
            return null;
        }
    }

    public class Case
    {
        public Symbol? SymbolCourant;

        public static void PositionnerSymbol(Case laCase, Symbol nouveauSymbol)
        {
            laCase.SymbolCourant = nouveauSymbol;
        }
    }

    public enum Symbol
    {
        Croix,
        Rond,
    }

    public class Tour
    {
        public int IndexLigneJouee;
        public int IndexColonneJouee;
    }

}
