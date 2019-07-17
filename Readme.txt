DataSwitch
2019/7/17

1、功能描述：
	将CAD要素类中的点线面和注记按相应的"Layer"属性导出为shp文件。

2、开发环境：
	操作系统：windows10
	编程语言：c#
	开发工具：vs2017、ArcEngine10.4
	平台：.net Framework4.6

3、解决方案中目录结构：
	|---README.txt			//说明文档
	|---Form1.cs			//设计界面及代码
	|---CADtoShape.cs			//提供将CAD要素类的指定"Layer"属性要素转换为shp文件的方法
	|---DataManager.cs			//数据管理基础类，提供shp文件创建、空间参考获取及文件操作的方法