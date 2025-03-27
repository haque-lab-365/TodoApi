// See https://aka.ms/new-console-template for more information
//--https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-threading-tasks-task
using System;
using ThreadTask.TaskExperiment;
using ThreadTask.TaskRaceExperiment;

//Console.WriteLine("Welcome to the task world!");

//--await Tasker.DoTasks();


//TaskBasedAsyncPro taskBasedAsyncPro = new TaskBasedAsyncPro();
//taskBasedAsyncPro.CreateAndRunTaskImlicitly();

//--ParallelInvokeDemo.ExecuteParallelInvoke();

//--MultipleParallelInvokeDemo.ExecuteMultipleParallelInvoke();

//--TaskRace.BunchofTasks();
await TaskRace.RaceTask();

Console.ReadLine();



