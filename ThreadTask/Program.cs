// See https://aka.ms/new-console-template for more information
//--https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-threading-tasks-task
using System;
using ThreadTask.ParallelAsync;
using ThreadTask.ParallelFor;
using ThreadTask.TaskExperiment;
using ThreadTask.TaskRaceExperiment;

//Console.WriteLine("Welcome to the task world!");

//--await Tasker.DoTasks();


//TaskBasedAsyncPro taskBasedAsyncPro = new TaskBasedAsyncPro();
//taskBasedAsyncPro.CreateAndRunTaskImlicitly();

//--ParallelInvokeDemo.ExecuteParallelInvoke();

//--MultipleParallelInvokeDemo.ExecuteMultipleParallelInvoke();

//--TaskRace.BunchofTasks();
//--await TaskRace.RaceTask();

//--ParallelAsyncExperiment.DoExperiment().GetAwaiter().GetResult();    

//--ParallelForExperiment.ParallelFor();
//--ParallelForExperiment.ParalleForInActionPerformance();

ParallelForExperiment.ParrellelForInActionDegreeofParallelism();

Console.ReadLine();



