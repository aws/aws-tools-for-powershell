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
using Amazon.StepFunctions;
using Amazon.StepFunctions.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SFN
{
    /// <summary>
    /// Creates an activity. An activity is a task that you write in any programming language
    /// and host on any machine that has access to Step Functions. Activities must poll Step
    /// Functions using the <c>GetActivityTask</c> API action and respond using <c>SendTask*</c>
    /// API actions. This function lets Step Functions know the existence of your activity
    /// and returns an identifier for use in a state machine and when polling from the activity.
    /// 
    ///  <note><para>
    /// This operation is eventually consistent. The results are best effort and may not reflect
    /// very recent updates and changes.
    /// </para></note><note><para><c>CreateActivity</c> is an idempotent API. Subsequent requests won’t create a duplicate
    /// resource if it was already created. <c>CreateActivity</c>'s idempotency check is based
    /// on the activity <c>name</c>. If a following request has different <c>tags</c> values,
    /// Step Functions will ignore these differences and treat it as an idempotent request
    /// of the previous. In this case, <c>tags</c> will not be updated, even if they are different.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SFNActivity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StepFunctions.Model.CreateActivityResponse")]
    [AWSCmdlet("Calls the AWS Step Functions CreateActivity API operation.", Operation = new[] {"CreateActivity"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.CreateActivityResponse))]
    [AWSCmdletOutput("Amazon.StepFunctions.Model.CreateActivityResponse",
        "This cmdlet returns an Amazon.StepFunctions.Model.CreateActivityResponse object containing multiple properties."
    )]
    public partial class NewSFNActivityCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EncryptionConfiguration_KmsDataKeyReusePeriodSecond
        /// <summary>
        /// <para>
        /// <para>Maximum duration that Step Functions will reuse data keys. When the period expires,
        /// Step Functions will call <c>GenerateDataKey</c>. Only applies to customer managed
        /// keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionConfiguration_KmsDataKeyReusePeriodSeconds")]
        public System.Int32? EncryptionConfiguration_KmsDataKeyReusePeriodSecond { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>An alias, alias ARN, key ID, or key ARN of a symmetric encryption KMS key to encrypt
        /// data. To specify a KMS key in a different Amazon Web Services account, you must use
        /// the key ARN or alias ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the activity to create. This name must be unique for your Amazon Web Services
        /// account and region for 90 days. For more information, see <a href="https://docs.aws.amazon.com/step-functions/latest/dg/limits.html#service-limits-state-machine-executions">
        /// Limits Related to State Machine Executions</a> in the <i>Step Functions Developer
        /// Guide</i>.</para><para>A name must <i>not</i> contain:</para><ul><li><para>white space</para></li><li><para>brackets <c>&lt; &gt; { } [ ]</c></para></li><li><para>wildcard characters <c>? *</c></para></li><li><para>special characters <c>" # % \ ^ | ~ ` $ &amp; , ; : /</c></para></li><li><para>control characters (<c>U+0000-001F</c>, <c>U+007F-009F</c>)</para></li></ul><para>To enable logging with CloudWatch Logs, the name should only contain 0-9, A-Z, a-z,
        /// - and _.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of tags to add to a resource.</para><para>An array of key-value pairs. For more information, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/cost-alloc-tags.html">Using
        /// Cost Allocation Tags</a> in the <i>Amazon Web Services Billing and Cost Management
        /// User Guide</i>, and <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_iam-tags.html">Controlling
        /// Access Using IAM Tags</a>.</para><para>Tags may only contain Unicode letters, digits, white space, or these symbols: <c>_
        /// . : / = + - @</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.StepFunctions.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>Encryption type</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StepFunctions.EncryptionType")]
        public Amazon.StepFunctions.EncryptionType EncryptionConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StepFunctions.Model.CreateActivityResponse).
        /// Specifying the name of a property of type Amazon.StepFunctions.Model.CreateActivityResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SFNActivity (CreateActivity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.CreateActivityResponse, NewSFNActivityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EncryptionConfiguration_KmsDataKeyReusePeriodSecond = this.EncryptionConfiguration_KmsDataKeyReusePeriodSecond;
            context.EncryptionConfiguration_KmsKeyId = this.EncryptionConfiguration_KmsKeyId;
            context.EncryptionConfiguration_Type = this.EncryptionConfiguration_Type;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.StepFunctions.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.StepFunctions.Model.CreateActivityRequest();
            
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.StepFunctions.Model.EncryptionConfiguration();
            System.Int32? requestEncryptionConfiguration_encryptionConfiguration_KmsDataKeyReusePeriodSecond = null;
            if (cmdletContext.EncryptionConfiguration_KmsDataKeyReusePeriodSecond != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsDataKeyReusePeriodSecond = cmdletContext.EncryptionConfiguration_KmsDataKeyReusePeriodSecond.Value;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsDataKeyReusePeriodSecond != null)
            {
                request.EncryptionConfiguration.KmsDataKeyReusePeriodSeconds = requestEncryptionConfiguration_encryptionConfiguration_KmsDataKeyReusePeriodSecond.Value;
                requestEncryptionConfigurationIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyId != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = cmdletContext.EncryptionConfiguration_KmsKeyId;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId != null)
            {
                request.EncryptionConfiguration.KmsKeyId = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId;
                requestEncryptionConfigurationIsNull = false;
            }
            Amazon.StepFunctions.EncryptionType requestEncryptionConfiguration_encryptionConfiguration_Type = null;
            if (cmdletContext.EncryptionConfiguration_Type != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_Type = cmdletContext.EncryptionConfiguration_Type;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_Type != null)
            {
                request.EncryptionConfiguration.Type = requestEncryptionConfiguration_encryptionConfiguration_Type;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.StepFunctions.Model.CreateActivityResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.CreateActivityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Step Functions", "CreateActivity");
            try
            {
                return client.CreateActivityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? EncryptionConfiguration_KmsDataKeyReusePeriodSecond { get; set; }
            public System.String EncryptionConfiguration_KmsKeyId { get; set; }
            public Amazon.StepFunctions.EncryptionType EncryptionConfiguration_Type { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.StepFunctions.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.StepFunctions.Model.CreateActivityResponse, NewSFNActivityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
