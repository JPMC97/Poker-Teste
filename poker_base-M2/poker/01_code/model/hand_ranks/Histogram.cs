namespace poker.code.model.hand_ranks;

public class Histogram
{
    //---------------------------------------------------------------------------------
    // instance variables / states
    //---------------------------------------------------------------------------------
	List<Card> to_organaize; // COPY cards to evaluate
	// a list of lists, 
	List<List<Card>> histo_;

    //---------------------------------------------------------------------------------
    //behaviors
    //---------------------------------------------------------------------------------
	public Histogram(List<Card> c_list) // constructor / in object creation
	{
	    to_organaize = new List<Card>();
		foreach (var c in c_list)
		    to_organaize.Add(new Card(c)); // make a copy

		histo_ = new List<List<Card>>(); // create empty (list of lists)

		for (int i = 0 ; i < 15 ; i++)				
		    histo_.Add(new List<Card>()); //create empty (a list of card)

        count_values(); // make the histogram
    }
    
	/*
	Method to craate a list of lists (the histogram).
	*/
	private void count_values()
	{
		for (int i = 0 ; i < to_organaize.Count; i++ )
	    {
		    //value variable kept the card value (number rank)
			int value = to_organaize[i].get_value();
			//the card value is used por index position
			histo_[value].Add(new Card(to_organaize[i]));
		}
	}
    
	public List<List<Card>> get_histogram()
	{return histo_;} // acces to the histogram
    
	// to ordene a list of cards(untested)
	public static List<Card> sort(List<Card>ordenar)
	{
		int loop = ordenar.Count -1;
        List<Card> ordenada = new List<Card>();
        
        foreach (var c in ordenar)
			ordenada.Add(new Card(c));
    	for (int i = 0 ; i < loop ; i++)
		{
		    bool swapped = false;
			//Console.WriteLine("For1");

			for(int j = 0 ; j < loop ; j++)
			{
				if (ordenada[j].get_value() > ordenada[j+1].get_value())
				{
					swap(j, ordenada);
					swapped = true;
				}
				//Console.WriteLine("For2");
			}

			if (!swapped)
				break;				
		}
		return ordenada;
	}

	//to suport sort method
	private static void swap(int index, List<Card> cards)
	{	
		int i = index;
		int j = index +1;

		Card temp = new Card (cards[i]);
		cards[i] = new Card (cards[j]);
		cards[j] = new Card (temp);
	}

}