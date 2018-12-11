/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.GlobalAccelerator;
using Amazon.GlobalAccelerator.Model;

namespace Amazon.PowerShell.Cmdlets.GACL
{
    /// <summary>
    /// Update an endpoint group. To see an AWS CLI example of updating an endpoint group,
    /// scroll down to <b>Example</b>.
    /// </summary>
    [Cmdlet("Update", "GACLEndpointGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GlobalAccelerator.Model.EndpointGroup")]
    [AWSCmdlet("Calls the AWS Global Accelerator UpdateEndpointGroup API operation.", Operation = new[] {"UpdateEndpointGroup"})]
    [AWSCmdletOutput("Amazon.GlobalAccelerator.Model.EndpointGroup",
        "This cmdlet returns a EndpointGroup object.",
        "The service call response (type Amazon.GlobalAccelerator.Model.UpdateEndpointGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGACLEndpointGroupCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        #region Parameter EndpointConfiguration
        /// <summary>
        /// <para>
        /// <para>The list of endpoint objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointConfigurations")]
        public Amazon.GlobalAccelerator.Model.EndpointConfiguration[] EndpointConfiguration { get; set; }
        #endregion
        
        #region Parameter EndpointGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the endpoint group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String EndpointGroupArn { get; set; }
        #endregion
        
        #region Parameter HealthCheckIntervalSecond
        /// <summary>
        /// <para>
        /// <para>The time, in seconds, between each health check for an endpoint. The default value
        /// is 30.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HealthCheckIntervalSeconds")]
        public System.Int32 HealthCheckIntervalSecond { get; set; }
        #endregion
        
        #region Parameter HealthCheckPath
        /// <summary>
        /// <para>
        /// <para>If the protocol is HTTP/S, then this specifies the path that is the destination for
        /// health check targets. The default value is slash (/).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheckPath { get; set; }
        #endregion
        
        #region Parameter HealthCheckPort
        /// <summary>
        /// <para>
        /// <para>The port that AWS Global Accelerator uses to check the health of endpoints that are
        /// part of this endpoint group. The default port is the listener port that this endpoint
        /// group is associated with. If the listener port is a list of ports, Global Accelerator
        /// uses the first port in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthCheckPort { get; set; }
        #endregion
        
        #region Parameter HealthCheckProtocol
        /// <summary>
        /// <para>
        /// <para>The protocol that AWS Global Accelerator uses to check the health of endpoints that
        /// are part of this endpoint group. The default value is TCP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GlobalAccelerator.HealthCheckProtocol")]
        public Amazon.GlobalAccelerator.HealthCheckProtocol HealthCheckProtocol { get; set; }
        #endregion
        
        #region Parameter ThresholdCount
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health checks required to set the state of a healthy endpoint
        /// to unhealthy, or to set an unhealthy endpoint to healthy. The default value is 3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ThresholdCount { get; set; }
        #endregion
        
        #region Parameter TrafficDialPercentage
        /// <summary>
        /// <para>
        /// <para>The percentage of traffic to send to an AWS Region. Additional traffic is distributed
        /// to other endpoint groups for this listener. </para><para>Use this action to increase (dial up) or decrease (dial down) traffic to a specific
        /// Region. The percentage is applied to the traffic that would otherwise have been routed
        /// to the Region based on optimal routing.</para><para>The default value is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Single TrafficDialPercentage { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("EndpointGroupArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GACLEndpointGroup (UpdateEndpointGroup)"))
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
            
            if (this.EndpointConfiguration != null)
            {
                context.EndpointConfigurations = new List<Amazon.GlobalAccelerator.Model.EndpointConfiguration>(this.EndpointConfiguration);
            }
            context.EndpointGroupArn = this.EndpointGroupArn;
            if (ParameterWasBound("HealthCheckIntervalSecond"))
                context.HealthCheckIntervalSeconds = this.HealthCheckIntervalSecond;
            context.HealthCheckPath = this.HealthCheckPath;
            if (ParameterWasBound("HealthCheckPort"))
                context.HealthCheckPort = this.HealthCheckPort;
            context.HealthCheckProtocol = this.HealthCheckProtocol;
            if (ParameterWasBound("ThresholdCount"))
                context.ThresholdCount = this.ThresholdCount;
            if (ParameterWasBound("TrafficDialPercentage"))
                context.TrafficDialPercentage = this.TrafficDialPercentage;
            
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
            var request = new Amazon.GlobalAccelerator.Model.UpdateEndpointGroupRequest();
            
            if (cmdletContext.EndpointConfigurations != null)
            {
                request.EndpointConfigurations = cmdletContext.EndpointConfigurations;
            }
            if (cmdletContext.EndpointGroupArn != null)
            {
                request.EndpointGroupArn = cmdletContext.EndpointGroupArn;
            }
            if (cmdletContext.HealthCheckIntervalSeconds != null)
            {
                request.HealthCheckIntervalSeconds = cmdletContext.HealthCheckIntervalSeconds.Value;
            }
            if (cmdletContext.HealthCheckPath != null)
            {
                request.HealthCheckPath = cmdletContext.HealthCheckPath;
            }
            if (cmdletContext.HealthCheckPort != null)
            {
                request.HealthCheckPort = cmdletContext.HealthCheckPort.Value;
            }
            if (cmdletContext.HealthCheckProtocol != null)
            {
                request.HealthCheckProtocol = cmdletContext.HealthCheckProtocol;
            }
            if (cmdletContext.ThresholdCount != null)
            {
                request.ThresholdCount = cmdletContext.ThresholdCount.Value;
            }
            if (cmdletContext.TrafficDialPercentage != null)
            {
                request.TrafficDialPercentage = cmdletContext.TrafficDialPercentage.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.EndpointGroup;
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
        
        private Amazon.GlobalAccelerator.Model.UpdateEndpointGroupResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.UpdateEndpointGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "UpdateEndpointGroup");
            try
            {
                #if DESKTOP
                return client.UpdateEndpointGroup(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateEndpointGroupAsync(request);
                return task.Result;
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
            public List<Amazon.GlobalAccelerator.Model.EndpointConfiguration> EndpointConfigurations { get; set; }
            public System.String EndpointGroupArn { get; set; }
            public System.Int32? HealthCheckIntervalSeconds { get; set; }
            public System.String HealthCheckPath { get; set; }
            public System.Int32? HealthCheckPort { get; set; }
            public Amazon.GlobalAccelerator.HealthCheckProtocol HealthCheckProtocol { get; set; }
            public System.Int32? ThresholdCount { get; set; }
            public System.Single? TrafficDialPercentage { get; set; }
        }
        
    }
}
