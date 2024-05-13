using System;
using System.Collections.Generic;

namespace poker.code.model.hand_ranks.ranks
{
     /*
    *   Classe para avaliar a categoria One Pair.
    *   Classe Base: Ranks
    */
    
    public class ThreeofaKind : Ranks
    {
        //---------------------------------------------------------------------------------
        // Estados
        //---------------------------------------------------------------------------------
        // Construtor (classe / base)

        List<Card> player; // armazena as cartas do jogador
        List<List<Card>> threeOfAKind; // armazena o conjunto de três cartas do mesmo valor

        // Construtor da classe ThreeofaKind
        public ThreeofaKind(List<List<Card>> h) : base(h)
        {
            // Inicializa a lista de cartas do jogador
            player = new List<Card>();

            // Inicializa a lista temporária para armazenar sequências específicas
            threeOfAKind = new List<List<Card>>();
        }

        // Implementação específica da classe Three Of A Kind para o método abstrato da classe base

        public override bool check()
        {
            FindThreeOfAKind(); // verifica se há uma sequência de 3 cartas de mesmo valor na mão do jogador
            return player.Count > 0; // retorna true se houver pelo menos uma sequência de mesmo valor na mão do jogador
        }

        // Verifica se há uma sequência de três cartas com o mesmo valor e armazena
        private void FindThreeOfAKind()
        {
             //  Itera a partir do índice 2
            for (int i = 2; i < ranks_histo.Count; i++)
            {
                if (ranks_histo[i].Count == 3) // verifica se há um conjunto de três cartas com o mesmo valor
                {
                    threeOfAKind.Add(value_copy(ranks_histo[i])); // adiciona a sequência de três cartas do mesmo valor à lista de sequência
                    foreach (var card in ranks_histo[i])
                    {
                        if (card.owner == 1) // verifica se a carta pertence ao jogador
                        {
                            player.Add(card); // adiciona a carta ao jogador se ele for o proprietário
                        }
                    }
                }
            }
        }
    }
}