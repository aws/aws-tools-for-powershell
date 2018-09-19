/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Sets the security configuration for a specified catalog. Once the configuration has
    /// been set, the specified encryption is applied to every catalog write thereafter.
    /// </summary>
    [Cmdlet("Set", "GLUEDataCatalogEncryptionSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Glue PutDataCatalogEncryptionSettings API operation.", Operation = new[] {"PutDataCatalogEncryptionSettings"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the CatalogId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Glue.Model.PutDataCatalogEncryptionSettingsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetGLUEDataCatalogEncryptionSettingCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter EncryptionAtRest_CatalogEncryptionMode
        /// <summary>
        /// <para>
        /// <para>The encryption-at-rest mode for encrypting Data Catalog data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DataCatalogEncryptionSettings_EncryptionAtRest_CatalogEncryptionMode")]
        [AWSConstantClassSource("Amazon.Glue.CatalogEncryptionMode")]
        public Amazon.Glue.CatalogEncryptionMode EncryptionAtRest_CatalogEncryptionMode { get; set; }
        #endregion
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the Data Catalog for which to set the security configuration. If none is
        /// supplied, the AWS account ID is used by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter EncryptionAtRest_SseAwsKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS KMS key to use for encryption at rest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DataCatalogEncryptionSettings_EncryptionAtRest_SseAwsKmsKeyId")]
        public System.String EncryptionAtRest_SseAwsKmsKeyId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the CatalogId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CatalogId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-GLUEDataCatalogEncryptionSetting (PutDataCatalogEncryptionSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CatalogId = this.CatalogId;
            context.DataCatalogEncryptionSettings_EncryptionAtRest_CatalogEncryptionMode = this.EncryptionAtRest_CatalogEncryptionMode;
            context.DataCatalogEncryptionSettings_EncryptionAtRest_SseAwsKmsKeyId = this.EncryptionAtRest_SseAwsKmsKeyId;
            
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
            bool requestDataCatalogEncryptionSettingsIsNull = true;
            request.DataCatalogEncryptionSettings = new Amazon.Glue.Model.DataCatalogEncryptionSettings();
            Amazon.Glue.Model.EncryptionAtRest requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest = null;
            
             // populate EncryptionAtRest
            bool requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRestIsNull = true;
            requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest = new Amazon.Glue.Model.EncryptionAtRest();
            Amazon.Glue.CatalogEncryptionMode requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest_encryptionAtRest_CatalogEncryptionMode = null;
            if (cmdletContext.DataCatalogEncryptionSettings_EncryptionAtRest_CatalogEncryptionMode != null)
            {
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest_encryptionAtRest_CatalogEncryptionMode = cmdletContext.DataCatalogEncryptionSettings_EncryptionAtRest_CatalogEncryptionMode;
            }
            if (requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest_encryptionAtRest_CatalogEncryptionMode != null)
            {
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest.CatalogEncryptionMode = requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest_encryptionAtRest_CatalogEncryptionMode;
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRestIsNull = false;
            }
            System.String requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest_encryptionAtRest_SseAwsKmsKeyId = null;
            if (cmdletContext.DataCatalogEncryptionSettings_EncryptionAtRest_SseAwsKmsKeyId != null)
            {
                requestDataCatalogEncryptionSettings_dataCatalogEncryptionSettings_EncryptionAtRest_encryptionAtRest_SseAwsKmsKeyId = cmdletContext.DataCatalogEncryptionSettings_EncryptionAtRest_SseAwsKmsKeyId;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.CatalogId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutDataCatalogEncryptionSettingsAsync(request);
                return task.Result;
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
            public Amazon.Glue.CatalogEncryptionMode DataCatalogEncryptionSettings_EncryptionAtRest_CatalogEncryptionMode { get; set; }
            public System.String DataCatalogEncryptionSettings_EncryptionAtRest_SseAwsKmsKeyId { get; set; }
        }
        
    }
}
