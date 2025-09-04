/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Returns summaries of invoked Hooks. For more information, see <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/hooks-userguide/hooks-view-invocations.html">View
    /// CloudFormation Hooks invocations</a> in the <i>CloudFormation Hooks User Guide</i>.
    /// 
    ///  
    /// <para>
    /// This operation supports the following parameter combinations:
    /// </para><ul><li><para>
    /// No parameters: Returns all Hook invocation summaries.
    /// </para></li><li><para><c>TypeArn</c> only: Returns summaries for a specific Hook.
    /// </para></li><li><para><c>TypeArn</c> and <c>Status</c>: Returns summaries for a specific Hook filtered
    /// by status.
    /// </para></li><li><para><c>TargetId</c> and <c>TargetType</c>: Returns summaries for a specific Hook invocation
    /// target.
    /// </para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFNHookResult")]
    [OutputType("Amazon.CloudFormation.Model.ListHookResultsResponse")]
    [AWSCmdlet("Calls the AWS CloudFormation ListHookResults API operation.", Operation = new[] {"ListHookResults"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.ListHookResultsResponse))]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.ListHookResultsResponse",
        "This cmdlet returns an Amazon.CloudFormation.Model.ListHookResultsResponse object containing multiple properties."
    )]
    public partial class GetCFNHookResultCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Filters results by the status of Hook invocations. Can only be used in combination
        /// with <c>TypeArn</c>. Valid values are:</para><ul><li><para><c>HOOK_IN_PROGRESS</c>: The Hook is currently running.</para></li><li><para><c>HOOK_COMPLETE_SUCCEEDED</c>: The Hook completed successfully.</para></li><li><para><c>HOOK_COMPLETE_FAILED</c>: The Hook completed but failed validation.</para></li><li><para><c>HOOK_FAILED</c>: The Hook encountered an error during execution.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.HookStatus")]
        public Amazon.CloudFormation.HookStatus Status { get; set; }
        #endregion
        
        #region Parameter TargetId
        /// <summary>
        /// <para>
        /// <para>Filters results by the unique identifier of the target the Hook was invoked against.</para><para>For change sets, this is the change set ARN. When the target is a Cloud Control API
        /// operation, this value must be the <c>HookRequestToken</c> returned by the Cloud Control
        /// API request. For more information on the <c>HookRequestToken</c>, see <a href="https://docs.aws.amazon.com/cloudcontrolapi/latest/APIReference/API_ProgressEvent.html">ProgressEvent</a>.</para><para>Required when <c>TargetType</c> is specified and cannot be used otherwise.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TargetId { get; set; }
        #endregion
        
        #region Parameter TargetType
        /// <summary>
        /// <para>
        /// <para>Filters results by target type. Currently, only <c>CHANGE_SET</c> and <c>CLOUD_CONTROL</c>
        /// are supported filter options.</para><para>Required when <c>TargetId</c> is specified and cannot be used otherwise.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.ListHookResultsTargetType")]
        public Amazon.CloudFormation.ListHookResultsTargetType TargetType { get; set; }
        #endregion
        
        #region Parameter TypeArn
        /// <summary>
        /// <para>
        /// <para>Filters results by the ARN of the Hook. Can be used alone or in combination with <c>Status</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TypeArn { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A string that identifies the next page of events that you want to retrieve.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.ListHookResultsResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.ListHookResultsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TargetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TargetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TargetId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.ListHookResultsResponse, GetCFNHookResultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TargetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.NextToken = this.NextToken;
            context.Status = this.Status;
            context.TargetId = this.TargetId;
            context.TargetType = this.TargetType;
            context.TypeArn = this.TypeArn;
            
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
            var request = new Amazon.CloudFormation.Model.ListHookResultsRequest();
            
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.TargetId != null)
            {
                request.TargetId = cmdletContext.TargetId;
            }
            if (cmdletContext.TargetType != null)
            {
                request.TargetType = cmdletContext.TargetType;
            }
            if (cmdletContext.TypeArn != null)
            {
                request.TypeArn = cmdletContext.TypeArn;
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
        
        private Amazon.CloudFormation.Model.ListHookResultsResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.ListHookResultsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "ListHookResults");
            try
            {
                #if DESKTOP
                return client.ListHookResults(request);
                #elif CORECLR
                return client.ListHookResultsAsync(request).GetAwaiter().GetResult();
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
            public System.String NextToken { get; set; }
            public Amazon.CloudFormation.HookStatus Status { get; set; }
            public System.String TargetId { get; set; }
            public Amazon.CloudFormation.ListHookResultsTargetType TargetType { get; set; }
            public System.String TypeArn { get; set; }
            public System.Func<Amazon.CloudFormation.Model.ListHookResultsResponse, GetCFNHookResultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
