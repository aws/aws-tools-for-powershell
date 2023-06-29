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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Creates an app block builder.
    /// </summary>
    [Cmdlet("New", "APSAppBlockBuilder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.AppBlockBuilder")]
    [AWSCmdlet("Calls the Amazon AppStream CreateAppBlockBuilder API operation.", Operation = new[] {"CreateAppBlockBuilder"}, SelectReturnType = typeof(Amazon.AppStream.Model.CreateAppBlockBuilderResponse))]
    [AWSCmdletOutput("Amazon.AppStream.Model.AppBlockBuilder or Amazon.AppStream.Model.CreateAppBlockBuilderResponse",
        "This cmdlet returns an Amazon.AppStream.Model.AppBlockBuilder object.",
        "The service call response (type Amazon.AppStream.Model.CreateAppBlockBuilderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAPSAppBlockBuilderCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        #region Parameter AccessEndpoint
        /// <summary>
        /// <para>
        /// <para>The list of interface VPC endpoint (interface endpoint) objects. Administrators can
        /// connect to the app block builder only through the specified endpoints.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessEndpoints")]
        public Amazon.AppStream.Model.AccessEndpoint[] AccessEndpoint { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the app block builder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the app block builder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter EnableDefaultInternetAccess
        /// <summary>
        /// <para>
        /// <para>Enables or disables default internet access for the app block builder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableDefaultInternetAccess { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to apply to the app block builder.
        /// To assume a role, the app block builder calls the AWS Security Token Service (STS)
        /// <code>AssumeRole</code> API operation and passes the ARN of the role to use. The operation
        /// creates a new session with temporary credentials. AppStream 2.0 retrieves the temporary
        /// credentials and creates the <b>appstream_machine_role</b> credential profile on the
        /// instance.</para><para>For more information, see <a href="https://docs.aws.amazon.com/appstream2/latest/developerguide/using-iam-roles-to-grant-permissions-to-applications-scripts-streaming-instances.html">Using
        /// an IAM Role to Grant Permissions to Applications and Scripts Running on AppStream
        /// 2.0 Streaming Instances</a> in the <i>Amazon AppStream 2.0 Administration Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type to use when launching the app block builder. The following instance
        /// types are available:</para><ul><li><para>stream.standard.small</para></li><li><para>stream.standard.medium</para></li><li><para>stream.standard.large</para></li><li><para>stream.standard.xlarge</para></li><li><para>stream.standard.2xlarge</para></li></ul>
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
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The unique name for the app block builder.</para>
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
        
        #region Parameter Platform
        /// <summary>
        /// <para>
        /// <para>The platform of the app block builder.</para><para><code>WINDOWS_SERVER_2019</code> is the only valid value.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AppStream.AppBlockBuilderPlatformType")]
        public Amazon.AppStream.AppBlockBuilderPlatformType Platform { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the security groups for the fleet or image builder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SubnetId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the subnets to which a network interface is attached from the fleet
        /// instance or image builder instance. Fleet instances use one or more subnets. Image
        /// builder instances use one subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SubnetIds")]
        public System.String[] VpcConfig_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the app block builder. A tag is a key-value pair, and the
        /// value is optional. For example, Environment=Test. If you do not specify a value, Environment=.
        /// </para><para>If you do not specify a value, the value is set to an empty string.</para><para>Generally allowed characters are: letters, numbers, and spaces representable in UTF-8,
        /// and the following special characters: </para><para>_ . : / = + \ - @</para><para>For more information, see <a href="https://docs.aws.amazon.com/appstream2/latest/developerguide/tagging-basic.html">Tagging
        /// Your Resources</a> in the <i>Amazon AppStream 2.0 Administration Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AppBlockBuilder'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.CreateAppBlockBuilderResponse).
        /// Specifying the name of a property of type Amazon.AppStream.Model.CreateAppBlockBuilderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AppBlockBuilder";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APSAppBlockBuilder (CreateAppBlockBuilder)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.CreateAppBlockBuilderResponse, NewAPSAppBlockBuilderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccessEndpoint != null)
            {
                context.AccessEndpoint = new List<Amazon.AppStream.Model.AccessEndpoint>(this.AccessEndpoint);
            }
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.EnableDefaultInternetAccess = this.EnableDefaultInternetAccess;
            context.IamRoleArn = this.IamRoleArn;
            context.InstanceType = this.InstanceType;
            #if MODULAR
            if (this.InstanceType == null && ParameterWasBound(nameof(this.InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Platform = this.Platform;
            #if MODULAR
            if (this.Platform == null && ParameterWasBound(nameof(this.Platform)))
            {
                WriteWarning("You are passing $null as a value for parameter Platform which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_SubnetId != null)
            {
                context.VpcConfig_SubnetId = new List<System.String>(this.VpcConfig_SubnetId);
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
            var request = new Amazon.AppStream.Model.CreateAppBlockBuilderRequest();
            
            if (cmdletContext.AccessEndpoint != null)
            {
                request.AccessEndpoints = cmdletContext.AccessEndpoint;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.EnableDefaultInternetAccess != null)
            {
                request.EnableDefaultInternetAccess = cmdletContext.EnableDefaultInternetAccess.Value;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Platform != null)
            {
                request.Platform = cmdletContext.Platform;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate VpcConfig
            var requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.AppStream.Model.VpcConfig();
            List<System.String> requestVpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestVpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestVpcConfig_vpcConfig_SecurityGroupId != null)
            {
                request.VpcConfig.SecurityGroupIds = requestVpcConfig_vpcConfig_SecurityGroupId;
                requestVpcConfigIsNull = false;
            }
            List<System.String> requestVpcConfig_vpcConfig_SubnetId = null;
            if (cmdletContext.VpcConfig_SubnetId != null)
            {
                requestVpcConfig_vpcConfig_SubnetId = cmdletContext.VpcConfig_SubnetId;
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
        
        private Amazon.AppStream.Model.CreateAppBlockBuilderResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.CreateAppBlockBuilderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "CreateAppBlockBuilder");
            try
            {
                #if DESKTOP
                return client.CreateAppBlockBuilder(request);
                #elif CORECLR
                return client.CreateAppBlockBuilderAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.AppStream.Model.AccessEndpoint> AccessEndpoint { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.Boolean? EnableDefaultInternetAccess { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String InstanceType { get; set; }
            public System.String Name { get; set; }
            public Amazon.AppStream.AppBlockBuilderPlatformType Platform { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_SubnetId { get; set; }
            public System.Func<Amazon.AppStream.Model.CreateAppBlockBuilderResponse, NewAPSAppBlockBuilderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AppBlockBuilder;
        }
        
    }
}
