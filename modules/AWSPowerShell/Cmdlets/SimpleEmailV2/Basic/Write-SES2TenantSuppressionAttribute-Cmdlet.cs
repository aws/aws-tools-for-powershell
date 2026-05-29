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
    /// Configure the suppression list preferences for a tenant. Use this operation to enable
    /// or disable tenant-level suppression, or to change the suppressed reasons for a tenant.
    /// 
    ///  
    /// <para>
    /// When you set the suppression scope to <c>TENANT</c>, Amazon SES maintains a separate
    /// suppression list for the tenant. When you set the scope to <c>ACCOUNT</c>, the tenant
    /// uses the account-level suppression list.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "SES2TenantSuppressionAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) PutTenantSuppressionAttributes API operation.", Operation = new[] {"PutTenantSuppressionAttributes"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.PutTenantSuppressionAttributesResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.PutTenantSuppressionAttributesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.PutTenantSuppressionAttributesResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteSES2TenantSuppressionAttributeCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SuppressedReason
        /// <summary>
        /// <para>
        /// <para>A list that contains the reasons that email addresses are automatically added to the
        /// suppression list for the tenant. This list can contain any or all of the following:</para><ul><li><para><c>COMPLAINT</c> – Amazon SES adds an email address to the suppression list when
        /// a message sent to that address results in a complaint.</para></li><li><para><c>BOUNCE</c> – Amazon SES adds an email address to the suppression list when a message
        /// sent to that address results in a hard bounce.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SuppressedReasons")]
        public System.String[] SuppressedReason { get; set; }
        #endregion
        
        #region Parameter SuppressionScope
        /// <summary>
        /// <para>
        /// <para>The suppression scope for the tenant. Specify <c>TENANT</c> to use the tenant's own
        /// suppression list, or <c>ACCOUNT</c> to use the account-level suppression list.</para><note><para>If you don't specify a suppression scope, the tenant defaults to <c>ACCOUNT</c> scope
        /// and uses the account-level suppression list.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.SuppressionListScope")]
        public Amazon.SimpleEmailV2.SuppressionListScope SuppressionScope { get; set; }
        #endregion
        
        #region Parameter TenantName
        /// <summary>
        /// <para>
        /// <para>The name of the tenant to configure suppression list preferences for.</para>
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
        public System.String TenantName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.PutTenantSuppressionAttributesResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TenantName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SES2TenantSuppressionAttribute (PutTenantSuppressionAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.PutTenantSuppressionAttributesResponse, WriteSES2TenantSuppressionAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.SuppressedReason != null)
            {
                context.SuppressedReason = new List<System.String>(this.SuppressedReason);
            }
            context.SuppressionScope = this.SuppressionScope;
            context.TenantName = this.TenantName;
            #if MODULAR
            if (this.TenantName == null && ParameterWasBound(nameof(this.TenantName)))
            {
                WriteWarning("You are passing $null as a value for parameter TenantName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleEmailV2.Model.PutTenantSuppressionAttributesRequest();
            
            if (cmdletContext.SuppressedReason != null)
            {
                request.SuppressedReasons = cmdletContext.SuppressedReason;
            }
            if (cmdletContext.SuppressionScope != null)
            {
                request.SuppressionScope = cmdletContext.SuppressionScope;
            }
            if (cmdletContext.TenantName != null)
            {
                request.TenantName = cmdletContext.TenantName;
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
        
        private Amazon.SimpleEmailV2.Model.PutTenantSuppressionAttributesResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.PutTenantSuppressionAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "PutTenantSuppressionAttributes");
            try
            {
                return client.PutTenantSuppressionAttributesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.SimpleEmailV2.SuppressionListScope SuppressionScope { get; set; }
            public System.String TenantName { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.PutTenantSuppressionAttributesResponse, WriteSES2TenantSuppressionAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
