using System;
using System.Collections.Generic;

namespace poker.code.model.hand_ranks.ranks
{
    /*
    *   Class to evaluate Royal Flush rank.
    *   Base Class: Ranks
    */
    public class RoyalFlush : Ranks
    {
        //---------------------------------------------------------------------------------
        //states
        //---------------------------------------------------------------------------------
        // constructor (class / base)
        List<Card> player; // armazena as cartas da pessoa
        List<List<Card>> royal; // temporaria para a sequencia especifica
        
        //---------------------------------------------------------------------------------
        //behaviors
        //---------------------------------------------------------------------------------
        // constructor (class / base)        
        public RoyalFlush (List<List<Card>> h) : base (h) 
        {
            player = new List<Card>();
            royal = new List<List<Card>>();
        }
        
        //implementacao especifica da classe RoyalFlush
        //para o metodo abstrato da classe base
        public override bool check()
        {
            if(chek_straight() && faind_woner())
            {
                Semantic.Suit suit_royal = find_suit();
                foreach (var cards_list in royal)
                {
                    foreach (var card in cards_list)
                    {
                        if (card.suit_ == suit_royal)
                            find.Add(card);
                    }
                }
                if (find.Count == 5)
                {
                    foreach (Card c in find)
                    {
                        if (c.owner == 1)
                            return true;
                    }

                }

                //return find.Count == 5;
            }
            return false;
        }

        //verifica se existem cartas nas posicoes que satisfacam 
        //a sequencia 10/11/12/13/14 
        //separa de <lists> as listas especificas da sequencia
        //e coloca em <royal> 
        private bool chek_straight()
        {
            int cout = 0;
            for (int i = 10 ; i < 15 ; i++)
            {
                if(ranks_histo[i].Count > 0 )                
                    cout++;
            }       
            return cout == 5 ? true : false;
        }
        
        //verifica se existe em <royal> uma ou duas cartas da pessoa
        //caso exista coloca em <player>
        private bool faind_woner()
        {
            for (int i = 10; i < 15; i++)
                royal.Add(value_copy(ranks_histo[i]));
            
            foreach(var list_ in royal)
            {
                foreach (var Card in list_)
                {
                    if(Card.owner == 1)
                    {
                        player.Add(Card);
                    }
                }
            }
            return player.Count > 0 ? true : false;
        }    
        // to define the suit to validate
        private Semantic.Suit find_suit()
        {
            //neste ponto oobrigatoriamente terá uma lista com um card ...
            Semantic.Suit s = new Semantic.Suit();
            foreach (var cards in royal)
            {
                if (cards.Count == 1)
                    s = cards[0].suit_;
            }
            return s;
        }
    }
}