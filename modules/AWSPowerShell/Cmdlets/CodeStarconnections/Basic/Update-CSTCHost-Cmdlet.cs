/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Updates a specified host with the provided configurations.
    /// </summary>
    [Cmdlet("Update", "CSTCHost", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS CodeStar Connections UpdateHost API operation.", Operation = new[] {"UpdateHost"}, SelectReturnType = typeof(Amazon.CodeStarconnections.Model.UpdateHostResponse))]
    [AWSCmdletOutput("None or Amazon.CodeStarconnections.Model.UpdateHostResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CodeStarconnections.Model.UpdateHostResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCSTCHostCmdlet : AmazonCodeStarconnectionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HostArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the host to be updated.</para>
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
        public System.String HostArn { get; set; }
        #endregion
        
        #region Parameter ProviderEndpoint
        /// <summary>
        /// <para>
        /// <para>The URL or endpoint of the host to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderEndpoint { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeStarconnections.Model.UpdateHostResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the HostArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^HostArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^HostArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HostArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CSTCHost (UpdateHost)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeStarconnections.Model.UpdateHostResponse, UpdateCSTCHostCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.HostArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HostArn = this.HostArn;
            #if MODULAR
            if (this.HostArn == null && ParameterWasBound(nameof(this.HostArn)))
            {
                WriteWarning("You are passing $null as a value for parameter HostArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProviderEndpoint = this.ProviderEndpoint;
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
            var request = new Amazon.CodeStarconnections.Model.UpdateHostRequest();
            
            if (cmdletContext.HostArn != null)
            {
                request.HostArn = cmdletContext.HostArn;
            }
            if (cmdletContext.ProviderEndpoint != null)
            {
                request.ProviderEndpoint = cmdletContext.ProviderEndpoint;
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
        
        private Amazon.CodeStarconnections.Model.UpdateHostResponse CallAWSServiceOperation(IAmazonCodeStarconnections client, Amazon.CodeStarconnections.Model.UpdateHostRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeStar Connections", "UpdateHost");
            try
            {
                #if DESKTOP
                return client.UpdateHost(request);
                #elif CORECLR
                return client.UpdateHostAsync(request).GetAwaiter().GetResult();
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
            public System.String HostArn { get; set; }
            public System.String ProviderEndpoint { get; set; }
            public List<System.String> VpcConfiguration_SecurityGroupId { get; set; }
            public List<System.String> VpcConfiguration_SubnetId { get; set; }
            public System.String VpcConfiguration_TlsCertificate { get; set; }
            public System.String VpcConfiguration_VpcId { get; set; }
            public System.Func<Amazon.CodeStarconnections.Model.UpdateHostResponse, UpdateCSTCHostCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
