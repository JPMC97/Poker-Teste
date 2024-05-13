using System;
using System.Collections.Generic;

namespace poker.code.model.hand_ranks.ranks
{
    /*
    *   Classe para avaliar a categoria Four of a Kind.
    *   Classe Base: Ranks
    */
    public class FourOfKind : Ranks
    {
        //---------------------------------------------------------------------------------
        // Estados
        //---------------------------------------------------------------------------------
        // Construtor (classe / base)
        List<Card> player; // armazena as cartas do jogador

        //Construtor da classe FourOfKind
        public FourOfKind(List<List<Card>> h) : base(h)
        {
            player = new List<Card>();
        }

        // Implementação específica da classe Full House
        // para o método abstrato da classe base
        public override bool check()
        {
            // Verifica se a mão contém um Four of a Kind e se o jogador é o vencedor
            if (CheckFourOfKind() && FindWinner())
            {
                return true;
            }
            return false;
        }

        // Verifica se existe um Four Of Kind
        // e armazena em <player>
        private bool CheckFourOfKind()
        {
            // Itera sobre os valores das cartas (2 a Ás)
            for (int i = 2; i < 15; i++)
            {
                // Verifica se o valor atual tem quatro cartas
                if (ranks_histo[i].Count == 4)
                {
                    // Caso possua quatro cartas iguais, retorna como verdadeiro
                    return true;
                }
            }
            // Caso não possua quatro cartas iguais, retorna como falso
            return false;
        }

        // Verifica se existe um jogador com o Four Of Kind
        // Caso exista, coloca em <player>
        private bool FindWinner()
        {
            // Itera sobre o dicionário de valores e suas cartas
            foreach (var list in ranks_histo)
            {
                // Verifica se o valor atual tem quatro cartas
                if (list.Count == 4)
                {
                    player = list;
                    return true;
                }
            }
            // Retorna falso se não foi encontrado um jogador com um Four of Kind
            return false;
        }
    }
}