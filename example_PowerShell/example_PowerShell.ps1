Add-Type -Path "$PSScriptRoot/CtrlCHandlerLib.dll"

try
{
    # CTRL+C ハンドラーを登録する
    [tonkun_nickname.CtrlCHandler.CtrlCHandler]::registerHandler()

    # メインの処理を実行する
    Write-Host "メインの処理を開始．．．"

    for ($j = 0; $j -lt 10; $j++)
    {
        if ([tonkun_nickname.CtrlCHandler.CtrlCHandler]::stopRequested)
        {
            Write-Host "CTRL+C が押されました。"
            break;
        }

        # CTRL+C で止められてはいけない処理
        Write-Host ("CTRL+C で止められてはいけない処理を実行 {0}/10" -f ($j + 1))

        for ($i = 0; $i -lt 10; $i++)
        {
            Write-Host ("処理 {0}/10" -f ($i + 1))
            Start-Sleep -Milliseconds (1 * 1000)
        }
        Write-Host "終了"
    }

    Write-Host "メインの処理が終了しました。"
}
catch
{
    Write-Host "catch block"

    # エラー時の処理を実行
    Write-Error "エラーが発生しました。: $_"
}
finally
{
    Write-Host "finally block"

    # 使用したリソースの破棄などを実行
    Write-Host "終了処理を実行"
    for ($i = 0; $i -lt 10; $i++)
    {
        Write-Host ("処理 {0}/10" -f ($i + 1))
        Start-Sleep -Milliseconds (1 * 1000)
    }
    Write-Host "終了処理が完了しました。"

    # CTRL+C ハンドラーを解除する（とっても重要）
    [tonkun_nickname.CtrlCHandler.CtrlCHandler]::unregisterHandler()
}
