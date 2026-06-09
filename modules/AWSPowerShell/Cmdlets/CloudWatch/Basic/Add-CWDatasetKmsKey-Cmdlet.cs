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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Associates an Amazon Web Services Key Management Service (Amazon Web Services KMS)
    /// customer managed key with the specified dataset. After this operation completes, all
    /// data published to the dataset is encrypted at rest using the specified KMS key. Callers
    /// must have <c>kms:Decrypt</c> permission on the key to read the encrypted data.
    /// 
    ///  
    /// <para>
    /// Only the <c>default</c> dataset is supported. The <c>default</c> dataset is implicit
    /// for every account in every Region — you do not need to create it before calling this
    /// operation.
    /// </para><para>
    /// You can call <c>AssociateDatasetKmsKey</c> on a dataset that is already associated
    /// with a KMS key to replace the existing key with a different one. To replace a key,
    /// the caller must have <c>kms:Decrypt</c> permission on both the current key and the
    /// new key.
    /// </para><para>
    /// The KMS key that you specify must meet all of the following requirements:
    /// </para><ul><li><para>
    /// It must be a symmetric encryption KMS key (key spec <c>SYMMETRIC_DEFAULT</c>, key
    /// usage <c>ENCRYPT_DECRYPT</c>). Asymmetric keys, HMAC keys, and key material types
    /// other than <c>SYMMETRIC_DEFAULT</c> are not supported.
    /// </para></li><li><para>
    /// It must be enabled and not pending deletion.
    /// </para></li><li><para>
    /// Its key policy must grant the CloudWatch service principal (<c>cloudwatch.amazonaws.com</c>)
    /// these permissions: <c>kms:DescribeKey</c>, <c>kms:GenerateDataKey</c>, <c>kms:Encrypt</c>,
    /// <c>kms:Decrypt</c>, and <c>kms:ReEncrypt*</c>. Amazon CloudWatch requires these permissions
    /// to manage the data on your behalf.
    /// </para></li><li><para>
    /// The calling principal must have <c>kms:Decrypt</c> permission on the key.
    /// </para></li><li><para>
    /// It must be specified as a fully qualified key ARN. Key IDs, aliases, and alias ARNs
    /// are not accepted.
    /// </para></li><li><para>
    /// It must be in the same Amazon Web Services Region as the dataset.
    /// </para></li></ul><para>
    /// Before completing the association, Amazon CloudWatch validates the key by performing
    /// a series of dry-run KMS operations. Service-principal checks run first to verify that
    /// the key policy grants the required access to Amazon CloudWatch. These checks include
    /// <c>kms:DescribeKey</c>, <c>kms:GenerateDataKey</c>, <c>kms:Encrypt</c>, <c>kms:Decrypt</c>,
    /// and <c>kms:ReEncrypt*</c>. After those succeed, a <c>kms:Decrypt</c> dry-run is run
    /// with the caller's credentials to verify that the calling principal can use the key.
    /// When you are replacing an existing key, the caller's <c>kms:Decrypt</c> dry-run is
    /// run on the current key first, and only then on the new key.
    /// </para><para>
    /// If any of these checks fails, the operation fails and the existing key association
    /// (if any) remains unchanged. Common failure causes include the key being disabled,
    /// the key policy not granting the required permissions to Amazon CloudWatch, or the
    /// caller lacking <c>kms:Decrypt</c> permission on the key.
    /// </para><para>
    /// For more information about using customer managed keys with Amazon CloudWatch, see
    /// <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/cmk-encryption.html">Encryption
    /// at rest with customer managed keys</a> in the <i>Amazon CloudWatch User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "CWDatasetKmsKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch AssociateDatasetKmsKey API operation.", Operation = new[] {"AssociateDatasetKmsKey"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.AssociateDatasetKmsKeyResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatch.Model.AssociateDatasetKmsKeyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatch.Model.AssociateDatasetKmsKeyResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddCWDatasetKmsKeyCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DatasetIdentifier
        /// <summary>
        /// <para>
        /// <para>Specifies the identifier of the dataset that you want to associate the KMS key with.
        /// For the <c>default</c> dataset, you can specify either <c>default</c> or the full
        /// dataset Amazon Resource Name (ARN) in the format <c>arn:aws:cloudwatch:<i>Region</i>:<i>account-id</i>:dataset/default</c>.</para>
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
        public System.String DatasetIdentifier { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Resource Name (ARN) of the customer managed KMS key to associate
        /// with the dataset. The key must be a symmetric encryption KMS key (<c>SYMMETRIC_DEFAULT</c>)
        /// in the same Amazon Web Services Region as the dataset.</para><para>The ARN must be in the format <c>arn:aws:kms:<i>Region</i>:<i>account-id</i>:key/<i>key-id</i></c>. Key IDs, aliases, and alias ARNs are not accepted.</para><para>For more information about KMS key ARNs, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id-key-ARN">Key
        /// ARN</a> in the <i>Amazon Web Services Key Management Service Developer Guide</i>.</para>
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
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.AssociateDatasetKmsKeyResponse).
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.KmsKeyArn),
                nameof(this.DatasetIdentifier)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-CWDatasetKmsKey (AssociateDatasetKmsKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.AssociateDatasetKmsKeyResponse, AddCWDatasetKmsKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatasetIdentifier = this.DatasetIdentifier;
            #if MODULAR
            if (this.DatasetIdentifier == null && ParameterWasBound(nameof(this.DatasetIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyArn = this.KmsKeyArn;
            #if MODULAR
            if (this.KmsKeyArn == null && ParameterWasBound(nameof(this.KmsKeyArn)))
            {
                WriteWarning("You are passing $null as a value for parameter KmsKeyArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatch.Model.AssociateDatasetKmsKeyRequest();
            
            if (cmdletContext.DatasetIdentifier != null)
            {
                request.DatasetIdentifier = cmdletContext.DatasetIdentifier;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
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
        
        private Amazon.CloudWatch.Model.AssociateDatasetKmsKeyResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.AssociateDatasetKmsKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "AssociateDatasetKmsKey");
            try
            {
                return client.AssociateDatasetKmsKeyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DatasetIdentifier { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.Func<Amazon.CloudWatch.Model.AssociateDatasetKmsKeyResponse, AddCWDatasetKmsKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
