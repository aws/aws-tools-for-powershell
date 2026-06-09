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
    /// Removes the customer managed Amazon Web Services Key Management Service (Amazon Web
    /// Services KMS) key association from the specified dataset. After this operation completes,
    /// data that you publish to the dataset is encrypted at rest using an Amazon Web Services
    /// owned key managed by Amazon CloudWatch.
    /// 
    ///  
    /// <para>
    /// Only the <c>default</c> dataset is supported. To call this operation, the dataset
    /// must currently have a customer managed KMS key associated with it. If the dataset
    /// has no associated KMS key, the operation fails with <c>ResourceNotFoundException</c>.
    /// </para><para>
    /// Amazon CloudWatch performs a dry-run <c>kms:Decrypt</c> call on the key as part of
    /// this operation. This verifies that the caller is authorized to use the currently associated
    /// key. The caller must have <c>kms:Decrypt</c> permission on the currently associated
    /// key, and the key must be enabled and accessible. If the key has been disabled or scheduled
    /// for deletion, you must first re-enable or restore it before you can disassociate it
    /// from the dataset.
    /// </para><important><para>
    /// Disassociating a KMS key from a dataset does not immediately remove the <c>kms:Decrypt</c>
    /// requirement on data plane operations. For up to three hours after disassociation,
    /// callers must continue to have <c>kms:Decrypt</c> permission on the previously associated
    /// key. Some data may still be encrypted with that key during this window. After this
    /// enforcement window elapses, the <c>kms:Decrypt</c> requirement is lifted.
    /// </para></important><para>
    /// For more information about using customer managed keys with Amazon CloudWatch, see
    /// <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/cmk-encryption.html">Encryption
    /// at rest with customer managed keys</a> in the <i>Amazon CloudWatch User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "CWDatasetKmsKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch DisassociateDatasetKmsKey API operation.", Operation = new[] {"DisassociateDatasetKmsKey"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.DisassociateDatasetKmsKeyResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatch.Model.DisassociateDatasetKmsKeyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatch.Model.DisassociateDatasetKmsKeyResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveCWDatasetKmsKeyCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DatasetIdentifier
        /// <summary>
        /// <para>
        /// <para>Specifies the identifier of the dataset from which to remove the KMS key association.
        /// For the <c>default</c> dataset, you can specify either <c>default</c> or the full
        /// dataset Amazon Resource Name (ARN) in the format <c>arn:aws:cloudwatch:<i>Region</i>:<i>account-id</i>:dataset/default</c>.</para>
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
        public System.String DatasetIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.DisassociateDatasetKmsKeyResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CWDatasetKmsKey (DisassociateDatasetKmsKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.DisassociateDatasetKmsKeyResponse, RemoveCWDatasetKmsKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatasetIdentifier = this.DatasetIdentifier;
            #if MODULAR
            if (this.DatasetIdentifier == null && ParameterWasBound(nameof(this.DatasetIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatch.Model.DisassociateDatasetKmsKeyRequest();
            
            if (cmdletContext.DatasetIdentifier != null)
            {
                request.DatasetIdentifier = cmdletContext.DatasetIdentifier;
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
        
        private Amazon.CloudWatch.Model.DisassociateDatasetKmsKeyResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.DisassociateDatasetKmsKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "DisassociateDatasetKmsKey");
            try
            {
                return client.DisassociateDatasetKmsKeyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.CloudWatch.Model.DisassociateDatasetKmsKeyResponse, RemoveCWDatasetKmsKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
