# CtrlCHandlerクラス

Windowsコンソールアプリケーションで Ctrl+C (SIGINT) シグナルを処理するためのシンプルな C# 静的クラスです。
アプリケーションが終了要求を傍受し、クリーンアップ処理を実行してから正常に終了できるようにします。
処理途中で終了しては困る場合や、リソースの解放などの後処理が必要なアプリケーションに使用できます。

## プログラムの説明

* Ctrl+C が押された際に `Console.CancelKeyPress` イベントを捕捉します。
* `args.Cancel = true` を設定することで、アプリケーションの即時終了を防ぎます。
* 終了が要求されたことを示す静的ブール値フラグ `stopRequested` を `true` に設定します。
* イベントハンドラを登録 (`registerHandler`) および解除 (`unregisterHandler`) するメソッドを提供します。
* メインアプリケーションループが `stopRequested` フラグを監視して、安全なシャットダウンシーケンスを開始できるようにします。

## 実装例

`CtrlCHandler` をコンソールアプリケーションで使用する基本的な実装例

* C#の例
  * example_csharp/example_csharp.cs
* PowerShellスクリプトの例
  * example_PowerShell/example_PowerShell.ps1
