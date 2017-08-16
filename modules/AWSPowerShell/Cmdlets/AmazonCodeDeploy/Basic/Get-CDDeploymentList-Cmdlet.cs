/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Lists the deployments in a deployment group for an application registered with the
    /// applicable IAM user or AWS account.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "CDDeploymentList")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ListDeployments operation against AWS CodeDeploy.", Operation = new[] {"ListDeployments"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.CodeDeploy.Model.ListDeploymentsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCDDeploymentListCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of an AWS CodeDeploy application associated with the applicable IAM user
        /// or AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter DeploymentGroupName
        /// <summary>
        /// <para>
        /// <para>The name of an existing deployment group for the specified application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeploymentGroupName { get; set; }
        #endregion
        
        #region Parameter CreateTimeRange_End
        /// <summary>
        /// <para>
        /// <para>The end time of the time range.</para><note><para>Specify null to leave the end time open-ended.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime CreateTimeRange_End { get; set; }
        #endregion
        
        #region Parameter IncludeOnlyStatus
        /// <summary>
        /// <para>
        /// <para>A subset of deployments to list by status:</para><ul><li><para>Created: Include created deployments in the resulting list.</para></li><li><para>Queued: Include queued deployments in the resulting list.</para></li><li><para>In Progress: Include in-progress deployments in the resulting list.</para></li><li><para>Succeeded: Include successful deployments in the resulting list.</para></li><li><para>Failed: Include failed deployments in the resulting list.</para></li><li><para>Stopped: Include stopped deployments in the resulting list.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IncludeOnlyStatuses")]
        public System.String[] IncludeOnlyStatus { get; set; }
        #endregion
        
        #region Parameter CreateTimeRange_Start
        /// <summary>
        /// <para>
        /// <para>The start time of the time range.</para><note><para>Specify null to leave the start time open-ended.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime CreateTimeRange_Start { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An identifier returned from the previous list deployments call. It can be used to
        /// return the next set of deployments in the list.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ApplicationName = this.ApplicationName;
            if (ParameterWasBound("CreateTimeRange_End"))
                context.CreateTimeRange_End = this.CreateTimeRange_End;
            if (ParameterWasBound("CreateTimeRange_Start"))
                context.CreateTimeRange_Start = this.CreateTimeRange_Start;
            context.DeploymentGroupName = this.DeploymentGroupName;
            if (this.IncludeOnlyStatus != null)
            {
                context.IncludeOnlyStatuses = new List<System.String>(this.IncludeOnlyStatus);
            }
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.CodeDeploy.Model.ListDeploymentsRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            
             // populate CreateTimeRange
            bool requestCreateTimeRangeIsNull = true;
            request.CreateTimeRange = new Amazon.CodeDeploy.Model.TimeRange();
            System.DateTime? requestCreateTimeRange_createTimeRange_End = null;
            if (cmdletContext.CreateTimeRange_End != null)
            {
                requestCreateTimeRange_createTimeRange_End = cmdletContext.CreateTimeRange_End.Value;
            }
            if (requestCreateTimeRange_createTimeRange_End != null)
            {
                request.CreateTimeRange.End = requestCreateTimeRange_createTimeRange_End.Value;
                requestCreateTimeRangeIsNull = false;
            }
            System.DateTime? requestCreateTimeRange_createTimeRange_Start = null;
            if (cmdletContext.CreateTimeRange_Start != null)
            {
                requestCreateTimeRange_createTimeRange_Start = cmdletContext.CreateTimeRange_Start.Value;
            }
            if (requestCreateTimeRange_createTimeRange_Start != null)
            {
                request.CreateTimeRange.Start = requestCreateTimeRange_createTimeRange_Start.Value;
                requestCreateTimeRangeIsNull = false;
            }
             // determine if request.CreateTimeRange should be set to null
            if (requestCreateTimeRangeIsNull)
            {
                request.CreateTimeRange = null;
            }
            if (cmdletContext.DeploymentGroupName != null)
            {
                request.DeploymentGroupName = cmdletContext.DeploymentGroupName;
            }
            if (cmdletContext.IncludeOnlyStatuses != null)
            {
                request.IncludeOnlyStatuses = cmdletContext.IncludeOnlyStatuses;
            }
            
            // Initialize loop variant and commence piping
            System.String _nextMarker = null;
            bool _userControllingPaging = false;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
                _userControllingPaging = true;
            }
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Deployments;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = response.Deployments.Count;
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    
                } while (AutoIterationHelpers.HasValue(_nextMarker));
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CodeDeploy.Model.ListDeploymentsResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.ListDeploymentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeDeploy", "ListDeployments");
            try
            {
                #if DESKTOP
                return client.ListDeployments(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListDeploymentsAsync(request);
                return task.Result;
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ApplicationName { get; set; }
            public System.DateTime? CreateTimeRange_End { get; set; }
            public System.DateTime? CreateTimeRange_Start { get; set; }
            public System.String DeploymentGroupName { get; set; }
            public List<System.String> IncludeOnlyStatuses { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
