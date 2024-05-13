
using System;
using System.Collections.Generic;

namespace poker.code.model.hand_ranks.ranks
{
    public class Flush : Ranks                           // Herança: Flush herda da classe Ranks
    {
        // Abstração: As listas player e flush representam dados da classe Flush,ocultando detalhes de implementação específicos.
        List<Card> player;                                // armazena as cartas
        List<List<Card>> flush;                           // temporaria para a sequencia especifica
          

        // Encapsulamento: Método público que encapsula a inicialização dos estados da classe Flush.
        public Flush (List<List<Card>> h) : base (h)
        {
            player = new List<Card>();
            flush = new List<List<Card>>();
        }
        
        //implementacao especifica da classe Flush para o metodo abstrato da classe base
        // Polimorfismo: Este método substitui (override) o método abstrato da classe base Ranks, e fornece uma implementação para Flush.
        public override bool check()  
        {
            if(faind_woner())                            // Verifica se há pelo menos uma carta do jogador no flush
            {
                Semantic.Suit suit_flush = find_suit();  // Utiliza um método específico para encontrar o naipe do flush
                                                        
                foreach (var cards_list in flush)       // Itera sobre as listas de cartas do flush
                {
                    foreach (var card in cards_list)
                    {
                        
                        if (card.suit_ == suit_flush)  // Compara os naipes das cartas com o naipe do flush
                            find.Add(card);           // Adiciona as cartas do flush à lista find
                    }
                }
                if (find.Count == 5)                  // Verifica se foram encontradas cinco cartas do flush
                {
                    foreach (Card c in find)
                    {
                        if (c.owner == 1)             // Verifica se todas as cartas do flush pertencem ao jogador
                            return true;              // Se sim, retorna verdadeiro
                    }

                }
                
                return find.Count == 5;               //Retorna o resultado da verificação do tamanho da lista find.
            }
            return false;                             // Retorna falso se não houver cartas do jogador no flush
        }

            //verifica se existe flush uma ou duas cartas, se existir coloca em player
            //Método privado usado para encapsular a lógica de verificação de cartas.
        private bool faind_woner() 
        {
            for (int i = 0; i < 15; i++)               // Itera sobre os valores de carta de 2 a 14 (A)
                flush.Add(value_copy(ranks_histo[i])); // adiciona listas de cartas do jogador à lista flush
                                                       
            
            foreach(var list_ in flush)                // Itera sobre cada lista de cartas em flush
            {
                foreach (var Card in list_)            // Verifica o dono de cada carta na lista
                {
                    if(Card.owner == 1)  
                    {
                        player.Add(Card);              //Adiciona as cartas do jogador à lista player.
                    }
                }
            }
            return player.Count > 0 ? true : false;    //Retorna true se o jogador possuir cartas no flush.
        }    
        
            //privado utilizado internamente para encontrar o naipe do flush.
        private Semantic.Suit find_suit() 
        {
            Semantic.Suit s = new Semantic.Suit();    // Inicializa uma variável para armazenar o naipe do flush
            foreach (var cards in flush)              // Itera sobre cada lista de cartas em flush
            {
                if (cards.Count == 1)                 // Verifica se a lista contém apenas uma carta
                    s = cards[0].suit_;               // tiver apenas uma carta, define o naipe como o naipe da primeira carta
            }
            return s;                                 // Retorna o naipe encontrado
        }
    }
}
