using System;
using System.Collections.Generic;

namespace poker.code.model.hand_ranks.ranks
{
    /*
    *   Class to evaluate Straight rank.
    *   Base Class: Ranks
    */
    public class Straight : Ranks
    {
        //---------------------------------------------------------------------------------
        // Estados
        //---------------------------------------------------------------------------------
        // Construtor (classe / base)

        List<Card> player; // armazena as cartas do jogador
        List<Card> straightCards; // armazena as cartas que formam uma sequência (straight)

        // Construtor da classe Straight     
        public Straight(List<List<Card>> h) : base(h) 
        {
              // Inicializa a lista de cartas do jogador
            player = new List<Card>();

            // Inicializa a lista temporária para armazenar a sequência específica
            straightCards = new List<Card>();
        }
        
        //implementação específica da classe Straight
        //para o método abstrato da classe base
        public override bool check()
        {
            // Verifica se a mão contém uma sequência de 5 cartas e se o jogador é o proprietário dessa sequência
            if (chekStraight() && FindOwner())
            {
                // Para cada carta na sequência de 5 cartas encontrada
                foreach (var card in straightCards)
                {
                     // Verifica se a carta pertence ao jogador (proprietário)
                    if (card.owner == 1)
                        return true;
                }
            }
             // Retorna falso se a mão não tiver uma sequência ou se o jogador não for o proprietário
            return false;
        }

        // verifica se há uma sequência presente nas cartas
        // se existir, armazena as cartas do straight em straightCards
        private bool chekStraight()
        {
            // Itera  do 2 até o 10
            for (int i = 2; i <= 10; i++)
            {   
                // Verifica se há cartas presentes para os próximos cinco valores consecutivos
                if (ranks_histo[i].Count > 0 &&
                    ranks_histo[i + 1].Count > 0 &&
                    ranks_histo[i + 2].Count > 0 &&
                    ranks_histo[i + 3].Count > 0 &&
                    ranks_histo[i + 4].Count > 0)
                {
                    // Se todas as cinco cartas consecutivas estiverem presentes, adiciona as cartas à lista straightCards
                    straightCards.Add(ranks_histo[i][0]);
                    straightCards.Add(ranks_histo[i + 1][0]);
                    straightCards.Add(ranks_histo[i + 2][0]);
                    straightCards.Add(ranks_histo[i + 3][0]);
                    straightCards.Add(ranks_histo[i + 4][0]);

                    return true; // Retorna verdadeiro indicando que uma sequência foi encontrada
                }
            }
            return false; // Retorna falso se não for encontrada uma sequência
        }
        
        // verifica se as cartas do straight contêm uma carta do jogador
        private bool FindOwner()
        {
            // Itera sobre cada carta na lista straightCards
            foreach (var card in straightCards)
            {
                // Verifica se a carta pertence ao jogador
                if (card.owner == 1)
                {
                    // Se a carta pertencer ao jogador, adiciona à lista de cartas do jogador
                    player.Add(card);
                }
            } 
             // Retorna verdadeiro se pelo menos uma carta do jogador estiver presente nas cartas do straight
            return player.Count > 0;
        }
    }
}
