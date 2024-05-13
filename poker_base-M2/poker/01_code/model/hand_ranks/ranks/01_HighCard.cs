using System;
using System.Collections.Generic;
namespace poker.code.model.hand_ranks.ranks
{
    /*
    *   Classe para avaliar a categoria High Card.
    *   Classe Base: Ranks
    */
    public class HighCard : Ranks 
    {
        //---------------------------------------------------------------------------------
        // Comportamentos
        //---------------------------------------------------------------------------------
        // Construtor (classe / base)

        public HighCard (List<List<Card>> h) : base (h) {}

        // Polimorfismo dinâmico 
        public override bool check()
        {
            bool find = true; // Variável para controlar se foi encontrado
            List<Card> temp_list = new List<Card>(); // Lista temporária local
            temp_list = this.copy_woner(); 

            // Obtém as duas primeiras cartas da lista temporária
            Card c1_tmp = temp_list[0];
            Card c2_tmp = temp_list[1];

            // Compara os valores das duas cartas temporárias para determinar qual é a carta mais alta
            if (c1_tmp.get_value() >= c2_tmp.get_value())
                this.find.Add(new Card(c1_tmp));
            else
             // Adiciona a carta mais alta à lista de cartas encontradas
                this.find.Add(new Card(c2_tmp));

            // Retorna a variável 'find', que indica se uma carta alta foi encontrada
            return find;
        }
    }// Fim da class
}// Fim do namespace