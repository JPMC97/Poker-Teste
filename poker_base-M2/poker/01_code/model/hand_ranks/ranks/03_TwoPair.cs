using System;
using System.Collections.Generic;

namespace poker.code.model.hand_ranks.ranks
{
     /*
    *   Classe para avaliar a categoria One Pair.
    *   Classe Base: Ranks
    */

    public class TwoPair : Ranks
    {
        //---------------------------------------------------------------------------------
        // Estados
        //---------------------------------------------------------------------------------
        // Construtor (classe / base)
        
        List<Card> player; // armazena as cartas do jogador
        List<List<Card>> two; // armazena os pares encontrados

        // Construtor da classe TwoPair
        public TwoPair(List<List<Card>> h) : base(h)
        {
             // Inicializa a lista de cartas do jogador
            player = new List<Card>();

             // Inicializa a lista temporária para armazenar duas sequências específicas de cartas
            two = new List<List<Card>>();
        }

        // Implementação específica da classe Two Pair para o método abstrato da classe base
        public override bool check()
        {
            FindPairs(); // verifica se há pares de cartas na mão do jogador
            return two.Count >= 2; // retorna true se pelo menos dois pares forem encontrados
        }

        // Verifica se há pares de cartas e armazena os pares encontrados
        private void FindPairs()
        {
             //  Itera a partir do índice 2
            for (int i = 2; i < ranks_histo.Count; i++)
            {
                if (ranks_histo[i].Count == 2) // verifica se há 2 pares de cartas
                {
                    two.Add(value_copy(ranks_histo[i])); // adiciona o par encontrado à lista de pares
                    foreach (var card in ranks_histo[i])
                    {
                        if (card.owner == 1) // verifica se a carta pertence ao jogador
                        {
                            player.Add(card); // adiciona a carta ao jogador se ele for o proprietário
                        }
                    }
                }
            } // Fim do loop for
        }
    } // Fim da classe
} // Fim do namespace