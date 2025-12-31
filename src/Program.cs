using Queens.Controllers;
var controller = new PageController(null);
var page = await controller.LoadGame();
await controller.DisposeAsync();
Console.WriteLine(page);
