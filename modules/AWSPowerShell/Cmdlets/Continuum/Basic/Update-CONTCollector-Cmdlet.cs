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
    /// Updates the customer-controlled mutable properties of a Collector. Only the name and
    /// Kubernetes cluster IAM role can be changed.
    /// </summary>
    [Cmdlet("Update", "CONTCollector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Continuum.Model.UpdateCollectorResponse")]
    [AWSCmdlet("Calls the AWS Continuum UpdateCollector API operation.", Operation = new[] {"UpdateCollector"}, SelectReturnType = typeof(Amazon.Continuum.Model.UpdateCollectorResponse))]
    [AWSCmdletOutput("Amazon.Continuum.Model.UpdateCollectorResponse",
        "This cmdlet returns an Amazon.Continuum.Model.UpdateCollectorResponse object containing multiple properties."
    )]
    public partial class UpdateCONTCollectorCmdlet : AmazonContinuumClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CollectorId
        /// <summary>
        /// <para>
        /// The unique identifier of the Collector to
        /// update.
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
        public System.String CollectorId { get; set; }
        #endregion
        
        #region Parameter KubernetesClusterRole_Set_ExternalId
        /// <summary>
        /// <para>
        /// Optional external ID Continuum supplies when
        /// assuming roleArn. This must match the role trust policy when configured and does not
        /// replace the caller's iam:PassRole permission.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KubernetesClusterRole_Set_ExternalId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The new customer-visible name.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter KubernetesClusterRole_Remove
        /// <summary>
        /// <para>
        /// Remove the configured role and external ID.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Continuum.Model.RemoveKubernetesClusterRole KubernetesClusterRole_Remove { get; set; }
        #endregion
        
        #region Parameter KubernetesClusterRole_Set_RoleArn
        /// <summary>
        /// <para>
        /// IAM role the authenticated caller passes to Continuum.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KubernetesClusterRole_Set_RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Continuum.Model.UpdateCollectorResponse).
        /// Specifying the name of a property of type Amazon.Continuum.Model.UpdateCollectorResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CollectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONTCollector (UpdateCollector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Continuum.Model.UpdateCollectorResponse, UpdateCONTCollectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CollectorId = this.CollectorId;
            #if MODULAR
            if (this.CollectorId == null && ParameterWasBound(nameof(this.CollectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter CollectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KubernetesClusterRole_Remove = this.KubernetesClusterRole_Remove;
            context.KubernetesClusterRole_Set_ExternalId = this.KubernetesClusterRole_Set_ExternalId;
            context.KubernetesClusterRole_Set_RoleArn = this.KubernetesClusterRole_Set_RoleArn;
            context.Name = this.Name;
            
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
            var request = new Amazon.Continuum.Model.UpdateCollectorRequest();
            
            if (cmdletContext.CollectorId != null)
            {
                request.CollectorId = cmdletContext.CollectorId;
            }
            
             // populate KubernetesClusterRole
            var requestKubernetesClusterRoleIsNull = true;
            request.KubernetesClusterRole = new Amazon.Continuum.Model.KubernetesClusterRoleUpdate();
            Amazon.Continuum.Model.RemoveKubernetesClusterRole requestKubernetesClusterRole_kubernetesClusterRole_Remove = null;
            if (cmdletContext.KubernetesClusterRole_Remove != null)
            {
                requestKubernetesClusterRole_kubernetesClusterRole_Remove = cmdletContext.KubernetesClusterRole_Remove;
            }
            if (requestKubernetesClusterRole_kubernetesClusterRole_Remove != null)
            {
                request.KubernetesClusterRole.Remove = requestKubernetesClusterRole_kubernetesClusterRole_Remove;
                requestKubernetesClusterRoleIsNull = false;
            }
            Amazon.Continuum.Model.KubernetesClusterRoleConfiguration requestKubernetesClusterRole_kubernetesClusterRole_Set = null;
            
             // populate Set
            var requestKubernetesClusterRole_kubernetesClusterRole_SetIsNull = true;
            requestKubernetesClusterRole_kubernetesClusterRole_Set = new Amazon.Continuum.Model.KubernetesClusterRoleConfiguration();
            System.String requestKubernetesClusterRole_kubernetesClusterRole_Set_kubernetesClusterRole_Set_ExternalId = null;
            if (cmdletContext.KubernetesClusterRole_Set_ExternalId != null)
            {
                requestKubernetesClusterRole_kubernetesClusterRole_Set_kubernetesClusterRole_Set_ExternalId = cmdletContext.KubernetesClusterRole_Set_ExternalId;
            }
            if (requestKubernetesClusterRole_kubernetesClusterRole_Set_kubernetesClusterRole_Set_ExternalId != null)
            {
                requestKubernetesClusterRole_kubernetesClusterRole_Set.ExternalId = requestKubernetesClusterRole_kubernetesClusterRole_Set_kubernetesClusterRole_Set_ExternalId;
                requestKubernetesClusterRole_kubernetesClusterRole_SetIsNull = false;
            }
            System.String requestKubernetesClusterRole_kubernetesClusterRole_Set_kubernetesClusterRole_Set_RoleArn = null;
            if (cmdletContext.KubernetesClusterRole_Set_RoleArn != null)
            {
                requestKubernetesClusterRole_kubernetesClusterRole_Set_kubernetesClusterRole_Set_RoleArn = cmdletContext.KubernetesClusterRole_Set_RoleArn;
            }
            if (requestKubernetesClusterRole_kubernetesClusterRole_Set_kubernetesClusterRole_Set_RoleArn != null)
            {
                requestKubernetesClusterRole_kubernetesClusterRole_Set.RoleArn = requestKubernetesClusterRole_kubernetesClusterRole_Set_kubernetesClusterRole_Set_RoleArn;
                requestKubernetesClusterRole_kubernetesClusterRole_SetIsNull = false;
            }
             // determine if requestKubernetesClusterRole_kubernetesClusterRole_Set should be set to null
            if (requestKubernetesClusterRole_kubernetesClusterRole_SetIsNull)
            {
                requestKubernetesClusterRole_kubernetesClusterRole_Set = null;
            }
            if (requestKubernetesClusterRole_kubernetesClusterRole_Set != null)
            {
                request.KubernetesClusterRole.Set = requestKubernetesClusterRole_kubernetesClusterRole_Set;
                requestKubernetesClusterRoleIsNull = false;
            }
             // determine if request.KubernetesClusterRole should be set to null
            if (requestKubernetesClusterRoleIsNull)
            {
                request.KubernetesClusterRole = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.Continuum.Model.UpdateCollectorResponse CallAWSServiceOperation(IAmazonContinuum client, Amazon.Continuum.Model.UpdateCollectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Continuum", "UpdateCollector");
            try
            {
                return client.UpdateCollectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CollectorId { get; set; }
            public Amazon.Continuum.Model.RemoveKubernetesClusterRole KubernetesClusterRole_Remove { get; set; }
            public System.String KubernetesClusterRole_Set_ExternalId { get; set; }
            public System.String KubernetesClusterRole_Set_RoleArn { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.Continuum.Model.UpdateCollectorResponse, UpdateCONTCollectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
