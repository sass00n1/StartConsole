# StartConsole
![图片](https://user-images.githubusercontent.com/41114110/138380755-f80ffcd4-2028-4082-9619-bf6c6cd16093.png)
## 这是什么？
应用于Unity游戏实机运行时调试的控制台，我们在Unity编辑器中可以很方便的在控制台观看调试log，但是打包到实机运行时却看不到log了，可能必须与电脑连线在AndroidStudio或Xcode上观看，很不方便，这个工具可以将控制台内置于游戏当中，便于游戏的测试。
## 如何使用？
* 五个手指同时触摸手机屏幕可以调出控制台
* 游戏运行中如果出现Error级别的log会自动调出控制台
* 在Editor环境中按F1调出控制台
* 打包时要选择Development Build才有堆栈轨迹
## 特色
* 及其干净与简洁的工具，完全的源码注释，非常方便新手入门与学习
* 支持堆栈轨迹，便于调试时bug的溯源
* 单一脚本，即插即用
