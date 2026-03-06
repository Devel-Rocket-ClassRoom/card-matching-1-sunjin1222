using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class Deck
{

    public readonly string[] CardNumbers = { " 1", " 2", " 3", " 4", " 5", " 6", " 7", " 8", " 1", " 2", " 3", " 4", " 5", " 6", " 7", " 8" };

    public int[] CurrDeck;

    public int Counter;

    public bool Opened;

    public static int GameendCounter=1;

    public int discovernumber = 8;
    public int hiddennumber = 8;


    public int Draw()
    {
        return CurrDeck[Counter++];
    }
    public void endCheck()
    {
        if(discovernumber == 8)
        {
            Console.WriteLine("=== 게임 클리어! ===");
            Console.WriteLine($"총 시도 횟수: {GameendCounter}");

            return;
        }
    }

    public void NewDeck()
    {

        CurrDeck = new int[16];

        Counter = 0;

        Console.WriteLine("카드를 섞는 중...");

        for (int i = 0; i < CurrDeck.Length; i++)
        {
            CurrDeck[i] = i;
        }

        for (int i = CurrDeck.Length - 1; i > 0; i--)
        {
            Random random = new Random();
            int x = random.Next(0, i + 1);

            int temp = CurrDeck[i];
            CurrDeck[i] = CurrDeck[x];
            CurrDeck[x] = temp;
        }

    }


    public void Showcard(Table123 table)
    {
    
        string cardNumber;
        int count=0;
        Console.Write($"    1열  2열  3열  4열");
        for (int i = 0; i < table.Counter; i++)
        { 
            cardNumber = CardNumbers[table.Tablecards[i]];
         
            if (i % 4 == 0)
            {
                Console.WriteLine();
            }
            if (i % 4 == 0)
            {
                count++;
                Console.Write($"{count}행 ");
               
            }
            if (table.Opened[i])  
            {
                cardNumber = CardNumbers[table.Tablecards[i]];
                Console.Write($"[{cardNumber}] ");
            }
            else              
            {
                Console.Write("[??] ");
            }
     
        }
        Console.WriteLine();
        Console.WriteLine($"시도 횟수: {GameendCounter} | 찾은 쌍: {discovernumber} / {hiddennumber}");

    }




}

