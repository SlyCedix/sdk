// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.CommandLine;
using LocalizableStrings = Microsoft.DotNet.Tools.Sln.LocalizableStrings;

namespace Microsoft.DotNet.Cli.Commands.Solution.List;

public static class SlnListParser
{
    public static readonly CliOption<bool> SolutionFolderOption = new("--solution-folders")
    {
        Description = LocalizableStrings.ListSolutionFoldersArgumentDescription,
        Arity = ArgumentArity.Zero
    };

    private static readonly CliCommand Command = ConstructCommand();

    public static CliCommand GetCommand()
    {
        return Command;
    }

    private static CliCommand ConstructCommand()
    {
        CliCommand command = new("list", LocalizableStrings.ListAppFullName);

        command.Options.Add(SolutionFolderOption);
        command.SetAction((parseResult) => new ListProjectsInSolutionCommand(parseResult).Execute());

        return command;
    }
}
