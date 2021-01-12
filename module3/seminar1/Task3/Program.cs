using System;

namespace Task3
{
    class Program
    {
        delegate double delegateConvertTemperature(double temperature);
        static string[] textFromCelsium = { "цельсии -> фаренгейты", "цельсии -> кельвины", "цельсии -> ранкины", "цельсии -> реомюры" };
        static string[] textToCelsium = { "цельсии <- фаренгейты", "цельсии <- кельвины", "цельсии <- ранкины", "цельсии <- реомюры" };
        static void Main(string[] args)
        {
            PartTwo();
        }

        private static void PartTwo()
        {
            TemperatureConverterImp temperatureConverterImp = new TemperatureConverterImp();

            delegateConvertTemperature[] delegatesConvertTemperatureFromCelsius = { temperatureConverterImp.FromCelsiusToFahrenheit,
            StaticTempConverters.FromCelsiusToKelvin, StaticTempConverters.FromCelsiusToRankins, StaticTempConverters.FromCelsiusToReaumur};
            delegateConvertTemperature[] delegatesConvertTemperatureToCelsius = { temperatureConverterImp.FromFahrenheitToCelsius,
                StaticTempConverters.FromKelvinToCelsius, StaticTempConverters.FromRankinsToCelsius, StaticTempConverters.FromReaumurToCelsius };

            do
            {
                try
                {
                    Console.Write("Введите температуру: ");
                    double temperature = double.Parse(Console.ReadLine());
                    Console.Write("В цельсии или из цельсиев? Введите 1 или 2 соответственно: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            for (int i = 0; i < delegatesConvertTemperatureToCelsius.Length; i++)
                                Console.WriteLine($"{textToCelsium[i]} {temperature}: -> {delegatesConvertTemperatureToCelsius[i](temperature)}");
                            break;
                        case "2":
                            for (int i = 0; i < delegatesConvertTemperatureToCelsius.Length; i++)
                                Console.WriteLine($"{textFromCelsium[0]} {temperature}: -> {delegatesConvertTemperatureFromCelsius[i](temperature)}");
                            break;
                        default:
                            Console.WriteLine("Такого варианта не было");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Неверное значение");
                }

                Console.WriteLine("Для выхода нажмите esc");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static void PartOne()
        {
            TemperatureConverterImp temperatureConverterImp = new TemperatureConverterImp();
            delegateConvertTemperature delegatesConvertTemperatureFromCelsius = temperatureConverterImp.FromCelsiusToFahrenheit;
            delegateConvertTemperature delegatesConvertTemperatureToCelsius = temperatureConverterImp.FromFahrenheitToCelsius;

            do
            {
                try
                {
                    Console.Write("Введите температуру: ");
                    double temperature = double.Parse(Console.ReadLine());
                    Console.Write("В цельсии или из цельсиев? Введите 1 или 2 соответственно: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine($"{textToCelsium[0]} {temperature}: -> {delegatesConvertTemperatureToCelsius(temperature)}");
                            break;
                        case "2":
                            Console.WriteLine($"{textFromCelsium[0]} {temperature}: -> {delegatesConvertTemperatureFromCelsius(temperature)}");
                            break;
                        default:
                            Console.WriteLine("Такого варианта не было");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Неверное значение");
                }

                Console.WriteLine("Для выхода нажмите esc");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }

    static class StaticTempConverters
    {
        internal static double FromCelsiusToKelvin(double temperature) => temperature + 273.15;
        internal static double FromKelvinToCelsius(double temperature) => temperature - 273.15;
        internal static double FromCelsiusToRankins(double temperature) => temperature * 9/5 + 491.67;
        internal static double FromRankinsToCelsius(double temperature) => (temperature - 495.67) * 5/9;
        internal static double FromCelsiusToReaumur(double temperature) => temperature * 0.8;
        internal static double FromReaumurToCelsius(double temperature) => temperature * 1.25;
    }

    class TemperatureConverterImp
    {
        public double FromFahrenheitToCelsius(double temperature) => 9/5 * temperature + 32;
        public double FromCelsiusToFahrenheit(double temperature) => 5/9 * (temperature - 32);
        
    }
} 
