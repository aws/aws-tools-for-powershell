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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a Spot fleet request.
    /// 
    ///  
    /// <para>
    /// You can submit a single request that includes multiple launch specifications that
    /// vary by instance type, AMI, Availability Zone, or subnet.
    /// </para><para>
    /// By default, the Spot fleet requests Spot instances in the Spot pool where the price
    /// per unit is the lowest. Each launch specification can include its own instance weighting
    /// that reflects the value of the instance type to your application workload.
    /// </para><para>
    /// Alternatively, you can specify that the Spot fleet distribute the target capacity
    /// across the Spot pools included in its launch specifications. By ensuring that the
    /// Spot instances in your Spot fleet are in different Spot pools, you can improve the
    /// availability of your fleet.
    /// </para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/spot-fleet-requests.html">Spot
    /// Fleet Requests</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Request", "EC2SpotFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the RequestSpotFleet operation against Amazon Elastic Compute Cloud.", Operation = new[] {"RequestSpotFleet"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.EC2.Model.RequestSpotFleetResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RequestEC2SpotFleetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter SpotFleetRequestConfig_AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>Indicates how to allocate the target capacity across the Spot pools specified by the
        /// Spot fleet request. The default is <code>lowestPrice</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.AllocationStrategy")]
        public Amazon.EC2.AllocationStrategy SpotFleetRequestConfig_AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier you provide to ensure idempotency of your listings.
        /// This helps avoid duplicate listings. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SpotFleetRequestConfig_ClientToken { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_ExcessCapacityTerminationPolicy
        /// <summary>
        /// <para>
        /// <para>Indicates whether running Spot instances should be terminated if the target capacity
        /// of the Spot fleet request is decreased below the current size of the Spot fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.ExcessCapacityTerminationPolicy")]
        public Amazon.EC2.ExcessCapacityTerminationPolicy SpotFleetRequestConfig_ExcessCapacityTerminationPolicy { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_IamFleetRole
        /// <summary>
        /// <para>
        /// <para>Grants the Spot fleet permission to terminate Spot instances on your behalf when you
        /// cancel its Spot fleet request using <a>CancelSpotFleetRequests</a> or when the Spot
        /// fleet request expires, if you set <code>terminateInstancesWithExpiration</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SpotFleetRequestConfig_IamFleetRole { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_LaunchSpecification
        /// <summary>
        /// <para>
        /// <para>Information about the launch specifications for the Spot fleet request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SpotFleetRequestConfig_LaunchSpecifications")]
        public Amazon.EC2.Model.SpotFleetLaunchSpecification[] SpotFleetRequestConfig_LaunchSpecification { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_SpotPrice
        /// <summary>
        /// <para>
        /// <para>The bid price per unit hour.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SpotFleetRequestConfig_SpotPrice { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_TargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of units to request. You can choose to set the target capacity in terms
        /// of instances or a performance characteristic that is important to your application
        /// workload, such as vCPUs, memory, or I/O.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 SpotFleetRequestConfig_TargetCapacity { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_TerminateInstancesWithExpiration
        /// <summary>
        /// <para>
        /// <para>Indicates whether running Spot instances should be terminated when the Spot fleet
        /// request expires.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SpotFleetRequestConfig_TerminateInstancesWithExpiration { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_ValidFrom
        /// <summary>
        /// <para>
        /// <para>The start date and time of the request, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).
        /// The default is to start fulfilling the request immediately.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime SpotFleetRequestConfig_ValidFrom { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_ValidUntil
        /// <summary>
        /// <para>
        /// <para>The end date and time of the request, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).
        /// At this point, no new Spot instance requests are placed or enabled to fulfill the
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime SpotFleetRequestConfig_ValidUntil { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SpotFleetRequestConfig_SpotPrice", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-EC2SpotFleet (RequestSpotFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.SpotFleetRequestConfig_AllocationStrategy = this.SpotFleetRequestConfig_AllocationStrategy;
            context.SpotFleetRequestConfig_ClientToken = this.SpotFleetRequestConfig_ClientToken;
            context.SpotFleetRequestConfig_ExcessCapacityTerminationPolicy = this.SpotFleetRequestConfig_ExcessCapacityTerminationPolicy;
            context.SpotFleetRequestConfig_IamFleetRole = this.SpotFleetRequestConfig_IamFleetRole;
            if (this.SpotFleetRequestConfig_LaunchSpecification != null)
            {
                context.SpotFleetRequestConfig_LaunchSpecifications = new List<Amazon.EC2.Model.SpotFleetLaunchSpecification>(this.SpotFleetRequestConfig_LaunchSpecification);
            }
            context.SpotFleetRequestConfig_SpotPrice = this.SpotFleetRequestConfig_SpotPrice;
            if (ParameterWasBound("SpotFleetRequestConfig_TargetCapacity"))
                context.SpotFleetRequestConfig_TargetCapacity = this.SpotFleetRequestConfig_TargetCapacity;
            if (ParameterWasBound("SpotFleetRequestConfig_TerminateInstancesWithExpiration"))
                context.SpotFleetRequestConfig_TerminateInstancesWithExpiration = this.SpotFleetRequestConfig_TerminateInstancesWithExpiration;
            if (ParameterWasBound("SpotFleetRequestConfig_ValidFrom"))
                context.SpotFleetRequestConfig_ValidFrom = this.SpotFleetRequestConfig_ValidFrom;
            if (ParameterWasBound("SpotFleetRequestConfig_ValidUntil"))
                context.SpotFleetRequestConfig_ValidUntil = this.SpotFleetRequestConfig_ValidUntil;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.RequestSpotFleetRequest();
            
            
             // populate SpotFleetRequestConfig
            bool requestSpotFleetRequestConfigIsNull = true;
            request.SpotFleetRequestConfig = new Amazon.EC2.Model.SpotFleetRequestConfigData();
            Amazon.EC2.AllocationStrategy requestSpotFleetRequestConfig_spotFleetRequestConfig_AllocationStrategy = null;
            if (cmdletContext.SpotFleetRequestConfig_AllocationStrategy != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_AllocationStrategy = cmdletContext.SpotFleetRequestConfig_AllocationStrategy;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_AllocationStrategy != null)
            {
                request.SpotFleetRequestConfig.AllocationStrategy = requestSpotFleetRequestConfig_spotFleetRequestConfig_AllocationStrategy;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.String requestSpotFleetRequestConfig_spotFleetRequestConfig_ClientToken = null;
            if (cmdletContext.SpotFleetRequestConfig_ClientToken != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_ClientToken = cmdletContext.SpotFleetRequestConfig_ClientToken;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_ClientToken != null)
            {
                request.SpotFleetRequestConfig.ClientToken = requestSpotFleetRequestConfig_spotFleetRequestConfig_ClientToken;
                requestSpotFleetRequestConfigIsNull = false;
            }
            Amazon.EC2.ExcessCapacityTerminationPolicy requestSpotFleetRequestConfig_spotFleetRequestConfig_ExcessCapacityTerminationPolicy = null;
            if (cmdletContext.SpotFleetRequestConfig_ExcessCapacityTerminationPolicy != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_ExcessCapacityTerminationPolicy = cmdletContext.SpotFleetRequestConfig_ExcessCapacityTerminationPolicy;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_ExcessCapacityTerminationPolicy != null)
            {
                request.SpotFleetRequestConfig.ExcessCapacityTerminationPolicy = requestSpotFleetRequestConfig_spotFleetRequestConfig_ExcessCapacityTerminationPolicy;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.String requestSpotFleetRequestConfig_spotFleetRequestConfig_IamFleetRole = null;
            if (cmdletContext.SpotFleetRequestConfig_IamFleetRole != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_IamFleetRole = cmdletContext.SpotFleetRequestConfig_IamFleetRole;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_IamFleetRole != null)
            {
                request.SpotFleetRequestConfig.IamFleetRole = requestSpotFleetRequestConfig_spotFleetRequestConfig_IamFleetRole;
                requestSpotFleetRequestConfigIsNull = false;
            }
            List<Amazon.EC2.Model.SpotFleetLaunchSpecification> requestSpotFleetRequestConfig_spotFleetRequestConfig_LaunchSpecification = null;
            if (cmdletContext.SpotFleetRequestConfig_LaunchSpecifications != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LaunchSpecification = cmdletContext.SpotFleetRequestConfig_LaunchSpecifications;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_LaunchSpecification != null)
            {
                request.SpotFleetRequestConfig.LaunchSpecifications = requestSpotFleetRequestConfig_spotFleetRequestConfig_LaunchSpecification;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.String requestSpotFleetRequestConfig_spotFleetRequestConfig_SpotPrice = null;
            if (cmdletContext.SpotFleetRequestConfig_SpotPrice != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_SpotPrice = cmdletContext.SpotFleetRequestConfig_SpotPrice;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_SpotPrice != null)
            {
                request.SpotFleetRequestConfig.SpotPrice = requestSpotFleetRequestConfig_spotFleetRequestConfig_SpotPrice;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.Int32? requestSpotFleetRequestConfig_spotFleetRequestConfig_TargetCapacity = null;
            if (cmdletContext.SpotFleetRequestConfig_TargetCapacity != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_TargetCapacity = cmdletContext.SpotFleetRequestConfig_TargetCapacity.Value;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_TargetCapacity != null)
            {
                request.SpotFleetRequestConfig.TargetCapacity = requestSpotFleetRequestConfig_spotFleetRequestConfig_TargetCapacity.Value;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.Boolean? requestSpotFleetRequestConfig_spotFleetRequestConfig_TerminateInstancesWithExpiration = null;
            if (cmdletContext.SpotFleetRequestConfig_TerminateInstancesWithExpiration != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_TerminateInstancesWithExpiration = cmdletContext.SpotFleetRequestConfig_TerminateInstancesWithExpiration.Value;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_TerminateInstancesWithExpiration != null)
            {
                request.SpotFleetRequestConfig.TerminateInstancesWithExpiration = requestSpotFleetRequestConfig_spotFleetRequestConfig_TerminateInstancesWithExpiration.Value;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.DateTime? requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidFrom = null;
            if (cmdletContext.SpotFleetRequestConfig_ValidFrom != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidFrom = cmdletContext.SpotFleetRequestConfig_ValidFrom.Value;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidFrom != null)
            {
                request.SpotFleetRequestConfig.ValidFrom = requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidFrom.Value;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.DateTime? requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidUntil = null;
            if (cmdletContext.SpotFleetRequestConfig_ValidUntil != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidUntil = cmdletContext.SpotFleetRequestConfig_ValidUntil.Value;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidUntil != null)
            {
                request.SpotFleetRequestConfig.ValidUntil = requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidUntil.Value;
                requestSpotFleetRequestConfigIsNull = false;
            }
             // determine if request.SpotFleetRequestConfig should be set to null
            if (requestSpotFleetRequestConfigIsNull)
            {
                request.SpotFleetRequestConfig = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private static Amazon.EC2.Model.RequestSpotFleetResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.RequestSpotFleetRequest request)
        {
            return client.RequestSpotFleet(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Amazon.EC2.AllocationStrategy SpotFleetRequestConfig_AllocationStrategy { get; set; }
            public System.String SpotFleetRequestConfig_ClientToken { get; set; }
            public Amazon.EC2.ExcessCapacityTerminationPolicy SpotFleetRequestConfig_ExcessCapacityTerminationPolicy { get; set; }
            public System.String SpotFleetRequestConfig_IamFleetRole { get; set; }
            public List<Amazon.EC2.Model.SpotFleetLaunchSpecification> SpotFleetRequestConfig_LaunchSpecifications { get; set; }
            public System.String SpotFleetRequestConfig_SpotPrice { get; set; }
            public System.Int32? SpotFleetRequestConfig_TargetCapacity { get; set; }
            public System.Boolean? SpotFleetRequestConfig_TerminateInstancesWithExpiration { get; set; }
            public System.DateTime? SpotFleetRequestConfig_ValidFrom { get; set; }
            public System.DateTime? SpotFleetRequestConfig_ValidUntil { get; set; }
        }
        
    }
}
