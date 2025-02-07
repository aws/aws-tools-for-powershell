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
using Amazon.AuditManager;
using Amazon.AuditManager.Model;

namespace Amazon.PowerShell.Cmdlets.AUDM
{
    /// <summary>
    /// Lists the latest analytics data for controls within a specific control domain and
    /// a specific active assessment.
    /// 
    ///  <note><para>
    /// Control insights are listed only if the control belongs to the control domain and
    /// assessment that was specified. Moreover, the control must have collected evidence
    /// on the <c>lastUpdated</c> date of <c>controlInsightsByAssessment</c>. If neither of
    /// these conditions are met, no data is listed for that control. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "AUDMAssessmentControlInsightsByControlDomainList")]
    [OutputType("Amazon.AuditManager.Model.ControlInsightsMetadataByAssessmentItem")]
    [AWSCmdlet("Calls the AWS Audit Manager ListAssessmentControlInsightsByControlDomain API operation.", Operation = new[] {"ListAssessmentControlInsightsByControlDomain"}, SelectReturnType = typeof(Amazon.AuditManager.Model.ListAssessmentControlInsightsByControlDomainResponse))]
    [AWSCmdletOutput("Amazon.AuditManager.Model.ControlInsightsMetadataByAssessmentItem or Amazon.AuditManager.Model.ListAssessmentControlInsightsByControlDomainResponse",
        "This cmdlet returns a collection of Amazon.AuditManager.Model.ControlInsightsMetadataByAssessmentItem objects.",
        "The service call response (type Amazon.AuditManager.Model.ListAssessmentControlInsightsByControlDomainResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAUDMAssessmentControlInsightsByControlDomainListCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssessmentId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the active assessment. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AssessmentId { get; set; }
        #endregion
        
        #region Parameter ControlDomainId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the control domain. </para><para>Audit Manager supports the control domains that are provided by Amazon Web Services
        /// Control Catalog. For information about how to find a list of available control domains,
        /// see <a href="https://docs.aws.amazon.com/controlcatalog/latest/APIReference/API_ListDomains.html"><c>ListDomains</c></a> in the Amazon Web Services Control Catalog API Reference.</para>
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
        public System.String ControlDomainId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Represents the maximum number of results on a page or for an API request call. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that's used to fetch the next set of results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ControlInsightsByAssessment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.ListAssessmentControlInsightsByControlDomainResponse).
        /// Specifying the name of a property of type Amazon.AuditManager.Model.ListAssessmentControlInsightsByControlDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ControlInsightsByAssessment";
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
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.ListAssessmentControlInsightsByControlDomainResponse, GetAUDMAssessmentControlInsightsByControlDomainListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssessmentId = this.AssessmentId;
            #if MODULAR
            if (this.AssessmentId == null && ParameterWasBound(nameof(this.AssessmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssessmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ControlDomainId = this.ControlDomainId;
            #if MODULAR
            if (this.ControlDomainId == null && ParameterWasBound(nameof(this.ControlDomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter ControlDomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
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
            // create request
            var request = new Amazon.AuditManager.Model.ListAssessmentControlInsightsByControlDomainRequest();
            
            if (cmdletContext.AssessmentId != null)
            {
                request.AssessmentId = cmdletContext.AssessmentId;
            }
            if (cmdletContext.ControlDomainId != null)
            {
                request.ControlDomainId = cmdletContext.ControlDomainId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.AuditManager.Model.ListAssessmentControlInsightsByControlDomainResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.ListAssessmentControlInsightsByControlDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "ListAssessmentControlInsightsByControlDomain");
            try
            {
                #if DESKTOP
                return client.ListAssessmentControlInsightsByControlDomain(request);
                #elif CORECLR
                return client.ListAssessmentControlInsightsByControlDomainAsync(request).GetAwaiter().GetResult();
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
            public System.String AssessmentId { get; set; }
            public System.String ControlDomainId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.AuditManager.Model.ListAssessmentControlInsightsByControlDomainResponse, GetAUDMAssessmentControlInsightsByControlDomainListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ControlInsightsByAssessment;
        }
        
    }
}
