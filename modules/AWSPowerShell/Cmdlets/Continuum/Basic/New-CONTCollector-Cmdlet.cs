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
    /// Creates the Collector for the caller's account. Provisions an AWS Config service-linked
    /// recorder using the caller's federated access session and begins recording infrastructure
    /// changes.
    /// </summary>
    [Cmdlet("New", "CONTCollector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Continuum.Model.CreateCollectorResponse")]
    [AWSCmdlet("Calls the AWS Continuum CreateCollector API operation.", Operation = new[] {"CreateCollector"}, SelectReturnType = typeof(Amazon.Continuum.Model.CreateCollectorResponse))]
    [AWSCmdletOutput("Amazon.Continuum.Model.CreateCollectorResponse",
        "This cmdlet returns an Amazon.Continuum.Model.CreateCollectorResponse object containing multiple properties."
    )]
    public partial class NewCONTCollectorCmdlet : AmazonContinuumClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter KubernetesClusterRole_ExternalId
        /// <summary>
        /// <para>
        /// Optional external ID Continuum supplies when
        /// assuming roleArn. This must match the role trust policy when configured and does not
        /// replace the caller's iam:PassRole permission.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KubernetesClusterRole_ExternalId { get; set; }
        #endregion
        
        #region Parameter KubernetesClusterRole_RoleArn
        /// <summary>
        /// <para>
        /// IAM role the authenticated caller passes to Continuum.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KubernetesClusterRole_RoleArn { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// Source to collect. Defaults to AWS_COLLECTOR when
        /// omitted.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.Continuum.CollectorType")]
        public Amazon.Continuum.CollectorType Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// Caller-provided token that makes retried create
        /// requests return the original Collector rather than creating a duplicate.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Continuum.Model.CreateCollectorResponse).
        /// Specifying the name of a property of type Amazon.Continuum.Model.CreateCollectorResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Type), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONTCollector (CreateCollector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Continuum.Model.CreateCollectorResponse, NewCONTCollectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.KubernetesClusterRole_ExternalId = this.KubernetesClusterRole_ExternalId;
            context.KubernetesClusterRole_RoleArn = this.KubernetesClusterRole_RoleArn;
            context.Type = this.Type;
            
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
            var request = new Amazon.Continuum.Model.CreateCollectorRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate KubernetesClusterRole
            var requestKubernetesClusterRoleIsNull = true;
            request.KubernetesClusterRole = new Amazon.Continuum.Model.KubernetesClusterRoleConfiguration();
            System.String requestKubernetesClusterRole_kubernetesClusterRole_ExternalId = null;
            if (cmdletContext.KubernetesClusterRole_ExternalId != null)
            {
                requestKubernetesClusterRole_kubernetesClusterRole_ExternalId = cmdletContext.KubernetesClusterRole_ExternalId;
            }
            if (requestKubernetesClusterRole_kubernetesClusterRole_ExternalId != null)
            {
                request.KubernetesClusterRole.ExternalId = requestKubernetesClusterRole_kubernetesClusterRole_ExternalId;
                requestKubernetesClusterRoleIsNull = false;
            }
            System.String requestKubernetesClusterRole_kubernetesClusterRole_RoleArn = null;
            if (cmdletContext.KubernetesClusterRole_RoleArn != null)
            {
                requestKubernetesClusterRole_kubernetesClusterRole_RoleArn = cmdletContext.KubernetesClusterRole_RoleArn;
            }
            if (requestKubernetesClusterRole_kubernetesClusterRole_RoleArn != null)
            {
                request.KubernetesClusterRole.RoleArn = requestKubernetesClusterRole_kubernetesClusterRole_RoleArn;
                requestKubernetesClusterRoleIsNull = false;
            }
             // determine if request.KubernetesClusterRole should be set to null
            if (requestKubernetesClusterRoleIsNull)
            {
                request.KubernetesClusterRole = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.Continuum.Model.CreateCollectorResponse CallAWSServiceOperation(IAmazonContinuum client, Amazon.Continuum.Model.CreateCollectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Continuum", "CreateCollector");
            try
            {
                return client.CreateCollectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String KubernetesClusterRole_ExternalId { get; set; }
            public System.String KubernetesClusterRole_RoleArn { get; set; }
            public Amazon.Continuum.CollectorType Type { get; set; }
            public System.Func<Amazon.Continuum.Model.CreateCollectorResponse, NewCONTCollectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
