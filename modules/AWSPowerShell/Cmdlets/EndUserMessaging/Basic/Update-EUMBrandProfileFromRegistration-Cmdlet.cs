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
using Amazon.EndUserMessaging;
using Amazon.EndUserMessaging.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EUM
{
    /// <summary>
    /// Imports or refreshes the attributes of an existing brand profile from an existing
    /// registration. This operation runs asynchronously. Use the GetJob operation to track
    /// its progress.
    /// </summary>
    [Cmdlet("Update", "EUMBrandProfileFromRegistration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EndUserMessaging.Model.JobResult")]
    [AWSCmdlet("Calls the AWS End User Messaging UpdateBrandProfileFromRegistration API operation.", Operation = new[] {"UpdateBrandProfileFromRegistration"}, SelectReturnType = typeof(Amazon.EndUserMessaging.Model.UpdateBrandProfileFromRegistrationResponse))]
    [AWSCmdletOutput("Amazon.EndUserMessaging.Model.JobResult or Amazon.EndUserMessaging.Model.UpdateBrandProfileFromRegistrationResponse",
        "This cmdlet returns a collection of Amazon.EndUserMessaging.Model.JobResult objects.",
        "The service call response (type Amazon.EndUserMessaging.Model.UpdateBrandProfileFromRegistrationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEUMBrandProfileFromRegistrationCmdlet : AmazonEndUserMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BrandProfileId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the brand profile. You can specify either the bare ID or
        /// the full Amazon Resource Name (ARN).</para>
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
        public System.String BrandProfileId { get; set; }
        #endregion
        
        #region Parameter OnAttributeConflict
        /// <summary>
        /// <para>
        /// <para>Specifies how the service resolves an attribute that already exists. REPLACE overwrites
        /// the existing value with the incoming value. PRESERVE keeps the existing value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EndUserMessaging.OnAttributeConflict")]
        public Amazon.EndUserMessaging.OnAttributeConflict OnAttributeConflict { get; set; }
        #endregion
        
        #region Parameter RegistrationId
        /// <summary>
        /// <para>
        /// <para>The identifier or Amazon Resource Name (ARN) of the registration to import attributes
        /// from.</para>
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
        public System.String RegistrationId { get; set; }
        #endregion
        
        #region Parameter SmartMatch
        /// <summary>
        /// <para>
        /// <para>Specifies whether to use semantic field mapping between brand profile attributes and
        /// registration fields. The default is true. When false, the service maps fields using
        /// a fixed set of standard field types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SmartMatch { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you do not specify a client token, the AWS SDK automatically generates
        /// one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Results'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EndUserMessaging.Model.UpdateBrandProfileFromRegistrationResponse).
        /// Specifying the name of a property of type Amazon.EndUserMessaging.Model.UpdateBrandProfileFromRegistrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Results";
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
                nameof(this.BrandProfileId),
                nameof(this.RegistrationId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EUMBrandProfileFromRegistration (UpdateBrandProfileFromRegistration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EndUserMessaging.Model.UpdateBrandProfileFromRegistrationResponse, UpdateEUMBrandProfileFromRegistrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BrandProfileId = this.BrandProfileId;
            #if MODULAR
            if (this.BrandProfileId == null && ParameterWasBound(nameof(this.BrandProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter BrandProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.OnAttributeConflict = this.OnAttributeConflict;
            context.RegistrationId = this.RegistrationId;
            #if MODULAR
            if (this.RegistrationId == null && ParameterWasBound(nameof(this.RegistrationId)))
            {
                WriteWarning("You are passing $null as a value for parameter RegistrationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SmartMatch = this.SmartMatch;
            
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
            var request = new Amazon.EndUserMessaging.Model.UpdateBrandProfileFromRegistrationRequest();
            
            if (cmdletContext.BrandProfileId != null)
            {
                request.BrandProfileId = cmdletContext.BrandProfileId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.OnAttributeConflict != null)
            {
                request.OnAttributeConflict = cmdletContext.OnAttributeConflict;
            }
            if (cmdletContext.RegistrationId != null)
            {
                request.RegistrationId = cmdletContext.RegistrationId;
            }
            if (cmdletContext.SmartMatch != null)
            {
                request.SmartMatch = cmdletContext.SmartMatch.Value;
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
        
        private Amazon.EndUserMessaging.Model.UpdateBrandProfileFromRegistrationResponse CallAWSServiceOperation(IAmazonEndUserMessaging client, Amazon.EndUserMessaging.Model.UpdateBrandProfileFromRegistrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging", "UpdateBrandProfileFromRegistration");
            try
            {
                return client.UpdateBrandProfileFromRegistrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BrandProfileId { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.EndUserMessaging.OnAttributeConflict OnAttributeConflict { get; set; }
            public System.String RegistrationId { get; set; }
            public System.Boolean? SmartMatch { get; set; }
            public System.Func<Amazon.EndUserMessaging.Model.UpdateBrandProfileFromRegistrationResponse, UpdateEUMBrandProfileFromRegistrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Results;
        }
        
    }
}
