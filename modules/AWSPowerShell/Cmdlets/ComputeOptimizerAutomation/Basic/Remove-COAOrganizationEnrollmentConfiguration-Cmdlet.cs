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
using Amazon.ComputeOptimizerAutomation;
using Amazon.ComputeOptimizerAutomation.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.COA
{
    /// <summary>
    /// Deletes the specified configuration types from an organization enrollment configuration.
    /// After deletion, Automation stays enabled for affected accounts and earlier account
    /// associations aren't restored. Affected accounts inherit the organization rule mode
    /// from the closest parent that has an organization enrollment configuration, or get
    /// None allowed if no parent has one. 
    /// 
    ///  <note><para>
    /// Only the management account or a delegated administrator can perform this action.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "COAOrganizationEnrollmentConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Compute Optimizer Automation DeleteOrganizationEnrollmentConfiguration API operation.", Operation = new[] {"DeleteOrganizationEnrollmentConfiguration"}, SelectReturnType = typeof(Amazon.ComputeOptimizerAutomation.Model.DeleteOrganizationEnrollmentConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.ComputeOptimizerAutomation.Model.DeleteOrganizationEnrollmentConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ComputeOptimizerAutomation.Model.DeleteOrganizationEnrollmentConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveCOAOrganizationEnrollmentConfigurationCmdlet : AmazonComputeOptimizerAutomationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Target_AccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the member account to target. You can't specify the management account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_AccountId { get; set; }
        #endregion
        
        #region Parameter ConfigurationType
        /// <summary>
        /// <para>
        /// <para> The organization enrollment configuration types to delete from the target. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
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
        [Alias("ConfigurationTypes")]
        public System.String[] ConfigurationType { get; set; }
        #endregion
        
        #region Parameter Target_OrganizationalUnitId
        /// <summary>
        /// <para>
        /// <para>The ID of the organizational unit (OU) or organization root to target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> A unique identifier to ensure idempotency of the request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComputeOptimizerAutomation.Model.DeleteOrganizationEnrollmentConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationType), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-COAOrganizationEnrollmentConfiguration (DeleteOrganizationEnrollmentConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ComputeOptimizerAutomation.Model.DeleteOrganizationEnrollmentConfigurationResponse, RemoveCOAOrganizationEnrollmentConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.ConfigurationType != null)
            {
                context.ConfigurationType = new List<System.String>(this.ConfigurationType);
            }
            #if MODULAR
            if (this.ConfigurationType == null && ParameterWasBound(nameof(this.ConfigurationType)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Target_AccountId = this.Target_AccountId;
            context.Target_OrganizationalUnitId = this.Target_OrganizationalUnitId;
            
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
            var request = new Amazon.ComputeOptimizerAutomation.Model.DeleteOrganizationEnrollmentConfigurationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConfigurationType != null)
            {
                request.ConfigurationTypes = cmdletContext.ConfigurationType;
            }
            
             // populate Target
            var requestTargetIsNull = true;
            request.Target = new Amazon.ComputeOptimizerAutomation.Model.OrganizationTarget();
            System.String requestTarget_target_AccountId = null;
            if (cmdletContext.Target_AccountId != null)
            {
                requestTarget_target_AccountId = cmdletContext.Target_AccountId;
            }
            if (requestTarget_target_AccountId != null)
            {
                request.Target.AccountId = requestTarget_target_AccountId;
                requestTargetIsNull = false;
            }
            System.String requestTarget_target_OrganizationalUnitId = null;
            if (cmdletContext.Target_OrganizationalUnitId != null)
            {
                requestTarget_target_OrganizationalUnitId = cmdletContext.Target_OrganizationalUnitId;
            }
            if (requestTarget_target_OrganizationalUnitId != null)
            {
                request.Target.OrganizationalUnitId = requestTarget_target_OrganizationalUnitId;
                requestTargetIsNull = false;
            }
             // determine if request.Target should be set to null
            if (requestTargetIsNull)
            {
                request.Target = null;
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
        
        private Amazon.ComputeOptimizerAutomation.Model.DeleteOrganizationEnrollmentConfigurationResponse CallAWSServiceOperation(IAmazonComputeOptimizerAutomation client, Amazon.ComputeOptimizerAutomation.Model.DeleteOrganizationEnrollmentConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Compute Optimizer Automation", "DeleteOrganizationEnrollmentConfiguration");
            try
            {
                return client.DeleteOrganizationEnrollmentConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<System.String> ConfigurationType { get; set; }
            public System.String Target_AccountId { get; set; }
            public System.String Target_OrganizationalUnitId { get; set; }
            public System.Func<Amazon.ComputeOptimizerAutomation.Model.DeleteOrganizationEnrollmentConfigurationResponse, RemoveCOAOrganizationEnrollmentConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
