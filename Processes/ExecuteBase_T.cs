using System;
using System.Threading.Tasks;

namespace DigitalFace.Processes
{
    public abstract class ExecuteBase<T>
    {
        public bool IsExecuting { get; protected set; }

        protected T Setting { get; set; }

        public ExecuteBase() { }

        public ExecuteBase(T setting) { this.Setting = setting; }

        public virtual void Execute()
        {
            if (this.IsExecuting == false)
            {
                this.IsExecuting = true;

                this.Execute(this.Setting);

                this.IsExecuting = false;
            }
        }

        public async virtual void ExecuteAsync()
        {
            if (this.IsExecuting == false)
            {
                this.IsExecuting = true;

                await Task.Run(() => { this.Execute(this.Setting); });

                this.IsExecuting = false;
            }
        }

        protected abstract void Execute(T setting);
    }
}
