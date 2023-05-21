using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Simulation
    {
        public int ProcessorsCount { get; private set; } //Number of processors in the system.
        public List<Task> Tasks { get; private set; } //List of tasks to be simulated.
        public Scheduler Scheduler;

        public Simulation(int processorsCount, List<Task> tasks)
        {
            this.ProcessorsCount = processorsCount;
            this.Tasks = tasks;
            Scheduler = new Scheduler();
        }

        public void RunSimulation() // Runs the simulation using the scheduler and updates the state of the processors and tasks.
        {
            Scheduler.ProcessorsCreation(ProcessorsCount);
            Scheduler.AddTask(Tasks);
            Scheduler.AssignAndExecuteTasks();
        }
    }
}