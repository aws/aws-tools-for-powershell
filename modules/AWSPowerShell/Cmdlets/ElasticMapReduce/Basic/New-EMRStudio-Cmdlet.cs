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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Creates a new Amazon EMR Studio.
    /// </summary>
    [Cmdlet("New", "EMRStudio", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticMapReduce.Model.CreateStudioResponse")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce CreateStudio API operation.", Operation = new[] {"CreateStudio"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.CreateStudioResponse))]
    [AWSCmdletOutput("Amazon.ElasticMapReduce.Model.CreateStudioResponse",
        "This cmdlet returns an Amazon.ElasticMapReduce.Model.CreateStudioResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMRStudioCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter AuthMode
        /// <summary>
        /// <para>
        /// <para>Specifies whether the Studio authenticates users using IAM or IAM Identity Center.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.AuthMode")]
        public Amazon.ElasticMapReduce.AuthMode AuthMode { get; set; }
        #endregion
        
        #region Parameter DefaultS3Location
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location to back up Amazon EMR Studio Workspaces and notebook files.</para>
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
        public System.String DefaultS3Location { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A detailed description of the Amazon EMR Studio.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EngineSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon EMR Studio Engine security group. The Engine security group allows
        /// inbound network traffic from the Workspace security group, and it must be in the same
        /// VPC specified by <code>VpcId</code>.</para>
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
        public System.String EngineSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter IdpAuthUrl
        /// <summary>
        /// <para>
        /// <para>The authentication endpoint of your identity provider (IdP). Specify this value when
        /// you use IAM authentication and want to let federated users log in to a Studio with
        /// the Studio URL and credentials from your IdP. Amazon EMR Studio redirects users to
        /// this endpoint to enter credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdpAuthUrl { get; set; }
        #endregion
        
        #region Parameter IdpRelayStateParameterName
        /// <summary>
        /// <para>
        /// <para>The name that your identity provider (IdP) uses for its <code>RelayState</code> parameter.
        /// For example, <code>RelayState</code> or <code>TargetSource</code>. Specify this value
        /// when you use IAM authentication and want to let federated users log in to a Studio
        /// using the Studio URL. The <code>RelayState</code> parameter differs by IdP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdpRelayStateParameterName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A descriptive name for the Amazon EMR Studio.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ServiceRole
        /// <summary>
        /// <para>
        /// <para>The IAM role that the Amazon EMR Studio assumes. The service role provides a way for
        /// Amazon EMR Studio to interoperate with other Amazon Web Services services.</para>
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
        public System.String ServiceRole { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of subnet IDs to associate with the Amazon EMR Studio. A Studio can have a
        /// maximum of 5 subnets. The subnets must belong to the VPC specified by <code>VpcId</code>.
        /// Studio users can create a Workspace in any of the specified subnets.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to associate with the Amazon EMR Studio. Tags are user-defined key-value
        /// pairs that consist of a required key string with a maximum of 128 characters, and
        /// an optional value string with a maximum of 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElasticMapReduce.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter UserRole
        /// <summary>
        /// <para>
        /// <para>The IAM user role that users and groups assume when logged in to an Amazon EMR Studio.
        /// Only specify a <code>UserRole</code> when you use IAM Identity Center authentication.
        /// The permissions attached to the <code>UserRole</code> can be scoped down for each
        /// user or group using session policies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserRole { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Virtual Private Cloud (Amazon VPC) to associate with the Studio.</para>
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
        public System.String VpcId { get; set; }
        #endregion
        
        #region Parameter WorkspaceSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon EMR Studio Workspace security group. The Workspace security group
        /// allows outbound network traffic to resources in the Engine security group, and it
        /// must be in the same VPC specified by <code>VpcId</code>.</para>
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
        public System.String WorkspaceSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.CreateStudioResponse).
        /// Specifying the name of a property of type Amazon.ElasticMapReduce.Model.CreateStudioResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMRStudio (CreateStudio)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.CreateStudioResponse, NewEMRStudioCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthMode = this.AuthMode;
            #if MODULAR
            if (this.AuthMode == null && ParameterWasBound(nameof(this.AuthMode)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefaultS3Location = this.DefaultS3Location;
            #if MODULAR
            if (this.DefaultS3Location == null && ParameterWasBound(nameof(this.DefaultS3Location)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultS3Location which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.EngineSecurityGroupId = this.EngineSecurityGroupId;
            #if MODULAR
            if (this.EngineSecurityGroupId == null && ParameterWasBound(nameof(this.EngineSecurityGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter EngineSecurityGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdpAuthUrl = this.IdpAuthUrl;
            context.IdpRelayStateParameterName = this.IdpRelayStateParameterName;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceRole = this.ServiceRole;
            #if MODULAR
            if (this.ServiceRole == null && ParameterWasBound(nameof(this.ServiceRole)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            #if MODULAR
            if (this.SubnetId == null && ParameterWasBound(nameof(this.SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElasticMapReduce.Model.Tag>(this.Tag);
            }
            context.UserRole = this.UserRole;
            context.VpcId = this.VpcId;
            #if MODULAR
            if (this.VpcId == null && ParameterWasBound(nameof(this.VpcId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkspaceSecurityGroupId = this.WorkspaceSecurityGroupId;
            #if MODULAR
            if (this.WorkspaceSecurityGroupId == null && ParameterWasBound(nameof(this.WorkspaceSecurityGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkspaceSecurityGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticMapReduce.Model.CreateStudioRequest();
            
            if (cmdletContext.AuthMode != null)
            {
                request.AuthMode = cmdletContext.AuthMode;
            }
            if (cmdletContext.DefaultS3Location != null)
            {
                request.DefaultS3Location = cmdletContext.DefaultS3Location;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EngineSecurityGroupId != null)
            {
                request.EngineSecurityGroupId = cmdletContext.EngineSecurityGroupId;
            }
            if (cmdletContext.IdpAuthUrl != null)
            {
                request.IdpAuthUrl = cmdletContext.IdpAuthUrl;
            }
            if (cmdletContext.IdpRelayStateParameterName != null)
            {
                request.IdpRelayStateParameterName = cmdletContext.IdpRelayStateParameterName;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ServiceRole != null)
            {
                request.ServiceRole = cmdletContext.ServiceRole;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UserRole != null)
            {
                request.UserRole = cmdletContext.UserRole;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
            }
            if (cmdletContext.WorkspaceSecurityGroupId != null)
            {
                request.WorkspaceSecurityGroupId = cmdletContext.WorkspaceSecurityGroupId;
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
        
        private Amazon.ElasticMapReduce.Model.CreateStudioResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.CreateStudioRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "CreateStudio");
            try
            {
                #if DESKTOP
                return client.CreateStudio(request);
                #elif CORECLR
                return client.CreateStudioAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ElasticMapReduce.AuthMode AuthMode { get; set; }
            public System.String DefaultS3Location { get; set; }
            public System.String Description { get; set; }
            public System.String EngineSecurityGroupId { get; set; }
            public System.String IdpAuthUrl { get; set; }
            public System.String IdpRelayStateParameterName { get; set; }
            public System.String Name { get; set; }
            public System.String ServiceRole { get; set; }
            public List<System.String> SubnetId { get; set; }
            public List<Amazon.ElasticMapReduce.Model.Tag> Tag { get; set; }
            public System.String UserRole { get; set; }
            public System.String VpcId { get; set; }
            public System.String WorkspaceSecurityGroupId { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.CreateStudioResponse, NewEMRStudioCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
