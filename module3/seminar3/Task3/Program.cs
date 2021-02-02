using System;


class Program
{
    static void Main(string[] args)
    {
        ElectoralComission electoralComission = new ElectoralComission();
        Voiter[] voiters = new Voiter[10];
        for (int i = 0; i < 10; i ++)
        {
            voiters[i] = new Voiter();
            electoralComission.OnVote += voiters[i].VoterHandler;
        }

        VoteEventArgs voteEventArgs = electoralComission.Vote("Привет?");
        Console.WriteLine($"Вопрос был: {voteEventArgs.Question}");
        Console.WriteLine($"\tЗа проголосовали:\t\t {voteEventArgs.VoteFor}");
        Console.WriteLine($"\tПротив проголосовали:\t\t {voteEventArgs.VoteAgaints}");
        Console.WriteLine($"\tВоздержались от голосования:\t {voteEventArgs.VoteAbstained}");
        Console.ReadKey();
    }
}

class VoteEventArgs: EventArgs
{
    public string Question { get; set; }
    public int VoteFor { get; set; }
    public int VoteAgaints { get; set; }
    public int VoteAbstained { get; set; }
}

class Voiter
{
    public void VoterHandler(object sender, VoteEventArgs e)
    {
        switch (new Random().Next(0, 3))
        {
            case 0:
                e.VoteFor += 1;
                break;
            case 1:
                e.VoteAgaints += 1;
                break;
            case 2:
                e.VoteAbstained += 1;
                break;
        }
    }
}
class ElectoralComission
{
    public event EventHandler<VoteEventArgs> OnVote;

    public VoteEventArgs Vote(string question)
    {
        VoteEventArgs voteEventArgs = new VoteEventArgs();
        voteEventArgs.Question = question;
        OnVote?.Invoke(this, voteEventArgs);
        return voteEventArgs;
    }
}