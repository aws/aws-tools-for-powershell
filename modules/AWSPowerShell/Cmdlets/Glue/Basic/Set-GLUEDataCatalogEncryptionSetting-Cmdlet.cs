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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Sets the security configuration for a specified catalog. After the configuration has
    /// been set, the specified encryption is applied to every catalog write thereafter.
    /// </summary>
    [Cmdlet("Set", "GLUEDataCatalogEncryptionSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Glue PutDataCatalogEncryptionSettings API operation.", Operation = new[] {"PutDataCatalogEncryptionSettings"}, SelectReturnType = typeof(Amazon.Glue.Model.PutDataCatalogEncryptionSettingsResponse))]
    [AWSCmdletOutput("None or Amazon.Glue.Model.PutDataCatalogEncryptionSettingsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Glue.Model.PutDataCatalogEncryptionSettingsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetGLUEDataCatalogEncryptionSettingCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectionPasswordEncryption_AwsKmsKeyId
        /// <summary>
        /// <para>
        /// <para>An KMS key that is used to encrypt the connection password. </para><para>If connection password protection is enabled, the caller of <c>CreateConnection</c>
        /// and <c>UpdateConnection</c> needs at least <c>kms:Encrypt</c> permission on the specified
        /// KMS key, to encrypt passwords before storing them in the Data Catalog. </para><para>You can set the decrypt permission to enable or restrict access on the password key
        /// according to your security requirements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataCatalogEncryptionSettings_ConnectionPasswordEncryption_AwsKmsKeyId")]
        public System.String ConnectionPasswordEncryption_AwsKmsKeyId { get; set; }
        #endregion
        
        #region Parameter EncryptionAtRest_CatalogEncryptionMode
        /// <summary>
        /// <para>
        /// <para>The encryption-at-rest mode for encrypting Data Catalog data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataCatalogEncryptionSettings_EncryptionAtRest_CatalogEncryptionMode")]
        [AWSConstantClassSource("Amazon.Glue.CatalogEncryptionMode")]
        public Amazon.Glue.CatalogEncryptionMode EncryptionAtRest_CatalogEncryptionMode { get; set; }
        #endregion
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the Data Catalog to set the security configuration for. If none is provided,
        /// the Amazon Web Services account ID is used by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter ConnectionPasswordEncryption_ReturnConnectionPasswordEncrypted
        /// <summary>
        /// <para>
        /// <para>When the <c>ReturnConnectionPasswordEncrypted</c> flag is set to "true", passwords
        /// remain encrypted in the responses of <c>GetConnection</c> and <c>GetConnections</c>.
        /// This encryption takes effect independently from catalog encryption. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataCatalogEncryptionSettings_ConnectionPasswordEncryption_ReturnConnectionPasswordEncrypted")]
        public System.Boolean? ConnectionPasswordEncryption_ReturnConnectionPasswordEncrypted { get; set; }
        #endregion
        
        #region Parameter EncryptionAtRest_SseAwsKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the KMS key to use for encryption at rest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataCatalogEncryptionSettings_EncryptionAtRest_SseAwsKmsKeyId")]
        public System.String EncryptionAtRest_SseAwsKmsKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.PutDataCatalogEncryptionSettingsResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CatalogId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CatalogId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CatalogId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CatalogId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-GLUEDataCatalogEncryptionSetting (PutDataCatalogEncryptionSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.PutDataCatalogEncryptionSettingsResponse, SetGLUEDataCatalogEncryptionSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CatalogId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CatalogId = this.CatalogId;
            context.ConnectionPasswordEncryption_AwsKmsKeyId = this.ConnectionPasswordEncryption_AwsKmsKeyId;
            context.ConnectionPasswordEncryption_ReturnConnectionPasswordEncrypted = this.ConnectionPasswordEncryption_ReturnConnectionPasswordEncrypted;
            context.EncryptionAtRest_CatalogEncryptionMode = this.EncryptionAtRest_CatalogEncryptionMode;
            context.EncryptionAtRest_SseAwsKmsKeyId = this.EncryptionAtRest_SseAwsKmsKeyId;
            
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
            var request = new Amazon.Glue.Model.PutDataCatalogEncryptionSettingsRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            
             // populate DataCatalogEncryptionSettings
            var requestDataCatalogEncryptionSettingsIsNull = true;
            request.DataCatalogEncryptionSettings = new Amazon.Glue.Model.DataCatalogEncryptionSettings();
            Amazon.Glue.Model.ConnectionPasswordEncryption requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption = null;
            
             // populate ConnectionPasswordEncryption
            var requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryptionIsNull = true;
            requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption = new Amazon.Glue.Model.ConnectionPasswordEncryption();
            System.String requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption_connectionPasswordEncryption_AwsKmsKeyId = null;
            if (cmdletContext.ConnectionPasswordEncryption_AwsKmsKeyId != null)
            {
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption_connectionPasswordEncryption_AwsKmsKeyId = cmdletContext.ConnectionPasswordEncryption_AwsKmsKeyId;
            }
            if (requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption_connectionPasswordEncryption_AwsKmsKeyId != null)
            {
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption.AwsKmsKeyId = requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption_connectionPasswordEncryption_AwsKmsKeyId;
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryptionIsNull = false;
            }
            System.Boolean? requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption_connectionPasswordEncryption_ReturnConnectionPasswordEncrypted = null;
            if (cmdletContext.ConnectionPasswordEncryption_ReturnConnectionPasswordEncrypted != null)
            {
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption_connectionPasswordEncryption_ReturnConnectionPasswordEncrypted = cmdletContext.ConnectionPasswordEncryption_ReturnConnectionPasswordEncrypted.Value;
            }
            if (requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption_connectionPasswordEncryption_ReturnConnectionPasswordEncrypted != null)
            {
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption.ReturnConnectionPasswordEncrypted = requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption_connectionPasswordEncryption_ReturnConnectionPasswordEncrypted.Value;
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryptionIsNull = false;
            }
             // determine if requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption should be set to null
            if (requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryptionIsNull)
            {
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption = null;
            }
            if (requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption != null)
            {
                request.DataCatalogEncryptionSettings.ConnectionPasswordEncryption = requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_ConnectionPasswordEncryption;
                requestDataCatalogEncryptionSettingsIsNull = false;
            }
            Amazon.Glue.Model.EncryptionAtRest requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest = null;
            
             // populate EncryptionAtRest
            var requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRestIsNull = true;
            requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest = new Amazon.Glue.Model.EncryptionAtRest();
            Amazon.Glue.CatalogEncryptionMode requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest_encryptionAtRest_CatalogEncryptionMode = null;
            if (cmdletContext.EncryptionAtRest_CatalogEncryptionMode != null)
            {
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest_encryptionAtRest_CatalogEncryptionMode = cmdletContext.EncryptionAtRest_CatalogEncryptionMode;
            }
            if (requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest_encryptionAtRest_CatalogEncryptionMode != null)
            {
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest.CatalogEncryptionMode = requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest_encryptionAtRest_CatalogEncryptionMode;
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRestIsNull = false;
            }
            System.String requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest_encryptionAtRest_SseAwsKmsKeyId = null;
            if (cmdletContext.EncryptionAtRest_SseAwsKmsKeyId != null)
            {
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest_encryptionAtRest_SseAwsKmsKeyId = cmdletContext.EncryptionAtRest_SseAwsKmsKeyId;
            }
            if (requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest_encryptionAtRest_SseAwsKmsKeyId != null)
            {
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest.SseAwsKmsKeyId = requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest_encryptionAtRest_SseAwsKmsKeyId;
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRestIsNull = false;
            }
             // determine if requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest should be set to null
            if (requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRestIsNull)
            {
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest = null;
            }
            if (requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest != null)
            {
                request.DataCatalogEncryptionSettings.EncryptionAtRest = requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest;
                requestDataCatalogEncryptionSettingsIsNull = false;
            }
             // determine if request.DataCatalogEncryptionSettings should be set to null
            if (requestDataCatalogEncryptionSettingsIsNull)
            {
                request.DataCatalogEncryptionSettings = null;
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
        
        private Amazon.Glue.Model.PutDataCatalogEncryptionSettingsResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.PutDataCatalogEncryptionSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "PutDataCatalogEncryptionSettings");
            try
            {
                #if DESKTOP
                return client.PutDataCatalogEncryptionSettings(request);
                #elif CORECLR
                return client.PutDataCatalogEncryptionSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.String CatalogId { get; set; }
            public System.String ConnectionPasswordEncryption_AwsKmsKeyId { get; set; }
            public System.Boolean? ConnectionPasswordEncryption_ReturnConnectionPasswordEncrypted { get; set; }
            public Amazon.Glue.CatalogEncryptionMode EncryptionAtRest_CatalogEncryptionMode { get; set; }
            public System.String EncryptionAtRest_SseAwsKmsKeyId { get; set; }
            public System.Func<Amazon.Glue.Model.PutDataCatalogEncryptionSettingsResponse, SetGLUEDataCatalogEncryptionSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
