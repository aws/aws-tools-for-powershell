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
using Amazon.RDS;
using Amazon.RDS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Switches over a blue/green deployment.
    /// 
    ///  
    /// <para>
    /// Before you switch over, production traffic is routed to the databases in the blue
    /// environment. After you switch over, production traffic is routed to the databases
    /// in the green environment.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/blue-green-deployments.html">Using
    /// Amazon RDS Blue/Green Deployments for database updates</a> in the <i>Amazon RDS User
    /// Guide</i> and <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/blue-green-deployments.html">Using
    /// Amazon RDS Blue/Green Deployments for database updates</a> in the <i>Amazon Aurora
    /// User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Switch", "RDSBlueGreenDeployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.BlueGreenDeployment")]
    [AWSCmdlet("Calls the Amazon Relational Database Service SwitchoverBlueGreenDeployment API operation.", Operation = new[] {"SwitchoverBlueGreenDeployment"}, SelectReturnType = typeof(Amazon.RDS.Model.SwitchoverBlueGreenDeploymentResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.BlueGreenDeployment or Amazon.RDS.Model.SwitchoverBlueGreenDeploymentResponse",
        "This cmdlet returns an Amazon.RDS.Model.BlueGreenDeployment object.",
        "The service call response (type Amazon.RDS.Model.SwitchoverBlueGreenDeploymentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SwitchRDSBlueGreenDeploymentCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BlueGreenDeploymentIdentifier
        /// <summary>
        /// <para>
        /// <para>The resource ID of the blue/green deployment.</para><para>Constraints:</para><ul><li><para>Must match an existing blue/green deployment resource ID.</para></li></ul>
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
        public System.String BlueGreenDeploymentIdentifier { get; set; }
        #endregion
        
        #region Parameter SwitchoverTimeout
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, for the switchover to complete.</para><para>Default: 300</para><para>If the switchover takes longer than the specified duration, then any changes are rolled
        /// back, and no changes are made to the environments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SwitchoverTimeout { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BlueGreenDeployment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.SwitchoverBlueGreenDeploymentResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.SwitchoverBlueGreenDeploymentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BlueGreenDeployment";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BlueGreenDeploymentIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Switch-RDSBlueGreenDeployment (SwitchoverBlueGreenDeployment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.SwitchoverBlueGreenDeploymentResponse, SwitchRDSBlueGreenDeploymentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BlueGreenDeploymentIdentifier = this.BlueGreenDeploymentIdentifier;
            #if MODULAR
            if (this.BlueGreenDeploymentIdentifier == null && ParameterWasBound(nameof(this.BlueGreenDeploymentIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter BlueGreenDeploymentIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SwitchoverTimeout = this.SwitchoverTimeout;
            
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
            var request = new Amazon.RDS.Model.SwitchoverBlueGreenDeploymentRequest();
            
            if (cmdletContext.BlueGreenDeploymentIdentifier != null)
            {
                request.BlueGreenDeploymentIdentifier = cmdletContext.BlueGreenDeploymentIdentifier;
            }
            if (cmdletContext.SwitchoverTimeout != null)
            {
                request.SwitchoverTimeout = cmdletContext.SwitchoverTimeout.Value;
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
        
        private Amazon.RDS.Model.SwitchoverBlueGreenDeploymentResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.SwitchoverBlueGreenDeploymentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "SwitchoverBlueGreenDeployment");
            try
            {
                return client.SwitchoverBlueGreenDeploymentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BlueGreenDeploymentIdentifier { get; set; }
            public System.Int32? SwitchoverTimeout { get; set; }
            public System.Func<Amazon.RDS.Model.SwitchoverBlueGreenDeploymentResponse, SwitchRDSBlueGreenDeploymentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BlueGreenDeployment;
        }
        
    }
}
