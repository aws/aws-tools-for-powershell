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
using Amazon.DataSync;
using Amazon.DataSync.Model;

namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Activates an AWS DataSync agent that you have deployed on your host. The activation
    /// process associates your agent with your account. In the activation process, you specify
    /// information such as the AWS Region that you want to activate the agent in. You activate
    /// the agent in the AWS Region where your target locations (in Amazon S3 or Amazon EFS)
    /// reside. Your tasks are created in this AWS Region.
    /// 
    ///  
    /// <para>
    /// You can activate the agent in a VPC (virtual private cloud) or provide the agent access
    /// to a VPC endpoint so you can run tasks without going over the public Internet.
    /// </para><para>
    /// You can use an agent for more than one location. If a task uses multiple agents, all
    /// of them need to have status AVAILABLE for the task to run. If you use multiple agents
    /// for a source location, the status of all the agents must be AVAILABLE for the task
    /// to run. 
    /// </para><para>
    /// Agents are automatically updated by AWS on a regular basis, using a mechanism that
    /// ensures minimal interruption to your tasks.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DSYNAgent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync CreateAgent API operation.", Operation = new[] {"CreateAgent"}, SelectReturnType = typeof(Amazon.DataSync.Model.CreateAgentResponse))]
    [AWSCmdletOutput("System.String or Amazon.DataSync.Model.CreateAgentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DataSync.Model.CreateAgentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDSYNAgentCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        #region Parameter ActivationKey
        /// <summary>
        /// <para>
        /// <para>Your agent activation key. You can get the activation key either by sending an HTTP
        /// GET request with redirects that enable you to get the agent IP address (port 80).
        /// Alternatively, you can get it from the AWS DataSync console.</para><para>The redirect URL returned in the response provides you the activation key for your
        /// agent in the query string parameter <code>activationKey</code>. It might also include
        /// other activation-related parameters; however, these are merely defaults. The arguments
        /// you pass to this API call determine the actual configuration of your agent.</para><para>For more information, see Activating an Agent in the <i>AWS DataSync User Guide.</i></para>
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
        public System.String ActivationKey { get; set; }
        #endregion
        
        #region Parameter AgentName
        /// <summary>
        /// <para>
        /// <para>The name you configured for your agent. This value is a text reference that is used
        /// to identify the agent in the console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AgentName { get; set; }
        #endregion
        
        #region Parameter SecurityGroupArn
        /// <summary>
        /// <para>
        /// <para>The ARNs of the security groups used to protect your data transfer task subnets. See
        /// <a>CreateAgentRequest$SubnetArns</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupArns")]
        public System.String[] SecurityGroupArn { get; set; }
        #endregion
        
        #region Parameter SubnetArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the subnets in which DataSync will create elastic
        /// network interfaces for each data transfer task. The agent that runs a task must be
        /// private. When you start a task that is associated with an agent created in a VPC,
        /// or one that has access to an IP address in a VPC, then the task is also private. In
        /// this case, DataSync creates four network interfaces for each task in your subnet.
        /// For a data transfer to work, the agent must be able to route to all these four network
        /// interfaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetArns")]
        public System.String[] SubnetArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pair that represents the tag that you want to associate with the agent.
        /// The value can be an empty string. This value helps you manage, filter, and search
        /// for your agents.</para><note><para>Valid characters for key and value are letters, spaces, and numbers representable
        /// in UTF-8 format, and the following special characters: + - = . _ : / @. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
        #endregion
        
        #region Parameter VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC (virtual private cloud) endpoint that the agent has access to. This
        /// is the client-side VPC endpoint, also called a PrivateLink. If you don't have a PrivateLink
        /// VPC endpoint, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/endpoint-service.html#create-endpoint-service">Creating
        /// a VPC Endpoint Service Configuration</a> in the Amazon VPC User Guide.</para><para>VPC endpoint ID looks like this: <code>vpce-01234d5aff67890e1</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AgentArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.CreateAgentResponse).
        /// Specifying the name of a property of type Amazon.DataSync.Model.CreateAgentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AgentArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ActivationKey parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ActivationKey' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ActivationKey' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSYNAgent (CreateAgent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.CreateAgentResponse, NewDSYNAgentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ActivationKey;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ActivationKey = this.ActivationKey;
            #if MODULAR
            if (this.ActivationKey == null && ParameterWasBound(nameof(this.ActivationKey)))
            {
                WriteWarning("You are passing $null as a value for parameter ActivationKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AgentName = this.AgentName;
            if (this.SecurityGroupArn != null)
            {
                context.SecurityGroupArn = new List<System.String>(this.SecurityGroupArn);
            }
            if (this.SubnetArn != null)
            {
                context.SubnetArn = new List<System.String>(this.SubnetArn);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DataSync.Model.TagListEntry>(this.Tag);
            }
            context.VpcEndpointId = this.VpcEndpointId;
            
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
            var request = new Amazon.DataSync.Model.CreateAgentRequest();
            
            if (cmdletContext.ActivationKey != null)
            {
                request.ActivationKey = cmdletContext.ActivationKey;
            }
            if (cmdletContext.AgentName != null)
            {
                request.AgentName = cmdletContext.AgentName;
            }
            if (cmdletContext.SecurityGroupArn != null)
            {
                request.SecurityGroupArns = cmdletContext.SecurityGroupArn;
            }
            if (cmdletContext.SubnetArn != null)
            {
                request.SubnetArns = cmdletContext.SubnetArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VpcEndpointId != null)
            {
                request.VpcEndpointId = cmdletContext.VpcEndpointId;
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
        
        private Amazon.DataSync.Model.CreateAgentResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.CreateAgentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "CreateAgent");
            try
            {
                #if DESKTOP
                return client.CreateAgent(request);
                #elif CORECLR
                return client.CreateAgentAsync(request).GetAwaiter().GetResult();
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
            public System.String ActivationKey { get; set; }
            public System.String AgentName { get; set; }
            public List<System.String> SecurityGroupArn { get; set; }
            public List<System.String> SubnetArn { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tag { get; set; }
            public System.String VpcEndpointId { get; set; }
            public System.Func<Amazon.DataSync.Model.CreateAgentResponse, NewDSYNAgentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AgentArn;
        }
        
    }
}
