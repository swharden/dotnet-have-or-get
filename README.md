# dotnet-have-or-get (dotnetHAG)
When windows users attempt to launch a .NET application but don't have the appropriate runtime installed, they are presented with a confusing or absent error message. 

dotnetHAG.exe checks what version of `dotnet` is installed, and if it's missing (or below the required version) it launches a pop-up window to indicate this with a link to download the appropriate runtime.

dotnetHAG is built using .NET Framework 3.0 (released in 2006) so it should run easily even on old systems.