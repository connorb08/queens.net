using Queens.Controllers;
var controller = new PageController(null);
var gameDefinition = await controller.GetGameDefinition();
await controller.DisposeAsync();
Console.WriteLine(gameDefinition);
