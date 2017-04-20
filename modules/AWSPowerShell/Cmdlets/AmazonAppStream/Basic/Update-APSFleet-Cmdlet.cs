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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Updates an existing fleet. All the attributes except the fleet name can be updated
    /// in the INACTIVE state. Only ComputeResourceCapacity and imageName can be updated in
    /// any other state.
    /// </summary>
    [Cmdlet("Update", "APSFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.Fleet")]
    [AWSCmdlet("Invokes the UpdateFleet operation against AWS AppStream.", Operation = new[] {"UpdateFleet"})]
    [AWSCmdletOutput("Amazon.AppStream.Model.Fleet",
        "This cmdlet returns a Fleet object.",
        "The service call response (type Amazon.AppStream.Model.UpdateFleetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAPSFleetCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        #region Parameter DeleteVpcConfig
        /// <summary>
        /// <para>
        /// <para>Delete Vpc Config, if the parameter is set and the fleet has Vpc Config, it can be
        /// deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DeleteVpcConfig { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ComputeCapacity_DesiredInstance
        /// <summary>
        /// <para>
        /// <para>The desired number of streaming instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputeCapacity_DesiredInstances")]
        public System.Int32 ComputeCapacity_DesiredInstance { get; set; }
        #endregion
        
        #region Parameter DisconnectTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The time after disconnection when a session is considered to have ended. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DisconnectTimeoutInSeconds")]
        public System.Int32 DisconnectTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter ImageName
        /// <summary>
        /// <para>
        /// <para>The image name from which a fleet is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ImageName { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type of compute resources for the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter MaxUserDurationInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time during which a streaming session can run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxUserDurationInSeconds")]
        public System.Int32 MaxUserDurationInSecond { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SubnetId
        /// <summary>
        /// <para>
        /// <para>The list of subnets in which the fleet is launched.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VpcConfig_SubnetIds")]
        public System.String[] VpcConfig_SubnetId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-APSFleet (UpdateFleet)"))
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
            
            if (ParameterWasBound("ComputeCapacity_DesiredInstance"))
                context.ComputeCapacity_DesiredInstances = this.ComputeCapacity_DesiredInstance;
            if (ParameterWasBound("DeleteVpcConfig"))
                context.DeleteVpcConfig = this.DeleteVpcConfig;
            context.Description = this.Description;
            if (ParameterWasBound("DisconnectTimeoutInSecond"))
                context.DisconnectTimeoutInSeconds = this.DisconnectTimeoutInSecond;
            context.DisplayName = this.DisplayName;
            context.ImageName = this.ImageName;
            context.InstanceType = this.InstanceType;
            if (ParameterWasBound("MaxUserDurationInSecond"))
                context.MaxUserDurationInSeconds = this.MaxUserDurationInSecond;
            context.Name = this.Name;
            if (this.VpcConfig_SubnetId != null)
            {
                context.VpcConfig_SubnetIds = new List<System.String>(this.VpcConfig_SubnetId);
            }
            
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
            var request = new Amazon.AppStream.Model.UpdateFleetRequest();
            
            
             // populate ComputeCapacity
            bool requestComputeCapacityIsNull = true;
            request.ComputeCapacity = new Amazon.AppStream.Model.ComputeCapacity();
            System.Int32? requestComputeCapacity_computeCapacity_DesiredInstance = null;
            if (cmdletContext.ComputeCapacity_DesiredInstances != null)
            {
                requestComputeCapacity_computeCapacity_DesiredInstance = cmdletContext.ComputeCapacity_DesiredInstances.Value;
            }
            if (requestComputeCapacity_computeCapacity_DesiredInstance != null)
            {
                request.ComputeCapacity.DesiredInstances = requestComputeCapacity_computeCapacity_DesiredInstance.Value;
                requestComputeCapacityIsNull = false;
            }
             // determine if request.ComputeCapacity should be set to null
            if (requestComputeCapacityIsNull)
            {
                request.ComputeCapacity = null;
            }
            if (cmdletContext.DeleteVpcConfig != null)
            {
                request.DeleteVpcConfig = cmdletContext.DeleteVpcConfig.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisconnectTimeoutInSeconds != null)
            {
                request.DisconnectTimeoutInSeconds = cmdletContext.DisconnectTimeoutInSeconds.Value;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.ImageName != null)
            {
                request.ImageName = cmdletContext.ImageName;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.MaxUserDurationInSeconds != null)
            {
                request.MaxUserDurationInSeconds = cmdletContext.MaxUserDurationInSeconds.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate VpcConfig
            bool requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.AppStream.Model.VpcConfig();
            List<System.String> requestVpcConfig_vpcConfig_SubnetId = null;
            if (cmdletContext.VpcConfig_SubnetIds != null)
            {
                requestVpcConfig_vpcConfig_SubnetId = cmdletContext.VpcConfig_SubnetIds;
            }
            if (requestVpcConfig_vpcConfig_SubnetId != null)
            {
                request.VpcConfig.SubnetIds = requestVpcConfig_vpcConfig_SubnetId;
                requestVpcConfigIsNull = false;
            }
             // determine if request.VpcConfig should be set to null
            if (requestVpcConfigIsNull)
            {
                request.VpcConfig = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Fleet;
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
        
        private Amazon.AppStream.Model.UpdateFleetResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.UpdateFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppStream", "UpdateFleet");
            #if DESKTOP
            return client.UpdateFleet(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateFleetAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Int32? ComputeCapacity_DesiredInstances { get; set; }
            public System.Boolean? DeleteVpcConfig { get; set; }
            public System.String Description { get; set; }
            public System.Int32? DisconnectTimeoutInSeconds { get; set; }
            public System.String DisplayName { get; set; }
            public System.String ImageName { get; set; }
            public System.String InstanceType { get; set; }
            public System.Int32? MaxUserDurationInSeconds { get; set; }
            public System.String Name { get; set; }
            public List<System.String> VpcConfig_SubnetIds { get; set; }
        }
        
    }
}
