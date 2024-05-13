using System;
using System.Collections.Generic;

namespace poker.code.model.hand_ranks.ranks
{
       //Classe para avaliar a classificação Straight Flush.
    public class StraightFlush : Ranks
    {
        // Construtor (classe / base)
        List<Card> player; // Armazena as cartas do jogador
        List<List<Card>> straightFlush; // Temporária para a sequência específica
            
        public StraightFlush(List<List<Card>> h) : base(h) 
        {
            player = new List<Card>(); // Inicializa a lista de cartas do jogador
            straightFlush = new List<List<Card>>(); // Inicializa a lista de listas de cartas para o Straight Flush
        }
        
         //Implementação específica da classe StraightFlush para o método abstrato da classe base
        public override bool check()
        {
            if (check_straight() && find_owner())
            {
                Semantic.Suit suit_straightFlush = find_suit(); // Encontra o naipe do Straight Flush
                foreach (var cards_list in straightFlush)
                {
                    foreach (var card in cards_list)
                    {
                        if (card.suit_ == suit_straightFlush)
                            find.Add(card); // Adiciona cartas do Straight Flush à lista find
                    }
                }
                return find.Count == 5; // Retorna true se encontrar cinco cartas
            }
            return false;
        }

        // Verifica se existem cartas nas posições que satisfaçam a sequência 2/3/4/5/6 
        // Separa de <lists> as listas específicas da sequência e coloca em <straightFlush>
        private bool check_straight()
        {
            int count = 0;
            for (int i = 2; i < 7; i++) // Sequência de 2 a 6 
            {
                if (ranks_histo[i].Count > 0)                
                    count++;
            }       
            return count == 5; // Retorna true se houver cinco cartas consecutivas
        }
        
        // Verifica se existe em <straightFlush> uma ou duas cartas do jogador
        // Caso exista, coloca em <player>
        private bool find_owner()
        {
            for (int i = 2; i < 7; i++) // Sequência de 2 a 6
                straightFlush.Add(value_copy(ranks_histo[i]));
            
            foreach (var list_ in straightFlush)
            {
                foreach (var card in list_)
                {
                    if (card.owner == 1)// Verifica se o dono da carta é o jogador (owner == 1)
                    player.Add(card);   // e adiciona as cartas do jogador à lista player
 
                }
            }
            return player.Count > 0; // Retorna true se encontrar cartas do jogador
        }    
        
        // Define o naipe para validar
        private Semantic.Suit find_suit() 
        {
            // Neste ponto, obrigatoriamente terá uma lista com um card ...
            Semantic.Suit s = new Semantic.Suit(); // Inicializa uma variável para armazenar o naipe do Straight Flush
            foreach (var cards in straightFlush)   // Itera sobre cada lista de cartas em straightFlush
            {
                if (cards.Count == 1) // Verifica se a lista contém apenas uma carta
                    s = cards[0].suit_;   // Se contiver apenas uma carta, define o naipe como o naipe da primeira carta
            }
            return s;  // Retorna o naipe encontrado
        }
    }
}