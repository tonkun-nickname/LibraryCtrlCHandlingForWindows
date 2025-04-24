using tonkun_nickname.CtrlCHandler;

try
{
    // CTRL+C ハンドラーを登録する
    CtrlCHandler.registerHandler();

    // メインの処理を実行する
    Console.WriteLine("メインの処理を開始．．．");

    for (int j = 0; j < 10; j++)
    {
        if (CtrlCHandler.stopRequested)
        {
            Console.WriteLine("CTRL+C が押されました。");
            break;
        }

        // CTRL+C で止められてはいけない処理
        Console.WriteLine($"CTRL+C で止められてはいけない処理を実行 ({j+1}/10)");

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"処理 ({i+1}/10)");
            Thread.Sleep(1 * 1000);
        }
        Console.WriteLine("終了");
    }

    Console.WriteLine("メインの処理が終了しました。");
}
catch(Exception ex)
{
    Console.WriteLine("catch block");

    // エラー時の処理を実行
    Console.Error.WriteLine($"エラー発生しました。:{ex.Message}");
}
finally
{
    Console.WriteLine("finally block");

    // 使用したリソースの破棄などを実行
    Console.WriteLine("終了処理を実行");
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"処理 ({i+1}/10)");
        Thread.Sleep(1 * 1000);
    }
    Console.WriteLine("終了処理が完了しました。");

    // CTRL+C ハンドラーを解除する（とっても重要）
    CtrlCHandler.unregisterHandler();
}
