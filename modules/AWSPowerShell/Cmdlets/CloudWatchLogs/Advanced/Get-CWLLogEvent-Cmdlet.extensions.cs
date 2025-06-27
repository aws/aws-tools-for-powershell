using System;
using System.Management.Automation;
using Amazon.CloudWatchLogs;
using Amazon.PowerShell.Common;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    public partial class GetCWLLogEventCmdlet
    {
        private void ProcessCustomAutoIteration(CmdletContext cmdletContext, GetLogEventsRequest request, bool useParameterSelect)
        {
            var nextToken = cmdletContext.NextToken;
            var userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                var currentToken = nextToken;
                request.NextToken = nextToken;
                
                CmdletOutput output;
                
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    nextToken = request.StartFromHead.GetValueOrDefault() ? response.NextForwardToken : response.NextBackwardToken;
                    
                    // Stop if token hasn't changed
                    if (nextToken == currentToken)
                    {
                        nextToken = null;
                    }
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!userControllingPaging && shouldAutoIterate && AutoIterationHelpers.HasValue(nextToken));
        }
    }
}