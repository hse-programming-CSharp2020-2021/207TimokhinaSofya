using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Bandmaster bandmaster = new Bandmaster();
            OrchestraPlayer[] orchestraPlayers = new OrchestraPlayer[10];
            for(int i = 0; i < 10; i ++)
            {
                switch (random.Next(0, 2)) {
                    case 0:
                        orchestraPlayers[i] = new Violinist(random.Next(10).ToString());
                        break;
                    case 1:
                        orchestraPlayers[i] = new Hornist(random.Next(10).ToString());
                        break;
                }
                bandmaster.PlayIsStartedEvent += orchestraPlayers[i].PlayIsStartedEventHandler;
            }
            try
            {

                int number = int.Parse(Console.ReadLine());
                for (int i = 0; i < number; i++)
                    bandmaster.StartPlay(random.Next(10));
            }
            catch
            {
                Console.WriteLine("Ошибка");
            }
            Console.ReadKey();
        }
    }



    class PlayIsStartedEventArgs: EventArgs
    {
        public int SoundNumber { get; set; }
    }

    class Bandmaster
    {
        public event EventHandler<PlayIsStartedEventArgs> PlayIsStartedEvent;
        public void StartPlay(int number)
        {
            Console.WriteLine("Новая композиция!");
            PlayIsStartedEvent?.Invoke(this, new PlayIsStartedEventArgs()
            { SoundNumber = number });
        }
    }



    abstract class OrchestraPlayer
    { 
        protected string Name { get; }

        public OrchestraPlayer(string name)
        {
            Name = name;
        }

        public abstract void PlayIsStartedEventHandler(object sender,
            PlayIsStartedEventArgs playIsStartedEventArgs);
    }

    class Violinist : OrchestraPlayer
    {
        public Violinist(string name) : base(name) { }

        public override void PlayIsStartedEventHandler(object sender,
            PlayIsStartedEventArgs playIsStartedEventArgs)
        {
            Console.WriteLine($"Violinist {Name} plays {playIsStartedEventArgs.SoundNumber}: La-la!");
        }

    }

    class Hornist : OrchestraPlayer
    {
        public Hornist(string name) : base(name) { }

        public override void PlayIsStartedEventHandler(object sender,
            PlayIsStartedEventArgs playIsStartedEventArgs)
        {
            Console.WriteLine($"Violinist {Name} plays {playIsStartedEventArgs.SoundNumber}: Du-du!");
        }
    }
}
