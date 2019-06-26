

# ASP.NET Core Background Tasks Sample (Generic Host)

This sample illustrates the use of [IHostedService](https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.ihostedservice). This sample demonstrates the features described in the [Background tasks with hosted services in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/host/hosted-services) topic.

When running the sample in [Visual Studio Code](https://code.visualstudio.com/), set the **console** value of the console configuration in *.vscode/launch.json* to either `externalTerminal` or `integratedTerminal`. Use of the `internalConsole` is incompatible with console keystroke input that the app uses to enqueue background work items.



2019年6月26日

	backgroudtask的使用方式讲解
		1 定时任务的方式，分两种
			timer
			quartz 
				appsetting.json 中设置 时间的 Corn表达式
				使用 ScheduleJob.ExecuteByCron<MyJob>(Component.GetTimerSet())来设置定时任务类(MyJob)和定时corn
		2 初始的方式见  Program 的 main 方法
		3 使用 IHostService 方式的好处

	加入 quartz 任务框架， 调用定时任务类MyJob

	serilog 不能使用的几个问题记录
		在 await host.WaitForShutdownAsync(); 之后的代码段去初始化  logger
	
		appconfig.json 中 serilog 节点没有在最上层
	
		appconfig.json  修改后 没有生效， 修改appconfig.json 属性为  copy if newer 