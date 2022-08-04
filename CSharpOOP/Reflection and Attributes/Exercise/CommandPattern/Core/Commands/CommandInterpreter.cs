namespace CommandPattern.Core
{
    using Core.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        { 
                string[] command = args.Split(' ');
                string[] arrayForCommand = command.Skip(1).ToArray();

                Assembly assembly = Assembly.GetCallingAssembly();

                Type cmdType = assembly
               .GetTypes()
               .FirstOrDefault(t => t.Name == $"{command[0]}Command");

                if (cmdType == null)
                    throw new InvalidOperationException("Not existing type!");

                var instance = Activator.CreateInstance(cmdType); 

                var metod = cmdType.GetMethods().First(x => x.Name == "Execute");

                return (string)metod.Invoke(instance, new object[] { arrayForCommand });
            
        }
    }
}
