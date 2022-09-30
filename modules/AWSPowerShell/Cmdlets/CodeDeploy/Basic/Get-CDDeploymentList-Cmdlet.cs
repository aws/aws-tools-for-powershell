/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// IAM user or Amazon Web Services account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CDDeploymentList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CodeDeploy ListDeployments API operation.", Operation = new[] {"ListDeployments"}, SelectReturnType = typeof(Amazon.CodeDeploy.Model.ListDeploymentsResponse))]
    [AWSCmdletOutput("System.String or Amazon.CodeDeploy.Model.ListDeploymentsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.CodeDeploy.Model.ListDeploymentsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCDDeploymentListCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of an CodeDeploy application associated with the IAM user or Amazon Web Services
        /// account.</para><note><para>If <code>applicationName</code> is specified, then <code>deploymentGroupName</code>
        /// must be specified. If it is not specified, then <code>deploymentGroupName</code> must
        /// not be specified. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter DeploymentGroupName
        /// <summary>
        /// <para>
        /// <para>The name of a deployment group for the specified application.</para><note><para>If <code>deploymentGroupName</code> is specified, then <code>applicationName</code>
        /// must be specified. If it is not specified, then <code>applicationName</code> must
        /// not be specified. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeploymentGroupName { get; set; }
        #endregion
        
        #region Parameter CreateTimeRange_End
        /// <summary>
        /// <para>
        /// <para>The end time of the time range.</para><note><para>Specify null to leave the end time open-ended.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreateTimeRange_End { get; set; }
        #endregion
        
        #region Parameter ExternalId
        /// <summary>
        /// <para>
        /// <para>The unique ID of an external resource for returning deployments linked to the external
        /// resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalId { get; set; }
        #endregion
        
        #region Parameter IncludeOnlyStatus
        /// <summary>
        /// <para>
        /// <para>A subset of deployments to list by status:</para><ul><li><para><code>Created</code>: Include created deployments in the resulting list.</para></li><li><para><code>Queued</code>: Include queued deployments in the resulting list.</para></li><li><para><code>In Progress</code>: Include in-progress deployments in the resulting list.</para></li><li><para><code>Succeeded</code>: Include successful deployments in the resulting list.</para></li><li><para><code>Failed</code>: Include failed deployments in the resulting list.</para></li><li><para><code>Stopped</code>: Include stopped deployments in the resulting list.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeOnlyStatuses")]
        public System.String[] IncludeOnlyStatus { get; set; }
        #endregion
        
        #region Parameter CreateTimeRange_Start
        /// <summary>
        /// <para>
        /// <para>The start time of the time range.</para><note><para>Specify null to leave the start time open-ended.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreateTimeRange_Start { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An identifier returned from the previous list deployments call. It can be used to
        /// return the next set of deployments in the list.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Deployments'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeDeploy.Model.ListDeploymentsResponse).
        /// Specifying the name of a property of type Amazon.CodeDeploy.Model.ListDeploymentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Deployments";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeDeploy.Model.ListDeploymentsResponse, GetCDDeploymentListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationName = this.ApplicationName;
            context.CreateTimeRange_End = this.CreateTimeRange_End;
            context.CreateTimeRange_Start = this.CreateTimeRange_Start;
            context.DeploymentGroupName = this.DeploymentGroupName;
            context.ExternalId = this.ExternalId;
            if (this.IncludeOnlyStatus != null)
            {
                context.IncludeOnlyStatus = new List<System.String>(this.IncludeOnlyStatus);
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.CodeDeploy.Model.ListDeploymentsRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            
             // populate CreateTimeRange
            var requestCreateTimeRangeIsNull = true;
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
            if (cmdletContext.ExternalId != null)
            {
                request.ExternalId = cmdletContext.ExternalId;
            }
            if (cmdletContext.IncludeOnlyStatus != null)
            {
                request.IncludeOnlyStatuses = cmdletContext.IncludeOnlyStatus;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
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
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
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
                return client.ListDeploymentsAsync(request).GetAwaiter().GetResult();
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
            public System.String ExternalId { get; set; }
            public List<System.String> IncludeOnlyStatus { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CodeDeploy.Model.ListDeploymentsResponse, GetCDDeploymentListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Deployments;
        }
        
    }
}
