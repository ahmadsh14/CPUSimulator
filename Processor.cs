namespace Assignment1
{
    public class Processor
    {
        public string Id { get; private set; } //Unique identifier for the processor
        public ProcessorState State { get; private set; } //Current state of the processor (busy or idle).
        public Task Task { get; private set; } //The task currently being executed on the processor.

        public Processor(string id)
        {
            Id = id;
            State = ProcessorState.Idle;
            Task = null;
        }

        public void AssignTask(Task task) //Assigns a task to the processor.
        {
            State = ProcessorState.Busy;
            Task = task;
            Task.State = TaskState.Executing;
            Console.WriteLine($"Task: {task.Id} Has been assigned to the processor: {Id}");
        }



        public void ExecuteTask(int clockCounter) //Resumes the interrupted task on the processor.
        {
            if (Task.State == TaskState.Executing)
            {
                Task.RequestedTime--;
                Console.WriteLine($"Task: {Task.Id} is executing now & Remaining: {Task.RequestedTime}");
            }
            if (Task.RequestedTime == 0)
            {
                State = ProcessorState.Idle;
                Task.State = TaskState.Completed;
                Task.CompletionTime = clockCounter;
                Console.WriteLine($"Task: {Task.Id} Has Completed at Cycle: {clockCounter}:{Task.CompletionTime}");
                Task = null;
            }
        }
    }

    public enum ProcessorState
    {
        Idle,
        Busy
    }
}

