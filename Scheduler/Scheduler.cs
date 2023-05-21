using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Scheduler
    {
        private List<Processor> Processors;
        private Queue<Task> TaskQueue;
        clockCycle ClockCycle = clockCycle.GetInstance();

        public Scheduler()
        {
            Processors = new List<Processor>();
            TaskQueue = new Queue<Task>();
        }

        public void ProcessorsCreation(int processorCount)
        {
            for (int i = 0; i < processorCount; i++)
            {
                Processors.Add(new Processor("P" + (i + 1)));
                Console.WriteLine("New Processor has Been Created");
            }
        }

        public void AddTask(List<Task> tasks)
        {
            while (TaskQueue.Count < tasks.Count)
            {
                foreach (var task in tasks)
                {
                    if (task.CreationTime == ClockCycle.ClockCounter)
                    {
                        task.State = TaskState.Waiting;
                        TaskQueue.Enqueue(task);
                        Console.WriteLine($"Task {task.Id} has been created at cycle: {ClockCycle.ClockCounter}");
                    }
                }
                ClockCycle.Addone();
            }
        }

        public void AssignAndExecuteTasks()
        {
            while (TaskQueue.Count > 0 || Processors.Any(p => p.State == ProcessorState.Busy))
            {
                ClockCycle.Addone();
                foreach (var processor in Processors)
                {
                    if (processor.State == ProcessorState.Idle && TaskQueue.Count != 0)
                    {
                        var task = TaskQueue.Dequeue();
                        if (task.State == TaskState.Waiting)
                        {
                            processor.AssignTask(task);
                        }
                    }
                }

                foreach (var processor in Processors)
                {
                    if (processor.State == ProcessorState.Busy)
                    {
                        processor.ExecuteTask(ClockCycle.ClockCounter);
                    }
                }
            }
        }
    }
}
