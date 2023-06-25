namespace Script
{
    public abstract class StateBase
    {
        protected IStateSwitcher _switcher;

        public StateBase(IStateSwitcher switcher)
        {
            _switcher = switcher;
        }
        
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
        public abstract void FixedUpdate();
    }
}