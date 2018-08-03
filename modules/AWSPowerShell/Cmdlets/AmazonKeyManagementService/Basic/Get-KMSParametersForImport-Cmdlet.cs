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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Returns the items you need in order to import key material into AWS KMS from your
    /// existing key management infrastructure. For more information about importing key material
    /// into AWS KMS, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">Importing
    /// Key Material</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// You must specify the key ID of the customer master key (CMK) into which you will import
    /// key material. This CMK's <code>Origin</code> must be <code>EXTERNAL</code>. You must
    /// also specify the wrapping algorithm and type of wrapping key (public key) that you
    /// will use to encrypt the key material. You cannot perform this operation on a CMK in
    /// a different AWS account.
    /// </para><para>
    /// This operation returns a public key and an import token. Use the public key to encrypt
    /// the key material. Store the import token to send with a subsequent <a>ImportKeyMaterial</a>
    /// request. The public key and import token from the same response must be used together.
    /// These items are valid for 24 hours. When they expire, they cannot be used for a subsequent
    /// <a>ImportKeyMaterial</a> request. To get new ones, send another <code>GetParametersForImport</code>
    /// request.
    /// </para><para>
    /// The result of this operation varies with the key state of the CMK. For details, see
    /// <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">How
    /// Key State Affects Use of a Customer Master Key</a> in the <i>AWS Key Management Service
    /// Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KMSParametersForImport")]
    [OutputType("Amazon.KeyManagementService.Model.GetParametersForImportResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service GetParametersForImport API operation.", Operation = new[] {"GetParametersForImport"})]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.GetParametersForImportResponse",
        "This cmdlet returns a Amazon.KeyManagementService.Model.GetParametersForImportResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetKMSParametersForImportCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the CMK into which you will import key material. The CMK's <code>Origin</code>
        /// must be <code>EXTERNAL</code>.</para><para>Specify the key ID or the Amazon Resource Name (ARN) of the CMK.</para><para>For example:</para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li></ul><para>To get the key ID and key ARN for a CMK, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter WrappingAlgorithm
        /// <summary>
        /// <para>
        /// <para>The algorithm you use to encrypt the key material before importing it with <a>ImportKeyMaterial</a>.
        /// For more information, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/importing-keys-encrypt-key-material.html">Encrypt
        /// the Key Material</a> in the <i>AWS Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.KeyManagementService.AlgorithmSpec")]
        public Amazon.KeyManagementService.AlgorithmSpec WrappingAlgorithm { get; set; }
        #endregion
        
        #region Parameter WrappingKeySpec
        /// <summary>
        /// <para>
        /// <para>The type of wrapping key (public key) to return in the response. Only 2048-bit RSA
        /// public keys are supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.KeyManagementService.WrappingKeySpec")]
        public Amazon.KeyManagementService.WrappingKeySpec WrappingKeySpec { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.KeyId = this.KeyId;
            context.WrappingAlgorithm = this.WrappingAlgorithm;
            context.WrappingKeySpec = this.WrappingKeySpec;
            
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
            var request = new Amazon.KeyManagementService.Model.GetParametersForImportRequest();
            
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.WrappingAlgorithm != null)
            {
                request.WrappingAlgorithm = cmdletContext.WrappingAlgorithm;
            }
            if (cmdletContext.WrappingKeySpec != null)
            {
                request.WrappingKeySpec = cmdletContext.WrappingKeySpec;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.KeyManagementService.Model.GetParametersForImportResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.GetParametersForImportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "GetParametersForImport");
            try
            {
                #if DESKTOP
                return client.GetParametersForImport(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetParametersForImportAsync(request);
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
            public System.String KeyId { get; set; }
            public Amazon.KeyManagementService.AlgorithmSpec WrappingAlgorithm { get; set; }
            public Amazon.KeyManagementService.WrappingKeySpec WrappingKeySpec { get; set; }
        }
        
    }
}
