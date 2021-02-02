using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            VetoComission vetoComission = new VetoComission();
            VetoVoter[] vetoVoters = new VetoVoter[5];
            for(int i = 0; i < 5; i++)
            {
                vetoVoters[i] = new VetoVoter(i.ToString());
                vetoComission.Onvote += vetoVoters[i].Vote;
            }

            VetoEventArgs _ = vetoComission.Vote("Отмена винформ");
            if (vetoComission.VetoBy == null)
                Console.WriteLine("Никто не проголосовал за отмену винформ(");
            else
                Console.WriteLine($"Избиратель {vetoComission.VetoBy.Name} " +
                    $"проголосовал за отмену винформ");
            Console.ReadKey();
        }
    }

    class VetoEventArgs : EventArgs
    {
        protected internal string Proposal { get; set; }
    }

    class VetoComission
    {
        protected internal EventHandler<VetoEventArgs> Onvote;
        private VetoVoter vetoBy = null;

        internal VetoEventArgs Vote(string proposal)
        {
            VetoEventArgs vetoEventArgs = new VetoEventArgs() { Proposal = proposal };
            Onvote?.Invoke(this, vetoEventArgs);
            return vetoEventArgs;
        }

        internal VetoVoter VetoBy
        {
            get => vetoBy;
            set => vetoBy = vetoBy == null ? value : vetoBy;
        }
    }


    class VetoVoter
    {
        protected internal string Name { get; }

        internal VetoVoter(string name)
        {
            Name = name;
        }

        internal void Vote(object sender, VetoEventArgs vetoEventArgs)
        {
            if ((new Random()).Next(0, 5) == 0)
            {
                VetoComission vetoComission = sender as VetoComission;
                vetoComission.VetoBy = this;
            }
        }
    }
}
