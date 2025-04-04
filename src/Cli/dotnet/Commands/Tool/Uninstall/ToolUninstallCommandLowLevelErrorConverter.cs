﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.DotNet.Cli.ShellShim;
using Microsoft.DotNet.Cli.ToolPackage;
using LocalizableStrings = Microsoft.DotNet.Tools.Tool.Uninstall.LocalizableStrings;

namespace Microsoft.DotNet.Cli.Commands.Tool.Uninstall;

internal static class ToolUninstallCommandLowLevelErrorConverter
{
    public static IEnumerable<string> GetUserFacingMessages(Exception ex, PackageId packageId)
    {
        string[] userFacingMessages = null;
        if (ex is ToolPackageException)
        {
            userFacingMessages = [string.Format(CommonLocalizableStrings.FailedToUninstallToolPackage, packageId, ex.Message)];
        }
        else if (ex is ToolConfigurationException || ex is ShellShimException)
        {
            userFacingMessages = [string.Format(LocalizableStrings.FailedToUninstallTool, packageId, ex.Message)];
        }

        return userFacingMessages;
    }

    public static bool ShouldConvertToUserFacingError(Exception ex)
    {
        return ex is ToolPackageException
               || ex is ToolConfigurationException
               || ex is ShellShimException;
    }
}
