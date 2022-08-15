namespace Pendu
{
    public class Game
    {
        string wordToFind = "";
        string wordHidden = "";
        public string Name
        {
            get => Name;
            set => Name = value;
        }
        const int MAXATTEMPT = 8;
        int attempt = 1;
        public Game(){
            initGame();
            startGame();
            endGame();
        }

        public void initGame(){
            // find a random word in the dataBase(.txt)
            Random rnd = new Random();
            int randomNbIndex = rnd.Next(0,File.ReadLines("words.txt").Count()+1);
            wordToFind = File.ReadLines("words.txt").ElementAt(randomNbIndex);
            wordToFind = wordToFind.ToLower();

            // create the word to discover with all _ or -
            foreach(char c in wordToFind){
                if(c == '-'){
                    wordHidden += "-";
                }
                else{
                    wordHidden += "_";
                }
            }
        }

        public void startGame(){
            Console.WriteLine("Jeu du Pendu ! 1 bonne réponse ne compte pas pour une tentative :) ! ");
            do
            {
                
                //input 
                Console.WriteLine("propose une lettre pour trouver le mot");
                Console.WriteLine("Tentative num {0} sur / {1} : ",attempt,MAXATTEMPT);
                Console.WriteLine(wordHidden);
                string letter = "";
                bool inputIsOk;
                do
                {
                    try{
                        letter = Console.ReadLine().ToLower() ;//gérer EXCEPTION !
                        inputIsOk = true;
                    }
                    catch (System.Exception){
                        Console.WriteLine("entrée invalide ! :c  // veuillez réessayer avec juste 1 caractère pouvant rentrer dans un mot (pas de chiffre)");
                        inputIsOk = false;
                    }
                } while (!inputIsOk);
                
                //test if the input char is in the wordToFind and discover the wordHidden
                bool isFound= false;
                for(int i = 0;i<wordToFind.Length;i++){
                    if(wordToFind[i].ToString() == letter){
                        wordHidden[i] = letter;
                        isFound = true;
                    }
                }

                if(!isFound){
                    attempt++;
                }
            } while (wordToFind != wordHidden && attempt <= MAXATTEMPT);
        }

        public void endGame(){
            if (wordToFind == wordHidden && attempt <= MAXATTEMPT)
            {
                Console.WriteLine("Bien joué ! le mot était : "+wordToFind);
                Console.WriteLine("Tu as trouvé en {0} tentative(s) ! t kro fort ! ;P",attempt);
            }
            else
            {
                Console.WriteLine("PERDU :c ! le mot était : "+wordToFind);
            }
        }
    }
}