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
    /// Creates an image builder. An image builder is a virtual machine that is used to create
    /// an image.
    /// 
    ///  
    /// <para>
    /// The initial state of the builder is <code>PENDING</code>. When it is ready, the state
    /// is <code>RUNNING</code>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "APSImageBuilder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.ImageBuilder")]
    [AWSCmdlet("Calls the AWS AppStream CreateImageBuilder API operation.", Operation = new[] {"CreateImageBuilder"})]
    [AWSCmdletOutput("Amazon.AppStream.Model.ImageBuilder",
        "This cmdlet returns a ImageBuilder object.",
        "The service call response (type Amazon.AppStream.Model.CreateImageBuilderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAPSImageBuilderCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        #region Parameter AppstreamAgentVersion
        /// <summary>
        /// <para>
        /// <para>The version of the AppStream 2.0 agent to use for this image builder. To use the latest
        /// version of the AppStream 2.0 agent, specify [LATEST]. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AppstreamAgentVersion { get; set; }
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
        
        #region Parameter DomainJoinInfo_DirectoryName
        /// <summary>
        /// <para>
        /// <para>The fully qualified name of the directory (for example, corp.example.com).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DomainJoinInfo_DirectoryName { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The image builder name to display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter EnableDefaultInternetAccess
        /// <summary>
        /// <para>
        /// <para>Enables or disables default internet access for the image builder.</para>
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
        /// <para>The name of the image used to create the image builder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ImageName { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type to use when launching the image builder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A unique name for the image builder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the image builder. A tag is a key-value pair (the value
        /// is optional). For example, Environment=Test, or, if you do not specify a value, Environment=.
        /// </para><para>If you do not specify a value, we set the value to an empty string.</para><para>For more information about tags, see <a href="http://docs.aws.amazon.com/appstream2/latest/developerguide/tagging-basic.html">Tagging
        /// Your Resources</a> in the <i>Amazon AppStream 2.0 Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ImageName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APSImageBuilder (CreateImageBuilder)"))
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
            
            context.AppstreamAgentVersion = this.AppstreamAgentVersion;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.DomainJoinInfo_DirectoryName = this.DomainJoinInfo_DirectoryName;
            context.DomainJoinInfo_OrganizationalUnitDistinguishedName = this.DomainJoinInfo_OrganizationalUnitDistinguishedName;
            if (ParameterWasBound("EnableDefaultInternetAccess"))
                context.EnableDefaultInternetAccess = this.EnableDefaultInternetAccess;
            context.ImageArn = this.ImageArn;
            context.ImageName = this.ImageName;
            context.InstanceType = this.InstanceType;
            context.Name = this.Name;
            if (this.Tag != null)
            {
                context.Tags = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tags.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
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
            var request = new Amazon.AppStream.Model.CreateImageBuilderRequest();
            
            if (cmdletContext.AppstreamAgentVersion != null)
            {
                request.AppstreamAgentVersion = cmdletContext.AppstreamAgentVersion;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
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
                object pipelineOutput = response.ImageBuilder;
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
        
        private Amazon.AppStream.Model.CreateImageBuilderResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.CreateImageBuilderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppStream", "CreateImageBuilder");
            try
            {
                #if DESKTOP
                return client.CreateImageBuilder(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateImageBuilderAsync(request);
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
            public System.String AppstreamAgentVersion { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String DomainJoinInfo_DirectoryName { get; set; }
            public System.String DomainJoinInfo_OrganizationalUnitDistinguishedName { get; set; }
            public System.Boolean? EnableDefaultInternetAccess { get; set; }
            public System.String ImageArn { get; set; }
            public System.String ImageName { get; set; }
            public System.String InstanceType { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tags { get; set; }
            public List<System.String> VpcConfig_SecurityGroupIds { get; set; }
            public List<System.String> VpcConfig_SubnetIds { get; set; }
        }
        
    }
}
