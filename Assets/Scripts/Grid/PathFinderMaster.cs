using Assets.Scripts.Entity;
using Assets.Scripts.Grid;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PathFinderMaster : MonoBehaviour
{
    private GridController grid;
    private static PathFinderMaster instance;
    void Awake()
    {
        instance = this;
        grid = GridController.Instance;
    }
    public static PathFinderMaster GetInstance()
    {
        return instance;
    }

    public Tile GetTile(Vector3 position)
    {
        return grid.GetTileFromWorldPosition(position);
    }

    //The maximum simultaneous threads we allow to open
    public int MaxJobs = 10;

    //Delegates are a variable that points to a function
    public delegate void PathfindingJobComplete(List<Tile> path);

    private List<PathFinder> currentJobs;
    private List<PathFinder> todoJobs;

    void Start()
    {
        currentJobs = new List<PathFinder>();
        todoJobs = new List<PathFinder>();
    }

    void Update()
    {
        /*
         * Another way to keep track of the threads we have open would have been to create 
         * a new thread for it but we can also just use Unity's main thread too since this class
         * derives from monoBehaviour
         */

        int i = 0;

        while (i < currentJobs.Count)
        {
            if (currentJobs[i].jobDone)
            {
                currentJobs[i].NotifyComplete();
                currentJobs.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }

        if (todoJobs.Count > 0 && currentJobs.Count < MaxJobs)
        {
            PathFinder job = todoJobs[0];
            todoJobs.RemoveAt(0);
            currentJobs.Add(job);

            //Start a new thread

            Thread jobThread = new Thread(job.FindPath);
            jobThread.Start();

            //As per the doc
            //https://msdn.microsoft.com/en-us/library/system.threading.thread(v=vs.110).aspx
            //It is not necessary to retain a reference to a Thread object once you have started the thread. 
            //The thread continues to execute until the thread procedure is complete.				
        }
    }

    public void RequestFindPath(Tile start, Tile target, bool flying, PathfindingJobComplete completeCallback)
    {
        PathFinder newJob = new PathFinder(grid, start, target, flying, completeCallback);
        todoJobs.Add(newJob);
    }
}

