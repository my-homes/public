(declare-project
  :name "my-janet-app"
  :author "Your Name")

(declare-executable
  :name "my_app" # 出力されるファイル名 (my_app.exe)
  :main "main.janet" # エントリーポイントのあるファイル
  :is-janet-extension true)