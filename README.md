

# ASP.NET Core Background Tasks Sample (Generic Host)

2019��6��26��
	serilog ����ʹ�õļ��������¼
		�� await host.WaitForShutdownAsync(); ֮��Ĵ����ȥ��ʼ��  logger
	
		appconfig.json �� serilog �ڵ�û�������ϲ�
	
		appconfig.json  �޸ĺ� û����Ч�� �޸�appconfig.json ����Ϊ  copy if newer 



This sample illustrates the use of [IHostedService](https://docs.microsoft.com/dotnet/api/microsoft.extensions.hosting.ihostedservice). This sample demonstrates the features described in the [Background tasks with hosted services in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/host/hosted-services) topic.

When running the sample in [Visual Studio Code](https://code.visualstudio.com/), set the **console** value of the console configuration in *.vscode/launch.json* to either `externalTerminal` or `integratedTerminal`. Use of the `internalConsole` is incompatible with console keystroke input that the app uses to enqueue background work items.
