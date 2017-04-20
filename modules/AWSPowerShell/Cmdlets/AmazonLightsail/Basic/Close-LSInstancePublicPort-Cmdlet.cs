/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Closes the public ports on a specific Amazon Lightsail instance.
    /// </summary>
    [Cmdlet("Close", "LSInstancePublicPort", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Invokes the CloseInstancePublicPorts operation against Amazon Lightsail.", Operation = new[] {"CloseInstancePublicPorts"})]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation",
        "This cmdlet returns a Operation object.",
        "The service call response (type Amazon.Lightsail.Model.CloseInstancePublicPortsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CloseLSInstancePublicPortCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter PortInfo_FromPort
        /// <summary>
        /// <para>
        /// <para>The first port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 PortInfo_FromPort { get; set; }
        #endregion
        
        #region Parameter InstanceName
        /// <summary>
        /// <para>
        /// <para>The name of the instance on which you're attempting to close the public ports.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceName { get; set; }
        #endregion
        
        #region Parameter PortInfo_Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Lightsail.NetworkProtocol")]
        public Amazon.Lightsail.NetworkProtocol PortInfo_Protocol { get; set; }
        #endregion
        
        #region Parameter PortInfo_ToPort
        /// <summary>
        /// <para>
        /// <para>The last port in the range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 PortInfo_ToPort { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Close-LSInstancePublicPort (CloseInstancePublicPorts)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.InstanceName = this.InstanceName;
            if (ParameterWasBound("PortInfo_FromPort"))
                context.PortInfo_FromPort = this.PortInfo_FromPort;
            context.PortInfo_Protocol = this.PortInfo_Protocol;
            if (ParameterWasBound("PortInfo_ToPort"))
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
            var request = new Amazon.Lightsail.Model.CloseInstancePublicPortsRequest();
            
            if (cmdletContext.InstanceName != null)
            {
                request.InstanceName = cmdletContext.InstanceName;
            }
            
             // populate PortInfo
            bool requestPortInfoIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Operation;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.Lightsail.Model.CloseInstancePublicPortsResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CloseInstancePublicPortsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CloseInstancePublicPorts");
            #if DESKTOP
            return client.CloseInstancePublicPorts(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CloseInstancePublicPortsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String InstanceName { get; set; }
            public System.Int32? PortInfo_FromPort { get; set; }
            public Amazon.Lightsail.NetworkProtocol PortInfo_Protocol { get; set; }
            public System.Int32? PortInfo_ToPort { get; set; }
        }
        
    }
}
