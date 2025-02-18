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
using Amazon.AppRunner;
using Amazon.AppRunner.Model;

namespace Amazon.PowerShell.Cmdlets.AAR
{
    /// <summary>
    /// Update an existing App Runner VPC Ingress Connection resource. The VPC Ingress Connection
    /// must be in one of the following states to be updated:
    /// 
    ///  <ul><li><para>
    ///  AVAILABLE 
    /// </para></li><li><para>
    ///  FAILED_CREATION 
    /// </para></li><li><para>
    ///  FAILED_UPDATE 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "AARVpcIngressConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppRunner.Model.VpcIngressConnection")]
    [AWSCmdlet("Calls the AWS App Runner UpdateVpcIngressConnection API operation.", Operation = new[] {"UpdateVpcIngressConnection"}, SelectReturnType = typeof(Amazon.AppRunner.Model.UpdateVpcIngressConnectionResponse))]
    [AWSCmdletOutput("Amazon.AppRunner.Model.VpcIngressConnection or Amazon.AppRunner.Model.UpdateVpcIngressConnectionResponse",
        "This cmdlet returns an Amazon.AppRunner.Model.VpcIngressConnection object.",
        "The service call response (type Amazon.AppRunner.Model.UpdateVpcIngressConnectionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateAARVpcIngressConnectionCmdlet : AmazonAppRunnerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IngressVpcConfiguration_VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC endpoint that your App Runner service connects to. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IngressVpcConfiguration_VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter IngressVpcConfiguration_VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC that is used for the VPC endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IngressVpcConfiguration_VpcId { get; set; }
        #endregion
        
        #region Parameter VpcIngressConnectionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (Arn) for the App Runner VPC Ingress Connection resource
        /// that you want to update.</para>
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
        public System.String VpcIngressConnectionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcIngressConnection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppRunner.Model.UpdateVpcIngressConnectionResponse).
        /// Specifying the name of a property of type Amazon.AppRunner.Model.UpdateVpcIngressConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcIngressConnection";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpcIngressConnectionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AARVpcIngressConnection (UpdateVpcIngressConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppRunner.Model.UpdateVpcIngressConnectionResponse, UpdateAARVpcIngressConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IngressVpcConfiguration_VpcEndpointId = this.IngressVpcConfiguration_VpcEndpointId;
            context.IngressVpcConfiguration_VpcId = this.IngressVpcConfiguration_VpcId;
            context.VpcIngressConnectionArn = this.VpcIngressConnectionArn;
            #if MODULAR
            if (this.VpcIngressConnectionArn == null && ParameterWasBound(nameof(this.VpcIngressConnectionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcIngressConnectionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppRunner.Model.UpdateVpcIngressConnectionRequest();
            
            
             // populate IngressVpcConfiguration
            var requestIngressVpcConfigurationIsNull = true;
            request.IngressVpcConfiguration = new Amazon.AppRunner.Model.IngressVpcConfiguration();
            System.String requestIngressVpcConfiguration_ingressVpcConfiguration_VpcEndpointId = null;
            if (cmdletContext.IngressVpcConfiguration_VpcEndpointId != null)
            {
                requestIngressVpcConfiguration_ingressVpcConfiguration_VpcEndpointId = cmdletContext.IngressVpcConfiguration_VpcEndpointId;
            }
            if (requestIngressVpcConfiguration_ingressVpcConfiguration_VpcEndpointId != null)
            {
                request.IngressVpcConfiguration.VpcEndpointId = requestIngressVpcConfiguration_ingressVpcConfiguration_VpcEndpointId;
                requestIngressVpcConfigurationIsNull = false;
            }
            System.String requestIngressVpcConfiguration_ingressVpcConfiguration_VpcId = null;
            if (cmdletContext.IngressVpcConfiguration_VpcId != null)
            {
                requestIngressVpcConfiguration_ingressVpcConfiguration_VpcId = cmdletContext.IngressVpcConfiguration_VpcId;
            }
            if (requestIngressVpcConfiguration_ingressVpcConfiguration_VpcId != null)
            {
                request.IngressVpcConfiguration.VpcId = requestIngressVpcConfiguration_ingressVpcConfiguration_VpcId;
                requestIngressVpcConfigurationIsNull = false;
            }
             // determine if request.IngressVpcConfiguration should be set to null
            if (requestIngressVpcConfigurationIsNull)
            {
                request.IngressVpcConfiguration = null;
            }
            if (cmdletContext.VpcIngressConnectionArn != null)
            {
                request.VpcIngressConnectionArn = cmdletContext.VpcIngressConnectionArn;
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
        
        private Amazon.AppRunner.Model.UpdateVpcIngressConnectionResponse CallAWSServiceOperation(IAmazonAppRunner client, Amazon.AppRunner.Model.UpdateVpcIngressConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Runner", "UpdateVpcIngressConnection");
            try
            {
                return client.UpdateVpcIngressConnectionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IngressVpcConfiguration_VpcEndpointId { get; set; }
            public System.String IngressVpcConfiguration_VpcId { get; set; }
            public System.String VpcIngressConnectionArn { get; set; }
            public System.Func<Amazon.AppRunner.Model.UpdateVpcIngressConnectionResponse, UpdateAARVpcIngressConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcIngressConnection;
        }
        
    }
}
