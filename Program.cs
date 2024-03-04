namespace DeadfishParser
{
    internal class Program
    {
        public static int[] Parse(string data)
        {
            int size = 0;
            foreach (char ch in data)
            {
                if (ch is 'o')
                    size++;
            }

            int[] output = new int[size];
            int outputIndexCounter = 0;
            int accumulator = 0;

            for (int iterator = 0; iterator < data.Length; iterator++)//посимвольно, пока не закончится строка
            {
                char command = data[iterator]; //чтение символа команды
                if (command is 'i')
                {
                    accumulator++;
                    continue;
                }

                if (command is 'd')
                {
                    accumulator--;
                    continue;
                }

                if (command is 's')
                {
                    accumulator *= accumulator;
                    continue;
                }

                if (command is 'o')
                {
                    output[outputIndexCounter] = accumulator; //запись результата
                    //accumulator = 0; //обнуление аккумулятора для следующего значения
                    outputIndexCounter++; //переход на следующий индекс вывода
                    continue;
                }    
            }
            return output;
        }
        static void Main(string[] args)
        {
            int[] test = Parse("iiisdoso"); //(1+1+1)^2-1 запись(8). 
            foreach (int i in test)
                Console.WriteLine(i);
        }
    }
}
