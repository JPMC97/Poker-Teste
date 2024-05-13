using poker.code.view;
using poker.code.model;
using poker.code.model.hand_ranks;
using poker.code.model.hand_ranks.ranks;

namespace poker.code.controller;
/*
Class to handle tests
*/
public class Test
{
    //---------------------------------------------------------------------------------
    // instance variables / states
    //---------------------------------------------------------------------------------
    private List<Card> loded_cards; // cards to evaluate (7)
    string rank_name; // name of the hand hank in evaluation
    string file_name; // file name of readed file
    private bool check_; // to control a miss or hit
    
    //---------------------------------------------------------------------------------
    //behaviors
    //---------------------------------------------------------------------------------
    public Test(string n, List<Card> cs) // constructor / in object creation
    {
        this.check_ = false; 
        this.rank_name = "";
        this.file_name = n;
        this.loded_cards = new List<Card>(cs);
    }
    
    public void full_test()
    {
        //vocês devem implementar uma lógica que mostre a execução de testes
        //um para cada mão de poker possível (10 ao total)
    }

    /*
    Method to run and show a single test (one file.csv)
    */
    public void single_test()
    {
        // A histogram a object of type Histogram.
        Histogram histogram = new Histogram(loded_cards);
        switch (file_name)
        {
            case "01.csv":
                HighCard high = new HighCard(histogram.get_histogram());
                check_ = high.check();
                Console.WriteLine("check_: " + check_);
                rank_name = "01.csv - HighCard";
                draw_single(high);
                break;
            case "02.csv":
                ShowText.print_text("Not implemented yet!");
                break;
            case "03.csv":
                ShowText.print_text("Not implemented yet!");
                break;
            case "04.csv":
                ShowText.print_text("Not implemented yet!");
                break;
            case "05.csv":
                ShowText.print_text("Not implemented yet!");
                break;
            case "06.csv":
                Flush flush = new Flush(histogram.get_histogram());
                check_ = flush.check();
                Console.WriteLine("check_: " + check_);
                rank_name = "06.csv - Flush";
                draw_single(flush);
                break;
            case "07.csv":
                ShowText.print_text("Not implemented yet!");
                break;
            case "08.csv":
                ShowText.print_text("Not implemented yet!");
                break;
            case "09.csv":
                StraightFlush straightFlush = new StraightFlush(histogram.get_histogram());
                check_ = straightFlush.check();
                Console.WriteLine("check_: " + check_);
                rank_name = "09.csv - StraightFlush";
                draw_single(straightFlush);
                break;
            case "10.csv":
                RoyalFlush royal = new RoyalFlush(histogram.get_histogram());
                check_ = royal.check();
                rank_name = "10.csv - RoyalFlush";
                draw_single(royal);
                break;
        }
    }

    private void draw_single(Ranks rank)    
{
    string msg = rank_name;
    if (this.check_)
        msg += " - FOUND!";
    else
        msg += " - NOT FOUND!";

    ShowText.show_single(msg);
    DrawCards.display_cards(loded_cards, Semantic.LEFT, Semantic.CARD_TOP1);
    DrawCards.display_cards(rank.get_find(), Semantic.LEFT, Semantic.CARD_TOP2);

    // Verifica se as coordenadas do cursor não ultrapassam os limites do console
    int left = Math.Max(Semantic.LEFT, 0); // Garante que o valor de left seja positivo
    int footer = Math.Min(Semantic.FOOTER, Console.WindowHeight - 1); // Garante que o valor de footer esteja dentro das dimensões verticais do console
    Console.SetCursorPosition(left, footer);

    ShowText.show_footer(msg);
    }
}