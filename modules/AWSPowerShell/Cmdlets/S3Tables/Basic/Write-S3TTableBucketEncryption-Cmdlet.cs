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
using Amazon.S3Tables;
using Amazon.S3Tables.Model;

namespace Amazon.PowerShell.Cmdlets.S3T
{
    /// <summary>
    /// Sets the encryption configuration for a table bucket.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3tables:PutTableBucketEncryption</c> permission to use this
    /// operation.
    /// </para><note><para>
    /// If you choose SSE-KMS encryption you must grant the S3 Tables maintenance principal
    /// access to your KMS key. For more information, see <a href="AmazonS3/latest/userguide/s3-tables-kms-permissions.html">Permissions
    /// requirements for S3 Tables SSE-KMS encryption</a></para></note></dd></dl>
    /// </summary>
    [Cmdlet("Write", "S3TTableBucketEncryption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Tables PutTableBucketEncryption API operation.", Operation = new[] {"PutTableBucketEncryption"}, SelectReturnType = typeof(Amazon.S3Tables.Model.PutTableBucketEncryptionResponse))]
    [AWSCmdletOutput("None or Amazon.S3Tables.Model.PutTableBucketEncryptionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Tables.Model.PutTableBucketEncryptionResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteS3TTableBucketEncryptionCmdlet : AmazonS3TablesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key to use for encryption. This field is
        /// required only when <c>sseAlgorithm</c> is set to <c>aws:kms</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_SseAlgorithm
        /// <summary>
        /// <para>
        /// <para>The server-side encryption algorithm to use. Valid values are <c>AES256</c> for S3-managed
        /// encryption keys, or <c>aws:kms</c> for Amazon Web Services KMS-managed encryption
        /// keys. If you choose SSE-KMS encryption you must grant the S3 Tables maintenance principal
        /// access to your KMS key. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-tables-kms-permissions.html">Permissions
        /// requirements for S3 Tables SSE-KMS encryption</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.S3Tables.SSEAlgorithm")]
        public Amazon.S3Tables.SSEAlgorithm EncryptionConfiguration_SseAlgorithm { get; set; }
        #endregion
        
        #region Parameter TableBucketARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the table bucket.</para>
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
        public System.String TableBucketARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Tables.Model.PutTableBucketEncryptionResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TableBucketARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TableBucketARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TableBucketARN' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EncryptionConfiguration_KmsKeyArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3TTableBucketEncryption (PutTableBucketEncryption)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Tables.Model.PutTableBucketEncryptionResponse, WriteS3TTableBucketEncryptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TableBucketARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EncryptionConfiguration_KmsKeyArn = this.EncryptionConfiguration_KmsKeyArn;
            context.EncryptionConfiguration_SseAlgorithm = this.EncryptionConfiguration_SseAlgorithm;
            #if MODULAR
            if (this.EncryptionConfiguration_SseAlgorithm == null && ParameterWasBound(nameof(this.EncryptionConfiguration_SseAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter EncryptionConfiguration_SseAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableBucketARN = this.TableBucketARN;
            #if MODULAR
            if (this.TableBucketARN == null && ParameterWasBound(nameof(this.TableBucketARN)))
            {
                WriteWarning("You are passing $null as a value for parameter TableBucketARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.S3Tables.Model.PutTableBucketEncryptionRequest();
            
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.S3Tables.Model.EncryptionConfiguration();
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
            Amazon.S3Tables.SSEAlgorithm requestEncryptionConfiguration_encryptionConfiguration_SseAlgorithm = null;
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
            if (cmdletContext.TableBucketARN != null)
            {
                request.TableBucketARN = cmdletContext.TableBucketARN;
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
        
        private Amazon.S3Tables.Model.PutTableBucketEncryptionResponse CallAWSServiceOperation(IAmazonS3Tables client, Amazon.S3Tables.Model.PutTableBucketEncryptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Tables", "PutTableBucketEncryption");
            try
            {
                #if DESKTOP
                return client.PutTableBucketEncryption(request);
                #elif CORECLR
                return client.PutTableBucketEncryptionAsync(request).GetAwaiter().GetResult();
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
            public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
            public Amazon.S3Tables.SSEAlgorithm EncryptionConfiguration_SseAlgorithm { get; set; }
            public System.String TableBucketARN { get; set; }
            public System.Func<Amazon.S3Tables.Model.PutTableBucketEncryptionResponse, WriteS3TTableBucketEncryptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
