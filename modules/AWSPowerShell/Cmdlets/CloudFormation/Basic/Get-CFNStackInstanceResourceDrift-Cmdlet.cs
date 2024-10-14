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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Returns drift information for resources in a stack instance.
    /// 
    ///  <note><para><c>ListStackInstanceResourceDrifts</c> returns drift information for the most recent
    /// drift detection operation. If an operation is in progress, it may only return partial
    /// results.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFNStackInstanceResourceDrift")]
    [OutputType("Amazon.CloudFormation.Model.StackInstanceResourceDriftsSummary")]
    [AWSCmdlet("Calls the AWS CloudFormation ListStackInstanceResourceDrifts API operation.", Operation = new[] {"ListStackInstanceResourceDrifts"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.ListStackInstanceResourceDriftsResponse))]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.StackInstanceResourceDriftsSummary or Amazon.CloudFormation.Model.ListStackInstanceResourceDriftsResponse",
        "This cmdlet returns a collection of Amazon.CloudFormation.Model.StackInstanceResourceDriftsSummary objects.",
        "The service call response (type Amazon.CloudFormation.Model.ListStackInstanceResourceDriftsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFNStackInstanceResourceDriftCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CallAs
        /// <summary>
        /// <para>
        /// <para>[Service-managed permissions] Specifies whether you are acting as an account administrator
        /// in the organization's management account or as a delegated administrator in a member
        /// account.</para><para>By default, <c>SELF</c> is specified. Use <c>SELF</c> for stack sets with self-managed
        /// permissions.</para><ul><li><para>If you are signed in to the management account, specify <c>SELF</c>.</para></li><li><para>If you are signed in to a delegated administrator account, specify <c>DELEGATED_ADMIN</c>.</para><para>Your Amazon Web Services account must be registered as a delegated administrator in
        /// the management account. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-orgs-delegated-admin.html">Register
        /// a delegated administrator</a> in the <i>CloudFormation User Guide</i>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.CallAs")]
        public Amazon.CloudFormation.CallAs CallAs { get; set; }
        #endregion
        
        #region Parameter OperationId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the drift operation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String OperationId { get; set; }
        #endregion
        
        #region Parameter StackInstanceAccount
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Web Services account that you want to list resource drifts
        /// for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String StackInstanceAccount { get; set; }
        #endregion
        
        #region Parameter StackInstanceRegion
        /// <summary>
        /// <para>
        /// <para>The name of the Region where you want to list resource drifts.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String StackInstanceRegion { get; set; }
        #endregion
        
        #region Parameter StackInstanceResourceDriftStatus
        /// <summary>
        /// <para>
        /// <para>The resource drift status of the stack instance. </para><ul><li><para><c>DELETED</c>: The resource differs from its expected template configuration in
        /// that the resource has been deleted.</para></li><li><para><c>MODIFIED</c>: One or more resource properties differ from their expected template
        /// values.</para></li><li><para><c>IN_SYNC</c>: The resource's actual configuration matches its expected template
        /// configuration.</para></li><li><para><c>NOT_CHECKED</c>: CloudFormation doesn't currently return this value.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StackInstanceResourceDriftStatuses")]
        public System.String[] StackInstanceResourceDriftStatus { get; set; }
        #endregion
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name or unique ID of the stack set that you want to list drifted resources for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String StackSetName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to be returned with a single call. If the number of
        /// available results exceeds this maximum, the response includes a <c>NextToken</c> value
        /// that you can assign to the <c>NextToken</c> request parameter to get the next set
        /// of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous paginated request didn't return all of the remaining results, the
        /// response object's <c>NextToken</c> parameter value is set to a token. To retrieve
        /// the next set of results, call this action again and assign that token to the request
        /// object's <c>NextToken</c> parameter. If there are no remaining results, the previous
        /// response object's <c>NextToken</c> parameter is set to <c>null</c>.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Summaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.ListStackInstanceResourceDriftsResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.ListStackInstanceResourceDriftsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Summaries";
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
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.ListStackInstanceResourceDriftsResponse, GetCFNStackInstanceResourceDriftCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CallAs = this.CallAs;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.OperationId = this.OperationId;
            #if MODULAR
            if (this.OperationId == null && ParameterWasBound(nameof(this.OperationId)))
            {
                WriteWarning("You are passing $null as a value for parameter OperationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StackInstanceAccount = this.StackInstanceAccount;
            #if MODULAR
            if (this.StackInstanceAccount == null && ParameterWasBound(nameof(this.StackInstanceAccount)))
            {
                WriteWarning("You are passing $null as a value for parameter StackInstanceAccount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StackInstanceRegion = this.StackInstanceRegion;
            #if MODULAR
            if (this.StackInstanceRegion == null && ParameterWasBound(nameof(this.StackInstanceRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter StackInstanceRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StackInstanceResourceDriftStatus != null)
            {
                context.StackInstanceResourceDriftStatus = new List<System.String>(this.StackInstanceResourceDriftStatus);
            }
            context.StackSetName = this.StackSetName;
            #if MODULAR
            if (this.StackSetName == null && ParameterWasBound(nameof(this.StackSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter StackSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.CloudFormation.Model.ListStackInstanceResourceDriftsRequest();
            
            if (cmdletContext.CallAs != null)
            {
                request.CallAs = cmdletContext.CallAs;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.OperationId != null)
            {
                request.OperationId = cmdletContext.OperationId;
            }
            if (cmdletContext.StackInstanceAccount != null)
            {
                request.StackInstanceAccount = cmdletContext.StackInstanceAccount;
            }
            if (cmdletContext.StackInstanceRegion != null)
            {
                request.StackInstanceRegion = cmdletContext.StackInstanceRegion;
            }
            if (cmdletContext.StackInstanceResourceDriftStatus != null)
            {
                request.StackInstanceResourceDriftStatuses = cmdletContext.StackInstanceResourceDriftStatus;
            }
            if (cmdletContext.StackSetName != null)
            {
                request.StackSetName = cmdletContext.StackSetName;
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
        
        private Amazon.CloudFormation.Model.ListStackInstanceResourceDriftsResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.ListStackInstanceResourceDriftsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "ListStackInstanceResourceDrifts");
            try
            {
                #if DESKTOP
                return client.ListStackInstanceResourceDrifts(request);
                #elif CORECLR
                return client.ListStackInstanceResourceDriftsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CloudFormation.CallAs CallAs { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String OperationId { get; set; }
            public System.String StackInstanceAccount { get; set; }
            public System.String StackInstanceRegion { get; set; }
            public List<System.String> StackInstanceResourceDriftStatus { get; set; }
            public System.String StackSetName { get; set; }
            public System.Func<Amazon.CloudFormation.Model.ListStackInstanceResourceDriftsResponse, GetCFNStackInstanceResourceDriftCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Summaries;
        }
        
    }
}
