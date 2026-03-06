using System;
using System.Threading;


while (true)
{
    Console.WriteLine("=== 카드 짝 맞추기 게임 ===");
    Table123 table = new Table123();
    Deck deck = new();
    deck.NewDeck();
    table.open(deck.Draw(), deck.Draw(), deck.Draw(), deck.Draw());
    table.open(deck.Draw(), deck.Draw(), deck.Draw(), deck.Draw());
    table.open(deck.Draw(), deck.Draw(), deck.Draw(), deck.Draw());
    table.open(deck.Draw(), deck.Draw(), deck.Draw(), deck.Draw());
    Thread.Sleep(1500);
    Console.Clear();
    while (true)
    {
        deck.Showcard(table);
        table.fisrst();
        Console.Clear();
        deck.Showcard(table);
        table.second();
        Console.Clear();
        deck.Showcard(table);
        table.CheckMatch(deck);
        Thread.Sleep(1500);
        if (deck.discovernumber == 8)
        {
            Console.WriteLine("=== 게임 클리어! ===");
            Console.WriteLine($"총 시도 횟수: {Deck.GameendCounter}");
            while (true)
            {
                Console.WriteLine("새 게임을 하시겠습니까? (Y/N): ");
                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    Console.Clear();
                    break;
                }

                else if (input == "N")
                {
                    Console.WriteLine("게임을 종료합니다");
                    return;
                }
                else
                {
                    Console.WriteLine("다시 입력해 주세요");
                }
            }
        }
        
    }
}
