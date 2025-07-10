using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace WireGram.Generators
{
    [Generator]
    internal class RegisterBotCommandsGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var provider = context.SyntaxProvider.CreateSyntaxProvider(
                (node, _) => node is ClassDeclarationSyntax,
                (ctx, _) => ctx.SemanticModel.GetDeclaredSymbol(ctx.Node));
            context.RegisterSourceOutput(provider.Collect(), Execute);
        }

        private static void Execute(SourceProductionContext ctx, ImmutableArray<ISymbol> symbols)
        {
            var builder = new StringBuilder();
            builder.AppendLine("""
                               using WireGram.Telegram.Commands;

                               namespace WireGram.Telegram
                               {
                                   internal partial class UpdateHandler
                                   {
                                       private readonly Dictionary<string, IBotCommand> _cmds = new()
                                       {
                               """);
            foreach(var symbol in symbols)
            {
                if (symbol is not INamedTypeSymbol nts) continue;
                if (!nts.Name.EndsWith("Command")) continue;
                if (nts.Interfaces.Any(i => i.ToDisplayString() != "WireGram.Abstractions.IBotCommand")) continue;
                builder.AppendLine($"            {{ \"{ToCommand(nts.Name)}\", new {nts.Name}() }}");
            }
            builder.AppendLine("""
                                       }
                                   }
                               }
                               """);
            ctx.AddSource("Commands.g.cs", builder.ToString());
        }

        private static string ToCommand(string className)
        {
            className = className.Replace("Command", "");
            className = className.ToLower();
            return className;
        }
    }
}
