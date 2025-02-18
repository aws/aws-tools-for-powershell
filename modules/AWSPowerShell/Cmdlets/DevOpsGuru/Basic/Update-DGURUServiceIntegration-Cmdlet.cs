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
using Amazon.DevOpsGuru;
using Amazon.DevOpsGuru.Model;

namespace Amazon.PowerShell.Cmdlets.DGURU
{
    /// <summary>
    /// Enables or disables integration with a service that can be integrated with DevOps
    /// Guru. The one service that can be integrated with DevOps Guru is Amazon Web Services
    /// Systems Manager, which can be used to create an OpsItem for each generated insight.
    /// </summary>
    [Cmdlet("Update", "DGURUServiceIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon DevOps Guru UpdateServiceIntegration API operation.", Operation = new[] {"UpdateServiceIntegration"}, SelectReturnType = typeof(Amazon.DevOpsGuru.Model.UpdateServiceIntegrationResponse))]
    [AWSCmdletOutput("None or Amazon.DevOpsGuru.Model.UpdateServiceIntegrationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DevOpsGuru.Model.UpdateServiceIntegrationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateDGURUServiceIntegrationCmdlet : AmazonDevOpsGuruClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter KMSServerSideEncryption_KMSKeyId
        /// <summary>
        /// <para>
        /// <para> Describes the specified KMS key.</para><para>To specify a KMS key, use its key ID, key ARN, alias name, or alias ARN. When using
        /// an alias name, prefix it with "alias/". If you specify a predefined Amazon Web Services
        /// alias (an Amazon Web Services alias with no key ID), Amazon Web Services KMS associates
        /// the alias with an Amazon Web Services managed key and returns its KeyId and Arn in
        /// the response. To specify a KMS key in a different Amazon Web Services account, you
        /// must use the key ARN or alias ARN.</para><para>For example: </para><para>Key ID: 1234abcd-12ab-34cd-56ef-1234567890ab</para><para>Key ARN: arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</para><para>Alias name: alias/ExampleAlias</para><para>Alias ARN: arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceIntegration_KMSServerSideEncryption_KMSKeyId")]
        public System.String KMSServerSideEncryption_KMSKeyId { get; set; }
        #endregion
        
        #region Parameter ServiceIntegration_OpsCenter
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public Amazon.DevOpsGuru.Model.OpsCenterIntegrationConfig ServiceIntegration_OpsCenter { get; set; }
        #endregion
        
        #region Parameter KMSServerSideEncryption_OptInStatus
        /// <summary>
        /// <para>
        /// <para> Specifies if DevOps Guru is enabled for KMS integration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceIntegration_KMSServerSideEncryption_OptInStatus")]
        [AWSConstantClassSource("Amazon.DevOpsGuru.OptInStatus")]
        public Amazon.DevOpsGuru.OptInStatus KMSServerSideEncryption_OptInStatus { get; set; }
        #endregion
        
        #region Parameter LogsAnomalyDetection_OptInStatus
        /// <summary>
        /// <para>
        /// <para>Specifies if DevOps Guru is configured to perform log anomaly detection on CloudWatch
        /// log groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceIntegration_LogsAnomalyDetection_OptInStatus")]
        [AWSConstantClassSource("Amazon.DevOpsGuru.OptInStatus")]
        public Amazon.DevOpsGuru.OptInStatus LogsAnomalyDetection_OptInStatus { get; set; }
        #endregion
        
        #region Parameter KMSServerSideEncryption_Type
        /// <summary>
        /// <para>
        /// <para> The type of KMS key used. Customer managed keys are the KMS keys that you create.
        /// Amazon Web Services owned keys are keys that are owned and managed by DevOps Guru.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceIntegration_KMSServerSideEncryption_Type")]
        [AWSConstantClassSource("Amazon.DevOpsGuru.ServerSideEncryptionType")]
        public Amazon.DevOpsGuru.ServerSideEncryptionType KMSServerSideEncryption_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsGuru.Model.UpdateServiceIntegrationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceIntegration_OpsCenter), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DGURUServiceIntegration (UpdateServiceIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsGuru.Model.UpdateServiceIntegrationResponse, UpdateDGURUServiceIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KMSServerSideEncryption_KMSKeyId = this.KMSServerSideEncryption_KMSKeyId;
            context.KMSServerSideEncryption_OptInStatus = this.KMSServerSideEncryption_OptInStatus;
            context.KMSServerSideEncryption_Type = this.KMSServerSideEncryption_Type;
            context.LogsAnomalyDetection_OptInStatus = this.LogsAnomalyDetection_OptInStatus;
            context.ServiceIntegration_OpsCenter = this.ServiceIntegration_OpsCenter;
            
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
            var request = new Amazon.DevOpsGuru.Model.UpdateServiceIntegrationRequest();
            
            
             // populate ServiceIntegration
            var requestServiceIntegrationIsNull = true;
            request.ServiceIntegration = new Amazon.DevOpsGuru.Model.UpdateServiceIntegrationConfig();
            Amazon.DevOpsGuru.Model.OpsCenterIntegrationConfig requestServiceIntegration_serviceIntegration_OpsCenter = null;
            if (cmdletContext.ServiceIntegration_OpsCenter != null)
            {
                requestServiceIntegration_serviceIntegration_OpsCenter = cmdletContext.ServiceIntegration_OpsCenter;
            }
            if (requestServiceIntegration_serviceIntegration_OpsCenter != null)
            {
                request.ServiceIntegration.OpsCenter = requestServiceIntegration_serviceIntegration_OpsCenter;
                requestServiceIntegrationIsNull = false;
            }
            Amazon.DevOpsGuru.Model.LogsAnomalyDetectionIntegrationConfig requestServiceIntegration_serviceIntegration_LogsAnomalyDetection = null;
            
             // populate LogsAnomalyDetection
            var requestServiceIntegration_serviceIntegration_LogsAnomalyDetectionIsNull = true;
            requestServiceIntegration_serviceIntegration_LogsAnomalyDetection = new Amazon.DevOpsGuru.Model.LogsAnomalyDetectionIntegrationConfig();
            Amazon.DevOpsGuru.OptInStatus requestServiceIntegration_serviceIntegration_LogsAnomalyDetection_logsAnomalyDetection_OptInStatus = null;
            if (cmdletContext.LogsAnomalyDetection_OptInStatus != null)
            {
                requestServiceIntegration_serviceIntegration_LogsAnomalyDetection_logsAnomalyDetection_OptInStatus = cmdletContext.LogsAnomalyDetection_OptInStatus;
            }
            if (requestServiceIntegration_serviceIntegration_LogsAnomalyDetection_logsAnomalyDetection_OptInStatus != null)
            {
                requestServiceIntegration_serviceIntegration_LogsAnomalyDetection.OptInStatus = requestServiceIntegration_serviceIntegration_LogsAnomalyDetection_logsAnomalyDetection_OptInStatus;
                requestServiceIntegration_serviceIntegration_LogsAnomalyDetectionIsNull = false;
            }
             // determine if requestServiceIntegration_serviceIntegration_LogsAnomalyDetection should be set to null
            if (requestServiceIntegration_serviceIntegration_LogsAnomalyDetectionIsNull)
            {
                requestServiceIntegration_serviceIntegration_LogsAnomalyDetection = null;
            }
            if (requestServiceIntegration_serviceIntegration_LogsAnomalyDetection != null)
            {
                request.ServiceIntegration.LogsAnomalyDetection = requestServiceIntegration_serviceIntegration_LogsAnomalyDetection;
                requestServiceIntegrationIsNull = false;
            }
            Amazon.DevOpsGuru.Model.KMSServerSideEncryptionIntegrationConfig requestServiceIntegration_serviceIntegration_KMSServerSideEncryption = null;
            
             // populate KMSServerSideEncryption
            var requestServiceIntegration_serviceIntegration_KMSServerSideEncryptionIsNull = true;
            requestServiceIntegration_serviceIntegration_KMSServerSideEncryption = new Amazon.DevOpsGuru.Model.KMSServerSideEncryptionIntegrationConfig();
            System.String requestServiceIntegration_serviceIntegration_KMSServerSideEncryption_kMSServerSideEncryption_KMSKeyId = null;
            if (cmdletContext.KMSServerSideEncryption_KMSKeyId != null)
            {
                requestServiceIntegration_serviceIntegration_KMSServerSideEncryption_kMSServerSideEncryption_KMSKeyId = cmdletContext.KMSServerSideEncryption_KMSKeyId;
            }
            if (requestServiceIntegration_serviceIntegration_KMSServerSideEncryption_kMSServerSideEncryption_KMSKeyId != null)
            {
                requestServiceIntegration_serviceIntegration_KMSServerSideEncryption.KMSKeyId = requestServiceIntegration_serviceIntegration_KMSServerSideEncryption_kMSServerSideEncryption_KMSKeyId;
                requestServiceIntegration_serviceIntegration_KMSServerSideEncryptionIsNull = false;
            }
            Amazon.DevOpsGuru.OptInStatus requestServiceIntegration_serviceIntegration_KMSServerSideEncryption_kMSServerSideEncryption_OptInStatus = null;
            if (cmdletContext.KMSServerSideEncryption_OptInStatus != null)
            {
                requestServiceIntegration_serviceIntegration_KMSServerSideEncryption_kMSServerSideEncryption_OptInStatus = cmdletContext.KMSServerSideEncryption_OptInStatus;
            }
            if (requestServiceIntegration_serviceIntegration_KMSServerSideEncryption_kMSServerSideEncryption_OptInStatus != null)
            {
                requestServiceIntegration_serviceIntegration_KMSServerSideEncryption.OptInStatus = requestServiceIntegration_serviceIntegration_KMSServerSideEncryption_kMSServerSideEncryption_OptInStatus;
                requestServiceIntegration_serviceIntegration_KMSServerSideEncryptionIsNull = false;
            }
            Amazon.DevOpsGuru.ServerSideEncryptionType requestServiceIntegration_serviceIntegration_KMSServerSideEncryption_kMSServerSideEncryption_Type = null;
            if (cmdletContext.KMSServerSideEncryption_Type != null)
            {
                requestServiceIntegration_serviceIntegration_KMSServerSideEncryption_kMSServerSideEncryption_Type = cmdletContext.KMSServerSideEncryption_Type;
            }
            if (requestServiceIntegration_serviceIntegration_KMSServerSideEncryption_kMSServerSideEncryption_Type != null)
            {
                requestServiceIntegration_serviceIntegration_KMSServerSideEncryption.Type = requestServiceIntegration_serviceIntegration_KMSServerSideEncryption_kMSServerSideEncryption_Type;
                requestServiceIntegration_serviceIntegration_KMSServerSideEncryptionIsNull = false;
            }
             // determine if requestServiceIntegration_serviceIntegration_KMSServerSideEncryption should be set to null
            if (requestServiceIntegration_serviceIntegration_KMSServerSideEncryptionIsNull)
            {
                requestServiceIntegration_serviceIntegration_KMSServerSideEncryption = null;
            }
            if (requestServiceIntegration_serviceIntegration_KMSServerSideEncryption != null)
            {
                request.ServiceIntegration.KMSServerSideEncryption = requestServiceIntegration_serviceIntegration_KMSServerSideEncryption;
                requestServiceIntegrationIsNull = false;
            }
             // determine if request.ServiceIntegration should be set to null
            if (requestServiceIntegrationIsNull)
            {
                request.ServiceIntegration = null;
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
        
        private Amazon.DevOpsGuru.Model.UpdateServiceIntegrationResponse CallAWSServiceOperation(IAmazonDevOpsGuru client, Amazon.DevOpsGuru.Model.UpdateServiceIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DevOps Guru", "UpdateServiceIntegration");
            try
            {
                return client.UpdateServiceIntegrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String KMSServerSideEncryption_KMSKeyId { get; set; }
            public Amazon.DevOpsGuru.OptInStatus KMSServerSideEncryption_OptInStatus { get; set; }
            public Amazon.DevOpsGuru.ServerSideEncryptionType KMSServerSideEncryption_Type { get; set; }
            public Amazon.DevOpsGuru.OptInStatus LogsAnomalyDetection_OptInStatus { get; set; }
            public Amazon.DevOpsGuru.Model.OpsCenterIntegrationConfig ServiceIntegration_OpsCenter { get; set; }
            public System.Func<Amazon.DevOpsGuru.Model.UpdateServiceIntegrationResponse, UpdateDGURUServiceIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
