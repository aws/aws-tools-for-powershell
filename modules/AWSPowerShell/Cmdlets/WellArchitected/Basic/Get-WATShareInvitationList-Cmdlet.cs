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
using System.Threading;
using Amazon.WellArchitected;
using Amazon.WellArchitected.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WAT
{
    /// <summary>
    /// List the share invitations.
    /// 
    ///  
    /// <para><c>WorkloadNamePrefix</c>, <c>LensNamePrefix</c>, <c>ProfileNamePrefix</c>, and <c>TemplateNamePrefix</c>
    /// are mutually exclusive. Use the parameter that matches your <c>ShareResourceType</c>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "WATShareInvitationList")]
    [OutputType("Amazon.WellArchitected.Model.ShareInvitationSummary")]
    [AWSCmdlet("Calls the AWS Well-Architected Tool ListShareInvitations API operation.", Operation = new[] {"ListShareInvitations"}, SelectReturnType = typeof(Amazon.WellArchitected.Model.ListShareInvitationsResponse))]
    [AWSCmdletOutput("Amazon.WellArchitected.Model.ShareInvitationSummary or Amazon.WellArchitected.Model.ListShareInvitationsResponse",
        "This cmdlet returns a collection of Amazon.WellArchitected.Model.ShareInvitationSummary objects.",
        "The service call response (type Amazon.WellArchitected.Model.ListShareInvitationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetWATShareInvitationListCmdlet : AmazonWellArchitectedClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LensNamePrefix
        /// <summary>
        /// <para>
        /// <para>An optional string added to the beginning of each lens name returned in the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LensNamePrefix { get; set; }
        #endregion
        
        #region Parameter ProfileNamePrefix
        /// <summary>
        /// <para>
        /// <para>An optional string added to the beginning of each profile name returned in the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProfileNamePrefix { get; set; }
        #endregion
        
        #region Parameter ShareResourceType
        /// <summary>
        /// <para>
        /// <para>The type of share invitations to be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WellArchitected.ShareResourceType")]
        public Amazon.WellArchitected.ShareResourceType ShareResourceType { get; set; }
        #endregion
        
        #region Parameter TemplateNamePrefix
        /// <summary>
        /// <para>
        /// <para>An optional string added to the beginning of each review template name returned in
        /// the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateNamePrefix { get; set; }
        #endregion
        
        #region Parameter WorkloadNamePrefix
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String WorkloadNamePrefix { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return for this request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ShareInvitationSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WellArchitected.Model.ListShareInvitationsResponse).
        /// Specifying the name of a property of type Amazon.WellArchitected.Model.ListShareInvitationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ShareInvitationSummaries";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WellArchitected.Model.ListShareInvitationsResponse, GetWATShareInvitationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LensNamePrefix = this.LensNamePrefix;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.ProfileNamePrefix = this.ProfileNamePrefix;
            context.ShareResourceType = this.ShareResourceType;
            context.TemplateNamePrefix = this.TemplateNamePrefix;
            context.WorkloadNamePrefix = this.WorkloadNamePrefix;
            
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
            var request = new Amazon.WellArchitected.Model.ListShareInvitationsRequest();
            
            if (cmdletContext.LensNamePrefix != null)
            {
                request.LensNamePrefix = cmdletContext.LensNamePrefix;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.ProfileNamePrefix != null)
            {
                request.ProfileNamePrefix = cmdletContext.ProfileNamePrefix;
            }
            if (cmdletContext.ShareResourceType != null)
            {
                request.ShareResourceType = cmdletContext.ShareResourceType;
            }
            if (cmdletContext.TemplateNamePrefix != null)
            {
                request.TemplateNamePrefix = cmdletContext.TemplateNamePrefix;
            }
            if (cmdletContext.WorkloadNamePrefix != null)
            {
                request.WorkloadNamePrefix = cmdletContext.WorkloadNamePrefix;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
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
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.WellArchitected.Model.ListShareInvitationsResponse CallAWSServiceOperation(IAmazonWellArchitected client, Amazon.WellArchitected.Model.ListShareInvitationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Well-Architected Tool", "ListShareInvitations");
            try
            {
                return client.ListShareInvitationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String LensNamePrefix { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ProfileNamePrefix { get; set; }
            public Amazon.WellArchitected.ShareResourceType ShareResourceType { get; set; }
            public System.String TemplateNamePrefix { get; set; }
            public System.String WorkloadNamePrefix { get; set; }
            public System.Func<Amazon.WellArchitected.Model.ListShareInvitationsResponse, GetWATShareInvitationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ShareInvitationSummaries;
        }
        
    }
}
