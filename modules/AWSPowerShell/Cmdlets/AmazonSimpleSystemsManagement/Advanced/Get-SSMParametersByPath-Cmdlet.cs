using Amazon.PowerShell.Common;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    public partial class GetSSMParametersByPathCmdlet
    {
        protected override void PostExecutionContextLoad(ExecutorContext context)
        {
            base.PostExecutionContextLoad(context);

            var cmdletContext = context as CmdletContext;

            // as a convenience to the user, fullfil ssm's requirement that the
            // path be /-prefixed
            if (!cmdletContext.Path.StartsWith("/"))
            {
                cmdletContext.Path = "/" + cmdletContext.Path;
            }
        }
    }
}
