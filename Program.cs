namespace Pendu
{
    class Program{
        static void Main(string [] args){
            bool wantToRePlay;
            do
            {
                wantToRePlay = false;
                Game game = new Game();
                Console.WriteLine("Want to replay? Press 'o' for replay or anything else for leave.");
                if(Console.ReadKey().Key == ConsoleKey.O){
                    wantToRePlay = true;
                }
            } while (wantToRePlay);
            
        }
    }
}
