using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Wizard wizard = new Wizard(CreateRandomString(), CreateRandomString());
        for(int i = 0; i < 4; i ++)
            wizard.RaiseRingIsFoundEvent += (new Hobbit(CreateRandomString(), CreateRandomString())).RingIsFoundEventHandler;
        for(int i = 0; i < 2; i++)
            wizard.RaiseRingIsFoundEvent += (new Human(CreateRandomString(), CreateRandomString())).RingIsFoundEventHandler;
        wizard.RaiseRingIsFoundEvent += (new Dwarf(CreateRandomString(), CreateRandomString())).RingIsFoundEventHandler;
        wizard.RaiseRingIsFoundEvent += (new Elf(CreateRandomString(), CreateRandomString())).RingIsFoundEventHandler;
        wizard.SomeThisIsChangedInTheAir();
        Console.ReadKey();
    }

    internal static string CreateRandomString()
    {
        Random random = new Random();
        StringBuilder stringBuilder = new StringBuilder();
        int lenght = random.Next(5, 8);
        for (int i = 0; i < lenght; i++)
            stringBuilder.Append((char)random.Next('а', 'я'));
        stringBuilder[0] = char.ToUpper(stringBuilder[0]);
        return stringBuilder.ToString();
    }
}


class RingIsFoundEventArgs: EventArgs
{
    protected internal string Message { get; set; }

    internal RingIsFoundEventArgs(string message)
    {
        Message = message;
    }
}
abstract class Creature
{
    protected internal string Location { get; set; }
    protected internal string Name { get; }

    public Creature(string name, string location) { Name = name; Location = location;  }
}

class Wizard: Creature
{
    internal delegate void RingIsFoundEventHandler(object sender,
        RingIsFoundEventArgs ringIsFoundEventArgs);

    internal event RingIsFoundEventHandler RaiseRingIsFoundEvent;

    public Wizard(string name, string location) : base(name, location) { }

    public void SomeThisIsChangedInTheAir()
    {
        string location = Program.CreateRandomString();
        Console.WriteLine($"{Name} >> Кольцо найдено у старого Бильбо! Призываю вас в {location}! ");
        RaiseRingIsFoundEvent(this, new RingIsFoundEventArgs(location));
    }
}

class Hobbit: Creature
{
    public Hobbit(string name, string location) : base(name, location) { }

    public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
    {
        Console.WriteLine($"{Name} >> Покидаю {Location}! Иду в " + e.Message);
    }
}

class Human: Creature
{
    public Human(string name, string location) : base(name, location) { }

    public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
    {
        Console.WriteLine($"{Name} >> Волшебник {((Wizard)sender).Name} " +
            $"позвал. Моя цель {e.Message}, отправляюсь из {Location}");
    }
}

class Elf: Creature
{
    public Elf(string name, string location) : base(name, location) { }

    public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
    {
        Console.WriteLine($"{Name} >> Звёзды светят не так ярко как обычно в {Location}. Цветы увядают. Листья предсказывают идти в " + e.Message);
    }
}

class Dwarf : Creature
{
    public Dwarf(string name, string location) : base(name, location) { }
    public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
    {
        Console.WriteLine($"{Name} >> Точим топоры, собираем припасы! " +
            $"Выдвигаемся из {Location} в " + e.Message);
    }
}


