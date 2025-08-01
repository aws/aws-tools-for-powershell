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
using Amazon.ObservabilityAdmin;
using Amazon.ObservabilityAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.CWOADMN
{
    /// <summary>
    /// Lists all telemetry rules in your organization. This operation can only be called
    /// by the organization's management account or a delegated administrator account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWOADMNTelemetryRulesForOrganizationList")]
    [OutputType("Amazon.ObservabilityAdmin.Model.TelemetryRuleSummary")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service ListTelemetryRulesForOrganization API operation.", Operation = new[] {"ListTelemetryRulesForOrganization"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.ListTelemetryRulesForOrganizationResponse))]
    [AWSCmdletOutput("Amazon.ObservabilityAdmin.Model.TelemetryRuleSummary or Amazon.ObservabilityAdmin.Model.ListTelemetryRulesForOrganizationResponse",
        "This cmdlet returns a collection of Amazon.ObservabilityAdmin.Model.TelemetryRuleSummary objects.",
        "The service call response (type Amazon.ObservabilityAdmin.Model.ListTelemetryRulesForOrganizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWOADMNTelemetryRulesForOrganizationListCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RuleNamePrefix
        /// <summary>
        /// <para>
        /// <para> A string to filter organization telemetry rules whose names begin with the specified
        /// prefix. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RuleNamePrefix { get; set; }
        #endregion
        
        #region Parameter SourceAccountId
        /// <summary>
        /// <para>
        /// <para> The list of account IDs to filter organization telemetry rules by their source accounts.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceAccountIds")]
        public System.String[] SourceAccountId { get; set; }
        #endregion
        
        #region Parameter SourceOrganizationUnitId
        /// <summary>
        /// <para>
        /// <para> The list of organizational unit IDs to filter organization telemetry rules by their
        /// source organizational units. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceOrganizationUnitIds")]
        public System.String[] SourceOrganizationUnitId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of organization telemetry rules to return in a single call. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The token for the next set of results. A previous call generates this token. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TelemetryRuleSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.ListTelemetryRulesForOrganizationResponse).
        /// Specifying the name of a property of type Amazon.ObservabilityAdmin.Model.ListTelemetryRulesForOrganizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TelemetryRuleSummaries";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RuleNamePrefix parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RuleNamePrefix' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RuleNamePrefix' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.ListTelemetryRulesForOrganizationResponse, GetCWOADMNTelemetryRulesForOrganizationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RuleNamePrefix;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.RuleNamePrefix = this.RuleNamePrefix;
            if (this.SourceAccountId != null)
            {
                context.SourceAccountId = new List<System.String>(this.SourceAccountId);
            }
            if (this.SourceOrganizationUnitId != null)
            {
                context.SourceOrganizationUnitId = new List<System.String>(this.SourceOrganizationUnitId);
            }
            
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
            var request = new Amazon.ObservabilityAdmin.Model.ListTelemetryRulesForOrganizationRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.RuleNamePrefix != null)
            {
                request.RuleNamePrefix = cmdletContext.RuleNamePrefix;
            }
            if (cmdletContext.SourceAccountId != null)
            {
                request.SourceAccountIds = cmdletContext.SourceAccountId;
            }
            if (cmdletContext.SourceOrganizationUnitId != null)
            {
                request.SourceOrganizationUnitIds = cmdletContext.SourceOrganizationUnitId;
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
        
        private Amazon.ObservabilityAdmin.Model.ListTelemetryRulesForOrganizationResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.ListTelemetryRulesForOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "ListTelemetryRulesForOrganization");
            try
            {
                #if DESKTOP
                return client.ListTelemetryRulesForOrganization(request);
                #elif CORECLR
                return client.ListTelemetryRulesForOrganizationAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String RuleNamePrefix { get; set; }
            public List<System.String> SourceAccountId { get; set; }
            public List<System.String> SourceOrganizationUnitId { get; set; }
            public System.Func<Amazon.ObservabilityAdmin.Model.ListTelemetryRulesForOrganizationResponse, GetCWOADMNTelemetryRulesForOrganizationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TelemetryRuleSummaries;
        }
        
    }
}
