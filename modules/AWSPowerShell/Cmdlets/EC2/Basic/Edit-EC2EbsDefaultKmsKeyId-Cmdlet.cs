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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Changes the default KMS key for EBS encryption by default for your account in this
    /// Region.
    /// 
    ///  
    /// <para>
    /// Amazon Web Services creates a unique Amazon Web Services managed KMS key in each Region
    /// for use with encryption by default. If you change the default KMS key to a symmetric
    /// customer managed KMS key, it is used instead of the Amazon Web Services managed KMS
    /// key. To reset the default KMS key to the Amazon Web Services managed KMS key for EBS,
    /// use <a>ResetEbsDefaultKmsKeyId</a>. Amazon EBS does not support asymmetric KMS keys.
    /// </para><para>
    /// If you delete or disable the customer managed KMS key that you specified for use with
    /// encryption by default, your instances will fail to launch.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/ebs-encryption.html">Amazon
    /// EBS encryption</a> in the <i>Amazon EBS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2EbsDefaultKmsKeyId", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyEbsDefaultKmsKeyId API operation.", Operation = new[] {"ModifyEbsDefaultKmsKeyId"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyEbsDefaultKmsKeyIdResponse))]
    [AWSCmdletOutput("System.String or Amazon.EC2.Model.ModifyEbsDefaultKmsKeyIdResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EC2.Model.ModifyEbsDefaultKmsKeyIdResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2EbsDefaultKmsKeyIdCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the KMS key to use for Amazon EBS encryption. If this parameter
        /// is not specified, your KMS key for Amazon EBS is used. If <c>KmsKeyId</c> is specified,
        /// the encrypted state must be <c>true</c>.</para><para>You can specify the KMS key using any of the following:</para><ul><li><para>Key ID. For example, 1234abcd-12ab-34cd-56ef-1234567890ab.</para></li><li><para>Key alias. For example, alias/ExampleAlias.</para></li><li><para>Key ARN. For example, arn:aws:kms:us-east-1:012345678910:key/1234abcd-12ab-34cd-56ef-1234567890ab.</para></li><li><para>Alias ARN. For example, arn:aws:kms:us-east-1:012345678910:alias/ExampleAlias.</para></li></ul><para>Amazon Web Services authenticates the KMS key asynchronously. Therefore, if you specify
        /// an ID, alias, or ARN that is not valid, the action can appear to complete, but eventually
        /// fails.</para><para>Amazon EBS does not support asymmetric KMS keys.</para>
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
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KmsKeyId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyEbsDefaultKmsKeyIdResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyEbsDefaultKmsKeyIdResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KmsKeyId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KmsKeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2EbsDefaultKmsKeyId (ModifyEbsDefaultKmsKeyId)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyEbsDefaultKmsKeyIdResponse, EditEC2EbsDefaultKmsKeyIdCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KmsKeyId = this.KmsKeyId;
            #if MODULAR
            if (this.KmsKeyId == null && ParameterWasBound(nameof(this.KmsKeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KmsKeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyEbsDefaultKmsKeyIdRequest();
            
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
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
        
        private Amazon.EC2.Model.ModifyEbsDefaultKmsKeyIdResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyEbsDefaultKmsKeyIdRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyEbsDefaultKmsKeyId");
            try
            {
                #if DESKTOP
                return client.ModifyEbsDefaultKmsKeyId(request);
                #elif CORECLR
                return client.ModifyEbsDefaultKmsKeyIdAsync(request).GetAwaiter().GetResult();
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
            public System.String KmsKeyId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyEbsDefaultKmsKeyIdResponse, EditEC2EbsDefaultKmsKeyIdCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KmsKeyId;
        }
        
    }
}
