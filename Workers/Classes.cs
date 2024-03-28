namespace Workers
{
    class Worker
    {
        public string name;
        public Worker(string name)
        {
            this.name = name;
        }
        public virtual void work()
        {
            Console.WriteLine(name + " working");
        }
    }
    class Manager : Worker
    {
        public Manager(string name) : base(name) { }
        public override void work()
        {
            Console.WriteLine(name + " managing");
        }
    }
    class Programmer : Worker
    {
        public Programmer(string name) : base(name) { }
        public override void work()
        {
            Console.WriteLine(name + " programming");
        }
    }
}