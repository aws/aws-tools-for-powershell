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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Creates a custom Availability Zone (AZ).
    /// 
    ///  
    /// <para>
    /// A custom AZ is an on-premises AZ that is integrated with a VMware vSphere cluster.
    /// </para><para>
    /// For more information about RDS on VMware, see the <a href="https://docs.aws.amazon.com/AmazonRDS/latest/RDSonVMwareUserGuide/rds-on-vmware.html"><i>RDS on VMware User Guide.</i></a></para>
    /// </summary>
    [Cmdlet("New", "RDSCustomAvailabilityZone", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.CustomAvailabilityZone")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateCustomAvailabilityZone API operation.", Operation = new[] {"CreateCustomAvailabilityZone"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateCustomAvailabilityZoneResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.CustomAvailabilityZone or Amazon.RDS.Model.CreateCustomAvailabilityZoneResponse",
        "This cmdlet returns an Amazon.RDS.Model.CustomAvailabilityZone object.",
        "The service call response (type Amazon.RDS.Model.CreateCustomAvailabilityZoneResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRDSCustomAvailabilityZoneCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter CustomAvailabilityZoneName
        /// <summary>
        /// <para>
        /// <para>The name of the custom Availability Zone (AZ).</para>
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
        public System.String CustomAvailabilityZoneName { get; set; }
        #endregion
        
        #region Parameter ExistingVpnId
        /// <summary>
        /// <para>
        /// <para>The ID of an existing virtual private network (VPN) between the Amazon RDS website
        /// and the VMware vSphere cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExistingVpnId { get; set; }
        #endregion
        
        #region Parameter NewVpnTunnelName
        /// <summary>
        /// <para>
        /// <para>The name of a new VPN tunnel between the Amazon RDS website and the VMware vSphere
        /// cluster.</para><para>Specify this parameter only if <code>ExistingVpnId</code> isn't specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewVpnTunnelName { get; set; }
        #endregion
        
        #region Parameter VpnTunnelOriginatorIP
        /// <summary>
        /// <para>
        /// <para>The IP address of network traffic from your on-premises data center. A custom AZ receives
        /// the network traffic.</para><para>Specify this parameter only if <code>ExistingVpnId</code> isn't specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpnTunnelOriginatorIP { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CustomAvailabilityZone'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CreateCustomAvailabilityZoneResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CreateCustomAvailabilityZoneResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CustomAvailabilityZone";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CustomAvailabilityZoneName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CustomAvailabilityZoneName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CustomAvailabilityZoneName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CustomAvailabilityZoneName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSCustomAvailabilityZone (CreateCustomAvailabilityZone)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CreateCustomAvailabilityZoneResponse, NewRDSCustomAvailabilityZoneCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CustomAvailabilityZoneName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CustomAvailabilityZoneName = this.CustomAvailabilityZoneName;
            #if MODULAR
            if (this.CustomAvailabilityZoneName == null && ParameterWasBound(nameof(this.CustomAvailabilityZoneName)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomAvailabilityZoneName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExistingVpnId = this.ExistingVpnId;
            context.NewVpnTunnelName = this.NewVpnTunnelName;
            context.VpnTunnelOriginatorIP = this.VpnTunnelOriginatorIP;
            
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
            var request = new Amazon.RDS.Model.CreateCustomAvailabilityZoneRequest();
            
            if (cmdletContext.CustomAvailabilityZoneName != null)
            {
                request.CustomAvailabilityZoneName = cmdletContext.CustomAvailabilityZoneName;
            }
            if (cmdletContext.ExistingVpnId != null)
            {
                request.ExistingVpnId = cmdletContext.ExistingVpnId;
            }
            if (cmdletContext.NewVpnTunnelName != null)
            {
                request.NewVpnTunnelName = cmdletContext.NewVpnTunnelName;
            }
            if (cmdletContext.VpnTunnelOriginatorIP != null)
            {
                request.VpnTunnelOriginatorIP = cmdletContext.VpnTunnelOriginatorIP;
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
        
        private Amazon.RDS.Model.CreateCustomAvailabilityZoneResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateCustomAvailabilityZoneRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateCustomAvailabilityZone");
            try
            {
                #if DESKTOP
                return client.CreateCustomAvailabilityZone(request);
                #elif CORECLR
                return client.CreateCustomAvailabilityZoneAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomAvailabilityZoneName { get; set; }
            public System.String ExistingVpnId { get; set; }
            public System.String NewVpnTunnelName { get; set; }
            public System.String VpnTunnelOriginatorIP { get; set; }
            public System.Func<Amazon.RDS.Model.CreateCustomAvailabilityZoneResponse, NewRDSCustomAvailabilityZoneCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CustomAvailabilityZone;
        }
        
    }
}
