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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates Amazon Quick Sight customizations. Currently, the only customization that
    /// you can use is a theme.
    /// 
    ///  
    /// <para>
    /// You can use customizations for your Amazon Web Services account or, if you specify
    /// a namespace, for a Quick Sight namespace instead. Customizations that apply to a namespace
    /// override customizations that apply to an Amazon Web Services account. To find out
    /// which customizations apply, use the <c>DescribeAccountCustomization</c> API operation.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "QSAccountCustomization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.UpdateAccountCustomizationResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateAccountCustomization API operation.", Operation = new[] {"UpdateAccountCustomization"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateAccountCustomizationResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.UpdateAccountCustomizationResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.UpdateAccountCustomizationResponse object containing multiple properties."
    )]
    public partial class UpdateQSAccountCustomizationCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID for the Amazon Web Services account that you want to update Quick Sight customizations
        /// for.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter AccountCustomization_DefaultEmailCustomizationTemplate
        /// <summary>
        /// <para>
        /// <para>The default email customization template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountCustomization_DefaultEmailCustomizationTemplate { get; set; }
        #endregion
        
        #region Parameter AccountCustomization_DefaultTheme
        /// <summary>
        /// <para>
        /// <para>The default theme for this Quick Sight subscription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountCustomization_DefaultTheme { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace that you want to update Quick Sight customizations for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateAccountCustomizationResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateAccountCustomizationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AwsAccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSAccountCustomization (UpdateAccountCustomization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateAccountCustomizationResponse, UpdateQSAccountCustomizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountCustomization_DefaultEmailCustomizationTemplate = this.AccountCustomization_DefaultEmailCustomizationTemplate;
            context.AccountCustomization_DefaultTheme = this.AccountCustomization_DefaultTheme;
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            
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
            var request = new Amazon.QuickSight.Model.UpdateAccountCustomizationRequest();
            
            
             // populate AccountCustomization
            var requestAccountCustomizationIsNull = true;
            request.AccountCustomization = new Amazon.QuickSight.Model.AccountCustomization();
            System.String requestAccountCustomization_accountCustomization_DefaultEmailCustomizationTemplate = null;
            if (cmdletContext.AccountCustomization_DefaultEmailCustomizationTemplate != null)
            {
                requestAccountCustomization_accountCustomization_DefaultEmailCustomizationTemplate = cmdletContext.AccountCustomization_DefaultEmailCustomizationTemplate;
            }
            if (requestAccountCustomization_accountCustomization_DefaultEmailCustomizationTemplate != null)
            {
                request.AccountCustomization.DefaultEmailCustomizationTemplate = requestAccountCustomization_accountCustomization_DefaultEmailCustomizationTemplate;
                requestAccountCustomizationIsNull = false;
            }
            System.String requestAccountCustomization_accountCustomization_DefaultTheme = null;
            if (cmdletContext.AccountCustomization_DefaultTheme != null)
            {
                requestAccountCustomization_accountCustomization_DefaultTheme = cmdletContext.AccountCustomization_DefaultTheme;
            }
            if (requestAccountCustomization_accountCustomization_DefaultTheme != null)
            {
                request.AccountCustomization.DefaultTheme = requestAccountCustomization_accountCustomization_DefaultTheme;
                requestAccountCustomizationIsNull = false;
            }
             // determine if request.AccountCustomization should be set to null
            if (requestAccountCustomizationIsNull)
            {
                request.AccountCustomization = null;
            }
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
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
        
        private Amazon.QuickSight.Model.UpdateAccountCustomizationResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateAccountCustomizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateAccountCustomization");
            try
            {
                return client.UpdateAccountCustomizationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountCustomization_DefaultEmailCustomizationTemplate { get; set; }
            public System.String AccountCustomization_DefaultTheme { get; set; }
            public System.String AwsAccountId { get; set; }
            public System.String Namespace { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateAccountCustomizationResponse, UpdateQSAccountCustomizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
