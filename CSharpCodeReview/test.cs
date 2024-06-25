public class HilhdaselloePR
    {
        public string Greet(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "Hello, Guest!";
            }
            else
            {
                return $"Hello, {name}!";
            }
        }

        public void PrintGreeting(string name)
        {
            string greeting = Greet(name);
            Console.WriteLine(greeting);
        }

        public string Grtesteet(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "Hello, Guest!";
            }
            else
            {
                return $"Hello, {name}!";
            }
        }

        public string GreetAllen(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "Hello, Allen! you are my first guest";
            }
            else
            {
                return $"Hello, {name}!";
            }
        }
    }