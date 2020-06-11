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
using Amazon.CodeStarconnections;
using Amazon.CodeStarconnections.Model;

namespace Amazon.PowerShell.Cmdlets.CSTC
{
    /// <summary>
    /// Creates a resource that represents the infrastructure where a third-party provider
    /// is installed. The host is used when you create connections to an installed third-party
    /// provider type, such as GitHub Enterprise Server. You create one host for all connections
    /// to that provider.
    /// 
    ///  <note><para>
    /// A host created through the CLI or the SDK is in `PENDING` status by default. You can
    /// make its status `AVAILABLE` by setting up the host in the console.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "CSTCHost", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CodeStar Connections CreateHost API operation.", Operation = new[] {"CreateHost"}, SelectReturnType = typeof(Amazon.CodeStarconnections.Model.CreateHostResponse))]
    [AWSCmdletOutput("System.String or Amazon.CodeStarconnections.Model.CreateHostResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CodeStarconnections.Model.CreateHostResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCSTCHostCmdlet : AmazonCodeStarconnectionsClientCmdlet, IExecutor
    {
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the host to be created. The name must be unique in the calling AWS account.</para>
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
        
        #region Parameter ProviderEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint of the infrastructure to be represented by the host after it is created.</para>
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
        public System.String ProviderEndpoint { get; set; }
        #endregion
        
        #region Parameter ProviderType
        /// <summary>
        /// <para>
        /// <para>The name of the installed provider to be associated with your connection. The host
        /// resource represents the infrastructure where your provider type is installed. The
        /// valid provider type is GitHub Enterprise Server.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeStarconnections.ProviderType")]
        public Amazon.CodeStarconnections.ProviderType ProviderType { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the security group or security groups associated with the Amazon VPC connected
        /// to the infrastructure where your provider type is installed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfiguration_SecurityGroupIds")]
        public System.String[] VpcConfiguration_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet or subnets associated with the Amazon VPC connected to the infrastructure
        /// where your provider type is installed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfiguration_SubnetIds")]
        public System.String[] VpcConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_TlsCertificate
        /// <summary>
        /// <para>
        /// <para>The value of the Transport Layer Security (TLS) certificate associated with the infrastructure
        /// where your provider type is installed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcConfiguration_TlsCertificate { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon VPC connected to the infrastructure where your provider type
        /// is installed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcConfiguration_VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HostArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeStarconnections.Model.CreateHostResponse).
        /// Specifying the name of a property of type Amazon.CodeStarconnections.Model.CreateHostResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HostArn";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CSTCHost (CreateHost)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeStarconnections.Model.CreateHostResponse, NewCSTCHostCmdlet>(Select) ??
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
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProviderEndpoint = this.ProviderEndpoint;
            #if MODULAR
            if (this.ProviderEndpoint == null && ParameterWasBound(nameof(this.ProviderEndpoint)))
            {
                WriteWarning("You are passing $null as a value for parameter ProviderEndpoint which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProviderType = this.ProviderType;
            #if MODULAR
            if (this.ProviderType == null && ParameterWasBound(nameof(this.ProviderType)))
            {
                WriteWarning("You are passing $null as a value for parameter ProviderType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VpcConfiguration_SecurityGroupId != null)
            {
                context.VpcConfiguration_SecurityGroupId = new List<System.String>(this.VpcConfiguration_SecurityGroupId);
            }
            if (this.VpcConfiguration_SubnetId != null)
            {
                context.VpcConfiguration_SubnetId = new List<System.String>(this.VpcConfiguration_SubnetId);
            }
            context.VpcConfiguration_TlsCertificate = this.VpcConfiguration_TlsCertificate;
            context.VpcConfiguration_VpcId = this.VpcConfiguration_VpcId;
            
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
            var request = new Amazon.CodeStarconnections.Model.CreateHostRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProviderEndpoint != null)
            {
                request.ProviderEndpoint = cmdletContext.ProviderEndpoint;
            }
            if (cmdletContext.ProviderType != null)
            {
                request.ProviderType = cmdletContext.ProviderType;
            }
            
             // populate VpcConfiguration
            var requestVpcConfigurationIsNull = true;
            request.VpcConfiguration = new Amazon.CodeStarconnections.Model.VpcConfiguration();
            List<System.String> requestVpcConfiguration_vpcConfiguration_SecurityGroupId = null;
            if (cmdletContext.VpcConfiguration_SecurityGroupId != null)
            {
                requestVpcConfiguration_vpcConfiguration_SecurityGroupId = cmdletContext.VpcConfiguration_SecurityGroupId;
            }
            if (requestVpcConfiguration_vpcConfiguration_SecurityGroupId != null)
            {
                request.VpcConfiguration.SecurityGroupIds = requestVpcConfiguration_vpcConfiguration_SecurityGroupId;
                requestVpcConfigurationIsNull = false;
            }
            List<System.String> requestVpcConfiguration_vpcConfiguration_SubnetId = null;
            if (cmdletContext.VpcConfiguration_SubnetId != null)
            {
                requestVpcConfiguration_vpcConfiguration_SubnetId = cmdletContext.VpcConfiguration_SubnetId;
            }
            if (requestVpcConfiguration_vpcConfiguration_SubnetId != null)
            {
                request.VpcConfiguration.SubnetIds = requestVpcConfiguration_vpcConfiguration_SubnetId;
                requestVpcConfigurationIsNull = false;
            }
            System.String requestVpcConfiguration_vpcConfiguration_TlsCertificate = null;
            if (cmdletContext.VpcConfiguration_TlsCertificate != null)
            {
                requestVpcConfiguration_vpcConfiguration_TlsCertificate = cmdletContext.VpcConfiguration_TlsCertificate;
            }
            if (requestVpcConfiguration_vpcConfiguration_TlsCertificate != null)
            {
                request.VpcConfiguration.TlsCertificate = requestVpcConfiguration_vpcConfiguration_TlsCertificate;
                requestVpcConfigurationIsNull = false;
            }
            System.String requestVpcConfiguration_vpcConfiguration_VpcId = null;
            if (cmdletContext.VpcConfiguration_VpcId != null)
            {
                requestVpcConfiguration_vpcConfiguration_VpcId = cmdletContext.VpcConfiguration_VpcId;
            }
            if (requestVpcConfiguration_vpcConfiguration_VpcId != null)
            {
                request.VpcConfiguration.VpcId = requestVpcConfiguration_vpcConfiguration_VpcId;
                requestVpcConfigurationIsNull = false;
            }
             // determine if request.VpcConfiguration should be set to null
            if (requestVpcConfigurationIsNull)
            {
                request.VpcConfiguration = null;
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
        
        private Amazon.CodeStarconnections.Model.CreateHostResponse CallAWSServiceOperation(IAmazonCodeStarconnections client, Amazon.CodeStarconnections.Model.CreateHostRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeStar Connections", "CreateHost");
            try
            {
                #if DESKTOP
                return client.CreateHost(request);
                #elif CORECLR
                return client.CreateHostAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String ProviderEndpoint { get; set; }
            public Amazon.CodeStarconnections.ProviderType ProviderType { get; set; }
            public List<System.String> VpcConfiguration_SecurityGroupId { get; set; }
            public List<System.String> VpcConfiguration_SubnetId { get; set; }
            public System.String VpcConfiguration_TlsCertificate { get; set; }
            public System.String VpcConfiguration_VpcId { get; set; }
            public System.Func<Amazon.CodeStarconnections.Model.CreateHostResponse, NewCSTCHostCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HostArn;
        }
        
    }
}
