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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the evaluation results for the specified Amazon Web Services resource. The
    /// results indicate which Config rules were used to evaluate the resource, when each
    /// rule was last invoked, and whether the resource complies with each rule.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFGComplianceDetailsByResource")]
    [OutputType("Amazon.ConfigService.Model.EvaluationResult")]
    [AWSCmdlet("Calls the AWS Config GetComplianceDetailsByResource API operation.", Operation = new[] {"GetComplianceDetailsByResource"}, SelectReturnType = typeof(Amazon.ConfigService.Model.GetComplianceDetailsByResourceResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.EvaluationResult or Amazon.ConfigService.Model.GetComplianceDetailsByResourceResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.EvaluationResult objects.",
        "The service call response (type Amazon.ConfigService.Model.GetComplianceDetailsByResourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFGComplianceDetailsByResourceCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ComplianceType
        /// <summary>
        /// <para>
        /// <para>Filters the results by compliance.</para><para><c>INSUFFICIENT_DATA</c> is a valid <c>ComplianceType</c> that is returned when an
        /// Config rule cannot be evaluated. However, <c>INSUFFICIENT_DATA</c> cannot be used
        /// as a <c>ComplianceType</c> for filtering results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComplianceTypes")]
        public System.String[] ComplianceType { get; set; }
        #endregion
        
        #region Parameter ResourceEvaluationId
        /// <summary>
        /// <para>
        /// <para>The unique ID of Amazon Web Services resource execution for which you want to retrieve
        /// evaluation results. </para><note><para>You need to only provide either a <c>ResourceEvaluationID</c> or a <c>ResourceID </c>and
        /// <c>ResourceType</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceEvaluationId { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services resource for which you want compliance information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of the Amazon Web Services resource for which you want compliance information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceType { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>nextToken</c> string returned on a previous page that you use to get the next
        /// page of results in a paginated response.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EvaluationResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.GetComplianceDetailsByResourceResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.GetComplianceDetailsByResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EvaluationResults";
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
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.GetComplianceDetailsByResourceResponse, GetCFGComplianceDetailsByResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ComplianceType != null)
            {
                context.ComplianceType = new List<System.String>(this.ComplianceType);
            }
            context.NextToken = this.NextToken;
            context.ResourceEvaluationId = this.ResourceEvaluationId;
            context.ResourceId = this.ResourceId;
            context.ResourceType = this.ResourceType;
            
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
            var request = new Amazon.ConfigService.Model.GetComplianceDetailsByResourceRequest();
            
            if (cmdletContext.ComplianceType != null)
            {
                request.ComplianceTypes = cmdletContext.ComplianceType;
            }
            if (cmdletContext.ResourceEvaluationId != null)
            {
                request.ResourceEvaluationId = cmdletContext.ResourceEvaluationId;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
        
        private Amazon.ConfigService.Model.GetComplianceDetailsByResourceResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.GetComplianceDetailsByResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "GetComplianceDetailsByResource");
            try
            {
                #if DESKTOP
                return client.GetComplianceDetailsByResource(request);
                #elif CORECLR
                return client.GetComplianceDetailsByResourceAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ComplianceType { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceEvaluationId { get; set; }
            public System.String ResourceId { get; set; }
            public System.String ResourceType { get; set; }
            public System.Func<Amazon.ConfigService.Model.GetComplianceDetailsByResourceResponse, GetCFGComplianceDetailsByResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EvaluationResults;
        }
        
    }
}
