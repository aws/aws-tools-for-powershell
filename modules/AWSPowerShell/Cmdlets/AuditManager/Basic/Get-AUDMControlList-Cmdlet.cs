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
using Amazon.AuditManager;
using Amazon.AuditManager.Model;

namespace Amazon.PowerShell.Cmdlets.AUDM
{
    /// <summary>
    /// Returns a list of controls from Audit Manager.
    /// </summary>
    [Cmdlet("Get", "AUDMControlList")]
    [OutputType("Amazon.AuditManager.Model.ControlMetadata")]
    [AWSCmdlet("Calls the AWS Audit Manager ListControls API operation.", Operation = new[] {"ListControls"}, SelectReturnType = typeof(Amazon.AuditManager.Model.ListControlsResponse))]
    [AWSCmdletOutput("Amazon.AuditManager.Model.ControlMetadata or Amazon.AuditManager.Model.ListControlsResponse",
        "This cmdlet returns a collection of Amazon.AuditManager.Model.ControlMetadata objects.",
        "The service call response (type Amazon.AuditManager.Model.ListControlsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAUDMControlListCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ControlCatalogId
        /// <summary>
        /// <para>
        /// <para>A filter that narrows the list of controls to a specific resource from the Amazon
        /// Web Services Control Catalog. </para><para>To use this parameter, specify the ARN of the Control Catalog resource. You can specify
        /// either a control domain, a control objective, or a common control. For information
        /// about how to find the ARNs for these resources, see <a href="https://docs.aws.amazon.com/controlcatalog/latest/APIReference/API_ListDomains.html"><c>ListDomains</c></a>, <a href="https://docs.aws.amazon.com/controlcatalog/latest/APIReference/API_ListObjectives.html"><c>ListObjectives</c></a>, and <a href="https://docs.aws.amazon.com/controlcatalog/latest/APIReference/API_ListCommonControls.html"><c>ListCommonControls</c></a>.</para><note><para>You can only filter by one Control Catalog resource at a time. Specifying multiple
        /// resource ARNs isn’t currently supported. If you want to filter by more than one ARN,
        /// we recommend that you run the <c>ListControls</c> operation separately for each ARN.
        /// </para></note><para>Alternatively, specify <c>UNCATEGORIZED</c> to list controls that aren't mapped to
        /// a Control Catalog resource. For example, this operation might return a list of custom
        /// controls that don't belong to any control domain or control objective.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ControlCatalogId { get; set; }
        #endregion
        
        #region Parameter ControlType
        /// <summary>
        /// <para>
        /// <para>A filter that narrows the list of controls to a specific type. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AuditManager.ControlType")]
        public Amazon.AuditManager.ControlType ControlType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results on a page or for an API request call. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ControlMetadataList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.ListControlsResponse).
        /// Specifying the name of a property of type Amazon.AuditManager.Model.ListControlsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ControlMetadataList";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.ListControlsResponse, GetAUDMControlListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ControlCatalogId = this.ControlCatalogId;
            context.ControlType = this.ControlType;
            #if MODULAR
            if (this.ControlType == null && ParameterWasBound(nameof(this.ControlType)))
            {
                WriteWarning("You are passing $null as a value for parameter ControlType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AuditManager.Model.ListControlsRequest();
            
            if (cmdletContext.ControlCatalogId != null)
            {
                request.ControlCatalogId = cmdletContext.ControlCatalogId;
            }
            if (cmdletContext.ControlType != null)
            {
                request.ControlType = cmdletContext.ControlType;
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
        
        private Amazon.AuditManager.Model.ListControlsResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.ListControlsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "ListControls");
            try
            {
                return client.ListControlsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ControlCatalogId { get; set; }
            public Amazon.AuditManager.ControlType ControlType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.AuditManager.Model.ListControlsResponse, GetAUDMControlListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ControlMetadataList;
        }
        
    }
}
