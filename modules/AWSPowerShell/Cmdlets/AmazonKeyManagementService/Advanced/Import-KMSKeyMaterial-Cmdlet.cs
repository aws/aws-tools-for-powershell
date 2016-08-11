/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;
using System.IO;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Imports key material into an AWS KMS customer master key (CMK) from your existing
    /// key management infrastructure. For more information about importing key material into
    /// AWS KMS, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">Importing
    /// Key Material</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// You must specify the key ID of the CMK to import the key material into. This CMK's
    /// <code>Origin</code> must be <code>EXTERNAL</code>. You must also send an import token
    /// and the encrypted key material. Send the import token that you received in the same
    /// <a>GetParametersForImport</a> response that contained the public key that you used
    /// to encrypt the key material. You must also specify whether the key material expires
    /// and if so, when. When the key material expires, AWS KMS deletes the key material and
    /// the CMK becomes unusable. To use the CMK again, you can reimport the same key material.
    /// If you set an expiration date, you can change it only by reimporting the same key
    /// material and specifying a new expiration date.
    /// </para><para>
    /// When this operation is successful, the specified CMK's key state changes to <code>Enabled</code>,
    /// and you can use the CMK.
    /// </para><para>
    /// After you successfully import key material into a CMK, you can reimport the same key
    /// material into that CMK, but you cannot import different key material.
    /// </para>
    /// </summary>
    [Cmdlet("Import", "KMSKeyMaterial", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ImportKeyMaterial operation against AWS Key Management Service.", Operation = new[] {"ImportKeyMaterial"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the KeyId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.KeyManagementService.Model.ImportKeyMaterialResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class ImportKMSKeyMaterialCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter EncryptedKeyMaterial
        /// <summary>
        /// <para>
        /// <para>The encrypted key material to import. It must be encrypted with the public key that
        /// you received in the response to a previous <a>GetParametersForImport</a> request,
        /// using the wrapping algorithm that you specified in that request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] EncryptedKeyMaterial { get; set; }
        #endregion
        
        #region Parameter ExpirationModel
        /// <summary>
        /// <para>
        /// <para>Specifies whether the key material expires. The default is <code>KEY_MATERIAL_EXPIRES</code>,
        /// in which case you must include the <code>ValidTo</code> parameter. When this parameter
        /// is set to <code>KEY_MATERIAL_DOES_NOT_EXPIRE</code>, you must omit the <code>ValidTo</code>
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.KeyManagementService.ExpirationModelType")]
        public Amazon.KeyManagementService.ExpirationModelType ExpirationModel { get; set; }
        #endregion
        
        #region Parameter ImportToken
        /// <summary>
        /// <para>
        /// <para>The import token that you received in the response to a previous <a>GetParametersForImport</a>
        /// request. It must be from the same response that contained the public key that you
        /// used to encrypt the key material.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] ImportToken { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the CMK to import the key material into. The CMK's <code>Origin</code>
        /// must be <code>EXTERNAL</code>.</para><para>A valid identifier is the unique key ID or the Amazon Resource Name (ARN) of the CMK.
        /// Examples:</para><ul><li><para>Unique key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter ValidTo
        /// <summary>
        /// <para>
        /// <para>The time at which the imported key material expires. When the key material expires,
        /// AWS KMS deletes the key material and the CMK becomes unusable. You must omit this
        /// parameter when the <code>ExpirationModel</code> parameter is set to <code>KEY_MATERIAL_DOES_NOT_EXPIRE</code>.
        /// Otherwise it is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ValidTo { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the KeyId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("KeyId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-KMSKeyMaterial (ImportKeyMaterial)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.EncryptedKeyMaterial = this.EncryptedKeyMaterial;
            context.ExpirationModel = this.ExpirationModel;
            context.ImportToken = this.ImportToken;
            context.KeyId = this.KeyId;
            if (ParameterWasBound("ValidTo"))
                context.ValidTo = this.ValidTo;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.KeyManagementService.Model.ImportKeyMaterialRequest();

            MemoryStream _encryptedKeyMaterial = null;
            MemoryStream _importToken = null;

            try
            {
                if (cmdletContext.EncryptedKeyMaterial != null)
                {
                    _encryptedKeyMaterial = new MemoryStream(cmdletContext.EncryptedKeyMaterial);
                    request.EncryptedKeyMaterial = _encryptedKeyMaterial;
                }
                if (cmdletContext.ExpirationModel != null)
                {
                    request.ExpirationModel = cmdletContext.ExpirationModel;
                }
                if (cmdletContext.ImportToken != null)
                {
                    _importToken = new MemoryStream(cmdletContext.ImportToken);
                    request.ImportToken = _importToken;
                }
                if (cmdletContext.KeyId != null)
                {
                    request.KeyId = cmdletContext.KeyId;
                }
                if (cmdletContext.ValidTo != null)
                {
                    request.ValidTo = cmdletContext.ValidTo.Value;
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
                        pipelineOutput = this.KeyId;
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
            finally
            {
                if (_encryptedKeyMaterial != null)
                    _encryptedKeyMaterial.Dispose();
                if (_importToken != null)
                    _importToken = null;
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private static Amazon.KeyManagementService.Model.ImportKeyMaterialResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.ImportKeyMaterialRequest request)
        {
            return client.ImportKeyMaterial(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public byte[] EncryptedKeyMaterial { get; set; }
            public Amazon.KeyManagementService.ExpirationModelType ExpirationModel { get; set; }
            public byte[] ImportToken { get; set; }
            public System.String KeyId { get; set; }
            public System.DateTime? ValidTo { get; set; }
        }
        
    }
}
