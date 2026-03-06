using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;


internal class Table123
{

    public int[] Tablecards;
    public int Counter;
    public bool[] Opened = new bool[16];
    public int firstIndex = -1;
    public int secondIndex = -1;


    public Table123()
    {
        Tablecards = new int[16];
    }
    public void open(params int[] cards)
    {
        foreach (int card in cards)
        {
            Tablecards[Counter++] = card;
        }
    }

    public void CheckMatch(Deck deck)
    {
        string firstCard = deck.CardNumbers[Tablecards[firstIndex]];
        string secondCard = deck.CardNumbers[Tablecards[secondIndex]];

        if (firstCard == secondCard)
        {
            deck.discovernumber++;
            Deck.GameendCounter++;
            Console.WriteLine();
            Console.WriteLine("짝을 찾았습니다!");
        }
        else
        {
            Opened[firstIndex] = false;
            Opened[secondIndex] = false;
            Console.WriteLine();
            Console.WriteLine("짝이 아닙니다. 다시 뒤집습니다.");
        }

        firstIndex = -1;
        secondIndex = -1;
    }

    public void fisrst()
      {
          while (true)
          {
              Console.WriteLine();
              Console.Write("첫 번째 카드를 선택하세요 (행 열): ");
              string input = Console.ReadLine();

              string[] parts = input.Split(' ');

              if (parts.Length != 2)
              {
                  Console.WriteLine("숫자사이에 스페이스를 눌러주세요");
                  continue;
              }

              int row = -1;
              int line = -1;

              if (!int.TryParse(parts[0], out row) || !int.TryParse(parts[1], out line))
              {
                  Console.WriteLine("숫자를 입력해주세요.");
                  continue;
              }


            if (row < 1 || row > 4 || line < 1 || line > 4)
            {
                Console.WriteLine("1부터 4까지의 숫자를 입력해주세요.");
                continue;
            }

            int index = (row - 1) * 4 + (line - 1);



            if (Opened[index])
              {
                  Console.WriteLine("이미 선택된 카드입니다. 다른 카드를 선택해주세요.");
                  continue;
              }
                Console.WriteLine();
                Opened[index] = true;
                firstIndex = index;
                break;
          }
      }
      public void second()
      {

          while (true)
          {
              Console.WriteLine();
              Console.Write("두 번째 카드를 선택하세요 (행 열): ");
              string input = Console.ReadLine();

              string[] parts = input.Split(' ');

              if (parts.Length != 2)
              {
                  Console.WriteLine("숫자사이에 스페이스를 눌러주세요");
                  continue;
              }

              int row;
              int line;

              if (!int.TryParse(parts[0], out row) || !int.TryParse(parts[1], out line))
              {
                  Console.WriteLine("숫자를 입력해주세요.");
                  continue;
              }

              int index = (row - 1) * 4 + (line - 1);

              if (Opened[index])
              {
                  Console.WriteLine("이미 선택된 카드입니다. 다른 카드를 선택해주세요.");
                  continue;
              }
             Console.WriteLine();
             Opened[index] = true;
             secondIndex = index;
              break;
          }
      }

}
   


