namespace Ranjan.DesignPattern.Strategy.RealWorldExample
{
    public abstract class Sort
    {
        private ISortStrategy _strategy;

        protected Sort(ISortStrategy strategy)
        {
            _strategy = strategy;
        }

        public void PerformSort()
        {
            _strategy.Sort();
        }
    }
}
