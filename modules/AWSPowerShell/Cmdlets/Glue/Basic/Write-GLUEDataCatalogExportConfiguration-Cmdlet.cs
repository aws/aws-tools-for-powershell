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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Creates or updates the export configuration for the Glue Data Catalog. Use this operation
    /// to enable or disable the export of catalog metadata to S3 Tables.
    /// </summary>
    [Cmdlet("Write", "GLUEDataCatalogExportConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glue.Model.PutDataCatalogExportConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Glue PutDataCatalogExportConfiguration API operation.", Operation = new[] {"PutDataCatalogExportConfiguration"}, SelectReturnType = typeof(Amazon.Glue.Model.PutDataCatalogExportConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.PutDataCatalogExportConfigurationResponse",
        "This cmdlet returns an Amazon.Glue.Model.PutDataCatalogExportConfigurationResponse object containing multiple properties."
    )]
    public partial class WriteGLUEDataCatalogExportConfigurationCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExportSetting
        /// <summary>
        /// <para>
        /// <para>The export setting for the data catalog. Specify <c>ENABLED</c> to start exporting
        /// catalog metadata to S3 Tables, or <c>DISABLED</c> to stop exporting. This field is
        /// required.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Glue.ExportSetting")]
        public Amazon.Glue.ExportSetting ExportSetting { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key used to encrypt the exported data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_SseAlgorithm
        /// <summary>
        /// <para>
        /// <para>The server-side encryption algorithm used for the exported data. Valid values are
        /// <c>AES256</c> and <c>aws:kms</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_SseAlgorithm { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.PutDataCatalogExportConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.PutDataCatalogExportConfigurationResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExportSetting), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-GLUEDataCatalogExportConfiguration (PutDataCatalogExportConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.PutDataCatalogExportConfigurationResponse, WriteGLUEDataCatalogExportConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.EncryptionConfiguration_KmsKeyArn = this.EncryptionConfiguration_KmsKeyArn;
            context.EncryptionConfiguration_SseAlgorithm = this.EncryptionConfiguration_SseAlgorithm;
            context.ExportSetting = this.ExportSetting;
            #if MODULAR
            if (this.ExportSetting == null && ParameterWasBound(nameof(this.ExportSetting)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportSetting which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glue.Model.PutDataCatalogExportConfigurationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.Glue.Model.ExportEncryptionConfiguration();
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyArn != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn = cmdletContext.EncryptionConfiguration_KmsKeyArn;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn != null)
            {
                request.EncryptionConfiguration.KmsKeyArn = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn;
                requestEncryptionConfigurationIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_SseAlgorithm = null;
            if (cmdletContext.EncryptionConfiguration_SseAlgorithm != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_SseAlgorithm = cmdletContext.EncryptionConfiguration_SseAlgorithm;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_SseAlgorithm != null)
            {
                request.EncryptionConfiguration.SseAlgorithm = requestEncryptionConfiguration_encryptionConfiguration_SseAlgorithm;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            if (cmdletContext.ExportSetting != null)
            {
                request.ExportSetting = cmdletContext.ExportSetting;
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
        
        private Amazon.Glue.Model.PutDataCatalogExportConfigurationResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.PutDataCatalogExportConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "PutDataCatalogExportConfiguration");
            try
            {
                return client.PutDataCatalogExportConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
            public System.String EncryptionConfiguration_SseAlgorithm { get; set; }
            public Amazon.Glue.ExportSetting ExportSetting { get; set; }
            public System.Func<Amazon.Glue.Model.PutDataCatalogExportConfigurationResponse, WriteGLUEDataCatalogExportConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
