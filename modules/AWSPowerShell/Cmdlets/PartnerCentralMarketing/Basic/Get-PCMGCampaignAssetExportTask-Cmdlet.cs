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
using Amazon.PartnerCentralMarketing;
using Amazon.PartnerCentralMarketing.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PCMG
{
    /// <summary>
    /// Retrieves a campaign asset export task by its identifier, reporting its status and,
    /// when the task is COMPLETED, a freshly minted short-lived presigned URL for downloading
    /// the ZIP archive. The download URL is minted on each call and is valid for at most
    /// 15 minutes; clients should download promptly rather than caching it. When the task
    /// has FAILED, FailureReason explains why. Poll this operation (roughly every 2-5 seconds)
    /// until the task reaches a terminal state.
    /// </summary>
    [Cmdlet("Get", "PCMGCampaignAssetExportTask")]
    [OutputType("Amazon.PartnerCentralMarketing.Model.GetCampaignAssetExportTaskResponse")]
    [AWSCmdlet("Calls the Partner Central Marketing API GetCampaignAssetExportTask API operation.", Operation = new[] {"GetCampaignAssetExportTask"}, SelectReturnType = typeof(Amazon.PartnerCentralMarketing.Model.GetCampaignAssetExportTaskResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralMarketing.Model.GetCampaignAssetExportTaskResponse",
        "This cmdlet returns an Amazon.PartnerCentralMarketing.Model.GetCampaignAssetExportTaskResponse object containing multiple properties."
    )]
    public partial class GetPCMGCampaignAssetExportTaskCmdlet : AmazonPartnerCentralMarketingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CampaignAssetExportTaskIdentifier
        /// <summary>
        /// <para>
        /// The export task to retrieve:
        /// the `Id` StartCampaignAssetExportTask returned (`etsk-…`). An id only. An export task
        /// has no ARN: none is returned, recorded or authorized on (the read authorizes on its
        /// campaign), so there is no ARN to accept (DG-063 D-35).
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
        public System.String CampaignAssetExportTaskIdentifier { get; set; }
        #endregion
        
        #region Parameter CampaignIdentifier
        /// <summary>
        /// <para>
        /// The campaign that owns the export task.
        /// Accepts the campaign id or ARN. Required so the read is authorized on campaign/{CampaignId};
        /// the task must belong to this campaign or the request resolves to not-found.
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
        public System.String CampaignIdentifier { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// The catalog (AWS or Sandbox).
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralMarketing.Catalog")]
        public Amazon.PartnerCentralMarketing.Catalog Catalog { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralMarketing.Model.GetCampaignAssetExportTaskResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralMarketing.Model.GetCampaignAssetExportTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralMarketing.Model.GetCampaignAssetExportTaskResponse, GetPCMGCampaignAssetExportTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CampaignAssetExportTaskIdentifier = this.CampaignAssetExportTaskIdentifier;
            #if MODULAR
            if (this.CampaignAssetExportTaskIdentifier == null && ParameterWasBound(nameof(this.CampaignAssetExportTaskIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter CampaignAssetExportTaskIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CampaignIdentifier = this.CampaignIdentifier;
            #if MODULAR
            if (this.CampaignIdentifier == null && ParameterWasBound(nameof(this.CampaignIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter CampaignIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            // create request
            var request = new Amazon.PartnerCentralMarketing.Model.GetCampaignAssetExportTaskRequest();
            
            if (cmdletContext.CampaignAssetExportTaskIdentifier != null)
            {
                request.CampaignAssetExportTaskIdentifier = cmdletContext.CampaignAssetExportTaskIdentifier;
            }
            if (cmdletContext.CampaignIdentifier != null)
            {
                request.CampaignIdentifier = cmdletContext.CampaignIdentifier;
            }
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
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
        
        private Amazon.PartnerCentralMarketing.Model.GetCampaignAssetExportTaskResponse CallAWSServiceOperation(IAmazonPartnerCentralMarketing client, Amazon.PartnerCentralMarketing.Model.GetCampaignAssetExportTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Marketing API", "GetCampaignAssetExportTask");
            try
            {
                return client.GetCampaignAssetExportTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CampaignAssetExportTaskIdentifier { get; set; }
            public System.String CampaignIdentifier { get; set; }
            public Amazon.PartnerCentralMarketing.Catalog Catalog { get; set; }
            public System.Func<Amazon.PartnerCentralMarketing.Model.GetCampaignAssetExportTaskResponse, GetPCMGCampaignAssetExportTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
