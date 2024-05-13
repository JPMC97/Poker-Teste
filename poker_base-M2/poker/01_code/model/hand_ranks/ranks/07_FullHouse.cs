using System;
using System.Collections.Generic;

namespace poker.code.model.hand_ranks.ranks
{
    /*
    *   Classe para avaliar a categoria Full House.
    *   Classe Base: Ranks
    */
    public class FullHouse : Ranks
    {
        //---------------------------------------------------------------------------------
        // Estados
        //---------------------------------------------------------------------------------
        // Construtor (classe / base)

        List<Card> player; // armazena as cartas do jogador

        // Construtor da classe Full House
        public FullHouse(List<List<Card>> h) : base(h)
        {
             // Inicializa a lista de cartas do jogador
            player = new List<Card>();
        }

        // Implementação específica da classe Full House
        // para o método abstrato da classe base
        public override bool check()
        {   
            // Verifica se a mão contém um Full House e se o jogador é o vencedor
            if (CheckFullHouse() && FindWinner())
            {
                return true;
            }
            return false;
        }

        // Verifica se existe uma trinca (trio) e um par
        // e armazena em <player>
        private bool CheckFullHouse()
        {
            // Variáveis para controlar a existência de um trio e um par
            bool trioFound = false;
            bool pairFound = false;

            // Itera sobre os valores das cartas (2 a Ás)
            for (int i = 2; i < 15; i++)
            {
                // Verifica se o valor atual tem três cartas
                if (ranks_histo[i].Count == 3)
                {
                    trioFound = true;
                }
                // Verifica se o valor atual tem duas cartas
                else if (ranks_histo[i].Count == 2)
                {
                    pairFound = true;
                }
            }

            // Retorna se foi encontrado um trio e um par
            return trioFound && pairFound;
        }

        // Verifica se existe um jogador com o trio e o par
        // Caso exista, coloca em <player>
        private bool FindWinner()
        {
            // Itera sobre o dicionário de valores e suas cartas
            foreach (var list in ranks_histo)
            {
                // Verifica se o valor atual tem três cartas
                if (list.Count == 3)
                {
                    player = list;
                }
                // Verifica se o valor atual tem duas cartas
                else if (list.Count == 2)
                {
                    player = list;
                    return true;
                }
            }

            // Retorna falso se não foi encontrado um jogador com o trio e o par
            return false;
        }
    }
}