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
    /// Updates an app block builder.
    /// 
    ///  
    /// <para>
    /// If the app block builder is in the <c>STARTING</c> or <c>STOPPING</c> state, you can't
    /// update it. If the app block builder is in the <c>RUNNING</c> state, you can only update
    /// the DisplayName and Description. If the app block builder is in the <c>STOPPED</c>
    /// state, you can update any attribute except the Name.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "APSAppBlockBuilder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.AppBlockBuilder")]
    [AWSCmdlet("Calls the Amazon AppStream UpdateAppBlockBuilder API operation.", Operation = new[] {"UpdateAppBlockBuilder"}, SelectReturnType = typeof(Amazon.AppStream.Model.UpdateAppBlockBuilderResponse))]
    [AWSCmdletOutput("Amazon.AppStream.Model.AppBlockBuilder or Amazon.AppStream.Model.UpdateAppBlockBuilderResponse",
        "This cmdlet returns an Amazon.AppStream.Model.AppBlockBuilder object.",
        "The service call response (type Amazon.AppStream.Model.UpdateAppBlockBuilderResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateAPSAppBlockBuilderCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter AttributesToDelete
        /// <summary>
        /// <para>
        /// <para>The attributes to delete from the app block builder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AttributesToDelete { get; set; }
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
        /// <c>AssumeRole</c> API operation and passes the ARN of the role to use. The operation
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The unique name for the app block builder.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Platform
        /// <summary>
        /// <para>
        /// <para>The platform of the app block builder.</para><para><c>WINDOWS_SERVER_2019</c> is the only valid value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppStream.PlatformType")]
        public Amazon.AppStream.PlatformType Platform { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AppBlockBuilder'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.UpdateAppBlockBuilderResponse).
        /// Specifying the name of a property of type Amazon.AppStream.Model.UpdateAppBlockBuilderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AppBlockBuilder";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-APSAppBlockBuilder (UpdateAppBlockBuilder)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.UpdateAppBlockBuilderResponse, UpdateAPSAppBlockBuilderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AccessEndpoint != null)
            {
                context.AccessEndpoint = new List<Amazon.AppStream.Model.AccessEndpoint>(this.AccessEndpoint);
            }
            if (this.AttributesToDelete != null)
            {
                context.AttributesToDelete = new List<System.String>(this.AttributesToDelete);
            }
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.EnableDefaultInternetAccess = this.EnableDefaultInternetAccess;
            context.IamRoleArn = this.IamRoleArn;
            context.InstanceType = this.InstanceType;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Platform = this.Platform;
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
            var request = new Amazon.AppStream.Model.UpdateAppBlockBuilderRequest();
            
            if (cmdletContext.AccessEndpoint != null)
            {
                request.AccessEndpoints = cmdletContext.AccessEndpoint;
            }
            if (cmdletContext.AttributesToDelete != null)
            {
                request.AttributesToDelete = cmdletContext.AttributesToDelete;
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
        
        private Amazon.AppStream.Model.UpdateAppBlockBuilderResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.UpdateAppBlockBuilderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "UpdateAppBlockBuilder");
            try
            {
                #if DESKTOP
                return client.UpdateAppBlockBuilder(request);
                #elif CORECLR
                return client.UpdateAppBlockBuilderAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AttributesToDelete { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.Boolean? EnableDefaultInternetAccess { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String InstanceType { get; set; }
            public System.String Name { get; set; }
            public Amazon.AppStream.PlatformType Platform { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_SubnetId { get; set; }
            public System.Func<Amazon.AppStream.Model.UpdateAppBlockBuilderResponse, UpdateAPSAppBlockBuilderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AppBlockBuilder;
        }
        
    }
}
