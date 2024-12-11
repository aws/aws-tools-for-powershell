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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Creates a topic rule destination. The destination must be confirmed prior to use.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">CreateTopicRuleDestination</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IOTTopicRuleDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.TopicRuleDestination")]
    [AWSCmdlet("Calls the AWS IoT CreateTopicRuleDestination API operation.", Operation = new[] {"CreateTopicRuleDestination"}, SelectReturnType = typeof(Amazon.IoT.Model.CreateTopicRuleDestinationResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.TopicRuleDestination or Amazon.IoT.Model.CreateTopicRuleDestinationResponse",
        "This cmdlet returns an Amazon.IoT.Model.TopicRuleDestination object.",
        "The service call response (type Amazon.IoT.Model.CreateTopicRuleDestinationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewIOTTopicRuleDestinationCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HttpUrlConfiguration_ConfirmationUrl
        /// <summary>
        /// <para>
        /// <para>The URL IoT uses to confirm ownership of or access to the topic rule destination URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("DestinationConfiguration_HttpUrlConfiguration_ConfirmationUrl")]
        public System.String HttpUrlConfiguration_ConfirmationUrl { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of a role that has permission to create and attach to elastic network interfaces
        /// (ENIs).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_VpcConfiguration_RoleArn")]
        public System.String VpcConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The security groups of the VPC destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_VpcConfiguration_SecurityGroups")]
        public System.String[] VpcConfiguration_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>The subnet IDs of the VPC destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_VpcConfiguration_SubnetIds")]
        public System.String[] VpcConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_VpcConfiguration_VpcId")]
        public System.String VpcConfiguration_VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TopicRuleDestination'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreateTopicRuleDestinationResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreateTopicRuleDestinationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TopicRuleDestination";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HttpUrlConfiguration_ConfirmationUrl), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTTopicRuleDestination (CreateTopicRuleDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreateTopicRuleDestinationResponse, NewIOTTopicRuleDestinationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HttpUrlConfiguration_ConfirmationUrl = this.HttpUrlConfiguration_ConfirmationUrl;
            context.VpcConfiguration_RoleArn = this.VpcConfiguration_RoleArn;
            if (this.VpcConfiguration_SecurityGroup != null)
            {
                context.VpcConfiguration_SecurityGroup = new List<System.String>(this.VpcConfiguration_SecurityGroup);
            }
            if (this.VpcConfiguration_SubnetId != null)
            {
                context.VpcConfiguration_SubnetId = new List<System.String>(this.VpcConfiguration_SubnetId);
            }
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
            var request = new Amazon.IoT.Model.CreateTopicRuleDestinationRequest();
            
            
             // populate DestinationConfiguration
            var requestDestinationConfigurationIsNull = true;
            request.DestinationConfiguration = new Amazon.IoT.Model.TopicRuleDestinationConfiguration();
            Amazon.IoT.Model.HttpUrlDestinationConfiguration requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration = null;
            
             // populate HttpUrlConfiguration
            var requestDestinationConfiguration_destinationConfiguration_HttpUrlConfigurationIsNull = true;
            requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration = new Amazon.IoT.Model.HttpUrlDestinationConfiguration();
            System.String requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration_httpUrlConfiguration_ConfirmationUrl = null;
            if (cmdletContext.HttpUrlConfiguration_ConfirmationUrl != null)
            {
                requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration_httpUrlConfiguration_ConfirmationUrl = cmdletContext.HttpUrlConfiguration_ConfirmationUrl;
            }
            if (requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration_httpUrlConfiguration_ConfirmationUrl != null)
            {
                requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration.ConfirmationUrl = requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration_httpUrlConfiguration_ConfirmationUrl;
                requestDestinationConfiguration_destinationConfiguration_HttpUrlConfigurationIsNull = false;
            }
             // determine if requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration should be set to null
            if (requestDestinationConfiguration_destinationConfiguration_HttpUrlConfigurationIsNull)
            {
                requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration = null;
            }
            if (requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration != null)
            {
                request.DestinationConfiguration.HttpUrlConfiguration = requestDestinationConfiguration_destinationConfiguration_HttpUrlConfiguration;
                requestDestinationConfigurationIsNull = false;
            }
            Amazon.IoT.Model.VpcDestinationConfiguration requestDestinationConfiguration_destinationConfiguration_VpcConfiguration = null;
            
             // populate VpcConfiguration
            var requestDestinationConfiguration_destinationConfiguration_VpcConfigurationIsNull = true;
            requestDestinationConfiguration_destinationConfiguration_VpcConfiguration = new Amazon.IoT.Model.VpcDestinationConfiguration();
            System.String requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_RoleArn = null;
            if (cmdletContext.VpcConfiguration_RoleArn != null)
            {
                requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_RoleArn = cmdletContext.VpcConfiguration_RoleArn;
            }
            if (requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_RoleArn != null)
            {
                requestDestinationConfiguration_destinationConfiguration_VpcConfiguration.RoleArn = requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_RoleArn;
                requestDestinationConfiguration_destinationConfiguration_VpcConfigurationIsNull = false;
            }
            List<System.String> requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_SecurityGroup = null;
            if (cmdletContext.VpcConfiguration_SecurityGroup != null)
            {
                requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_SecurityGroup = cmdletContext.VpcConfiguration_SecurityGroup;
            }
            if (requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_SecurityGroup != null)
            {
                requestDestinationConfiguration_destinationConfiguration_VpcConfiguration.SecurityGroups = requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_SecurityGroup;
                requestDestinationConfiguration_destinationConfiguration_VpcConfigurationIsNull = false;
            }
            List<System.String> requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_SubnetId = null;
            if (cmdletContext.VpcConfiguration_SubnetId != null)
            {
                requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_SubnetId = cmdletContext.VpcConfiguration_SubnetId;
            }
            if (requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_SubnetId != null)
            {
                requestDestinationConfiguration_destinationConfiguration_VpcConfiguration.SubnetIds = requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_SubnetId;
                requestDestinationConfiguration_destinationConfiguration_VpcConfigurationIsNull = false;
            }
            System.String requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_VpcId = null;
            if (cmdletContext.VpcConfiguration_VpcId != null)
            {
                requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_VpcId = cmdletContext.VpcConfiguration_VpcId;
            }
            if (requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_VpcId != null)
            {
                requestDestinationConfiguration_destinationConfiguration_VpcConfiguration.VpcId = requestDestinationConfiguration_destinationConfiguration_VpcConfiguration_vpcConfiguration_VpcId;
                requestDestinationConfiguration_destinationConfiguration_VpcConfigurationIsNull = false;
            }
             // determine if requestDestinationConfiguration_destinationConfiguration_VpcConfiguration should be set to null
            if (requestDestinationConfiguration_destinationConfiguration_VpcConfigurationIsNull)
            {
                requestDestinationConfiguration_destinationConfiguration_VpcConfiguration = null;
            }
            if (requestDestinationConfiguration_destinationConfiguration_VpcConfiguration != null)
            {
                request.DestinationConfiguration.VpcConfiguration = requestDestinationConfiguration_destinationConfiguration_VpcConfiguration;
                requestDestinationConfigurationIsNull = false;
            }
             // determine if request.DestinationConfiguration should be set to null
            if (requestDestinationConfigurationIsNull)
            {
                request.DestinationConfiguration = null;
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
        
        private Amazon.IoT.Model.CreateTopicRuleDestinationResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateTopicRuleDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateTopicRuleDestination");
            try
            {
                #if DESKTOP
                return client.CreateTopicRuleDestination(request);
                #elif CORECLR
                return client.CreateTopicRuleDestinationAsync(request).GetAwaiter().GetResult();
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
            public System.String HttpUrlConfiguration_ConfirmationUrl { get; set; }
            public System.String VpcConfiguration_RoleArn { get; set; }
            public List<System.String> VpcConfiguration_SecurityGroup { get; set; }
            public List<System.String> VpcConfiguration_SubnetId { get; set; }
            public System.String VpcConfiguration_VpcId { get; set; }
            public System.Func<Amazon.IoT.Model.CreateTopicRuleDestinationResponse, NewIOTTopicRuleDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TopicRuleDestination;
        }
        
    }
}
