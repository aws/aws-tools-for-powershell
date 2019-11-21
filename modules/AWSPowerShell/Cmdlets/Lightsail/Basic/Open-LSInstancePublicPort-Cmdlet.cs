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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Adds public ports to an Amazon Lightsail instance.
    /// 
    ///  
    /// <para>
    /// The <code>open instance public ports</code> operation supports tag-based access control
    /// via resource tags applied to the resource identified by <code>instance name</code>.
    /// For more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en/articles/amazon-lightsail-controlling-access-using-tags">Lightsail
    /// Dev Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Open", "LSInstancePublicPort", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail OpenInstancePublicPorts API operation.", Operation = new[] {"OpenInstancePublicPorts"}, SelectReturnType = typeof(Amazon.Lightsail.Model.OpenInstancePublicPortsResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.OpenInstancePublicPortsResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.Operation object.",
        "The service call response (type Amazon.Lightsail.Model.OpenInstancePublicPortsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class OpenLSInstancePublicPortCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter PortInfo_FromPort
        /// <summary>
        /// <para>
        /// <para>The first port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PortInfo_FromPort { get; set; }
        #endregion
        
        #region Parameter InstanceName
        /// <summary>
        /// <para>
        /// <para>The name of the instance for which you want to open the public ports.</para>
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
        public System.String InstanceName { get; set; }
        #endregion
        
        #region Parameter PortInfo_Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lightsail.NetworkProtocol")]
        public Amazon.Lightsail.NetworkProtocol PortInfo_Protocol { get; set; }
        #endregion
        
        #region Parameter PortInfo_ToPort
        /// <summary>
        /// <para>
        /// <para>The last port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PortInfo_ToPort { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.OpenInstancePublicPortsResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.OpenInstancePublicPortsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operation";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Open-LSInstancePublicPort (OpenInstancePublicPorts)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.OpenInstancePublicPortsResponse, OpenLSInstancePublicPortCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InstanceName = this.InstanceName;
            #if MODULAR
            if (this.InstanceName == null && ParameterWasBound(nameof(this.InstanceName)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PortInfo_FromPort = this.PortInfo_FromPort;
            context.PortInfo_Protocol = this.PortInfo_Protocol;
            context.PortInfo_ToPort = this.PortInfo_ToPort;
            
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
            var request = new Amazon.Lightsail.Model.OpenInstancePublicPortsRequest();
            
            if (cmdletContext.InstanceName != null)
            {
                request.InstanceName = cmdletContext.InstanceName;
            }
            
             // populate PortInfo
            var requestPortInfoIsNull = true;
            request.PortInfo = new Amazon.Lightsail.Model.PortInfo();
            System.Int32? requestPortInfo_portInfo_FromPort = null;
            if (cmdletContext.PortInfo_FromPort != null)
            {
                requestPortInfo_portInfo_FromPort = cmdletContext.PortInfo_FromPort.Value;
            }
            if (requestPortInfo_portInfo_FromPort != null)
            {
                request.PortInfo.FromPort = requestPortInfo_portInfo_FromPort.Value;
                requestPortInfoIsNull = false;
            }
            Amazon.Lightsail.NetworkProtocol requestPortInfo_portInfo_Protocol = null;
            if (cmdletContext.PortInfo_Protocol != null)
            {
                requestPortInfo_portInfo_Protocol = cmdletContext.PortInfo_Protocol;
            }
            if (requestPortInfo_portInfo_Protocol != null)
            {
                request.PortInfo.Protocol = requestPortInfo_portInfo_Protocol;
                requestPortInfoIsNull = false;
            }
            System.Int32? requestPortInfo_portInfo_ToPort = null;
            if (cmdletContext.PortInfo_ToPort != null)
            {
                requestPortInfo_portInfo_ToPort = cmdletContext.PortInfo_ToPort.Value;
            }
            if (requestPortInfo_portInfo_ToPort != null)
            {
                request.PortInfo.ToPort = requestPortInfo_portInfo_ToPort.Value;
                requestPortInfoIsNull = false;
            }
             // determine if request.PortInfo should be set to null
            if (requestPortInfoIsNull)
            {
                request.PortInfo = null;
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
        
        private Amazon.Lightsail.Model.OpenInstancePublicPortsResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.OpenInstancePublicPortsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "OpenInstancePublicPorts");
            try
            {
                #if DESKTOP
                return client.OpenInstancePublicPorts(request);
                #elif CORECLR
                return client.OpenInstancePublicPortsAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceName { get; set; }
            public System.Int32? PortInfo_FromPort { get; set; }
            public Amazon.Lightsail.NetworkProtocol PortInfo_Protocol { get; set; }
            public System.Int32? PortInfo_ToPort { get; set; }
            public System.Func<Amazon.Lightsail.Model.OpenInstancePublicPortsResponse, OpenLSInstancePublicPortCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operation;
        }
        
    }
}
