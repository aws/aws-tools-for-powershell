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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Updates the specified fleet.
    /// 
    ///  
    /// <para>
    /// If the fleet is in the <code>STOPPED</code> state, you can update any attribute except
    /// the fleet name. If the fleet is in the <code>RUNNING</code> state, you can update
    /// the <code>DisplayName</code> and <code>ComputeCapacity</code> attributes. If the fleet
    /// is in the <code>STARTING</code> or <code>STOPPING</code> state, you can't update it.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "APSFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.Fleet")]
    [AWSCmdlet("Calls the AWS AppStream UpdateFleet API operation.", Operation = new[] {"UpdateFleet"})]
    [AWSCmdletOutput("Amazon.AppStream.Model.Fleet",
        "This cmdlet returns a Fleet object.",
        "The service call response (type Amazon.AppStream.Model.UpdateFleetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAPSFleetCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        #region Parameter AttributesToDelete
        /// <summary>
        /// <para>
        /// <para>The fleet attributes to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] AttributesToDelete { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description to display.</para>
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
        
        #region Parameter DomainJoinInfo_DirectoryName
        /// <summary>
        /// <para>
        /// <para>The fully qualified name of the directory (for example, corp.example.com).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DomainJoinInfo_DirectoryName { get; set; }
        #endregion
        
        #region Parameter DisconnectTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The time after disconnection when a session is considered to have ended, in seconds.
        /// If a user who was disconnected reconnects within this time interval, the user is connected
        /// to their previous session. Specify a value between 60 and 360000. By default, the
        /// value is 900 seconds (15 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DisconnectTimeoutInSeconds")]
        public System.Int32 DisconnectTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The fleet name to display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter EnableDefaultInternetAccess
        /// <summary>
        /// <para>
        /// <para>Enables or disables default internet access for the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableDefaultInternetAccess { get; set; }
        #endregion
        
        #region Parameter ImageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the public, private, or shared image to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ImageArn { get; set; }
        #endregion
        
        #region Parameter ImageName
        /// <summary>
        /// <para>
        /// <para>The name of the image used to create the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ImageName { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type to use when launching fleet instances. The following instance types
        /// are available:</para><ul><li><para>stream.standard.medium</para></li><li><para>stream.standard.large</para></li><li><para>stream.compute.large</para></li><li><para>stream.compute.xlarge</para></li><li><para>stream.compute.2xlarge</para></li><li><para>stream.compute.4xlarge</para></li><li><para>stream.compute.8xlarge</para></li><li><para>stream.memory.large</para></li><li><para>stream.memory.xlarge</para></li><li><para>stream.memory.2xlarge</para></li><li><para>stream.memory.4xlarge</para></li><li><para>stream.memory.8xlarge</para></li><li><para>stream.graphics-design.large</para></li><li><para>stream.graphics-design.xlarge</para></li><li><para>stream.graphics-design.2xlarge</para></li><li><para>stream.graphics-design.4xlarge</para></li><li><para>stream.graphics-desktop.2xlarge</para></li><li><para>stream.graphics-pro.4xlarge</para></li><li><para>stream.graphics-pro.8xlarge</para></li><li><para>stream.graphics-pro.16xlarge</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter MaxUserDurationInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time that a streaming session can run, in seconds. Specify a value between
        /// 600 and 360000. By default, the value is 900 seconds (15 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxUserDurationInSeconds")]
        public System.Int32 MaxUserDurationInSecond { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A unique name for the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter DomainJoinInfo_OrganizationalUnitDistinguishedName
        /// <summary>
        /// <para>
        /// <para>The distinguished name of the organizational unit for computer accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DomainJoinInfo_OrganizationalUnitDistinguishedName { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the security groups for the fleet or image builder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SubnetId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the subnets to which a network interface is attached from the fleet
        /// instance or image builder instance. Fleet instances use one or two subnets. Image
        /// builder instances use one subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VpcConfig_SubnetIds")]
        public System.String[] VpcConfig_SubnetId { get; set; }
        #endregion
        
        #region Parameter DeleteVpcConfig
        /// <summary>
        /// <para>
        /// <para>Deletes the VPC association for the specified fleet.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This property is deprecated")]
        public System.Boolean DeleteVpcConfig { get; set; }
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
            
            if (this.AttributesToDelete != null)
            {
                context.AttributesToDelete = new List<System.String>(this.AttributesToDelete);
            }
            if (ParameterWasBound("ComputeCapacity_DesiredInstance"))
                context.ComputeCapacity_DesiredInstances = this.ComputeCapacity_DesiredInstance;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("DeleteVpcConfig"))
                context.DeleteVpcConfig = this.DeleteVpcConfig;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            if (ParameterWasBound("DisconnectTimeoutInSecond"))
                context.DisconnectTimeoutInSeconds = this.DisconnectTimeoutInSecond;
            context.DisplayName = this.DisplayName;
            context.DomainJoinInfo_DirectoryName = this.DomainJoinInfo_DirectoryName;
            context.DomainJoinInfo_OrganizationalUnitDistinguishedName = this.DomainJoinInfo_OrganizationalUnitDistinguishedName;
            if (ParameterWasBound("EnableDefaultInternetAccess"))
                context.EnableDefaultInternetAccess = this.EnableDefaultInternetAccess;
            context.ImageArn = this.ImageArn;
            context.ImageName = this.ImageName;
            context.InstanceType = this.InstanceType;
            if (ParameterWasBound("MaxUserDurationInSecond"))
                context.MaxUserDurationInSeconds = this.MaxUserDurationInSecond;
            context.Name = this.Name;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupIds = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
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
            
            if (cmdletContext.AttributesToDelete != null)
            {
                request.AttributesToDelete = cmdletContext.AttributesToDelete;
            }
            
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.DeleteVpcConfig != null)
            {
                request.DeleteVpcConfig = cmdletContext.DeleteVpcConfig.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            
             // populate DomainJoinInfo
            bool requestDomainJoinInfoIsNull = true;
            request.DomainJoinInfo = new Amazon.AppStream.Model.DomainJoinInfo();
            System.String requestDomainJoinInfo_domainJoinInfo_DirectoryName = null;
            if (cmdletContext.DomainJoinInfo_DirectoryName != null)
            {
                requestDomainJoinInfo_domainJoinInfo_DirectoryName = cmdletContext.DomainJoinInfo_DirectoryName;
            }
            if (requestDomainJoinInfo_domainJoinInfo_DirectoryName != null)
            {
                request.DomainJoinInfo.DirectoryName = requestDomainJoinInfo_domainJoinInfo_DirectoryName;
                requestDomainJoinInfoIsNull = false;
            }
            System.String requestDomainJoinInfo_domainJoinInfo_OrganizationalUnitDistinguishedName = null;
            if (cmdletContext.DomainJoinInfo_OrganizationalUnitDistinguishedName != null)
            {
                requestDomainJoinInfo_domainJoinInfo_OrganizationalUnitDistinguishedName = cmdletContext.DomainJoinInfo_OrganizationalUnitDistinguishedName;
            }
            if (requestDomainJoinInfo_domainJoinInfo_OrganizationalUnitDistinguishedName != null)
            {
                request.DomainJoinInfo.OrganizationalUnitDistinguishedName = requestDomainJoinInfo_domainJoinInfo_OrganizationalUnitDistinguishedName;
                requestDomainJoinInfoIsNull = false;
            }
             // determine if request.DomainJoinInfo should be set to null
            if (requestDomainJoinInfoIsNull)
            {
                request.DomainJoinInfo = null;
            }
            if (cmdletContext.EnableDefaultInternetAccess != null)
            {
                request.EnableDefaultInternetAccess = cmdletContext.EnableDefaultInternetAccess.Value;
            }
            if (cmdletContext.ImageArn != null)
            {
                request.ImageArn = cmdletContext.ImageArn;
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
            List<System.String> requestVpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupIds != null)
            {
                requestVpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupIds;
            }
            if (requestVpcConfig_vpcConfig_SecurityGroupId != null)
            {
                request.VpcConfig.SecurityGroupIds = requestVpcConfig_vpcConfig_SecurityGroupId;
                requestVpcConfigIsNull = false;
            }
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
            try
            {
                #if DESKTOP
                return client.UpdateFleet(request);
                #elif CORECLR
                return client.UpdateFleetAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AttributesToDelete { get; set; }
            public System.Int32? ComputeCapacity_DesiredInstances { get; set; }
            [System.ObsoleteAttribute]
            public System.Boolean? DeleteVpcConfig { get; set; }
            public System.String Description { get; set; }
            public System.Int32? DisconnectTimeoutInSeconds { get; set; }
            public System.String DisplayName { get; set; }
            public System.String DomainJoinInfo_DirectoryName { get; set; }
            public System.String DomainJoinInfo_OrganizationalUnitDistinguishedName { get; set; }
            public System.Boolean? EnableDefaultInternetAccess { get; set; }
            public System.String ImageArn { get; set; }
            public System.String ImageName { get; set; }
            public System.String InstanceType { get; set; }
            public System.Int32? MaxUserDurationInSeconds { get; set; }
            public System.String Name { get; set; }
            public List<System.String> VpcConfig_SecurityGroupIds { get; set; }
            public List<System.String> VpcConfig_SubnetIds { get; set; }
        }
        
    }
}
