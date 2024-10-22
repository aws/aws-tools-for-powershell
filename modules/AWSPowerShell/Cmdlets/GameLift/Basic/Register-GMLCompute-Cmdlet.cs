/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// <b>This operation has been expanded to use with the Amazon GameLift containers feature,
    /// which is currently in public preview.</b><para>
    /// Registers a compute resource in an Amazon GameLift fleet. Register computes with an
    /// Amazon GameLift Anywhere fleet or a container fleet. 
    /// </para><para>
    /// For an Anywhere fleet or a container fleet that's running the Amazon GameLift Agent,
    /// the Agent handles all compute registry tasks for you. For an Anywhere fleet that doesn't
    /// use the Agent, call this operation to register fleet computes.
    /// </para><para>
    /// To register a compute, give the compute a name (must be unique within the fleet) and
    /// specify the compute resource's DNS name or IP address. Provide a fleet ID and a fleet
    /// location to associate with the compute being registered. You can optionally include
    /// the path to a TLS certificate on the compute resource.
    /// </para><para>
    /// If successful, this operation returns compute details, including an Amazon GameLift
    /// SDK endpoint or Agent endpoint. Game server processes running on the compute can use
    /// this endpoint to communicate with the Amazon GameLift service. Each server process
    /// includes the SDK endpoint in its call to the Amazon GameLift server SDK action <c>InitSDK()</c>.
    /// 
    /// </para><para>
    /// To view compute details, call <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_DescribeCompute.html">DescribeCompute</a>
    /// with the compute name. 
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-creating-anywhere.html">Create
    /// an Anywhere fleet</a></para></li><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/integration-testing.html">Test
    /// your integration</a></para></li><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/reference-serversdk.html">Server
    /// SDK reference guides</a> (for version 5.x)
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Register", "GMLCompute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.Compute")]
    [AWSCmdlet("Calls the Amazon GameLift Service RegisterCompute API operation.", Operation = new[] {"RegisterCompute"}, SelectReturnType = typeof(Amazon.GameLift.Model.RegisterComputeResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.Compute or Amazon.GameLift.Model.RegisterComputeResponse",
        "This cmdlet returns an Amazon.GameLift.Model.Compute object.",
        "The service call response (type Amazon.GameLift.Model.RegisterComputeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterGMLComputeCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CertificatePath
        /// <summary>
        /// <para>
        /// <para>The path to a TLS certificate on your compute resource. Amazon GameLift doesn't validate
        /// the path and certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificatePath { get; set; }
        #endregion
        
        #region Parameter ComputeName
        /// <summary>
        /// <para>
        /// <para>A descriptive label for the compute resource.</para>
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
        public System.String ComputeName { get; set; }
        #endregion
        
        #region Parameter DnsName
        /// <summary>
        /// <para>
        /// <para>The DNS name of the compute resource. Amazon GameLift requires either a DNS name or
        /// IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DnsName { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the fleet to register the compute to. You can use either the
        /// fleet ID or ARN value.</para>
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
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter IpAddress
        /// <summary>
        /// <para>
        /// <para>The IP address of the compute resource. Amazon GameLift requires either a DNS name
        /// or IP address. When registering an Anywhere fleet, an IP address is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IpAddress { get; set; }
        #endregion
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <para>The name of a custom location to associate with the compute resource being registered.
        /// This parameter is required when registering a compute for an Anywhere fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Compute'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.RegisterComputeResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.RegisterComputeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Compute";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ComputeName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-GMLCompute (RegisterCompute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.RegisterComputeResponse, RegisterGMLComputeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificatePath = this.CertificatePath;
            context.ComputeName = this.ComputeName;
            #if MODULAR
            if (this.ComputeName == null && ParameterWasBound(nameof(this.ComputeName)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DnsName = this.DnsName;
            context.FleetId = this.FleetId;
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IpAddress = this.IpAddress;
            context.Location = this.Location;
            
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
            var request = new Amazon.GameLift.Model.RegisterComputeRequest();
            
            if (cmdletContext.CertificatePath != null)
            {
                request.CertificatePath = cmdletContext.CertificatePath;
            }
            if (cmdletContext.ComputeName != null)
            {
                request.ComputeName = cmdletContext.ComputeName;
            }
            if (cmdletContext.DnsName != null)
            {
                request.DnsName = cmdletContext.DnsName;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.IpAddress != null)
            {
                request.IpAddress = cmdletContext.IpAddress;
            }
            if (cmdletContext.Location != null)
            {
                request.Location = cmdletContext.Location;
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
        
        private Amazon.GameLift.Model.RegisterComputeResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.RegisterComputeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "RegisterCompute");
            try
            {
                #if DESKTOP
                return client.RegisterCompute(request);
                #elif CORECLR
                return client.RegisterComputeAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.String CertificatePath { get; set; }
            public System.String ComputeName { get; set; }
            public System.String DnsName { get; set; }
            public System.String FleetId { get; set; }
            public System.String IpAddress { get; set; }
            public System.String Location { get; set; }
            public System.Func<Amazon.GameLift.Model.RegisterComputeResponse, RegisterGMLComputeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Compute;
        }
        
    }
}
