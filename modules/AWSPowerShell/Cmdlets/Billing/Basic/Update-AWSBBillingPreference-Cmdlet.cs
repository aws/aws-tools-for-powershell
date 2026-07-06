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
using Amazon.Billing;
using Amazon.Billing.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AWSB
{
    /// <summary>
    /// Updates billing preferences for the specified feature. Each feature targets a distinct
    /// billing capability and has its own set of supported keys. The action sets the value
    /// for each provided key; keys not present in the request are unchanged.
    /// 
    ///  
    /// <para>
    /// Sharing keys (<c>RI_SHARING</c>, <c>CREDIT_SHARING</c>, <c>CREDIT_LEVEL_SHARING</c>,
    /// and sharing keys under <c>CREDIT_PREFERENCE_OPTIONS</c>) may only be set by the management
    /// account of a consolidated billing family. The <c>credit/{creditId}/status</c> key
    /// may be set by member accounts for credits they own, or by the management account for
    /// any credit in the family.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "AWSBBillingPreference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Billing UpdateBillingPreferences API operation.", Operation = new[] {"UpdateBillingPreferences"}, SelectReturnType = typeof(Amazon.Billing.Model.UpdateBillingPreferencesResponse))]
    [AWSCmdletOutput("None or Amazon.Billing.Model.UpdateBillingPreferencesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Billing.Model.UpdateBillingPreferencesResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateAWSBBillingPreferenceCmdlet : AmazonBillingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BillingPreferencesPerKey
        /// <summary>
        /// <para>
        /// <para>Key/value pairs to apply. All keys in a single request must be valid for the specified
        /// <c>feature</c> and must not be duplicated. For <c>CREDIT_PREFERENCE_OPTIONS</c>, all
        /// keys must reference the same <c>creditId</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Billing.Model.BillingPreferenceForKey[] BillingPreferencesPerKey { get; set; }
        #endregion
        
        #region Parameter Feature
        /// <summary>
        /// <para>
        /// <para>The feature to update. Valid values: <c>BILLING_ALERTS</c>, <c>RI_SHARING</c>, <c>CREDIT_SHARING</c>,
        /// <c>CREDIT_LEVEL_SHARING</c>, <c>CREDIT_PREFERENCE_OPTIONS</c>. The history features
        /// (<c>RI_SHARING_HISTORY</c> and <c>CREDIT_SHARING_HISTORY</c>) are read-only and cannot
        /// be updated.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Billing.BillingFeature")]
        public Amazon.Billing.BillingFeature Feature { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Billing.Model.UpdateBillingPreferencesResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Feature), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AWSBBillingPreference (UpdateBillingPreferences)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Billing.Model.UpdateBillingPreferencesResponse, UpdateAWSBBillingPreferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.BillingPreferencesPerKey != null)
            {
                context.BillingPreferencesPerKey = new List<Amazon.Billing.Model.BillingPreferenceForKey>(this.BillingPreferencesPerKey);
            }
            #if MODULAR
            if (this.BillingPreferencesPerKey == null && ParameterWasBound(nameof(this.BillingPreferencesPerKey)))
            {
                WriteWarning("You are passing $null as a value for parameter BillingPreferencesPerKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Feature = this.Feature;
            #if MODULAR
            if (this.Feature == null && ParameterWasBound(nameof(this.Feature)))
            {
                WriteWarning("You are passing $null as a value for parameter Feature which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Billing.Model.UpdateBillingPreferencesRequest();
            
            if (cmdletContext.BillingPreferencesPerKey != null)
            {
                request.BillingPreferencesPerKey = cmdletContext.BillingPreferencesPerKey;
            }
            if (cmdletContext.Feature != null)
            {
                request.Feature = cmdletContext.Feature;
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
        
        private Amazon.Billing.Model.UpdateBillingPreferencesResponse CallAWSServiceOperation(IAmazonBilling client, Amazon.Billing.Model.UpdateBillingPreferencesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Billing", "UpdateBillingPreferences");
            try
            {
                return client.UpdateBillingPreferencesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Billing.Model.BillingPreferenceForKey> BillingPreferencesPerKey { get; set; }
            public Amazon.Billing.BillingFeature Feature { get; set; }
            public System.Func<Amazon.Billing.Model.UpdateBillingPreferencesResponse, UpdateAWSBBillingPreferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
