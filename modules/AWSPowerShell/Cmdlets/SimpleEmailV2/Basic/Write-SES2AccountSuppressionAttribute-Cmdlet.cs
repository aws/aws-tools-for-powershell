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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Change the settings for the account-level suppression list.
    /// </summary>
    [Cmdlet("Write", "SES2AccountSuppressionAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) PutAccountSuppressionAttributes API operation.", Operation = new[] {"PutAccountSuppressionAttributes"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.PutAccountSuppressionAttributesResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.PutAccountSuppressionAttributesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.PutAccountSuppressionAttributesResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteSES2AccountSuppressionAttributeCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ValidationAttributes_ConditionThreshold_ConditionThresholdEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether Auto Validation is enabled for suppression. Set to <c>ENABLED</c>
        /// to enable the Auto Validation feature, or set to <c>DISABLED</c> to disable it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.FeatureStatus")]
        public Amazon.SimpleEmailV2.FeatureStatus ValidationAttributes_ConditionThreshold_ConditionThresholdEnabled { get; set; }
        #endregion
        
        #region Parameter ValidationAttributes_ConditionThreshold_OverallConfidenceThreshold_ConfidenceVerdictThreshold
        /// <summary>
        /// <para>
        /// <para>The confidence level threshold for suppression decisions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.SuppressionConfidenceVerdictThreshold")]
        public Amazon.SimpleEmailV2.SuppressionConfidenceVerdictThreshold ValidationAttributes_ConditionThreshold_OverallConfidenceThreshold_ConfidenceVerdictThreshold { get; set; }
        #endregion
        
        #region Parameter SuppressedReason
        /// <summary>
        /// <para>
        /// <para>A list that contains the reasons that email addresses will be automatically added
        /// to the suppression list for your account. This list can contain any or all of the
        /// following:</para><ul><li><para><c>COMPLAINT</c> – Amazon SES adds an email address to the suppression list for your
        /// account when a message sent to that address results in a complaint.</para></li><li><para><c>BOUNCE</c> – Amazon SES adds an email address to the suppression list for your
        /// account when a message sent to that address results in a hard bounce.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("SuppressedReasons")]
        public System.String[] SuppressedReason { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.PutAccountSuppressionAttributesResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SuppressedReason), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SES2AccountSuppressionAttribute (PutAccountSuppressionAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.PutAccountSuppressionAttributesResponse, WriteSES2AccountSuppressionAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.SuppressedReason != null)
            {
                context.SuppressedReason = new List<System.String>(this.SuppressedReason);
            }
            context.ValidationAttributes_ConditionThreshold_ConditionThresholdEnabled = this.ValidationAttributes_ConditionThreshold_ConditionThresholdEnabled;
            context.ValidationAttributes_ConditionThreshold_OverallConfidenceThreshold_ConfidenceVerdictThreshold = this.ValidationAttributes_ConditionThreshold_OverallConfidenceThreshold_ConfidenceVerdictThreshold;
            
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
            var request = new Amazon.SimpleEmailV2.Model.PutAccountSuppressionAttributesRequest();
            
            if (cmdletContext.SuppressedReason != null)
            {
                request.SuppressedReasons = cmdletContext.SuppressedReason;
            }
            
             // populate ValidationAttributes
            var requestValidationAttributesIsNull = true;
            request.ValidationAttributes = new Amazon.SimpleEmailV2.Model.SuppressionValidationAttributes();
            Amazon.SimpleEmailV2.Model.SuppressionConditionThreshold requestValidationAttributes_validationAttributes_ConditionThreshold = null;
            
             // populate ConditionThreshold
            var requestValidationAttributes_validationAttributes_ConditionThresholdIsNull = true;
            requestValidationAttributes_validationAttributes_ConditionThreshold = new Amazon.SimpleEmailV2.Model.SuppressionConditionThreshold();
            Amazon.SimpleEmailV2.FeatureStatus requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_ConditionThresholdEnabled = null;
            if (cmdletContext.ValidationAttributes_ConditionThreshold_ConditionThresholdEnabled != null)
            {
                requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_ConditionThresholdEnabled = cmdletContext.ValidationAttributes_ConditionThreshold_ConditionThresholdEnabled;
            }
            if (requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_ConditionThresholdEnabled != null)
            {
                requestValidationAttributes_validationAttributes_ConditionThreshold.ConditionThresholdEnabled = requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_ConditionThresholdEnabled;
                requestValidationAttributes_validationAttributes_ConditionThresholdIsNull = false;
            }
            Amazon.SimpleEmailV2.Model.SuppressionConfidenceThreshold requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThreshold = null;
            
             // populate OverallConfidenceThreshold
            var requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThresholdIsNull = true;
            requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThreshold = new Amazon.SimpleEmailV2.Model.SuppressionConfidenceThreshold();
            Amazon.SimpleEmailV2.SuppressionConfidenceVerdictThreshold requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThreshold_ConfidenceVerdictThreshold = null;
            if (cmdletContext.ValidationAttributes_ConditionThreshold_OverallConfidenceThreshold_ConfidenceVerdictThreshold != null)
            {
                requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThreshold_ConfidenceVerdictThreshold = cmdletContext.ValidationAttributes_ConditionThreshold_OverallConfidenceThreshold_ConfidenceVerdictThreshold;
            }
            if (requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThreshold_ConfidenceVerdictThreshold != null)
            {
                requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThreshold.ConfidenceVerdictThreshold = requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThreshold_ConfidenceVerdictThreshold;
                requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThresholdIsNull = false;
            }
             // determine if requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThreshold should be set to null
            if (requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThresholdIsNull)
            {
                requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThreshold = null;
            }
            if (requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThreshold != null)
            {
                requestValidationAttributes_validationAttributes_ConditionThreshold.OverallConfidenceThreshold = requestValidationAttributes_validationAttributes_ConditionThreshold_validationAttributes_ConditionThreshold_OverallConfidenceThreshold;
                requestValidationAttributes_validationAttributes_ConditionThresholdIsNull = false;
            }
             // determine if requestValidationAttributes_validationAttributes_ConditionThreshold should be set to null
            if (requestValidationAttributes_validationAttributes_ConditionThresholdIsNull)
            {
                requestValidationAttributes_validationAttributes_ConditionThreshold = null;
            }
            if (requestValidationAttributes_validationAttributes_ConditionThreshold != null)
            {
                request.ValidationAttributes.ConditionThreshold = requestValidationAttributes_validationAttributes_ConditionThreshold;
                requestValidationAttributesIsNull = false;
            }
             // determine if request.ValidationAttributes should be set to null
            if (requestValidationAttributesIsNull)
            {
                request.ValidationAttributes = null;
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
        
        private Amazon.SimpleEmailV2.Model.PutAccountSuppressionAttributesResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.PutAccountSuppressionAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "PutAccountSuppressionAttributes");
            try
            {
                return client.PutAccountSuppressionAttributesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> SuppressedReason { get; set; }
            public Amazon.SimpleEmailV2.FeatureStatus ValidationAttributes_ConditionThreshold_ConditionThresholdEnabled { get; set; }
            public Amazon.SimpleEmailV2.SuppressionConfidenceVerdictThreshold ValidationAttributes_ConditionThreshold_OverallConfidenceThreshold_ConfidenceVerdictThreshold { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.PutAccountSuppressionAttributesResponse, WriteSES2AccountSuppressionAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
