

# ASP.NET Core Background Tasks Sample (Generic Host)

2019年6月26日
	serilog 不能使用的几个问题记录
		在 await host.WaitForShutdownAsync(); 之后的代码段去初始化  logger
	
		appconfig.json 中 serilog 节点没有在最上层
	
		appconfig.json  修改后 没有生效， 修改appconfig.json 属性为  copy if newer 



This sample illustrates the use of [IHostedService](https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.ihostedservice). This sample demonstrates the features described in the [Background tasks with hosted services in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/host/hosted-services) topic.

When running the sample in [Visual Studio Code](https://code.visualstudio.com/), set the **console** value of the console configuration in *.vscode/launch.json* to either `externalTerminal` or `integratedTerminal`. Use of the `internalConsole` is incompatible with console keystroke input that the app uses to enqueue background work items.
