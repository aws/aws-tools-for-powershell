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
using Amazon.Continuum;
using Amazon.Continuum.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONT
{
    /// <summary>
    /// Associates one Collector with this Environment and configures the customer role Continuum
    /// uses to authorize access to associated Collector data. The caller must have permission
    /// on the Environment and permission to pass the role. Continuum assumes the supplied
    /// role and calls GetCollectorDataAccessAuthorization on the requested Collector; only
    /// a successful authorization response permits the association. The caller does not need
    /// Collector data-access permission. The Environment retains its other Collector associations.
    /// Calling again with an existing association is safe and does not create a duplicate.
    /// </summary>
    [Cmdlet("Register", "CONTCollector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Continuum.Model.AssociateCollectorResponse")]
    [AWSCmdlet("Calls the AWS Continuum AssociateCollector API operation.", Operation = new[] {"AssociateCollector"}, SelectReturnType = typeof(Amazon.Continuum.Model.AssociateCollectorResponse))]
    [AWSCmdletOutput("Amazon.Continuum.Model.AssociateCollectorResponse",
        "This cmdlet returns an Amazon.Continuum.Model.AssociateCollectorResponse object containing multiple properties."
    )]
    public partial class RegisterCONTCollectorCmdlet : AmazonContinuumClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CollectorArn
        /// <summary>
        /// <para>
        /// The ARN of the Collector to associate with
        /// this Environment.
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
        public System.String CollectorArn { get; set; }
        #endregion
        
        #region Parameter CollectorDataAccessRoleArn
        /// <summary>
        /// <para>
        /// IAM role in the Environment
        /// account that Continuum assumes before authorizing access to associated Collector inventory.
        /// Every association, including a same-account association, requires this role. The supplied
        /// ARN replaces the Environment's previously stored role. The customer is responsible
        /// for granting the role access to every Collector that should contribute data.
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
        public System.String CollectorDataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// The unique identifier of the Environment
        /// making the association.
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
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// Caller-provided token that makes retried association
        /// requests idempotent. The first successful request binds the token to the complete
        /// Collector ARN, supplied role, and result for at least 24 hours. During that retry
        /// window, reusing it with a different request fails with ConflictException. A matching
        /// replay still requires the supplied role to have current Collector access. Once authorized,
        /// a matching replay returns the stored result without changing association state. Revocation
        /// can deny a replay; it does not remove the stored association or its original result.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Continuum.Model.AssociateCollectorResponse).
        /// Specifying the name of a property of type Amazon.Continuum.Model.AssociateCollectorResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CollectorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-CONTCollector (AssociateCollector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Continuum.Model.AssociateCollectorResponse, RegisterCONTCollectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.CollectorArn = this.CollectorArn;
            #if MODULAR
            if (this.CollectorArn == null && ParameterWasBound(nameof(this.CollectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CollectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CollectorDataAccessRoleArn = this.CollectorDataAccessRoleArn;
            #if MODULAR
            if (this.CollectorDataAccessRoleArn == null && ParameterWasBound(nameof(this.CollectorDataAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CollectorDataAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Continuum.Model.AssociateCollectorRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CollectorArn != null)
            {
                request.CollectorArn = cmdletContext.CollectorArn;
            }
            if (cmdletContext.CollectorDataAccessRoleArn != null)
            {
                request.CollectorDataAccessRoleArn = cmdletContext.CollectorDataAccessRoleArn;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
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
        
        private Amazon.Continuum.Model.AssociateCollectorResponse CallAWSServiceOperation(IAmazonContinuum client, Amazon.Continuum.Model.AssociateCollectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Continuum", "AssociateCollector");
            try
            {
                return client.AssociateCollectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CollectorArn { get; set; }
            public System.String CollectorDataAccessRoleArn { get; set; }
            public System.String EnvironmentId { get; set; }
            public System.Func<Amazon.Continuum.Model.AssociateCollectorResponse, RegisterCONTCollectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
