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
using Amazon.AuditManager;
using Amazon.AuditManager.Model;

namespace Amazon.PowerShell.Cmdlets.AUDM
{
    /// <summary>
    /// Lists the latest analytics data for controls within a specific control domain across
    /// all active assessments.
    /// 
    ///  <note><para>
    /// Control insights are listed only if the control belongs to the control domain that
    /// was specified and the control collected evidence on the <c>lastUpdated</c> date of
    /// <c>controlInsightsMetadata</c>. If neither of these conditions are met, no data is
    /// listed for that control. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "AUDMControlInsightsByControlDomainList")]
    [OutputType("Amazon.AuditManager.Model.ControlInsightsMetadataItem")]
    [AWSCmdlet("Calls the AWS Audit Manager ListControlInsightsByControlDomain API operation.", Operation = new[] {"ListControlInsightsByControlDomain"}, SelectReturnType = typeof(Amazon.AuditManager.Model.ListControlInsightsByControlDomainResponse))]
    [AWSCmdletOutput("Amazon.AuditManager.Model.ControlInsightsMetadataItem or Amazon.AuditManager.Model.ListControlInsightsByControlDomainResponse",
        "This cmdlet returns a collection of Amazon.AuditManager.Model.ControlInsightsMetadataItem objects.",
        "The service call response (type Amazon.AuditManager.Model.ListControlInsightsByControlDomainResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetAUDMControlInsightsByControlDomainListCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ControlDomainId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the control domain. </para><para>Audit Manager supports the control domains that are provided by Amazon Web Services
        /// Control Catalog. For information about how to find a list of available control domains,
        /// see <a href="https://docs.aws.amazon.com/controlcatalog/latest/APIReference/API_ListDomains.html"><c>ListDomains</c></a> in the Amazon Web Services Control Catalog API Reference.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ControlInsightsMetadata'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.ListControlInsightsByControlDomainResponse).
        /// Specifying the name of a property of type Amazon.AuditManager.Model.ListControlInsightsByControlDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ControlInsightsMetadata";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ControlDomainId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ControlDomainId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ControlDomainId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.ListControlInsightsByControlDomainResponse, GetAUDMControlInsightsByControlDomainListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ControlDomainId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.AuditManager.Model.ListControlInsightsByControlDomainRequest();
            
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
        
        private Amazon.AuditManager.Model.ListControlInsightsByControlDomainResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.ListControlInsightsByControlDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "ListControlInsightsByControlDomain");
            try
            {
                #if DESKTOP
                return client.ListControlInsightsByControlDomain(request);
                #elif CORECLR
                return client.ListControlInsightsByControlDomainAsync(request).GetAwaiter().GetResult();
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
            public System.String ControlDomainId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.AuditManager.Model.ListControlInsightsByControlDomainResponse, GetAUDMControlInsightsByControlDomainListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ControlInsightsMetadata;
        }
        
    }
}
