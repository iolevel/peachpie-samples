<?php

use System\Threading\Tasks\Task;
use System\Threading\CancellationToken;
use System\Threading\CancellationTokenSource;

function main()
{

    $source = new CancellationTokenSource();
    $token = $source->Token;

    $task = Task::Run(function () use ($token) {

        echo "Starting background task ...", PHP_EOL;

        for ($i = 0; $i < 1000; $i++) {

            if ($token->IsCancellationRequested)  // 
            {
                echo "Operation aborted.", PHP_EOL;
                break;
            }

            usleep(100_000);
            echo "Iteration $i ...", PHP_EOL;
        }

        echo "Finished.", PHP_EOL;

    }, $token);

    $source->CancelAfter(/*miliseconds:*/ 1000);
    $task->Wait();
}

main();